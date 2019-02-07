using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


using System.Data;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class ChangeQuantity: PosDialogEvent
    {

        /** Prompt for line number. */
        public const int ENTER_LINE_NUMBER = 0;
        /** Get line number. */
        public const int GET_LINE_NUMBER = 1;
        /** Prompt for amount. */
        public const int ENTER_QUANTITY = 2;
        /** Get Amount */
        public const int GET_QUANTITY = 3;
        /** Complete the transaction. */
        public const int ITEM_FINAL = 4;

        private int lineNumber = 0;
        private double newQuantity = 0;
        private TransItem transItem = null;
        private Item item = null;
        private EjItem ejItem = null;

        

        public ChangeQuantity()
		{
            this.States().PushState(ENTER_LINE_NUMBER);
		}

		public override void  Engage(int keyValue)
		{
            switch (this.States().PeekState())
            {

                case ENTER_LINE_NUMBER:
                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptEnterLineNumber");
                    this.PopState();
                    this.PushState(GET_LINE_NUMBER);
                    PosContext.Instance.Operprompt.Update(this);
                    
                    break;

                case GET_LINE_NUMBER:

                    this.lineNumber = PosContext.Instance.Input();
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();

                    this.PopState();

                    if (this.lineNumber > 0 && this.lineNumber <= PosContext.Instance.CurrentEj.LineNo)
                    {

                        this.PushState(ENTER_QUANTITY);
                    }
                    else
                    {
                        this.PushState(ENTER_LINE_NUMBER);
                        PosContext.Beep(500, 50);
                    }
                    PosEventStack.Instance.NextEvent();
                    break;



                case ENTER_QUANTITY:

                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("EnterQuantity");
                    PosContext.Instance.Operprompt.Update(this);

                    //Wait for the Enter key after after input amount 
                    this.PopState();
                    this.States().PushState(GET_QUANTITY);
                    PosContext.Beep(500, 50);
                  
                    break;

                case GET_QUANTITY:

                    this.PopState();
                    this.newQuantity = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
                    PosContext.Instance.ClearInput();
                    this.States().PushState(ITEM_FINAL);
                    PosEventStack.Instance.NextEvent();
                    break;

                case ITEM_FINAL:


                    this.EffectChangeQuantity(this.lineNumber);

                    this.ReComputeWholeOrderDiscounts(this.ejItem);

                    this.ReComputeSurchrge();

                    this.States().Clear();
                    PosEventStack.Instance.NextEvent();

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

        public bool AmountIsValid()
        {
            return true;
        }


        public void EffectChangeQuantity(int lineNumber)
        {

            object[] ejList = PosContext.Instance.CurrentEj.EjArrayList.ToArray();
            foreach (object obj in ejList)
            {
                EjLine ejLine = obj as EjLine;
                if (ejLine.LineNo != lineNumber) continue;
                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        this.ejItem = ejLine as EjItem;

                        this.transItem = (TransItem)ejLine.DataRecord();

                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {
                       
                            transItem.Quantity = this.newQuantity;

                            transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Amount, this.newQuantity);
                            transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Ext_amount, PosContext.Instance.Sign);

                            transItem.UpdateAmounts();

                            PosContext.Instance.Operprompt.Update(this.ejItem);
                            PosContext.Instance.Receipt.Update(this);


                        }
                        break;

                    case (int)EjLineType.ITEM_LINK:
                        //	TransItemLink itemLink = (TransItemLink) line.dataRecord ();
                        //	itemLink.setAmount (0.0);
                        break;



                    case (int)EjLineType.TAX:
                        EjTax itemTax = (EjTax)ejLine as EjTax;
                        itemTax.ApplyTax();
                       

                        break;



                }


            }
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



        public void ReComputeWholeOrderDiscounts(EjItem ejitem)
        {

            if (PosContext.Instance.SaleMode != null)
            {

                ArrayList ejList = PosContext.Instance.CurrentEj.EjArrayList;
                foreach (object obj in ejList)
                {
                    if (obj is EjPromotion)
                    {
                        EjPromotion ejPromo = obj as EjPromotion;
                        if (ejPromo.LineNo == ejitem.LineNo)
                        {
                            if (ejPromo.Promotion.PromotionType == (int)EjPromotionTypes.WHOLE_ORDER)
                            {
                                ejPromo.ReCompute(ejitem);
                                return;
                            }
                        }
                    }



                }


            }
        }




        #region Properties
        public TransItem TransItem
        {
            set
            {
                transItem = value;
            }
            get
            {
                return transItem;
            }
        }

        public Item Item
        {
            set
            {
                item = value;
            }
            get
            {
                return item;
            }
        }

        

        public double Quantity
        {
            get
            {
                return (int)transItem.Quantity;
            }
            set
            {
            }
        }

        public double ExtAmount
        {
            get
            {
                return transItem.Ext_amount;
            }
            set
            {
            }
        }

        public  int LineNo
        {
            get
            {
                return transItem.Seq_no;
            }
            set
            {
            }
        }

        
        
        public double Amount
        {
            get
            {
                return transItem.Amount;
            }
            set
            {
            }
        }

        

       


        #endregion

       

    
    }
}
