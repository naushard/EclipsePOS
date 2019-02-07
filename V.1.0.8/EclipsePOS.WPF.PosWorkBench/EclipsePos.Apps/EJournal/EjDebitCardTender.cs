using System;
using System.Windows;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjDebitTender.
	/// </summary>
    public class EjDebitCardTender : EjLine	
	{

        /** Start dialog. */
        public const int DEBIT_TENDER = 0;
        /** Prompt for cash back amount. */
        public const int ENTER_CASH_BACK_AMOUNT = 1;
        /** Prompt for check number. */
        public const int ENTER_APPROVAL_NO = 2;
		/** Get cash back amount. */
        public const int GET_CASH_BACK_AMOUNT = 3;
        /** Get the approval number. */
        public const int GET_APPROVAL_NO = 4;
        /** Complete the transaction. */
        public const int TENDER_FINAL = 5;

        private double splitAmount;
        private double cashBack;
        private string approvalNumber;
        private TransTender transTender;

        private bool tenderComplete = false;


		public EjDebitCardTender()
		{
			//
			// TODO: Add constructor logic here
			//
            this.LineType = (int)EjLineType.DEBIT_TENDER;
		}

        #region Properties

        public override bool TenderComplete
        {
            get
            {
                return tenderComplete;
            }

        }

        public override string Desc
        {
            get
            {
                return transTender.Tender_desc;
            }
            set
            {
                transTender.Tender_desc = value;
            }
        }

        public override double Amount
        {
            get
            {
                return transTender.Amount;
            }
            set
            {
            }
        }

        public override double ExtAmount
        {
            get
            {
                return this.Amount;
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


        public override int State
        {
            get
            {
                return this.transTender.State;
            }
            set
            {
                this.transTender.State = value;
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

        public override int SeqNo
        {
            set
            {
                this.transTender.Seq_no = value;
            }
            get
            {
                return this.transTender.Seq_no;
            }
        }



        #endregion


        public override void UpdateTotals()
        {
            //return null;
            if (PosContext.Instance.Training)
                return;

            EclipsePos.Data.Total total = new EclipsePos.Data.Total();
            total.AddToTotal(
                PosSettings.Default.Organization,
                PosContext.Instance.RetailStore.Retail_store_no,
                 PosSettings.Default.Station,
                 EclipsePos.Data.TotalName.DAILY_BASE,
                TotalType.DEBIT,
                this.Amount);

            if (transTender.Change_amount > 0)
            {
                // subtract cash back from drawer
                EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
                total2.AddToTotal(
                    PosSettings.Default.Organization,
                    PosContext.Instance.RetailStore.Retail_store_no,
                    PosSettings.Default.Station,
                    EclipsePos.Data.TotalName.DAILY_BASE,
                    TotalType.CASH_IN_DRAWER,
                    PosContext.Instance.PosMath.Mult(transTender.Change_amount, -1.0)
                    );
            }
           
            
            int count = PosContext.Instance.CurrentEj.SalesPerson.Count;
            PosContext.Instance.CurrentEj.SalesPerson.ForEach(delegate(EjSalesPerson ejSalesPerson) {

                TransSalesPerson transSalesPerson = (TransSalesPerson)ejSalesPerson.DataRecord();
                string employee_id = transSalesPerson.Employee_no;

                EclipsePos.Data.PosEmployeeTotal empTotal = new EclipsePos.Data.PosEmployeeTotal();
                empTotal.AddToEmployeeTotalAndCount(
                PosSettings.Default.Organization,
                PosContext.Instance.RetailStore.Retail_store_no,
                PosSettings.Default.Station,
                employee_id,
                0,
                EclipsePos.Data.TotalName.DAILY_BASE,
                TotalType.DEBIT,
                1,
                Amount/count
                );

            
            });

            

            transTender.State = (int) EjLineStates.PAID;
            transTender.UpdateState();

        }


        public override bool Save()
        {
            if (!PosContext.Instance.Training)
            {
                try
                {
                    transTender.Add();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return true;
        }


        public override void SaveState(EjLineStates state)
        {
            transTender.State = (int)state;
            transTender.UpdateState();
        }





        public override void Engage(int keyValue)
        {

            switch (this.PeekState())
            {

                case ENTER_CASH_BACK_AMOUNT: // prompts for cash back

                    if (PosContext.Instance.InputLine.Length > 0)
                    {
                        splitAmount = Math.Round(double.Parse(PosContext.Instance.InputLine) / 100.00, 2);
                    }
                    else
                    {
                        splitAmount = 0;
                        // tenderAmount = PosContext.Instance.CurrentEj.EjBalance();
                    }

                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptCashBack");
                    //numbertype = EjLine.AMOUNT;
                    //setType (PosNumberDialog.CURRENCY);
                    //	PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.Operprompt.Update(this);
                    this.PushState(GET_CASH_BACK_AMOUNT);

                    break;

                case ENTER_APPROVAL_NO:          // prompts for check number

                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("DebitCardApprovalNo");
                    //	numbertype = EjLine.NUMBER;
                    //	setType = PosNumberDialog.PosEventType.cl.CLEAR);
                    PosContext.Instance.Operprompt.Update(this);
                    this.PushState(GET_APPROVAL_NO);

                    break;
            

                case GET_CASH_BACK_AMOUNT:  // get the amount and save it

                    this.PopState();
                    cashBack = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
                    if (this.AmountIsValid() )  //cashBackIsValid())
                    {
                        this.PopState();
                    }
                    else
                    {
                        // get out of this transaction and prompt error.
                        PosContext.Instance.ClearInput();
                        PosEventStack.Instance.ClearPending();
                        PosError error = new PosError(PosErrorCode.CASH_EXCEEDED);
                        this.PromptText = PosContext.Instance.Parameters.getParam("CashLimitExceeded");
                        PosEventStack.Instance.PushEvent(error);
                        PosContext.Instance.Operprompt.Update(this);
                        PosEventStack.Instance.NextEvent();
                        return;
                    }
                    PosContext.Instance.ClearInput();
                    PosEventStack.Instance.NextEvent();

                    break;

                case GET_APPROVAL_NO:

                    this.PopState();
                    approvalNumber = PosContext.Instance.InputLine;
                    if (this.ApprovalNumberIsValid())
                    {
                        this.PopState();
                        this.PushState(TENDER_FINAL);
                    }
                    else
                    {
                    }
                    PosContext.Instance.ClearInput();
                    PosEventStack.Instance.NextEvent();

                    break;

              
                case TENDER_FINAL:  // this completes the transaction


                    this.transTender = new TransTender();

                    // logic for cash back, assume amount () is either 0 or the amount, add it regardless

                    if (splitAmount > 0.0)
                    {
                        transTender.Amount = splitAmount + cashBack;
                    }
                    else
                    {
                        transTender.Amount = PosContext.Instance.PosMath.Add(cashBack, PosContext.Instance.CurrentEj.EjBalance());  // amount was requested cash back
                    }


                    transTender.Trans_no = PosContext.Instance.TrxNo;
                    transTender.Organization_no = PosSettings.Default.Organization;
                    transTender.Store_no = PosSettings.Default.Store;
                    transTender.Pos_no = PosSettings.Default.Station;
                    transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    transTender.Tender_desc = PosContext.Instance.Parameters.getParam("DebitCardTender");
                    transTender.Change_amount = cashBack;
                    transTender.Change_desc = PosContext.Instance.Parameters.getParam("CashBack");
                    transTender.Tendertype = (int)TransTender.TenderTypes.DEBIT;
                    transTender.Data_capture = approvalNumber;
                    transTender.Locale_language = "";
                    transTender.Locale_country = "";
                    transTender.State = (int)EjLineStates.IN_PROGRESS;

                    PosContext.Instance.CurrentEj.EjAdd(this);

                    transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;

                    // if not training mode
                    if (!PosContext.Instance.Training)
                    {
                        transTender.Add();
                    }

                    if (PosContext.Instance.CurrentEj.EjBalance() <= transTender.Amount)
                    {

                        this.tenderComplete = true;
                    }
                    else
                    {
                        this.tenderComplete = false;
                    }

                    

                    PosContext.Instance.Receipt.Update(this);
                    PosContext.Instance.Operprompt.Update(this);

                    // finish up and resume the dialog

                    this.States().Clear();
                    PosEventStack.Instance.NextEvent();

                    break;

                default:
                    break;

            }
        }

        /**
 * Validate cash back value.
 */
        private bool cashBackIsValid()
        {
            return true;
        }

        /**
         * Validate check number Format.
         */
        private bool ApprovalNumberIsValid()
        {
            return true;
        }
        /**
         * For future use.
         */
        private bool ValidateCheckNo(string check_no)
        {
            return true;
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
            return transTender;
        }


        private bool AmountIsValid()
        {

            // because it is already negative

            double amount = this.cashBack;


            PosTotal posTotal = new PosTotal();
            posTotal.Organization_no = PosSettings.Default.Organization;
            posTotal.Store_no = PosSettings.Default.Store;
            posTotal.Pos_no = PosSettings.Default.Station;
            posTotal.Total_name = (int)TotalName.DAILY_BASE;
            posTotal.Load();
            posTotal.Relations();
            foreach (object obj in posTotal.Totals)
            {
                EclipsePos.Data.Total tot = obj as EclipsePos.Data.Total;
                if (tot.Total_type == (int)EclipsePos.Data.TotalType.CASH_IN_DRAWER)
                {
                    if (tot.Total_amount > amount) return true;

                }
            }

            return false;


        }

        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.ToString());
        }


	}
}
