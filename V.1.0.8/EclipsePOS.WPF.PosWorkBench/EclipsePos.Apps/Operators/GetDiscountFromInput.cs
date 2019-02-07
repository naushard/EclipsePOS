using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;

namespace EclipsePos.Apps.Operators
{
    public class GetDiscountFromInput : PosItemModifier
    {

        private double amount;
        private int quantity;
        private bool applied;
        private EjItem item;
        private Promotion promo;
        private string desc;
        private static int applyCount;
        private int lineNo;


        public GetDiscountFromInput()
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

            if (PosContext.Instance.InputDouble() == 0)
            {
                PosContext.Instance.ClearInput();
                PosEventStack.Instance.ClearPending();
                PosError error = new PosError(PosErrorCode.INVALID_INPUT);
                error.PromptText = PosContext.Instance.Parameters.getParam("InvalidInput");
                PosEventStack.Instance.PushEvent(error);
                PosContext.Instance.Operprompt.Update(error);
                PosContext.Instance.ClearInput();
                PosEventStack.Instance.NextEvent();
                return;

            }

            this.applied = true;
            //Fixed value discount. For exampel .20 cts discount 
            this.amount = PosContext.Instance.PosMath.Negate(PosContext.Instance.InputDouble());
            PosContext.Instance.ClearInput();		
        }

        public string Desc
        {
            get
            {
                return promo.PromotionString + " " + String.Format("{0:####.00}", this.amount.ToString());
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
