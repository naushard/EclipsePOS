using System;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using System.Globalization;
using EclipsePos.Apps.Hardware;

namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjAltCurrTender.
	/// </summary>
	public class EjAltCurrTender:EjLine	
	{
		/** Prompt for amount. */
		public const int ENTER_ALT_CURR_AMOUNT = 1;
		/** get amount. */
		public const int GET_ALT_CURR_AMOUNT = 2;
		/** Complete the transaction. */
		public const int TENDER_FINAL = 3;

		private TransTender transTender;
		private double convertedAmount;
		private double splitAmount;
		private string prompttext;
		private string convertText;
	//	private Currency tenderCurrency;


		public EjAltCurrTender()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int) EjLineType.ALT_CURRENCY_TENDER;
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
				return transTender.State;
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

		public double ConvertedAmount
		{
			get
			{
				return convertedAmount;
			}
			set
			{
				convertedAmount = value;
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
				splitAmount = value;
			}
		}
 
		public string ConvertText
		{
			get
			{
				return convertText;
			}
			set
			{
				convertText = value;
			}
		}

		public override  int SeqNo
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
 
		public string TenderDesc
		{
			set
			{
				this.transTender.Tender_desc = value;
			}
			get
			{
				return this.transTender.Tender_desc;
			}
		}

		
 
 
		#endregion


	//
	// Get the currency record from the database from value (value is
	// configured in the key database). If the currency is found
	// start the alt currency dialog, which prompts for the amount
	// tenderd, and completes the transaction if the tendered amount
	// covers the sale, else split tender.
	
		public override void Engage (int keyValue)
		{
 
			
			switch (this.States().PeekState() )
			{

				case ENTER_ALT_CURR_AMOUNT: // prompts for amount tendered
				/*	this.transTender = new TransTender ();  // create a tender record

					transTender.Locale_language = "sg"; 
					transTender.Locale_country = "sg";
					transTender.Trans_id = PosContext.Instance.TrxNo;
					transTender.Seq_no = PosContext.Instance.CurrentEj.Seq_no;
					transTender.Tendertype = (int) TransTender.TenderTypes.ALT_CURRENCY;
					transTender.Tender_desc = PosContext.Instance.Parameters.getParam("AltCurrencyDescription");
					transTender.Data_capture = "XX"; //context ().altCurrency ().locale () + "," + context ().altCurrency ().conversionRate ());
					ConvertedAmount = PosContext.Instance.PosMath.Mult(PosContext.Instance.CurrentEj.EjSubTotal(), PosContext.Instance.AltCurrency.Conversion_rate);
					transTender.Amount = PosContext.Instance.PosMath.Mult( PosContext.Instance.CurrentEj.EjTotal(), PosContext.Instance.AltCurrency.Conversion_rate);
					*/
			 		PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("AltCurrTenderPrompt");
					ConvertText = PosContext.Instance.Parameters.getParam("ConvertedAltCurrency");
					PosContext.Instance.Operprompt.Update(this);
				//	PosContext.Instance.Receipt.Update(this);
				//	this.States().Clear();
				    this.States().PushState(GET_ALT_CURR_AMOUNT);

					break;

				case GET_ALT_CURR_AMOUNT:  // Pick up the amount from the input

					this.PopState();
					SplitAmount = Math.Round(PosContext.Instance.PosMath.Div(PosContext.Instance.InputDouble(), 100), 2);

					if (this.AmountIsValid())
					{
						this.PopState();
					}
					else
					{
						return;
					}

					PosContext.Instance.ClearInput();
					double amount = this.SplitAmount;
					double localAmount = Math.Round(PosContext.Instance.PosMath.Mult(amount, PosContext.Instance.AltCurrency.Conversion_rate), 2);


					this.transTender = new TransTender ();  // create a tender record

                    transTender.Organization_no = PosSettings.Default.Organization;
                    transTender.Store_no = PosSettings.Default.Store;
                    transTender.Pos_no = PosSettings.Default.Station;

                    transTender.Locale_language = ""; // CultureInfo.CurrentCulture.Name;
                    transTender.Locale_country = ""; 
					transTender.Trans_no = PosContext.Instance.TrxNo;
					transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
					transTender.Tendertype = (int) TransTender.TenderTypes.ALT_CURRENCY;
					transTender.Tender_desc = PosContext.Instance.Parameters.getParam("AltCurrencyDescription");
                    transTender.Data_capture = PosContext.Instance.AltCurrencyCode.Currency_name + "," + PosContext.Instance.AltCurrency.Conversion_rate.ToString();  //context ().altCurrency ().locale () + "," + context ().altCurrency ().conversionRate ());
					this.convertedAmount = localAmount; //PosContext.Instance.PosMath.Mult(PosContext.Instance.CurrentEj.EjTotal(), PosContext.Instance.AltCurrency.Conversion_rate);
					
					transTender.Amount = localAmount;
					transTender.Change_amount = PosContext.Instance.PosMath.Sub(localAmount, PosContext.Instance.CurrentEj.EjTotal());
					transTender.Change_desc  = PosContext.Instance.Parameters.getParam("Change");
                    transTender.State = (int)EjLineStates.IN_PROGRESS;

					// save the transaction
                   
                    // if not training mode
                    if (!PosContext.Instance.Training)
                    {
                        transTender.Add();
                    }


					PosContext.Instance.CurrentEj.EjAdd(this);
					PosContext.Instance.Receipt.Update(this);
					this.States().Clear();
					PosEventStack.Instance.NextEvent();
					break;
			}

			

		}
		/**
		 * Validate alternate currency amount.
		 */
		private bool AmountIsValid ()
		{
			return true;
		}


		// Abstract implementations, PosEvent

		/** Validate transistions state. */
		public override bool ValidTransition (string pEvent)
		{
			return true;
		}

		public override void Clear ()
		{
		}
		
		public override IRelatable DataRecord()
		{
			return transTender;
		}

		/** Save the transaction record */
		public override bool Save ()
		{

			if (!PosContext.Instance.Training)
			{
				transTender.Add();
			}
			return true;
		}


        public override void SaveState(EjLineStates state)
        {
            transTender.State =(int) state;
            transTender.UpdateState();
        }

		public override void UpdateTotals ()
		{

			if (PosContext.Instance.Training)
				return;

			EclipsePos.Data.Total total = new EclipsePos.Data.Total();
			total.AddToTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
                PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
				TotalType.ALT_CURRENCY_BASE + PosContext.Instance.AltCurrencyCode.Pos_key_number, 
				this.SplitAmount ); 


            total.AddToTotal(
                PosSettings.Default.Organization,
                PosSettings.Default.Store,
                PosSettings.Default.Station,
                EclipsePos.Data.TotalName.DAILY_BASE,
                TotalType.CASH_SALES,
                transTender.Amount-transTender.Change_amount  );

			if (transTender.Change_amount  != 0.0)
			{
				//EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
				total.AddToTotal(
                    PosSettings.Default.Organization,
                    PosSettings.Default.Store,
                    PosSettings.Default.Station,
                    EclipsePos.Data.TotalName.DAILY_BASE,
					TotalType.CASH_IN_DRAWER,
					PosContext.Instance.PosMath.Mult(transTender.Change_amount, -1) );
			}
             
           /* total.AddToTotal(
                    PosSettings.Default.Organization,
                    PosContext.Instance.RetailStore.Retail_store_no,
                    PosSettings.Default.Station,
                    EclipsePos.Data.TotalName.DAILY_BASE,
                    TotalType.CASH_IN_DRAWER,
                    transTender.Amount - transTender.Change_amount );*/

            this.transTender.State = (int)EjLineStates.PAID;
            this.transTender.UpdateState();


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

            //PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
        }


		#region IComparable Members

		public int CompareTo(object obj)
		{
			// TODO:  Add EjAltCurrTender.CompareTo implementation
			return 0;
		}

		#endregion
	}
}
