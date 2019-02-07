using System;
 
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for ItemDiscount.
	/// </summary>
	public class ItemDiscount: PosItemModifier
	{

		private double amount;
		private int quantity;
		private bool applied;
		private EjItem item;
		private Promotion promo;
		private string desc;
		private static int applyCount;
        private int lineNo;


		public ItemDiscount()
		{
			applied = false;
		}

		#region PosItemModifier Members

		public void Init(EjItem item, Promotion promotion)
		{
			this.item = item;
			this.promo = promotion;
			this.amount = 0;
			this.quantity = 0;
			this.desc = promo.PromotionString + " " + promo.PromotionDval1 + "%";
            this.lineNo = item.LineNo;
		}


		public void Apply()
		{
		//	applyCount += item.Quantity;
		//	if ( applyCount == promo.PromotionVal1 )
		//	{
				this.applied = true;
				double percent = promo.PromotionDval1/100;
              	this.amount = Math.Round(PosContext.Instance.PosMath.Mult(item.ExtAmount, percent), 2);
				this.amount = PosContext.Instance.PosMath.Negate(this.amount);
		//		applyCount =0;
				
		//	}
		}
 
		public double Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount= value;
			}
		}

		public int Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				quantity=value;
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
				applied=value;
			}
		}

		public string Desc
		{
			get
			{
				return  desc;
			}
			set
			{
				desc = value;
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
