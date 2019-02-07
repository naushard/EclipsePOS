using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
    public class EjSalesPerson : EjLine
    {

        /** Enter text */
        public const int ENTER_SALES_PERSON = 0;
        /** Get text */
        public const int GET_SALES_PERSON = 1;

        //Create/Update journal
        public const int SET_SALES_PERSON_JOURNAL = 2;


        private TransSalesPerson transSalesPerson;
        private int transType;

        private string promptText;
        private Employee emp;
        private string desc = " ";
       


        public EjSalesPerson()
        {
            this.LineType = (int)EjLineType.SALES_PERSON;
            //this.States().PushState(ENTER_SALES_PERSON);
            this.emp = new Employee();
            this.emp.FName = "";

        }

        public EjSalesPerson(TransSalesPerson parm)
        {
           // this.transText = pTransText;
            this.LineType = (int)EjLineType.SALES_PERSON;
            this.transSalesPerson = parm;
            this.emp = new Employee();
            this.emp.Organization_no = parm.Organization_no;
            this.emp.Employee_no = parm.Employee_no;
            this.emp.LoadByEmployeeNo();
            this.desc = emp.FName;

            
        }


        #region Properties

        public override bool TenderComplete
        {
            get
            {
                return true;
            }

        }

        public override string Desc
        {
            get
            {
                return this.emp.FName;
            }
            set
            {
                //transSalesPerson.Employee_no = value;
            }
        }

        public override double Amount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double ExtAmount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override int LineNo
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }


        public override string PromptText
        {
            get
            {
                return promptText;
            }
            set
            {
                promptText = value;
            }
        }

        public override string SKU
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public override double Quantity
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double TaxAmount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }


        public override double Change
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override int State
        {
            set
            {

                
            }
            get
            {
                return 0;
            }
        }


        public override int SeqNo
        {
            set
            {
                  
            }
            get
            {
                return 0;
            }
        }

        public Employee Employee
        {
            get
            {
                return this.emp;
            }
        }

        #endregion


        public override void UpdateTotals()
        {
            
        }


        public override bool Save()
        {
            if (!PosContext.Instance.Training)
            {
                try
                {
                    transSalesPerson.Add();
                }
                catch (Exception e)
                {
                    
                }
            }
            return true;
        }


        public override void SaveState(EjLineStates state)
        {
            
        }




        public override void Engage(int keyValue)
        {

            if (PosContext.Instance.Parameters.getParam("PromptForEmployee") == "FALSE")
            {
                this.States().Clear();
                PosEventStack.Instance.NextEvent();
                return;
            }

            switch (this.States().PeekState())
            {

                case ENTER_SALES_PERSON:
                    
                    // If previously entered salesman exists
                  //  if (PosContext.Instance.CurrentEj.SalesPerson.Count > 0)
                  //  {
                  //      this.States().Clear();
                  //      PosEventStack.Instance.NextEvent();
                  //      return;
                  //  }
                    

                    this.PromptText = PosContext.Instance.Parameters.getParam("EnterSalesPersonNo");
                    
                    PosContext.Instance.Operprompt.Update(this);
                    
                    PosContext.Instance.ClearInput();
                    this.States().PopState();

                    this.States().PushState(GET_SALES_PERSON);


                    //Try to load employee details
                    try
                    {
                        PosContext.Instance.CurrentPosDisplay.LoadEmployeeView();
                    }
                    catch
                    {
                    }
                   
                    break;



                case GET_SALES_PERSON: 

                    this.PopState();

                    string salesPerson  = PosContext.Instance.InputLine;

                    if ((PosContext.Instance.CurrentEj.SalesPerson.Count > 0) &&
                        (string.IsNullOrEmpty(salesPerson.Trim())))
                    {
                        this.States().Clear();
                        PosContext.Instance.ClearInput();
                        PosEventStack.Instance.NextEvent();
                        return;

                    }

                    emp = new Employee();
                    emp.Organization_no = PosSettings.Default.Organization;
                    emp.Employee_no  = salesPerson;
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

                    this.States().PushState(SET_SALES_PERSON_JOURNAL);
                    PosEventStack.Instance.NextEvent();
                    break;
                   


                case SET_SALES_PERSON_JOURNAL:

                    this.PopState();

                    transSalesPerson = new TransSalesPerson();
                    transSalesPerson.Trans_no = PosContext.Instance.TrxNo;
                    transSalesPerson.Organization_no = PosSettings.Default.Organization;
                    transSalesPerson.Pos_no = PosSettings.Default.Station;
                    transSalesPerson.Store_no = PosSettings.Default.Store;
                    transSalesPerson.Employee_no = emp.Employee_no;
                  
                   
                    transSalesPerson.Add();

                    PosContext.Instance.CurrentEj.EjAdd(this);


                    this.States().Clear();
                    this.promptText = "";
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.Receipt.Update(this);
                   
                    PosContext.Instance.ClearInput();
                   // this.States().PushState(ENTER_SALES_PERSON);
                    this.States().Clear();
                    PosEventStack.Instance.NextEvent();

                    break;

                default:
                    break;
            }



        }

        public void DeleteEj()
        {

            this.transSalesPerson.Delete();
        }

      

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }

        public override IRelatable DataRecord()
        {
            return transSalesPerson;
        }

        public override void PrintEj()
        {
           // PosHardware.Instance.PosPrinter.Println(this.ToString());

            // Print sales person
            StringBuilder sbSalesPerson = new StringBuilder();
            sbSalesPerson.Append(PosContext.Instance.Parameters.getParam("SalesStaff"));
            sbSalesPerson.Append(" ");
            sbSalesPerson.Append(this.Desc);
            PosHardware.Instance.PosPrinter.Println(sbSalesPerson.ToString());
        }

    }
}
