using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
//using EclipsePos.Data;
//using EclipsePos.Apps.Operators;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class SelectTable : PosDialogEvent 
    {
        /* Prompt for table no select */
		public const int ENTER_TABLE_NO = 0;
		/* Get table no */
		public const int GET_TABLE_NO = 1;

        private string tableNo;

        private string promptText = null;
        private string messageText = null;
        private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;
        private string input;
		

        public SelectTable()
        {
            this.StartState = ENTER_TABLE_NO;
        }



        public override void Engage(int keyValue)
        {
            if (! String.IsNullOrEmpty( PosContext.Instance.TableName.Trim()))
            {
                this.States().Clear();
                PosEventStack.Instance.NextEvent();
                return;
            }

            switch (this.PeekState())
            {

                case ENTER_TABLE_NO:  // prompts for table no
                    input = PosContext.Instance.InputLine;
                    PosContext.Instance.ClearInput();
                    this.PromptText = PosContext.Instance.Parameters.getParam("TableNumberPrompt");
                    PosContext.Instance.Operprompt.Update(this);
                    this.States().PushState(GET_TABLE_NO);

                    PosContext.Instance.CurrentPosDisplay.LoadTableSelect();
                    break;

               
                case GET_TABLE_NO:  // get table no

                    this.States().Clear();
                    this.tableNo = PosContext.Instance.Input().ToString();

                    if (String.IsNullOrEmpty(this.tableNo.Trim() ))
                    {
                        this.States().PushState(ENTER_TABLE_NO);
                        break;
                    }
                    this.PromptText = this.tableNo;
                    PosContext.Instance.TableName = PosContext.Instance.InputLine;
                    PosContext.Instance.InputLine = input;

                    if ( ! LoadEj(PosContext.Instance.TableName)  )
                    {

                        try
                        {
                            if ( PosContext.Instance.CurrentEj.EjArrayList.Count == 0 )
                            {
                                new StartTransaction().Engage(0);

                            }
                        }
                        catch (Exception e)
                        {
                            new StartTransaction().Engage(0);
                        }

                        PosContext.Instance.Operprompt.Update(this);
                    }

                    PosContext.Instance.CurrentPosDisplay.UnloadTableSelect();
                    PosEventStack.Instance.NextEvent();
                    break;

                 default:
                    break;
            }
           
            return;

        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }


        private bool LoadEj(string tableName)
        {
            //PrintJobQueue.Instance.Clear();

            Transaction trans = new Transaction(0);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.State = (int)Transaction.Status.SUSPEND;
            trans.Table_name = tableName;

            trans.LoadByTableAndState();

            if (trans.Trans_no != 0)
            {  // was this a suspended transaction?

                PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);
                PosContext.Instance.TransactionType = trans.Trans_type;

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

                if (!String.IsNullOrEmpty(trans.Customer_tax_id))
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
