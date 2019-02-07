using System;

using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Compute discount for  n for the price of x, i.e. 3 for $5.
	/// (Mix and match pricing).
	/// </summary>
	public class NForX: PosItemModifier	
	{
		private double totalAmount;
		private double totalDiscount;
		private bool applied;
		private EjItem item;
		private Promotion promotion;
        private int promoQty=0;
		//private static int apply_count=0;
		private static int trxNo=0;
        private int lineNo;

		public NForX()
		{
			applied = false;
		}
		
		~NForX()
		{
		}

		#region PosItemModifier Members

		public void Init(EjItem item, Promotion promotion)
		{
			this.item = item;
			this.promotion = promotion;
			//this.amount = 0;
			//this.quantity = 0;
			if (trxNo != PosContext.Instance.TrxNo )
			{
				trxNo = PosContext.Instance.TrxNo;
				//apply_count = 0;
			}
            this.lineNo = item.LineNo;
		}


        public void Apply()
        {
            applied = false;
            int applyCount = 0;
            totalDiscount = 0;
            double itemAmount = item.Amount;
            if (itemAmount < 0.0)
                itemAmount *= -1.0;

            Ej ej = PosContext.Instance.CurrentEj;
            foreach (Object obj in ej.EjArrayList )
            {
                EjLine ejLine = (EjLine)obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;


                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        TransItem transItem = ejLine.DataRecord() as TransItem;
                        if (item.SKU.Equals(transItem.Sku))
                        {
                            applyCount = applyCount + (int)transItem.Quantity;
                        }
                        break;

                   
                    case (int)EjLineType.PROMOTION:
                        EjPromotion ejPromotion = ejLine as EjPromotion;
                        if (this.item.SKU.Equals (ejPromotion.SKU ) )
                        {
                            applyCount = applyCount - (int) ejPromotion.Quantity;
                        }
                        
                        break;

                   
                    default:
                        break;
                }

                
            }

            //Remaining Qty to apply the promotion
            if (applyCount >= promotion.PromotionVal1)
            {
                //Actual price
                double promoPrice = promotion.PromotionDval1 / promotion.PromotionVal1;
                // Discount for on
                double discount = item.Amount - promoPrice;
                //caluclate N 
                this.promoQty = applyCount -(int) applyCount % promotion.PromotionVal1;


                totalDiscount = PosContext.Instance.PosMath.Mult( this.promoQty, discount);
               // totalDiscount = PosContext.Instance.PosMath.Negate(totalDiscount);
                this.applied = true;

               
            }
			
            

        }

        /* old code 
		public void Apply()
		{
			
			
			applied = true;
  
			totalDiscount = 0.0;
			double itemAmount = item.Amount;

			// reverse the sign of the amount if it's less than zero, (discount sale)

			if (itemAmount < 0.0)
				itemAmount *= -1.0;

			totalAmount = PosContext.Instance.PosMath.Mult(itemAmount, (double)item.Quantity);
			int remainingItemCount = item.Quantity;
			
			double tmp = promotion.PromotionDval1 / (double) promotion.PromotionVal1;
			double up = PosContext.Instance.PosMath.RoundUp(tmp);
			double down = PosContext.Instance.PosMath.RoundDown(tmp);

			// First compute the total discount price if the number of items
			// is greater than or equal to the discount qunatity

			if (remainingItemCount >= promotion.PromotionVal1)
			{
				int mult = item.Quantity/promotion.PromotionVal1;
				totalDiscount = PosContext.Instance.PosMath.Mult(promotion.PromotionDval1, (double) mult);
				remainingItemCount = item.Quantity % promotion.PromotionVal1;
			}

			// now compute the total discount for remaining items or
			// initial items

			for (int i = 0;i < remainingItemCount; i++)
			{

				if (up > down)
				{

					if (apply_count <= (promotion.PromotionVal1 / 2) )
					{
						totalDiscount = PosContext.Instance.PosMath.Add(totalDiscount, down);
					}
					else
					{
						totalDiscount = PosContext.Instance.PosMath.Add(totalDiscount, up);
					}
				}
				else
					totalDiscount = PosContext.Instance.PosMath.Add (totalDiscount, up);

		
				if (++apply_count == promotion.PromotionVal1)
					apply_count = 0;
			}
         * 
         * 
        
		}
         * 
         */



		public double Amount
		{
			get
			{
                return PosContext.Instance.PosMath.Negate(totalDiscount);  
                    
                    //PosContext.Instance.PosMath.Negate( PosContext.Instance.PosMath.Sub(totalAmount, totalDiscount));;
			}
			set
			{
				//this.totalAmount = value;
			}
		}

		public int Quantity
		{
			get
			{
				return this.promoQty;
			}
			set
			{
				this.promoQty = value;
			}
		}

		public bool Applied
		{
			get
			{
				return applied;
			}
			set
			{
				applied= value; 
			}
		}

		public string Desc
		{
			get
			{
					return promotion.PromotionVal1 +
						" for " + string.Format(new PosTextFormatter(), "{0:Money}", string.Format("{0:#########.00}", promotion.PromotionDval1) );
				
			}
			set
			{
				// TODO:  Add NForX.Desc setter implementation
			}
		}

        public int LineNo
        {
            get
            {
                return lineNo;
            }
            set
            {
                lineNo = value;
            }
        }

		#endregion
	}
}
