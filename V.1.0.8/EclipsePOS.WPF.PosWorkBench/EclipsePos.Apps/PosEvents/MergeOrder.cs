using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;



namespace EclipsePos.Apps.PosEvents
{
    public class MergeOrder :PosDialogEvent
    {
        /** Start merge event */
		public const int MERGE = 0;
		/** Prompt for transaction number. */
		public const int ENTER_TRANS_NO = 1;
		/** Get transaction number. */
		public const int GET_TRANS_NO = 2;
		/** Complete merge */
		public const int COMPLETE_MERGE = 3;

		private int trxno;
		private Transaction trans;
		private int posno;
		private string promptText=null;
		//private string messageText=null;
		//private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;

        public MergeOrder()
        {
            promptText = PosContext.Instance.Parameters.getParam("RegOpen");
        }

        public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}
		
        public override void  Engage(int keyValue)
		{

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("MergeOrder"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }


            //Merger to current order
            if (PosContext.Instance.CurrentEj == null || PosContext.Instance.CurrentEj.SeqNo == 0)
            {
                PosError posError = new PosError(PosErrorCode.ERROR_EVENT);
                posError.Engage(0);
                return;
            }


            switch (this.States().PeekState())
            {

                case MERGE:
                    
                    PosContext.Instance.CurrentPosDisplay.LoadOpenOrdersList();
                    
                    this.PopState();
                    this.PushState(ENTER_TRANS_NO);
                    PosEventStack.Instance.NextEvent();
                    break;

                case ENTER_TRANS_NO:

                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptTransNo");
                    PosContext.Instance.Operprompt.Update(this);
                    
                    this.PopState();
                    this.PushState(GET_TRANS_NO);

                    break;

                
                case GET_TRANS_NO:

                    this.trxno = PosContext.Instance.Input();
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    
                    this.PopState();
                    this.PushState(COMPLETE_MERGE);
                    PosEventStack.Instance.NextEvent();

                    break;

                
                case COMPLETE_MERGE:

                    PosContext.Instance.ClearInput();
                    trans = new Transaction(this.trxno);
                    trans.Pos_no = PosSettings.Default.Station;
                    trans.Organization_no = PosSettings.Default.Organization;
                    trans.Store_no = PosSettings.Default.Store;
                    trans.Load();

                    if (trans.State == (int)Transaction.Status.SUSPEND)
                    {  // was this a suspended transaction?

                        Ej ejFrom = Ej.GetSuspendedEj(trans);

                        if (ejFrom.EjArrayList.Count > 0)
                        {  // finally make sure there are records

                           // trans.State = (int)Transaction.Status.IN_PROGRESS;
                            foreach (Object obj in ejFrom.EjArrayList)
                            {
                                EjLine line = (EjLine)obj;
                                ProcessEjLine(line);
                            }

                            //	context ().homeGuis ();
                            //	context ().eventStack ().setEvent (new FirstItem (context ()));
                            this.States().Clear();
                            //	PosEventStack.Instance.NextEvent();
                        }

                       // ejFrom.Complete((int)Transaction.Status.VOIDED);
                        this.VoidEj(ejFrom);
                    }
                    
                    if (trans.Customer_tax_id.Length > 0)
                    {
                        EclipsePos.Data.Customer cus = new EclipsePos.Data.Customer();
                        cus.Organization_no = PosSettings.Default.Organization;
                        cus.Tax_id = trans.Customer_tax_id;
                        cus.LoadByTaxID();
                        EjCustomer ejCus = new EjCustomer(cus);
                        PosContext.Instance.Receipt.Update(ejCus);
                        PosContext.Instance.EjCustomer = ejCus;

                    }
                    
                    this.States().Clear();
                   // PosEventStack.Instance.ClearPending();
                    PosContext.Instance.HomeGUI();
                    PosEventStack.Instance.NextEvent();


                    break;
            }


        }


