using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.Devices;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Data;
using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Views.LeftMenu;
using EclipsePos.Apps.Views.BottomMenu;
using EclipsePos.Apps.Views.Invoice;
using EclipsePos.Apps.Views.InvoiceTotals;
using EclipsePos.Apps.Views.InvoiceHeader;
using EclipsePos.Apps.Views.ItemSearch;
using EclipsePos.Apps.Views.KeyPad;
using EclipsePos.Apps.Views.ItemDetails;
using EclipsePos.Apps.Constants;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.PosEvents
{
    public class OpenOrdersList :PosDialogEvent	
    {
        /** Prompt for transaction number. */
        public const int ENTER_TRANS_NO = 0;
        /** Get transaction number. */
        public const int GET_TRANS_NO = 1;
        

        public override void Engage(int keyValue)
        {
           // PosContext.Instance.CurrentPosDisplay.LoadOpenOrdersList();

            //Merger to current order
            if (PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.SeqNo > 0)
            {
                PosError posError = new PosError(PosErrorCode.ERROR_EVENT);
                posError.Engage(0);
                return;
            }


            switch (this.States().PeekState())
            {

                case ENTER_TRANS_NO:

                    PosContext.Instance.CurrentPosDisplay.LoadOpenOrdersList();

                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptTransNo");
                    PosContext.Instance.Operprompt.Update(this);

                    this.PopState();
                    this.PushState(GET_TRANS_NO);
                   // PosEventStack.Instance.NextEvent();
                    break;

               
                case GET_TRANS_NO:


                    int trxno = PosContext.Instance.Input();
                    this.LoadEj(trxno);
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    

                    this.States().Clear();
                    PosEventStack.Instance.ClearPending();
                    PosContext.Instance.HomeGUI();
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

        private bool LoadEj(int transNo)
        {
            //PrintJobQueue.Instance.Clear();

            Transaction trans = new Transaction(transNo);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.Pos_no = PosSettings.Default.Station;
            //   trans.State = (int)Transaction.Status.SUSPEND;

            trans.Load();

            if (trans.Trans_no != 0)
            {  // was this a suspended transaction?

                PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);
                PosContext.Instance.TransactionType = trans.Trans_type;
                PosContext.Instance.TableName = trans.Table_name;

                if (PosContext.Instance.CurrentEj.EjArrayList.Count > 0)
                {  // finally make sure there are records

                    PosContext.Instance.TableName = trans.Table_name;
                    PosContext.Instance.TrxNo = trans.Trans_no;
                    trans.State = (int)Transaction.Status.IN_PROGRESS;

                    foreach (Object obj in PosContext.Instance.CurrentEj.EjArrayList)
                    {
                        EjLine line = (EjLine)obj;
                        if (line is EjPromotion)
                        {
                            EjPromotion ejPromo = line as EjPromotion;
                            if (ejPromo.LineType == (int)EjPromotionTypes.WHOLE_ORDER)
                            {
                                PosContext.Instance.SaleMode = ejPromo.Promotion;
                            }
                        }
                        PosContext.Instance.Receipt.Update(line);
                    }
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

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
