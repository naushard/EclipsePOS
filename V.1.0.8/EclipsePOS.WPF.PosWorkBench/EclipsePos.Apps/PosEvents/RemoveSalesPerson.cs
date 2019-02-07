using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using System.Collections;

//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class RemoveSalesPerson : PosDialogEvent
    {

        /** Enter text */
        public const int ENTER_SALES_PERSON = 0;
        /** Get text */
        public const int GET_SALES_PERSON = 1;

        //Create/Update journal
        public const int DELETE_SALES_PERSON = 2;
        
        private EjSalesPerson ejSalesPerson;
        private string employee_no;
        


        public RemoveSalesPerson()
        {
            this.States().PushState(ENTER_SALES_PERSON);
        }

        public override void Engage(int keyValue)
        {

            if (PosContext.Instance.CurrentEj.SalesPerson.Count == 0)
            {
                this.States().Clear();
                PosContext.Instance.ClearInput();
                PosError posError = new PosError(PosErrorCode.INVALID_FUNCTION_KEY);
                posError.Engage(0);
                return;
          
            }


            switch (this.States().PeekState())
            {



                case ENTER_SALES_PERSON:

              

                    this.PromptText = PosContext.Instance.Parameters.getParam("EnterSalesPersonNo");
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.ClearInput();
                    this.States().PopState();

                    this.States().PushState(GET_SALES_PERSON);

                    break;



                case GET_SALES_PERSON:

                    this.PopState();

                    this.employee_no = PosContext.Instance.InputLine;

                    Employee emp = new Employee();
                    emp.Organization_no = PosSettings.Default.Organization;
                    emp.Employee_no = this.employee_no;
                    emp.LoadByEmployeeNo();

                    if (string.IsNullOrEmpty(emp.FName))
                    {
                        // get out of this transaction and prompt error.
                        PosContext.Instance.ClearInput();
                        PosEventStack.Instance.ClearPending();
                        PosError error = new PosError(PosErrorCode.INVALID_EMPLOYEE_NO);
                        this.PromptText = PosContext.Instance.Parameters.getParam("InvalidEmployeeNumber");
                        PosEventStack.Instance.PushEvent(error);
                        PosContext.Instance.Operprompt.Update(this);
                        PosContext.Instance.ClearInput();

                        this.States().PushState(GET_SALES_PERSON);
                        PosEventStack.Instance.NextEvent();
                        return;

                    }

                    PosContext.Instance.ClearInput();
                    this.States().PopState();

                    this.States().PushState(DELETE_SALES_PERSON);
                    PosEventStack.Instance.NextEvent();
                    break;



                case DELETE_SALES_PERSON:

                    this.PopState();

                    PosContext.Instance.CurrentEj.SalesPerson.ForEach(delegate(EjSalesPerson ejSalesP){
                        TransSalesPerson transSalesPerson = (TransSalesPerson)ejSalesP.DataRecord();
                        if (transSalesPerson.Employee_no == this.employee_no)
                        {
                            this.ejSalesPerson = ejSalesP;
                        }
                    
                    });

                //   foreach (EjSalesPerson ejPerson in PosContext.Instance.CurrentEj.SalesPerson)
                //   {
        //               MessageBox.Show(ejPerson.Employee.Employee_no);
             //          if (ejPerson.Employee.Employee_no == this.employee_no)
               //        {
                //          this.ejSalesPerson = ejPerson;
                 //      }
                 //  }


                    if (this.ejSalesPerson != null)
                    {
                        PosContext.Instance.CurrentEj.SalesPerson.Remove(this.ejSalesPerson);
                        this.ejSalesPerson.DeleteEj();
                        PosContext.Instance.Receipt.Update(this);
                    }



                    this.States().Clear();
                    PosEventStack.Instance.NextEvent();

                    break;

                default:
                    break;
            }
           

           


        }

        public string Employee_no
        {
            get
            {
                return employee_no;
            }
        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }
    }
}
