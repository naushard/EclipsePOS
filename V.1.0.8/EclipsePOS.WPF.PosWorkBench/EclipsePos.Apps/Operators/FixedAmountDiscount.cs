using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.Operators
{
    public class FixedAmountDiscount : PosItemModifier
    {

        private double amount;
		private int quantity;
		private bool applied;
		private EjItem item;
		private Promotion promo;
		private string desc;
		//private static int applyCount;
        private int lineNo;


		public FixedAmountDiscount()
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
            this.lineNo = item.LineNo;
		}

		public double Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount = value;
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
				quantity = value;
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
				applied = value;
			}
		}

		public void Apply()
		{
				this.applied = true;
                //Fixed value discount. For exampel .20 cts discount 
				this.amount = PosContext.Instance.PosMath.Negate(promo.PromotionDval1);
				
			
		}

		public string Desc
		{
			get
			{
				return  promo.PromotionString + " " +String.Format("{0:0.00}",  promo.PromotionDval1) ;
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
