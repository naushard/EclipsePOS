using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.Operators
{
    public class RoundDownToFactorN : PosItemModifier
    {
        private double amount;
        private int quantity;
        private bool applied;
        private EjItem item;
        private Promotion promo;
        private string desc;
        private static int applyCount;
        private int lineNo;

        public void Init(EjItem item, Promotion promotion)
		{
			this.item = item;
			this.promo = promotion;
			this.amount = 0;
			this.quantity = 0;
			this.desc = promo.PromotionString;
            this.lineNo = item.LineNo;
		}


		public void Apply()
		{
            this.applied = false;
            this.amount = 0;
            try
            {
			   double roundingFactor = this.promo.PromotionDval1;
               double total = PosContext.Instance.CurrentEj.EjBalance();
               double wrk1 = ((int)(total / roundingFactor)) * roundingFactor;
               double adjAmt = total - wrk1;
               this.amount = PosContext.Instance.PosMath.Negate(adjAmt);
            }
            catch 
            {
            }

            if (this.amount != 0 )
            {
                this.applied = true;
            } 
            
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

		
    }
}
