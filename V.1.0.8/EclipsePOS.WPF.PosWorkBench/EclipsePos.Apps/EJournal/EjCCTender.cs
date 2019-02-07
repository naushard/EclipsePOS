using System;
using System.Windows;
using System.Collections;
using System.Data;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Operators;

using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjCCTender.
	/// </summary>
	public class EjCCTender:EjLine		 
	{
		private TransTender transTender;
		private bool tenderComplete = false;
		private double splitAmount;
		private double cashBack;
		private string ccNumber;
		private string exprDate;
		private string firstName;
		private string lastName;
		private string mi;
		private string data;
		private string track1Data;
		private string track2Data;
		private string authCode;
		private Hashtable results;
		private string desc;
        private CardMedia cardMedia; 

		
        /** Get card name */
		public const int CHECK_CARD_NAME = 0;
        /** Final */
        public const int TENDER_FINAL = 1;


        public EjCCTender()
            : base()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int)EjLineType.CC_TENDER;
            this.Results = new Hashtable();
            this.States().PushState(CHECK_CARD_NAME);
          
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
				return desc; //transTender.Tender_desc;
			}
			set
			{
				desc = value; //transTender.Tender_desc = value;
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
				return transTender.Amount;
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


		//	public override double Price
		//	{
		//		get
		//		{
		//			return 0;
		//		}
		//		set
		//		{
		//		}
		//	}

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


		public double SplitAmount
		{
			get
			{
				return splitAmount;
			}
			set
			{
				splitAmount= value;
			}
		}

		
		public double CashBack
		{
			get
			{
				return cashBack;
			}
			set
			{
				cashBack = value;
			}
		}

		

		//Crdit card number
		public string CCNumber
		{
			get
			{
				return ccNumber;
			}
			set
			{
				ccNumber = value;
			}
		}

		
		public string ExprDate
		{
			get
			{
				return exprDate;
			}
			set
			{
				exprDate = value;
			}
		}


		public string FirstName
		{
			get
			{
				return firstName;	
			}
			set
			{
				firstName=value;
			}
		}

		
		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName=value;
			}
		}


		//private string mi;
		public string Mi
		{
			get
			{
				return mi;
			}
			set
			{
				mi=value;
			}
		}


		
		public string Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		
		public string Track1Data
		{
			get
			{
				return track1Data;
			}
			set
			{
				track1Data = value;
			}
		}

		
		public string Track2Data
		{
			get
			{
				return track1Data;
			}
			set
			{
				track2Data = value;
			}
		}


		

		public string AuthCode
		{
			get
			{
				return authCode;
			}
			set
			{
				authCode=value;
			}
		}

		public bool CCExprIsValid
		{
			get
			{
				return true;
			}
			set
			{
				//authCode=value;
			}
		}

		public bool CashBackIsValid
		{
			get
			{
				return true;
			}
			set
			{
				//authCode=value;
			}
		}

		public Hashtable Results
		{
			get
			{
				return results;
			}
			set
			{
				results = value;
			}
		}

		public override int State
		{
			set
			{
				
				this.transTender.State = value;
			}
			get
			{
                return this.transTender.State;
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

		#region initialize
		private void Init ()
		{
			this.LineType = (int) EjLineType.CC_TENDER;
			this.SplitAmount = 0.0;
			this.CashBack = 0.0;
			this.CCNumber = null;
			this.ExprDate = null;
			//this.InitTransition ();
		}
		#endregion


		public override  void UpdateTotals ()
		{
			if (PosContext.Instance.Training)
				return;

			EclipsePos.Data.Total total = new EclipsePos.Data.Total();
			total.AddToTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
				PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
				TotalType.CREDIT_CARD_BASE,
				this.Amount);


            total.AddToCardTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
                PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
                this.cardMedia.Total_type,
                this.Amount);
			
			

			if (transTender.Change_amount > 0)
			{ 
				   EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
                total2.AddToTotal(
                    PosSettings.Default.Organization,
                    PosSettings.Default.Store,
                    PosSettings.Default.Station,
                    EclipsePos.Data.TotalName.DAILY_BASE,
                    TotalType.CASH_IN_DRAWER,
                    PosContext.Instance.PosMath.Mult(transTender.Change_amount, -1.0) );
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
                TotalType.CREDIT_CARD_BASE,
                1,
                Amount/count
                );

            
            });

            

            this.transTender.State = (int)EjLineStates.PAID;
            this.transTender.UpdateState();


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
            transTender.State = (int) state;
            transTender.UpdateState();
        }
		
	
		//
		//	  Gather input and create Credit Card tender record, TransTender.
		//	  MSR filters are applied along with check digit.
		//	 
    	public  override void Engage(int keyValue)
		{
            //MessageBox.Show("OK");
            //object obj2 = PosEventStack.Instance.Peek() as Object;
            //MessageBox.Show(obj2.ToString());

            keyValue = (int) PosContext.Instance.PosKeyValue;
			switch (this.States().PeekState())
			{

			
            case CHECK_CARD_NAME:

                    if (!this.ValidCardType(keyValue))
                    {

                        PosError error = new PosError(PosErrorCode.INVALID_CC);
                        PosEventStack.Instance.PushEvent(error);
                        PosEventStack.Instance.NextEvent();
                        return;
                    }
                    this.desc = this.cardMedia.Media_name;
                    this.States().PopState();
                    PosContext.Instance.ClearInput();
                    this.PushState(TENDER_FINAL);
                    PosEventStack.Instance.NextEvent();
                    break;
                
               
               
                break;

	
		  case TENDER_FINAL:  // this completes the transaction

				this.States().PopState();
				this.transTender = new TransTender ();

                transTender.Trans_no = PosContext.Instance.TrxNo; 
                transTender.Organization_no = PosSettings.Default.Organization;
                transTender.Store_no = PosSettings.Default.Store;
                transTender.Pos_no = PosSettings.Default.Station;
                transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;



                if (this.Results[Filter.DISPLAY_NAME] != null)
                {
                    transTender.Tender_desc = (string)this.Results[Filter.DISPLAY_NAME];
                }
                else
                {
                    transTender.Tender_desc = PosContext.Instance.Parameters.getParam("CreditTender") + " "+ this.Desc; // "Not Known";
                }

				transTender.Data_capture =  this.CCNumber  + "," + this.ExprDate;

            // logic for cash back, assume amount () is either 0 or the amount, add it regardless
            // if it's 0 charge the full amount

				if (this.SplitAmount > 0.0)
				{
					transTender.Amount = this.SplitAmount +  this.CashBack;
				}
				else
				{
                // add cash back into amount
					transTender.Amount  = PosContext.Instance.PosMath.Add( this.CashBack, PosContext.Instance.CurrentEj.EjBalance());
				}

				transTender.Change_amount= this.CashBack;
                transTender.Change_desc =  PosContext.Instance.Parameters.getParam("CashBack");
				transTender.Locale_language =  ""; // Application.l.localeLanguage ());
				transTender.Locale_country = ""; // ().setLocaleCountry (Application.localeCountry ());
                this.PromptText = transTender.Change_desc;

                transTender.State = (int)EjLineStates.IN_PROGRESS;

				//PosContext.Instance.CurrentEj.EjAdd(this);

			//	if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			//	{
			//	  
			//	  this.PromptText = transTender.Change_desc;
			//	}
			//	else
			//	{
			//	  this.tenderComplete = true;
			//	}

                if (PosContext.Instance.CurrentEj.EjBalance() <= transTender.Amount)
                {
                    this.tenderComplete = true;
                }
                else
                {
                    this.tenderComplete = false;
                }

                PosContext.Instance.CurrentEj.EjAdd(this);
                transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    

                // if not training mode
                if (!PosContext.Instance.Training)
                {
                    transTender.Add();
                }


                this.States().Clear();
				PosContext.Instance.Operprompt.Update(this);
				PosContext.Instance.Receipt.Update(this);

                PosContext.Instance.HomeGUI();
				PosEventStack.Instance.NextEvent();
				break;

			default:
				break;
			}
			
			return;


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


		//public override double Change
		//{
		//	get
		//	{
		//		return null;
		//	}
		//}


        private bool AmountIsValid()
        {

            // because it is already negative

            double amount = this.cashBack;

            if (amount == 0) return true;


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


        private bool ValidCardType(int input)
        {
            try
            {
                object obj = PosContext.Instance.Config.CardMedia[input];

                if (obj is CardMedia)
                {
                    this.cardMedia = (CardMedia)obj;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public override void PrintEj()
        {
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;

            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            string strAmount = string.Format("{0:############.00}", transTender.Amount);
            tmpStr.Insert(0, transTender.Tender_desc);
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);

            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
        }



	}
}
