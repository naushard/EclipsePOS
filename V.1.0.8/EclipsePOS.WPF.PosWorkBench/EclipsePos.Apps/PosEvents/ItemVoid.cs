using System;
using System.Collections;

//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Data;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ItemVoid.
	/// </summary>
	public class ItemVoid:PosDialogEvent	
	{

        /** Start item void */
        public const int VOID_ITEM = 0;
        /** Prompt for line number. */
        public const int ENTER_LINE_NUMBER = 1;
        /** Get line number. */
        public const int GET_LINE_NUMBER = 2;
     
        public const int COMPLETE_ITEM_VOID = 3;

        private int lineNumber = 0;

		public ItemVoid()
		{
			//
			// TODO: Add constructor logic here
			//
           this.PromptText  = PosContext.Instance.Parameters.getParam("RegOpen");
           this.PushState(VOID_ITEM);
		}

	/**
	 * Void the last item in the ej. Logic also
	 * sets any related ej record amounts to 0, 
	 * but doesn't remove them.
	 */
		public override void  Engage(int keyValue)
		{

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("VoidItemLine"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            // if in a middle of a dialog just return
         //   if (!(PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen))
         //   {

          //      PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
          //      PosEventStack.Instance.NextEvent();
          //      return;
          //  }


            // If tried to void without any sales, just return
         //   if (PosContext.Instance.CurrentEj == null) return;
            
           

            switch (this.States().PeekState())
            {
                
                case VOID_ITEM:
                    this.PopState();
                    this.PushState(ENTER_LINE_NUMBER);
                    PosEventStack.Instance.NextEvent();
                    break;

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

                        this.PushState(COMPLETE_ITEM_VOID);
                    }
                    else
                    {
                        this.PushState(ENTER_LINE_NUMBER);
                        PosContext.Beep(500, 50);
                    }
                    PosEventStack.Instance.NextEvent();
                    break;

               
                case COMPLETE_ITEM_VOID:
                   // this.ProcessItemVoid(this.lineNumber);
                    this.VoidLine(this.lineNumber);
                    this.States().Clear();
                    PosContext.Instance.HomeGUI();
                    PosEventStack.Instance.NextEvent();

                    break;
            }

            
             
		}


        private void VoidLine(int lineNumber)
        {
            ArrayList ejList = PosContext.Instance.CurrentEj.EjArrayList;
            foreach (object obj in ejList)
            {
                EjLine ejLine = obj as EjLine;
                if (ejLine.LineNo != lineNumber) continue;
                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        TransItem transItem = (TransItem)ejLine.DataRecord();

                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            transItem.State = (int)EjLineStates.VOID_ITEM;
                            transItem.UpdateState();
                            PosContext.Instance.Receipt.Update((EjItem)ejLine);
                        }
                        break;

                    case (int)EjLineType.ITEM_LINK:
                        //	TransItemLink itemLink = (TransItemLink) line.dataRecord ();
                        //	itemLink.setAmount (0.0);
                        break;

                    case (int)EjLineType.PROMOTION:
                        TransPromotion itemPromo = (TransPromotion)ejLine.DataRecord();
                        if (itemPromo.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            itemPromo.State = (int)EjLineStates.VOID_ITEM;
                            itemPromo.UpdateState();

                            if (itemPromo.PromotionType == (int)EjPromotionTypes.WHOLE_ORDER)
                            {
                                PosContext.Instance.SaleMode = null;
                            }
                            PosContext.Instance.Receipt.Update((EjPromotion)ejLine);
                        }
                        //  itemPromo.PromotionAmount = 0;
                        break;

                    case (int)EjLineType.TAX:
                        TransTax itemTax = ejLine.DataRecord() as TransTax;

                        itemTax.State = (int)EjLineStates.VOID_ITEM;
                        itemTax.UpdateState();
                        ///	itemTax.TaxAmount = 0.0;
                        //  itemTax.TaxableAmount = 0.0;
                        // ejLine.ExtAmount = 0;
                        // ejLine.TaxAmount = 0;
                        // ejLine.Amount = 0;
                        PosContext.Instance.Receipt.Update((EjTax)ejLine);
                        break;

                    case (int)EjLineType.SURCHARGE:
                        TransItem transSurcharge = (TransItem)ejLine.DataRecord();

                        if (transSurcharge.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            transSurcharge.State = (int)EjLineStates.VOID_ITEM;
                            transSurcharge.UpdateState();
                            PosContext.Instance.Receipt.Update((EjSurcharge)ejLine);
                        }

                        break;

                }


            }
        }

        private void VoidCurrentItem()
        {
            ItemList itemList = new ItemList(PosContext.Instance.CurrentEjItem, PosContext.Instance.CurrentEj);
            for (int i = 0; i < itemList.Count; i++)
            {
                Object obj = itemList[i];
                EjLine ejLine = (EjLine)obj;

                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        TransItem transItem = (TransItem)ejLine.DataRecord();

                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            transItem.State = (int)EjLineStates.VOID_ITEM;
                            transItem.UpdateState();
                            PosContext.Instance.Receipt.Update((EjItem)ejLine);
                        }
                        break;
                    case (int)EjLineType.ITEM_LINK:
                        //	TransItemLink itemLink = (TransItemLink) line.dataRecord ();
                        //	itemLink.setAmount (0.0);
                        break;

                    case (int)EjLineType.PROMOTION:
                        TransPromotion itemPromo = (TransPromotion)ejLine.DataRecord();
                        if (itemPromo.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            itemPromo.State = (int)EjLineStates.VOID_ITEM;
                            itemPromo.UpdateState();
                            PosContext.Instance.Receipt.Update((EjPromotion)ejLine);
                        }
                        //  itemPromo.PromotionAmount = 0;
                        break;

                    case (int)EjLineType.TAX:
                        TransTax itemTax = ejLine.DataRecord() as TransTax;

                        itemTax.State = (int)EjLineStates.VOID_ITEM;
                        itemTax.UpdateState();
                        ///	itemTax.TaxAmount = 0.0;
                        //  itemTax.TaxableAmount = 0.0;
                        // ejLine.ExtAmount = 0;
                        // ejLine.TaxAmount = 0;
                        // ejLine.Amount = 0;
                        PosContext.Instance.Receipt.Update((EjTax)ejLine);
                        break;
                   
                    case (int)EjLineType.SURCHARGE:
                        TransItem transSurcharge = (TransItem)ejLine.DataRecord();

                        if (transSurcharge.State != (int)EjLineStates.VOID_ITEM)
                        {  // already voided?

                            transSurcharge.State = (int)EjLineStates.VOID_ITEM;
                            transSurcharge.UpdateState();
                            PosContext.Instance.Receipt.Update((EjSurcharge)ejLine);
                        }
                       
                        break;

                }

            }
        }




		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}
	}
}
