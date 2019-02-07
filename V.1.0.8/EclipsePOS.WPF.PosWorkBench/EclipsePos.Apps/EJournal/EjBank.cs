using System;
using System.Windows;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;  


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjBank.
	/// </summary>
	public class EjBank:EjLine	 
	{

		/** Enter paid-in amount */
		public const int PAID_IN = 1;
		/** Enter paid out amount */
		public const int PAID_OUT= 2;
		/** Enter loan amount */
		public const int LOAN = 3;
		/** Enter pickup amount */
		public const int PICKUP = 4;
		/** Prompt for amount. */
		public const int GET_AMOUNT = 5;
		/** Complete the transaction. */
		public const int BANK_FINAL = 6;

		
		private TransBank transBank;
		private int transType;  // paid-in/paid-out
		private double transAmount;
		private string desc = "Unkown payment type";
		private string promptText;
		private double sign;


		public EjBank()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int) EjLineType.BANK;
            this.States().Clear();
            
		}

        public EjBank(TransBank tb)
        {
            //
            // TODO: Add constructor logic here
            //
            this.LineType = (int)EjLineType.BANK;
            this.transBank = tb;
            this.States().PushState(BANK_FINAL);

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
				return transBank.Bank_desc;
			}
			set
			{
				transBank.Bank_desc = value;
			}
		}

		public override double Amount
		{
			get
			{
				return transBank.Amount;
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
				
				transBank.State = value;
			}
			get
			{
				return transBank.State;
			}
		}


		public override int SeqNo
		{
			set
			{
				this.transBank.Seq_no = value;
			}
			get
			{
				return this.transBank.Seq_no;
			}
		}
 
		#endregion

        
        public override  void UpdateTotals ()
		{
			if (PosContext.Instance.Training)
				return;

			if (this.Amount != 0.0)
			{
			
				/*
                EclipsePos.Data.Total total = new EclipsePos.Data.Total();
				total.AddToTotal(
                    PosContext.Instance.RetailStore.Retail_store_no,
					PosSettings.Default.Station,
					TotalType.CASH,
					 transBank.Amount);
				
				
			
				switch ((TotalType)transBank.Pay_type)
				{

					case TotalType.PAID_IN:
					case TotalType.PAID_OUT:
					case TotalType.PICK_UP:
					case TotalType.LOAN:

						EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
                        total2.Total_id = PosContext.Instance.RetailStore.Retail_store_no;
						total2.Pos_total_id = PosSettings.Default.Station;
						total2.Total_type = (int)TotalType.CASH_IN_DRAWER;
						total2.Total_count = 0;
						total2.Total_amount = transBank.Amount;
						total2.Add();
	
						break;
					default:
						break;
				}
                 */

                //return null;
                

                EclipsePos.Data.Total total1 = new EclipsePos.Data.Total();
                total1.AddToTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
                PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
                (TotalType)transBank.Pay_type,
                transBank.Amount);


                EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
                total2.AddToTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
                PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
                TotalType.CASH_IN_DRAWER,
                transBank.Amount);

                int count = PosContext.Instance.CurrentEj.SalesPerson.Count;
                PosContext.Instance.CurrentEj.SalesPerson.ForEach(delegate(EjSalesPerson ejSalesPerson ) {

                    TransSalesPerson transSalesPerson = (TransSalesPerson)ejSalesPerson.DataRecord(); //PosContext.Instance.CurrentEj.SalesPerson.DataRecord();
                    string employee_id = transSalesPerson.Employee_no;

                    EclipsePos.Data.PosEmployeeTotal empTotal = new EclipsePos.Data.PosEmployeeTotal();
                    empTotal.AddToEmployeeTotalAndCount(
                    PosSettings.Default.Organization,
                    PosContext.Instance.RetailStore.Retail_store_no,
                    PosSettings.Default.Station,
                    employee_id,
                    0,
                    EclipsePos.Data.TotalName.DAILY_BASE,
                    (TotalType)transBank.Pay_type,
                    1,
                    (Amount - Change)/count
                    );

                });


                

			}
		}


		public override bool Save()
		{
			if (!PosContext.Instance.Training)
			{
				try 
				{
					transBank.Add();
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
            
        }
		
		

		public  override void Engage(int keyValue)
		{

			switch (this.States().PeekState())
			{

				case PAID_IN:

					this.PromptText = PosContext.Instance.Parameters.getParam("PromptAmount");
					desc =  PosContext.Instance.Parameters.getParam("PaidInAmount");
					sign = 1.0;
                   // PosContext.Instance.TransactionType = (int)Transaction.Types.PAID_IN;
                    PosContext.Instance.Operprompt.Update(this);
					this.transType = (int)TotalType.PAID_IN;
					PosContext.Instance.ClearInput();
					this.States().PushState(GET_AMOUNT);
					break;

				case PAID_OUT:

					this.PromptText = PosContext.Instance.Parameters.getParam("PromptAmount");
					desc =  PosContext.Instance.Parameters.getParam("PaidOutAmount");
					sign = -1.0;
                   // PosContext.Instance.TransactionType = (int)Transaction.Types.PAID_OUT;
					PosContext.Instance.Operprompt.Update(this);
					this.transType = (int)TotalType.PAID_OUT;
					PosContext.Instance.ClearInput();
					this.States().PushState(GET_AMOUNT);
					break;

	 			case LOAN:
					this.PromptText = PosContext.Instance.Parameters.getParam("PromptAmount");
					desc =  PosContext.Instance.Parameters.getParam("LoanAmount");
					sign = -1.0;
                 //   PosContext.Instance.TransactionType = (int)Transaction.Types.LOAN;
					PosContext.Instance.Operprompt.Update(this);
					this.transType = (int)TotalType.LOAN;
					PosContext.Instance.ClearInput();
					this.States().PushState(GET_AMOUNT);
					break;

				case PICKUP:
					this.promptText = PosContext.Instance.Parameters.getParam("PromptAmount");
					desc =  PosContext.Instance.Parameters.getParam("Pickup");
					sign = -1.0;
                   // PosContext.Instance.TransactionType = (int)Transaction.Types.PICKUP;
					PosContext.Instance.Operprompt.Update(this);
					this.transType = (int)TotalType.PICK_UP;
					PosContext.Instance.ClearInput();
					this.States().PushState(GET_AMOUNT);
					break;


				case GET_AMOUNT: // prompts for amout tendered

					this.PopState();

                    double inputAmt = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
					
                    this.transAmount = PosContext.Instance.PosMath.Mult( inputAmt, sign);

					if (this.AmountIsValid())
					{
			
						this.PopState();
					}
					else
					{
						// get out of this transaction and prompt error.
						PosContext.Instance.ClearInput();
						PosEventStack.Instance.ClearPending();
						PosError error = new PosError (PosErrorCode.CASH_EXCEEDED);
						this.PromptText = PosContext.Instance.Parameters.getParam("CashLimitExceeded");
						PosEventStack.Instance.PushEvent(error);
						PosContext.Instance.Operprompt.Update(this);
						PosEventStack.Instance.NextEvent();
						return;
					}

					transBank = new TransBank ();  // create a bank record

					transBank.Bank_desc  = desc;
					transBank.Trans_no  = PosContext.Instance.TrxNo;
                    transBank.Organization_no = PosSettings.Default.Organization;
                    transBank.Store_no = PosSettings.Default.Store;
                    transBank.Pos_no = PosSettings.Default.Station;
					transBank.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
					transBank.Pay_type = this.transType;
					transBank.Deposit_no = 0;
					transBank.State = 0;
					transBank.Drawer_no = 0;// ().setDrawerNo (context ().drawerNo ());
					transBank.Locale_language = "" ; // ().setLocaleLanguage (Application.localeLanguage ());
					transBank.Locale_country = ""; //   ().setLocaleCountry (Application.localeCountry ());
					transBank.Amount = this.transAmount;

                    transBank.State = (int)EjLineStates.IN_PROGRESS;
                    


					PosContext.Instance.CurrentEj.EjAdd(this);

                    transBank.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    transBank.Add();

					PosContext.Instance.Receipt.Update(this);
					PosContext.Instance.Operprompt.Update(this);

                   // PosContext.Instance.HomeGUI();
					PosEventStack.Instance.NextEvent();

					break;

				default:
					break;
			}



		}

		/**
	 * Validate the validity of the input amount.
	 */
		private bool AmountIsValid()
		{

			if (this.transType == (int)TotalType.PAID_IN) return true;

			// because it is already negative

			double amount = PosContext.Instance.PosMath.Mult(transAmount, -1.0);

            
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

			
		/*	String fetchSpec = PosTotal.getBySiteAndPos (context ().siteID (), context ().posNo ());
			Vector results = Application.dbConnection ().fetch (new PosTotal (), fetchSpec);

			if (results.size () > 0)
			{
				PosTotal posTotal = (PosTotal) results.elementAt (0);
				for (int i=0; i<posTotal.totals ().size (); i++)
				{

					Total total = (Total) posTotal.totals ().elementAt (i);


					if (total.totalType () == Total.CASH_IN_DRAWER)
					{

						double mediaTotal = total.totalAmount ();
						if (mediaTotal < amount)
						{ 
							 return false;
						}
					}
				}
			}
			*/
			//return false;
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
			return transBank;
		}


		//public override double Change
		//{
		//	get
		//	{
		//		return null;
		//	}
		//}

        public override void PrintEj()
        {
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;

            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            string strAmount = string.Format("{0:############.00}", transBank.Amount);
            tmpStr.Insert(0, transBank.Bank_desc);
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);

            //PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
            
        }


	}
}
