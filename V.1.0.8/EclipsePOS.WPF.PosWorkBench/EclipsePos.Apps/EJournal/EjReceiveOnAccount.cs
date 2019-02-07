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
    public class EjReceiveOnAccount : EjLine
    {
        /** Prompt for Receipt amount */
        public const int PROMPT_AMOUNT = 1;
       /** Prompt for customer */
        public const int PROMPT_CUSTOMER = 2;
        /** Get amount */
        public const int GET_AMOUNT = 3;
        /** Get customer */
        public const int GET_CUSTOMER = 4;


        private string promptText;
        private string customer_tax_id;
        private EclipsePos.Data.Customer customerDataRec = null;
        private double tenderAmount = 0;

        

        public EjReceiveOnAccount()
        {
            this.LineType = (int) EjLineType.ACCOUNT;
        }

        public EjReceiveOnAccount(EclipsePos.Data.Customer cusData)
            : this()
        {
            this.customerDataRec = cusData;
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
                return null;
            }
            set
            {
                
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
                return customerDataRec.Current_debt;
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


        public string PromptText
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

        public double TenderAmount
        {
            get { return tenderAmount; }
            set { tenderAmount = value; }
        }

        #endregion



        public override void UpdateTotals()
        {
            if (PosContext.Instance.Training)
                return;

            this.customerDataRec.Current_debt = this.customerDataRec.Current_debt - this.TenderAmount;
            this.customerDataRec.UpdateCurrentDebt();
        }


        public override bool Save()
        {
            if (!PosContext.Instance.Training)
            {
                
            }
            return true;
        }

        public override void SaveState(EjLineStates state)
        {
    
        }




        public override void Engage(int keyValue)
        {

            switch (this.States().PeekState())
            {

                case PROMPT_AMOUNT:
                    this.PopState();

                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptAmount");
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.ClearInput();
                    this.States().PushState(GET_AMOUNT);

                
                   
                    break;

                case PROMPT_CUSTOMER:
                    this.PopState();

                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptCustomer");
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.ClearInput();
                    this.States().PushState(GET_CUSTOMER);

                    PosContext.Instance.CurrentPosDisplay.LoadCustomerSearch();
                   
                    break;

                case GET_AMOUNT:
                    this.States().PopState();
                    this.tenderAmount = PosContext.Instance.Input() / 100;
                    PosContext.Instance.ClearInput();
                    this.States().PushState(PROMPT_CUSTOMER);
                    PosEventStack.Instance.NextEvent();
                    break;
                
                case GET_CUSTOMER:

                                        
                   // this.PopState();

                    customer_tax_id = PosContext.Instance.InputLine;

                    
                    if (this.CustomerIsValid())
                    {

                        this.PopState();
                    }
                    else
                    {
                        // get out of this transaction and prompt error.
                        PosContext.Instance.ClearInput();
                        PosEventStack.Instance.ClearPending();
                        PosError error = new PosError(PosErrorCode.INVALID_CUSTOMER_NO);
                        this.PromptText = ""; //PosContext.Instance.Parameters.getParam("InvalidCustomer");
                        PosEventStack.Instance.PushEvent(error);
                       // PosContext.Instance.Operprompt.Update(this);
                        PosEventStack.Instance.NextEvent();
                        return;
                    }

                    EclipsePos.Data.Customer cus = new EclipsePos.Data.Customer();
                    cus.Organization_no = PosSettings.Default.Organization;
                    cus.Tax_id = this.customer_tax_id;
                    cus.LoadByTaxID();

                    
                    
                    Transaction trans = new Transaction(PosContext.Instance.TrxNo);
                    trans.Organization_no = PosSettings.Default.Organization;
                    trans.Store_no = PosSettings.Default.Store;
                    trans.Pos_no = PosSettings.Default.Station;
                    trans.Trans_no = PosContext.Instance.TrxNo;
                    trans.Load();
                    trans.Customer_tax_id = cus.Tax_id;
                    trans.UpdateCustomer();

                    PosContext.Instance.EjCustomer = new EjCustomer(cus);
                    PosContext.Instance.CurrentEj.EjAdd(this);
                   
                    PosContext.Instance.Receipt.Update(this);
                    PosContext.Instance.Operprompt.Update(this);
                    
                    PosEventStack.Instance.NextEvent();

                    break;
                    

                default:
                    break;
            }



        }

        public override IRelatable DataRecord()
        {
            return this.customerDataRec;
        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }

        public bool CustomerIsValid()
        {
            EclipsePos.Data.Customer cus = new EclipsePos.Data.Customer();
            cus.Organization_no = PosSettings.Default.Organization;
            cus.Tax_id = this.customer_tax_id;
            cus.LoadByTaxID();

            if (cus.Customer_first_name != null && cus.Customer_first_name.Trim().Length > 0)
            {
                this.customerDataRec = cus;
                return true;
               
            }
            else
            {
                return false;
            }

        }

        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.ToString());
        }


    }
}
