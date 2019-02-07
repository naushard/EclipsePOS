using System;
using System.Windows;
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
    public class EjDebtTender : EjLine
    {

       	private double debtAmount;
		private string checkNumber;
		private TransTender transTender;

        private double maxDebt=0;
        private double priviousDebt=0;
        private double currentDebt=0;
	
		private bool tenderComplete = false;

		public EjDebtTender()
		{
			this.LineType = (int) EjLineType.DEBIT_TENDER;
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


		public override  void UpdateTotals ()
		{
			//return null;
			if (PosContext.Instance.Training )
				return;

			EclipsePos.Data.Total total = new EclipsePos.Data.Total();
			total.AddToTotal(
                PosSettings.Default.Organization,
				PosContext.Instance.RetailStore.Retail_store_no,
				 PosSettings.Default.Station,
                 EclipsePos.Data.TotalName.DAILY_BASE,
				TotalType.DEBT,
				this.Amount);

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
                TotalType.DEBT,
                1,
                Amount/count
                );

            
            });

            
            

            transTender.State = (int)EjLineStates.PAID;
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
				catch ( Exception e)
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
		

		public  override void Engage(int keyValue)
		{

			if (PosContext.Instance.EjCustomer == null )
            {
                PosContext.Instance.ClearInput();
                PosEventStack.Instance.ClearPending();
                PosError error = new PosError(PosErrorCode.SELECT_CUSTOMER);
                this.PromptText = PosContext.Instance.Parameters.getParam("SELECT_CUSTOMER"); 
                PosEventStack.Instance.PushEvent(error);
                PosEventStack.Instance.NextEvent();
                return;

            }

				
            if (PosContext.Instance.InputLine.Length > 0)
            {
                debtAmount = Math.Round(double.Parse(PosContext.Instance.InputLine) / 100.00, 2);
            }
            else
            {
               debtAmount = PosContext.Instance.CurrentEj.EjBalance();
            }

			PosContext.Instance.ClearInput();
				
            EclipsePos.Data.Customer  cus = PosContext.Instance.EjCustomer.DataRecord() as EclipsePos.Data.Customer;        
		

            // Check max debt limit
	        if ( cus.Current_debt + debtAmount > cus.Max_debt )
            {
                PosContext.Instance.ClearInput();
                PosEventStack.Instance.ClearPending();
                PosError error = new PosError(PosErrorCode.INSUFFICIENT_CREDIT_LIMIT);
                this.PromptText = PosContext.Instance.Parameters.getParam("Insufficient_credit_limit");  
                PosEventStack.Instance.PushEvent(error);
                PosEventStack.Instance.NextEvent();
                return;

            }

			// this completes the transaction


			this.transTender = new TransTender();

					
			transTender.Amount   = debtAmount;
			
            transTender.Trans_no =  PosContext.Instance.TrxNo;
            transTender.Organization_no = PosSettings.Default.Organization;
            transTender.Store_no = PosSettings.Default.Store;
            transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
            transTender.Tender_desc = PosContext.Instance.Parameters.getParam("DebtTender");
			transTender.Change_amount = 0;
			transTender.Change_desc =  "";
			transTender.Tendertype = (int) TransTender.TenderTypes.CREDIT_ON_ACC;
			transTender.Data_capture = "";
			transTender.Locale_language = ""; 
			transTender.Locale_country =  "" ;

            transTender.State = (int)EjLineStates.IN_PROGRESS;

            PosContext.Instance.CurrentEj.EjAdd(this);
            transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;

            // if not training mode
            if (!PosContext.Instance.Training)
            {
                transTender.Add();
                this.priviousDebt = cus.Current_debt;

                cus.Current_debt += debtAmount;
                this.currentDebt = cus.Current_debt;
                this.maxDebt = cus.Max_debt;

                cus.UpdateCurrentDebt();
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
            PosContext.Instance.HomeGUI();
			PosEventStack.Instance.NextEvent();

			
			
		}

			/**
	 * Validate cash back value.
	 */
		private bool cashBackIsValid ()
		{
			return true;
		}

		/**
		 * Validate check number Format.
		 */
		private bool CheckNumberIsValid ()
		{
			return true;
		}
		/**
		 * For future use.
		 */
		private bool ValidateCheckNo (string check_no)
		{
			return true;
		}


		public override void Clear ()
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


        public double MaxDebt
        {
            get
            {
                return this.maxDebt;
            }
        }

        public double PreviousDebt
        {
            get
            {
                return this.priviousDebt;
            }
        }

        public double CurrentDebt
        {
            get
            {
                return this.currentDebt;
            }
        }

        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.ToString());
        }



    }
}