        private void ProcessEjLine(EjLine ejLine)
        {

            
            switch (ejLine.LineType)
            {

                case (int)EjLineType.TRANS_HEADER:
                    
                    break;

                case (int)EjLineType.ITEM:
                   
                    EjItem ejItemFrom = ejLine as EjItem;
                    
                    TransItem transItem = new TransItem();
                    
                    transItem.Trans_no = PosContext.Instance.TrxNo;
                    transItem.Organization_no = PosSettings.Default.Organization;
                    transItem.Store_no = PosSettings.Default.Store;
                    transItem.Pos_no = PosSettings.Default.Station;
                    transItem.Sku_link = " ";
                    transItem.Sku = ejItemFrom.TransItem.Sku;
                    transItem.Item_desc = ejItemFrom.TransItem.Item_desc;
                    transItem.Quantity = ejItemFrom.TransItem.Quantity;
                    transItem.Amount = ejItemFrom.TransItem.Amount;
                    transItem.Ext_amount = ejItemFrom.TransItem.Ext_amount;
                    transItem.Tax_exempt = ejItemFrom.TransItem.Tax_exempt;
                    transItem.Tax_incl = ejItemFrom.TransItem.Tax_incl;
                    transItem.State = (int)EjLineStates.IN_PROGRESS;
                    transItem.Reason_code = (int)EjItemReasonCodes.NORMAL_ITEM;
                    EjItem ejItem = new EjItem(transItem);

                    PosContext.Instance.CurrentEjItem = ejItem;

                    PosContext.Instance.CurrentEj.EjAdd(ejItem);
                    transItem.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    transItem.Line_no = PosContext.Instance.CurrentEj.LineNo;

                    // if not traning mode
                    if (!PosContext.Instance.Training)
                    {
                        transItem.Add();
                    }

                    PosContext.Instance.Receipt.Update(ejItem);
                    break;

                case (int)EjLineType.PROMOTION:

                    EjPromotion fromPromotion = ejLine as EjPromotion;

                    TransPromotion transPromotion  = new  TransPromotion();

                    transPromotion.Trans_no = PosContext.Instance.TrxNo;
                    transPromotion.Organization_no = PosSettings.Default.Organization;
                    transPromotion.Store_no = PosSettings.Default.Store;
                    transPromotion.Pos_no = PosSettings.Default.Station;
                    transPromotion.PromotionNo = fromPromotion.Promotion.PromotionNo;

                    transPromotion.PromotionAmount = fromPromotion.Amount;
                    transPromotion.PromotionQuantity = fromPromotion.Quantity; //PosContext.Instance.Quantity;
                    transPromotion.ReasonCode = 0;
                    transPromotion.PromotionData = " ";
                    transPromotion.PromotionDesc = fromPromotion.Desc;
                    transPromotion.State = (int)EjLineStates.IN_PROGRESS;

                    EjPromotion ejPromotion = new EjPromotion(transPromotion);

                    PosContext.Instance.CurrentEj.EjAdd(ejPromotion);
                    transPromotion.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    transPromotion.Line_no = PosContext.Instance.CurrentEj.LineNo;

                    // if not training mode
                    if (!PosContext.Instance.Training)
                    {
                        transPromotion.Add();
                    }
                    PosContext.Instance.Receipt.Update(ejPromotion);
                    
                    break;

                case (int)EjLineType.TAX:

                    EjTax fromTax= ejLine as EjTax;
                    TransTax fromTransTax = (TransTax)fromTax.DataRecord();

                    TransTax  transTax   = new TransTax();
                    transTax.Trans_no = PosContext.Instance.TrxNo;
                    transTax.Organization_no = PosSettings.Default.Organization;
                    transTax.Store_no = PosSettings.Default.Store;
                    transTax.Pos_no = PosSettings.Default.Station;
                    transTax.SeqNo = PosContext.Instance.CurrentEj.SeqNo;
                    transTax.Line_no = PosContext.Instance.CurrentEj.LineNo;
                    transTax.TaxId = fromTransTax.TaxId;
                    transTax.TaxDesc = fromTransTax.TaxDesc;
                    transTax.Rate = fromTransTax.Rate;
                    transTax.State = (int)EjLineStates.IN_PROGRESS;
                    transTax.TaxAmount = fromTransTax.TaxAmount;
                    transTax.TaxableAmount = fromTransTax.TaxableAmount;

                    //If not training mode
                    if (!PosContext.Instance.Training)
                    {
                        transTax.Add();
                    }

                    EjTax ejTax = new EjTax(transTax);
                    PosContext.Instance.CurrentEj.EjAdd(ejTax);
                  


                    break;

                case (int)EjLineType.TENDER:
                   
                    break;

                case (int)EjLineType.BANK:
                    //		Update( (EjBank)pEvent );
                    break;

                case (int)EjLineType.ACCOUNT:
                    break;

                case (int)EjLineType.ALT_CURRENCY_TENDER:
                   
                    break;

                case (int)EjLineType.CHECK_TENDER:
                   
                    break;

                case (int)EjLineType.DEBIT_TENDER:
                    
                    break;

                case (int)EjLineType.CC_TENDER:
                   
                    break;

                case (int)EjLineType.COUPON:
                    //		Update ((EjCoupon) pEvent );
                    break;

                case (int)EjLineType.FREE_TEXT:
                    
                    break;

                case (int)EjLineType.SURCHARGE:
                   
                    break;

                default:
                    //	Log.warning ("Unhandled ej type in Receipt " + line.toString ());
                    break;
            }
        }


        private void VoidEj(Ej ej)
        {
            if (PosContext.Instance.Training)
            {
                return;
            }

            foreach (Object obj in ej.EjArrayList)
            {
                EjLine ejLine = (EjLine)obj;
                int voidState = (int)Transaction.Status.VOIDED;
               // if (ejLine.State != (int)EjLineStates..IN_PROGRESS) continue;


                switch (ejLine.LineType)
                {

                    case (int)EjLineType.TRANS_HEADER:
                        EjHeader ejHeader = (EjHeader)ejLine;
                        if (!ejHeader.UpdateState(voidState))
                        {
                            MessageBox.Show("Error :- Unable to complete UpdateState-Ej");
                        }
                        break;
                    case (int)EjLineType.ITEM:
                    case (int)EjLineType.PROMOTION:
                    case (int)EjLineType.BANK:
                    case (int)EjLineType.TENDER:
                    case (int)EjLineType.CHECK_TENDER:
                    case (int)EjLineType.CC_TENDER:
                    case (int)EjLineType.GIFT_CERT_TENDER:
                    case (int)EjLineType.DEBIT_TENDER:
                    case (int)EjLineType.ALT_CURRENCY_TENDER:
                    case (int)EjLineType.COUPON:
                    case (int)EjLineType.ACCOUNT:
                    case (int)EjLineType.TAX:
                    case (int)EjLineType.SURCHARGE:

                       // ejLine..UpdateTotals();
                        break;

                    case (int)EjLineType.TOTAL:
                        break;
                    default:
                        break;
                }
                

            }

            

        }

    }
}
