using System;
using System.Windows;
using System.Collections;
using System.Data;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Hardware;

using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjCCTender.
	/// </summary>
	public class EjCCTenderBackup
        :EjLine		 
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





		/** Credit card tender base event */
		public const int CC_TENDER = 5;
		/** Prompt for cash back */
		public const int ENTER_CASH_BACK_AMOUNT = 6;
		/** Prompt for credit card number */
		//public const int ENTER_CC_NO = 2;
		/** Prompt for credit card expiration date */
		//public  const int ENTER_CC_EXPR = 3;
		/** Get cash back amount from context */
		public const int GET_CASH_BACK_AMOUNT = 4;
		/** Get credit card number from context */
		//public const int GET_CC_NO = 5;
		/** Get credit card expiration date from context */
		//public const int GET_CC_EXPR = 6;
		/** Finalize credit card transaction */
		public const int AUTHORIZE = 7;
		public const int TENDER_FINAL = 3;
		public const int READ_ERROR = 9;
		public const int AUTHORIZATION_DECLINED = 10;
        /** Prompt for card name */
		public const int ENTER_CARD_NAME = 0;
        /** Get card name */
		public const int GET_CARD_NAME = 1;


		public EjCCTenderBackup()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int)EjLineType.CC_TENDER;
            this.Results = new Hashtable();

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


        public override void SaveState(EjLineStates states)
        {
        }
		
	
		//
		//	  Gather input and create Credit Card tender record, TransTender.
		//	  MSR filters are applied along with check digit.
		//	 
    	public  override void Engage(int keyValue)
		{
			switch (this.PeekState())
			{

			case ENTER_CASH_BACK_AMOUNT:  // prompts for cash back amount

                if (PosContext.Instance.InputLine.Length > 0)
                {
                   this.SplitAmount = Math.Round(double.Parse(PosContext.Instance.InputLine), 2);
                }
                else
                {
                    this.SplitAmount = 0;

                }

				PosContext.Instance.ClearInput();
				this.PromptText = PosContext.Instance.Parameters.getParam("PromptCashBack");
 				//this.setType (PosNumberDialog.CURRENCY);
				PosContext.Instance.Operprompt.Update(this);
				this.States().PushState(GET_CASH_BACK_AMOUNT);
				break;

            case ENTER_CARD_NAME:  // prompts for cash back amount
                //Try to load media prompt
                try
                {
                    int menuNo = int.Parse(PosContext.Instance.Parameters.getParam("CreditMediaMenuNo"));
                    PosContext.Instance.CurrentPosDisplay.LoadMenu(menuNo);
                }
                catch
                {
                }
                PosContext.Instance.ClearInput();
                this.PromptText = PosContext.Instance.Parameters.getParam("PromptCardName");
                //this.setType (PosNumberDialog.CURRENCY);
                PosContext.Instance.Operprompt.Update(this);
                this.PopState();
                this.States().PushState(GET_CARD_NAME);
                break;

		/*	case ENTER_CC_NO:          // prompts for cc number

 				//results = new Hashtable ();
				PosContext.Instance.ClearInput();
				this.PromptText = PosContext.Instance.Parameters.getParam("PromptCCNo");
  				//setType (PosNumberDialog.CLEAR);
				PosContext.Instance.Operprompt.Update(this);
				this.States().PushState(GET_CC_NO);
				break;

			case ENTER_CC_EXPR:        // prompt for cc expiration date

				PosContext.Instance.ClearInput();
				this.PromptText = PosContext.Instance.Parameters.getParam("PromptCCExpr");
				PosContext.Instance.Operprompt.Update(this);
  				//setType (PosNumberDialog.CLEAR);
				this.States().PushState(GET_CC_EXPR);
				break;
     */
			case GET_CASH_BACK_AMOUNT:  // get the amount and save it

				this.PopState();
                this.CashBack = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
				if (this.AmountIsValid())
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

            case GET_CARD_NAME:  // get card name

                this.PopState();
                this.Desc = PosContext.Instance.InputLine.Trim();
                if (string.IsNullOrEmpty(this.Desc))
                {
                    return;
                }
        
                PosContext.Instance.ClearInput();
                this.States().PushState(TENDER_FINAL);
                PosEventStack.Instance.NextEvent();
                break;

		/*	case GET_CC_NO:  // get the CC number and save it

				this.PopState();
				this.CCNumber = PosContext.Instance.InputLine;
            */
			//	for (int i=0;i<context ().msrFilters ().size (); i++)
			//	{


			//		Filter f = context ().msrFilters ().getFilter (i);

					// If a filter matched deterimine what it is and
					// extract the data

			//		if (f.apply (ccNumber (), results) == Filter.CHECKDIGIT_FAILED)
			//		{
			//			Log.warning ("CC check digit failed " + ccNumber ());

                    // if the card is invalid, get all the way out of credit card and post
                    // an invalid credit card message, they'll have to pay some other way.

			//			context ().clearInput ();
			//			context ().eventStack ().clearPending ();
			//			context ().eventStack ().pushEvent (new PosError (context (),  PosError.INVALID_CC));
			//			context ().operPrompt ().update ((PosError) context ().eventStack ().event ());
			//			return;
			//		}

			//	}

				// see if anything matched

			 //  if (results.get (Filter.ACCT_NO) == null)
			//	{

			//		Log.warning ("Invalid CC number acct_no == null" + ccNumber ());

					// same as above, except no fields were picked up.

			//		context ().clearInput ();
			//		context ().eventStack ().clearPending ();
			//		context ().eventStack ().pushEvent (new PosError (context (),  PosError.INVALID_CC));
			//		context ().operPrompt ().update ((PosError) context ().eventStack ().event ());
			//		return;
			//	}
			//	else
			//	{
		//			this.PopState();
			//	}

		//		PosContext.Instance.ClearInput();
		//		PosEventStack.Instance.NextEvent();
		//		break;

		/*	case GET_CC_EXPR:  // this completes the transaction

 				this.PopState();
				this.ExprDate = PosContext.Instance.InputLine;
				PosContext.Instance.ClearInput();
				if (this.CCExprIsValid)
				{
					this.PopState();
				}
				else
				{
				}
				PosEventStack.Instance.NextEvent();
				break;
    */
 		  case AUTHORIZE:

 				this.PopState();
				//Random rand = new Random ();
				//int r = rand.nextInt () % 99999;
				//r *= (r < 0 ? -1 : 1);
				//authCode = Integer.toString (r);
				PosEventStack.Instance.NextEvent();
				break;

		  case READ_ERROR:

				//Application.cancelTimers ();
				//context ().eventStack ().event ().setBlocked (false);
				PosContext.Instance.Operprompt.Update(this);
				this.CCNumber = "";
				this.PopState();
				break;

		  case AUTHORIZATION_DECLINED:
				break;

		  case TENDER_FINAL:  // this completes the transaction

				this.PopState();
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
