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
    public class PercentageDiscount : PosItemModifier	
    {

        private double amount;
        private int quantity;
        private bool applied;
        private EjItem item;
        private Promotion promo;
        private string desc;
        private static int applyCount;
        private int lineNo;


        /** How to initialize */
        public void Init(EjItem item, Promotion promotion)
        {
            this.item = item;
            this.promo = promotion;
            this.amount = 0;
            this.quantity = 0;
            this.desc = promo.PromotionString + " " + promo.PromotionDval1 + "%";
            this.lineNo = item.LineNo;
        }

		/** Modifier apply logic. */
        public void Apply()
        {
            this.applied = true;
            double percent = promo.PromotionDval1 / 100;
            this.amount = Math.Round(PosContext.Instance.PosMath.Mult(item.ExtAmount, percent), 2);
            this.amount = PosContext.Instance.PosMath.Negate(this.amount);
        }

			
		/** Amount of this modifier */
		public double Amount
		{
			set
            {
                amount = value;
            }
			get
            {
                return amount;
            }
		}
		
        /** Quantity of this modifier */
		public int Quantity
		{
            set
            {
                this.quantity = value;
            }
            get
            {
                return this.quantity;
            }
		}
		
        /** Applied flag, true if this modifier can be applied to this item */
		public bool Applied
		{
            set
            {
                this.applied = value;
            }
            get
            {
                return this.applied;
            }
		}
		
        /** Description of the modifier. */
		public string Desc
		{
            set
            {
                this.desc = value;
            }
            get
            {
                return this.desc;
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
