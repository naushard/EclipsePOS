using System;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;
using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjLine.
	/// </summary>
	public abstract class EjLine: PosNumberDialog, IComparable 
	{
		private int lineType=0;
		private int numberType=0;
		private string promptText;
		private string messageText;

		public EjLine()
		{
			promptText = PosContext.Instance.Parameters.getParam("RegOpen");	
		}

		
		#region Properties

		/** Print the number as an amount or number */
		public int NumberType 
		{
			get 
			{
				return numberType;
			}
			set
			{
				numberType = value;
			}
		}


		/** Set the line type. */
		public int LineType
		{
			get 
			{
				return lineType;
			}
			set
			{
				lineType = value;
			}
		}

		/** Number dialog type */
		private PosNumberDialogTypes  type =  PosNumberDialogTypes.Clear;

		public override PosNumberDialogTypes Type
		{
			get 
			{
				return type;
			}
			set 
			{
				type = value;	
			}

		}

        public abstract void PrintEj();
        


		
	
		
		/** Quantitiy for this line. */
		public abstract double Quantity 
		{
			set; 
			get;
		}

		
		/** Amount for this line. */
		public abstract double Amount 
		{
			set; 
			get;
			
		}
		
		/** Extended amount (quantity * amount). */
		public abstract double ExtAmount
		{
			set; 
			get;
			
		}
		
		/** Taxable amount. */
		public abstract double TaxAmount
		{
			set; 
			get;
						
		}
		
		/** Chage for this transaction. */
		public abstract double Change
		{
			set; 
			get;
			
		}
		
		/** Access the line number. */
		public  abstract int LineNo 
		{
			set; 
			get;
			
		}

		

	
		/** Access the line number. */
		public  abstract string Desc 
		{
			get;
			set;
		}

		public abstract string SKU 
		{
			set; 
			get;
		}

		public abstract int State
		{
			set;
			get;
		}

		public abstract int SeqNo
		{
			set;
			get;
		}
		
		#endregion
		/** pdate total records for this object. */
		public abstract void UpdateTotals ();
		
		/** Return the associated transaction record, (database entity). */
		public abstract IRelatable DataRecord ();
		
		/** Database save function. */
		public abstract bool Save ();

        public abstract void SaveState(EjLineStates state);

	
		// useful display interfaces.

		
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
		
		public override string MessageText
		{
			get
			{
				return messageText;
			}
			set
			{
				messageText = value;
			}
		}

		public abstract bool TenderComplete 
		{
			get; 
			
		}


		#region IComparable Members

		public int CompareTo(object obj)
		{
			EjLine ejl = obj as EjLine; 
			return this.SeqNo.CompareTo(ejl.SeqNo); //ejl.Seq_no.CompareTo(this.Seq_no); 
			//return 0;
		}

		#endregion
	}

	public enum EjLineType
	{
		TRANS_HEADER = 0,
		ITEM = 1,
		PROMOTION = 2,
		TENDER = 3,
		TAX = 4,
		TOTAL = 5,
		ITEM_LINK = 6,
		BANK = 7,
		ACCOUNT = 8,
		ALT_CURRENCY_TENDER = 9,
		CHECK_TENDER = 10,
		CC_TENDER = 11,
		SPLIT = 12,
		DEBIT_TENDER = 13,
		GIFT_CERT_TENDER = 14,
		COUPON = 15,
		TABLE = 16,
        CUSTOMER =17,
        CREDIT_ON_ACC =18,
        ITEM_PRICE_OVERRIDE = 19,
        FREE_TEXT = 20,
        SURCHARGE = 21,
        SALES_PERSON = 22 
	}
}
