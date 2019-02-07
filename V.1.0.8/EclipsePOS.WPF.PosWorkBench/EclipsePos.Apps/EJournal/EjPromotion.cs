using System;
using System.Windows;
using System.Reflection;
using System.Collections;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjPromotion.
	/// </summary>
	public class EjPromotion:EjLine			
	{

		private int lineNo;
		private string sku;
		//private string desc;
		private Promotion promotion;
		private TransPromotion transPromotion;
		private PosItemModifier modifier;
        private EjItem ejItem;

		public EjPromotion()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int) EjLineType.PROMOTION;
		}
		
		public EjPromotion(TransPromotion trans)
		{
            try
            {
                this.TransPromotion = trans;
                this.LineType = (int)EjLineType.PROMOTION;
                Promotion pro = new Promotion();
                this.promotion = new Promotion();
                this.promotion.Organization_no = PosSettings.Default.Organization;
                this.promotion.PromotionNo = trans.PromotionNo;
                promotion.Load();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
		
		}

		public EjPromotion(Promotion pro, EjItem item)
		{
			this.promotion = pro;
			this.LineType = (int) EjLineType.PROMOTION;
            this.ejItem = item;
		}

		public override void Engage(int keyVal)
		{
			this.Modifier = null;

			try
			{
				this.Modifier = Assembly.GetExecutingAssembly().CreateInstance(promotion.PromotionClass) as PosItemModifier;
			}
			catch (Exception e)
			{
				Logger.Error("EjPromotion.cs", e.ToString() );
			}

			if (this.Modifier != null)
			{
				this.Modifier.Init(this.ejItem, this.Promotion);
				this.Modifier.Apply();
				//this.transPromotion = new TransPromotion();
				//this.transPromotion.Trans_no = PosContext.Instance.TrxNo;
				//this.transPromotion.Seq_no = PosContext.Instance.CurrentEj.Seq_no;
                //this.transPromotion.Line_no = PosContext.Instance.CurrentEj.LineNo;
                //this.transPromotion.Organization_no = PosSettings.Default.Organization;
                //this.transPromotion.Store_no = PosSettings.Default.Store;

				if (this.Modifier.Applied)
				{

                    this.transPromotion = new TransPromotion();
                    this.transPromotion.Trans_no = PosContext.Instance.TrxNo;
                    this.transPromotion.Organization_no = PosSettings.Default.Organization;
                    this.transPromotion.Store_no = PosSettings.Default.Store;
                    this.transPromotion.Pos_no = PosSettings.Default.Station;
                    this.transPromotion.PromotionNo = promotion.PromotionNo;

					this.transPromotion.PromotionAmount = this.Modifier.Amount;
                    this.transPromotion.PromotionQuantity = this.Modifier.Quantity; //PosContext.Instance.Quantity;
					this.transPromotion.ReasonCode = 0;
					this.transPromotion.PromotionData = " ";
					this.transPromotion.PromotionDesc = this.Modifier.Desc;
                    this.transPromotion.State = (int)EjLineStates.IN_PROGRESS;
                    
                    PosContext.Instance.CurrentEj.EjAdd(this);
                    this.transPromotion.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    this.transPromotion.Line_no = ejItem.LineNo; //PosContext.Instance.CurrentEj.LineNo;
                   
                    // if not training mode
                    if (!PosContext.Instance.Training)
                    {
                      this.transPromotion.Add();
                    }
 
                    
                   
					// Locate the associated EjTax item if any and force new tax
					// calculation based on discounted price
				/*	int lastIndex = PosContext.Instance.CurrentEj.EjArrayList.Count-1;
					for (int ejIndex = lastIndex-1; ejIndex < lastIndex; ejIndex++)
					{
						EjLine line = (EjLine) PosContext.Instance.CurrentEj.EjArrayList[ejIndex];
						if (line.LineType == (int) EjLineType.TAX)
						{
							EjTax itemTax = (EjTax) line as EjTax;
							itemTax.PromotionAmount += this.TransPromotion.PromotionAmount;
							itemTax.ApplyTax();
                            if (!PosContext.Instance.Training)
                            {
                                itemTax.Save();
                            }
						}
					}
                 * */

                    if (ejItem != null)
                    {
                        foreach (EjTax itemTax in ejItem.Taxes)
                        {
                            itemTax.PromotionAmount += this.TransPromotion.PromotionAmount;
                            itemTax.ApplyTax();
                            if (!PosContext.Instance.Training)
                            {
                                itemTax.Save();
                            }
                        }
                    }

					PosContext.Instance.Receipt.Update(this);
                    PosContext.Instance.Operprompt.Update(this);

                    //Recompute surcharges if exists
                  //  this.ReComputeSurchrge();

				}

			}
		}


        public void ReCompute(EjItem ejItem1)
        {

           this.Modifier = null;

			try
			{
				this.Modifier = Assembly.GetExecutingAssembly().CreateInstance(promotion.PromotionClass) as PosItemModifier;
			}
			catch (Exception e)
			{
				Logger.Error("EjPromotion.cs", e.ToString() );
			}

            if (this.Modifier != null)
            {
                this.Modifier.Init(ejItem1, this.Promotion);
                this.Modifier.Apply();
                
                if (this.Modifier.Applied)
                {
                    this.transPromotion.PromotionAmount = this.Modifier.Amount;
                    this.transPromotion.UpdatePromotionAmount();
                }

                if (ejItem1 != null)
                {
                    foreach (EjTax itemTax in ejItem1.Taxes)
                    {
                        itemTax.PromotionAmount += this.TransPromotion.PromotionAmount;
                        itemTax.ApplyTax();
                        if (!PosContext.Instance.Training)
                        {
                            itemTax.Save();
                        }
                    }
                }

                PosContext.Instance.Receipt.Update(this);

            }


        }

		#region Properties

		public Promotion Promotion 
		{
			get 
			{
				return promotion;
			}
			set
			{
				promotion = value;
			}
		}

		public TransPromotion TransPromotion 
		{
			get 
			{
				return transPromotion;
			}
			set
			{
				transPromotion = value;
			}
		}


		
		/** Quantitiy for this line. */
		public override double Quantity 
		{
			set
			{
				//quantity = value;
			} 
			get
			{
				return (int) transPromotion.PromotionQuantity;
			}
		}

		
		/** Amount for this line. */
		public override double Amount 
		{
			set
			{
				//amount = value;
			}
			get
			{
				return transPromotion.PromotionAmount;
			}
			
		}
		
		/** Extended amount (quantity * amount). */
		public override double ExtAmount
		{
			set
			{
				//extAmount = value;
			}
			get
			{
				return this.Amount;
			}
			
		}
		
		/** Taxable amount. */
		public override double TaxAmount
		{
			set
			{
				//taxAmount= value;
			}
			get
			{
				return 0.0;
			}
						
		}
		
		/** Chage for this transaction. */
		public override double Change
		{
			set
			{
				//change = value;
			}
			get
			{
				return 0.0;
			}
			
		}
		
		/** Access the line number. */
		public  override int LineNo 
		{
			set
			{
				transPromotion.Line_no = value;
			}
			get
			{
				return transPromotion.Line_no;
			}  
			
		}

		
	
		/** Access the line number. */
		public  override string Desc 
		{
			get
			{
				return transPromotion.PromotionDesc;
			}
			set
			{
				transPromotion.PromotionDesc = value;
			}
		}

		public override  string SKU 
		{
			set
			{
				sku  = value;
			}
			get
			{
				return sku;
			}
		}

		public PosItemModifier Modifier
		{
			set
			{
				modifier = value;
			}
			get
			{
				return modifier;
			}
		}
		

		public bool Applied
		{
			get 
			{
				if ( this.Modifier != null)
				{
					return this.Modifier.Applied; 							
				}
				else 
				{
					return false;
				}
			}
		}

		public override int State
		{
			set
			{
				
				this.transPromotion.State = value;
			}
			get
			{
				return this.transPromotion.State;
			}
		}

		public override int SeqNo
		{
			set
			{
				this.transPromotion.Seq_no = value;
			}
			get
			{
				return this.transPromotion.Seq_no;
			}
		}

        public EjItem EjItem
        {
            set
            {
                this.ejItem  = value;
            }
            get
            {
                return this.ejItem;
            }
        }


		#endregion
		/** pdate total records for this object. */
		public override void UpdateTotals ()
		{
            if (this.transPromotion.State == (int)EjLineStates.IN_PROGRESS)
            {
                this.transPromotion.State = (int)EjLineStates.PAID;
                this.transPromotion.UpdateState();
            }
		}
		/** Return the associated transaction record, (database entity). */
		public override IRelatable DataRecord()
		{
			return this.TransPromotion;
		}
		
		/** Database save function. */
		public override bool Save ()
		{
			this.TransPromotion.Add();
			return true;
		}

        public override void SaveState(EjLineStates state)
        {
            transPromotion.State = (int)state;
            transPromotion.UpdateState();
        }


		public override bool TenderComplete
		{
			get
			{
				return true;
			}

		}


		public override void Clear ()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

        public void ReComputeSurchrge()
        {

            ArrayList ejList = PosContext.Instance.CurrentEj.EjArrayList;
            foreach (object obj in ejList)
            {
                if (obj is EjSurcharge)
                {
                    EjSurcharge ejSur = obj as EjSurcharge;
                    if (ejSur.Method == 0) ejSur.ReApplySurcharge();
                }



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

            string strAmount = string.Format("{0:############.00}", this.Amount);
            tmpStr.Insert(0,this.Desc );
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);

            //PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
        }
	
	}
}
