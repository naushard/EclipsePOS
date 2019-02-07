using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class DiscountInput : PosDialogEvent
    {

        public const int ENTER_AMOUNT = 0;
        public const int GET_AMOUNT = 2;
        public const int APPLY_DISCOUNT = 3;

        private double discountAmt;


        public DiscountInput()
		{
            this.States().PushState(ENTER_AMOUNT);
		}

		public override void  Engage(int keyValue)
		{

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Discount"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }


            if (PosContext.Instance.CurrentEj.SeqNo == 0)
            {
                PosError posError = new PosError(PosErrorCode.ITEM_DISCOUNT_NOT_APPLICABLE);
                posError.Engage(0);
                return;
            }


			switch (this.States().PeekState())
			{

			
				case ENTER_AMOUNT:

					PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("EnterDiscountAmount");
					PosContext.Instance.Operprompt.Update(this);
					this.PopState();
					this.PushState(GET_AMOUNT);

					break;

		
				case GET_AMOUNT:

					this.discountAmt = PosContext.Instance.Input();
				//	PosContext.Instance.ClearInput();
				//	PosContext.Instance.Operprompt.Clear();
					this.PopState();
                    this.States().PushState(APPLY_DISCOUNT);
					PosEventStack.Instance.NextEvent();

					break;

				case APPLY_DISCOUNT:

                    Promotion promo = new Promotion();
                    // int keyValue = (int) PosContext.Instance.PosKeyValue;
                    promo.PromotionNo = 0;
                    promo.Organization_no = PosSettings.Default.Organization;
                    promo.PromotionType = 1;
                    promo.PromotionVal1 = 1;
                    promo.PromotionString = "Discount";
                    promo.PromotionClass = "EclipsePos.Apps.Operators.GetDiscountFromInput";
                    EjPromotion ejPromo = new EjPromotion(promo, PosContext.Instance.CurrentEjItem);
                    ejPromo.Engage(0);

                    this.States().Clear();
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    					
					break;
			}
		}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

        public int State
        {
            get
            {
                return this.States().PeekState();
            }
        }
		

		

		


    }
}
