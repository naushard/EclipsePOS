using System;
//using System.Windows.Forms;
using System.Collections;


using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjTax.
	/// </summary>
	public class EjTax:EjLine										
	{

		private Tax taxRecord;
		private TransTax transTax;
		private EjItem item;
		private double taxAmount;
		private bool useAltTax;
		private double promotionAmount=0.0;
        private EjSurcharge ejSurcharge;
		
		

		public EjTax(Tax t, EjItem i)
		{
			this.taxRecord = t;
			this.item = i;
			this.useAltTax = false;
			this.LineType  = (int) EjLineType.TAX;
            this.ejSurcharge = null;
		}

        public EjTax(Tax t, EjSurcharge i)
        {
            this.taxRecord = t;
            this.ejSurcharge = i;
            this.useAltTax = false;
            this.LineType = (int)EjLineType.TAX;
            this.item = null;
        }


		public EjTax(TransTax ttax)
		{
			this.transTax = ttax;
			this.LineType = (int) EjLineType.TAX;
            //this.item = 
		}


		/** pdate total records for this object. */
		public override  void UpdateTotals ()
		{
            if (this.transTax.State == (int)EjLineStates.IN_PROGRESS)
            {
                this.transTax.State = (int)EjLineStates.PAID;
                this.transTax.UpdateState();
            }
		}


		
		/** Return the associated transaction record, (database entity). */
		public override IRelatable DataRecord()
		{
			
			return transTax;
		}
		
		/** Database save function. */
		public override bool Save()
		{
			transTax.Save();
			return true;
		}


        public override void SaveState(EjLineStates state)
        {
            transTax.State = (int)state;
            transTax.UpdateState();
        }


		

		
		/*
		* Create a tax record and add it to the EJ. 
		* A tax record is created for each item, summaries
		* are implemented in the print objects.
		 */
		public  override void Engage(int keyValue)
		{	
			transTax = new TransTax ();

			transTax.Trans_no = PosContext.Instance.TrxNo;
            transTax.Organization_no = PosSettings.Default.Organization;
            transTax.Store_no = PosSettings.Default.Store;
            transTax.Pos_no = PosSettings.Default.Station;
			transTax.SeqNo = PosContext.Instance.CurrentEj.SeqNo;
            transTax.Line_no = PosContext.Instance.CurrentEj.LineNo; 
			transTax.TaxId = taxRecord.Tax_id;
			transTax.TaxDesc = taxRecord.ShortDesc;
			transTax.Rate = taxRecord.Rate;
            transTax.State = (int)EjLineStates.IN_PROGRESS;

            if (this.item != null)
            {

                ApplyTax();
            }

            if (this.ejSurcharge != null)
            {
                ApplyTaxSurcharge();
            }
            
            //If not training mode
            if (!PosContext.Instance.Training)
            {
                transTax.Add();
            }

			PosContext.Instance.CurrentEj.EjAdd(this);

						
		}
 
		public override void Clear ()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

		public void ApplyTax()
		{
			//transTax.TaxAmount = Math.Round(transTax.TaxableAmount*transTax.Rate, 2);
			if (item.TaxInclusive == 1)
			{

				//double tmpAmount1 = item.Amount * 1/taxRecord.Rate; 
				transTax.TaxAmount = Math.Round(((item.ExtAmount+promotionAmount)* transTax.Rate)/(100+transTax.Rate), 2);
            
                transTax.TaxableAmount = Math.Round((item.ExtAmount+PromotionAmount) * (100 / (taxRecord.Rate + 100)), 2);
			
			}
			else
			{
				transTax.TaxAmount = Math.Round(((item.ExtAmount+promotionAmount) * transTax.Rate)/100, 2);

                transTax.TaxableAmount = item.ExtAmount + this.PromotionAmount;

			}

		}


        public void ApplyTaxSurcharge()
        {
            if (this.ejSurcharge.TaxInclusive == 1)
            {

                transTax.TaxAmount = Math.Round(((ejSurcharge.ExtAmount ) * transTax.Rate) / (100 + transTax.Rate), 2);

                transTax.TaxableAmount = Math.Round((ejSurcharge.ExtAmount ) * (100 / (taxRecord.Rate + 100)), 2);

            }
            else
            {
                transTax.TaxAmount = Math.Round(((ejSurcharge.ExtAmount ) * transTax.Rate) / 100, 2);

                transTax.TaxableAmount = ejSurcharge.ExtAmount ;

            }

        }

		


		#region Properties 
		public override int State
		{
			set 
			{
				this.transTax.State  = value;
			}
			get
			{
				return this.transTax.State;
			}
		}
		

		public Item Item
		{
			set 
			{
				//item = value;
			}
			get
			{
				return null;
			}
		}

		public override string Desc
		{
			get 
			{
				return transTax.TaxDesc;
			}
			set
			{
				transTax.TaxDesc = value;
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

		public override double ExtAmount
		{
			get
			{
                return transTax.TaxAmount;
			}
			set
			{
			}
		}

		public override int LineNo
		{
			get
			{
				return transTax.SeqNo;
			}
			set
			{
			}
		}

		public override double TaxAmount
		{
			get
			{
                return transTax.TaxAmount;
			}
			set
			{
                transTax.TaxAmount = value;
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

		public override double Amount
		{
			get
			{
                return transTax.TaxableAmount;
			}
            set
            {
                transTax.TaxableAmount = value;
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

		public double PromotionAmount
		{
			get
			{
				return promotionAmount;
			}
			set
			{
				promotionAmount = value;
			}
		}

		public override bool TenderComplete
		{
			get
			{
				return true;
			}

		}

		public override int SeqNo
		{
			set
			{
				this.transTax.SeqNo = value;
			}
			get
			{
				return this.transTax.SeqNo;
			}
		}


		
		#endregion

        public override void PrintEj()
        {
           // PosHardware.Instance.PosPrinter.Println(this.ToString());
        }


		
	}
}
