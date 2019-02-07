using System;
//using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Microsoft.PointOfService;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjItem.
	/// </summary>
    public class EjItem : EjLine
    {
        private TransItem transItem = null;
        private Item item = null;
        private double qty;
        private double amount = 0;

        /** Prompt for Quantity */
        public const int ENTER_QTY = 1;
        /** Get Quantity */
        public const int GET_QTY = 2;
        /** Prompt for amount. */
        public const int ENTER_AMOUNT = 3;
        /** Get Amount */
        public const int GET_AMOUNT = 4;
        /** Complete the transaction. */
        public const int ITEM_FINAL = 5;

        public const int QTY_ERROR = 6;

        public const int AMOUNT_ERROR = 7;

        public const int ITEM_CLEAR = 8;

        public const int LOAD_FROM_EJ = 91;


        // private int state=0;

        private int text_line_no = 0;

        private List<EjTax> appliedTaxes = new List<EjTax>();


        public EjItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public EjItem(Item item)
        {
            this.LineType = (int)EjLineType.ITEM;
            this.item = item;
            //this.State = (int)EjItemStates.ENTER_AMOUNT;
            //qty= 0;
        }



        public EjItem(TransItem transItem)
        {
            this.transItem = transItem;
            this.LineType = (int)EjLineType.ITEM;
            Item item1 = new Item();
            item1.Sku = transItem.Sku;
            item1.Organization_no = PosSettings.Default.Organization;
            item1.LoadBySKU();
            this.Item = item1;
            //this.transItem.State = 1;
            this.qty = transItem.Quantity;
            this.States().PushState(LOAD_FROM_EJ);

        }

        public override void UpdateTotals()
        {
            if (transItem.State == (int)EjLineStates.IN_PROGRESS)
            {
                this.transItem.State = (int)EjLineStates.PAID;
                this.transItem.UpdateState();
            }
        }



        /** Return the associated transaction record, (database entity). */
        public override IRelatable DataRecord()
        {
            return transItem;
        }

        /** Database save function. */
        public override bool Save()
        {
            if (!PosContext.Instance.Training)
            {
                try
                {

                    transItem.Add();
                }
                catch (Exception e)
                {
                    Logger.Error("EjItem.cs", e.ToString());
                }
            }
            return true;
        }

        public override void SaveState(EjLineStates state)
        {
            transItem.State = (int)state;
            transItem.UpdateState();
        }



        public override void Engage(int keyValue)
        {
            // Created trans Header just before the first item
            if (PosContext.Instance.CurrentEj == null || PosContext.Instance.CurrentEj.SeqNo == 0)
            {
                new StartTransaction().Engage(0);
                return;
            }


            if (this.item == null) return;

            if (this.transItem == null)
            {
                this.transItem = new TransItem();
                transItem.Trans_no = PosContext.Instance.TrxNo;
                transItem.Organization_no = PosSettings.Default.Organization;
                transItem.Store_no = PosSettings.Default.Store;
                transItem.Pos_no = PosSettings.Default.Station;
                transItem.Sku_link = " ";
                transItem.Sku = item.Sku;
                transItem.Item_desc = item.Short_Desc;
            }
            transItem.Quantity = this.qty; //PosContext.Instance.Quantity == 0 ? 1 : PosContext.Instance.Quantity;
            transItem.Amount = amount; //item.Amount;
            transItem.Ext_amount = (float)Math.Round(amount * this.qty, 2);
            transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Ext_amount, PosContext.Instance.Sign);
            transItem.Tax_exempt = item.Tax_Exempt;
            transItem.Tax_incl = item.Tax_Inclusive;
            transItem.State = (int)EjLineStates.IN_PROGRESS;
            transItem.Reason_code = (int)EjItemReasonCodes.NORMAL_ITEM;
            transItem.Seq_no = PosContext.Instance.CurrentEj.SeqNo + 1;
            transItem.Line_no = PosContext.Instance.CurrentEj.LineNo + 1;

            PosContext.Instance.Receipt.Update(this);



            // double amount = item.Amount;

            // PosContext.Instance.CurrentEjItem = this;



            switch (this.PeekState())
            {

                case ENTER_QTY:
                case QTY_ERROR:

                    if (this.item.Def_quantity == 0)
                    {
                        PosContext.Instance.ClearInput();
                        this.PromptText = PosContext.Instance.Parameters.getParam("EnterQuantity");
                        PosContext.Instance.Operprompt.Update(this);
                        //Wait for the Enter key after input amount 
                        this.PopState();
                        this.States().PushState(GET_QTY);
                        PosContext.Instance.DisableKeys();
                        PosContext.Beep(500, 50);
                        return;

                    }
                    else
                    {
                        // Complet ej
                        this.PopState();
                        this.qty = item.Def_quantity;
                        this.States().PushState(ENTER_AMOUNT);
                        PosEventStack.Instance.NextEvent();

                    }

                    break;

                case GET_QTY:

                    this.PopState();
                    this.qty = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
                    PosContext.Instance.ClearInput();

                    if (this.qty == 0)
                    {
                        this.States().PushState(QTY_ERROR);
                        PosContext.Beep(500, 50);

                    }
                    else
                    {
                        this.PromptText = PosContext.Instance.Parameters.getParam("RegOpen");
                        PosContext.Instance.Operprompt.Update(this);
                        this.States().PushState(ENTER_AMOUNT);
                    }
                    PosEventStack.Instance.NextEvent();
                    break;


                case ENTER_AMOUNT:
                case AMOUNT_ERROR:

                    if (this.item.Pricing_Opt == (int)EclipsePos.Data.PricingOptions.Counter_pricing)
                    {
                        PosContext.Instance.ClearInput();
                        this.PromptText = PosContext.Instance.Parameters.getParam("PromptItemPrice");
                        PosContext.Instance.Operprompt.Update(this);

                        //Wait for the Enter key after after input amount 
                        this.PopState();
                        this.States().PushState(GET_AMOUNT);
                        PosContext.Beep(500, 50);
                        return;

                    }
                    else
                    {
                        // Complet ej
                        this.PopState();
                        amount = item.Amount;
                        this.States().PushState(ITEM_FINAL);
                        PosEventStack.Instance.NextEvent();

                    }

                    break;

                case GET_AMOUNT:

                    this.PopState();
                    amount = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
                    PosContext.Instance.ClearInput();

                    if (amount == 0)
                    {
                        this.States().PushState(AMOUNT_ERROR);
                        PosContext.Beep(500, 50);
                    }
                    else
                    {
                        this.PromptText = PosContext.Instance.Parameters.getParam("RegOpen");
                        PosContext.Instance.Operprompt.Update(this);
                        this.States().PushState(ITEM_FINAL);
                    }
                    PosEventStack.Instance.NextEvent();
                    break;
                
                case ITEM_CLEAR:
                    PosContext.Instance.Receipt.Update(this);
                    PosContext.Instance.CurrentEjItem = null;
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.Quantity = 0;
                    this.States().Clear();
                    PosEventStack.Instance.ClearPending();
                    PosContext.Instance.EnableKeys();
                    PosEventStack.Instance.NextEvent();

                    break;

                case ITEM_FINAL:


                    if (this.transItem == null)
                    {
                        this.transItem = new TransItem();
                    }

                    /*
                    transItem.Trans_no = PosContext.Instance.TrxNo;
                    transItem.Organization_no = PosSettings.Default.Organization;
                    transItem.Store_no = PosSettings.Default.Store;
                    transItem.Pos_no = PosSettings.Default.Station;
                    transItem.Sku_link = " ";
                    transItem.Sku = item.Sku;
                    transItem.Item_desc = item.Short_Desc;
                    transItem.Quantity = this.qty; //PosContext.Instance.Quantity == 0 ? 1 : PosContext.Instance.Quantity;
                    transItem.Amount = amount; //item.Amount;
                    transItem.Ext_amount = (float)Math.Round(amount * this.qty, 2);
                    transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Ext_amount, PosContext.Instance.Sign);
                    transItem.Tax_exempt = item.Tax_Exempt;
                    transItem.Tax_incl = item.Tax_Inclusive;
                    transItem.State = (int)EjLineStates.IN_PROGRESS;
                    transItem.Reason_code = (int)EjItemReasonCodes.NORMAL_ITEM;
                     * */

                    PosContext.Instance.CurrentEjItem = this;

                    PosContext.Instance.CurrentEj.EjAdd(this);
                    transItem.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    transItem.Line_no = PosContext.Instance.CurrentEj.LineNo;

                    // if not traning mode
                    if (!PosContext.Instance.Training)
                    {
                        transItem.Add();

                    }

                    if (!(item.Tax_Exempt == 1))
                    {
                        try
                        {
                            string taxGroupId = item.Tax_group_id;
                            TaxGroup taxGroup = (TaxGroup)PosContext.Instance.Config.TaxGroups[taxGroupId];
                            ArrayList taxes = taxGroup.Taxes;
                            foreach (Object obj in taxes)
                            {
                                Tax tax = (Tax)obj;
                                EjTax ejTax = new EjTax(tax, this);
                                ejTax.Engage(0);
                                appliedTaxes.Add(ejTax);
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Error("EjItem.cs", e.ToString());
                        }
                    }



                    //	Print the item at this point, discounts are printed in any modifiers
                    PosContext.Instance.Receipt.Update(this);

                    // add any modifiers that we find.

                    if (PosContext.Instance.SaleMode != null)
                    {
                        EjPromotion ejPromo1 = new EjPromotion(PosContext.Instance.SaleMode, this);
                        ejPromo1.SKU = item.Sku;
                        ejPromo1.Engage(0);
                    }


                    if (this.Item.Promotions() != null)
                    {  // now apply promos attached to the item
                        foreach (object obj in this.Item.Promotions())
                        {
                            Promotion promo2 = obj as Promotion;

                            // the modifier is applied in the EjPromotion constructor
                            EjPromotion ejPromo2 = new EjPromotion(promo2, this);
                            ejPromo2.SKU = item.Sku;
                            ejPromo2.Engage(0);
                        }
                    }

                    //Re - Compute whole order discount
                    this.ReComputeWholeOrderDiscounts();

                    // Re - Compute surcharge if necessary
                    this.ReComputeSurchrge();

                    // Display item details in Customer display after any discount 		
                    PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.Quantity = 0;


                    this.States().Clear();
                    PosEventStack.Instance.ClearPending();
                    PosContext.Instance.EnableKeys();
                    PosEventStack.Instance.NextEvent();


                    break;


            }

        }

        public void UpdateStock()
        {
            if (transItem.Reason_code == (int)EjItemReasonCodes.NORMAL_ITEM)
            {
                //Update stock
                TransStock transStock = new TransStock();
                transStock.Organization_no = PosSettings.Default.Organization;
                transStock.Store_no = PosSettings.Default.Store;
                transStock.Sku = transItem.Sku;
                transStock.Transaction_type = (int)TransStockTypes.SALE_OUT;
                transStock.Reference_number = TransItem.Trans_no.ToString().PadLeft(10, '0') + "/" + TransItem.Line_no.ToString().PadLeft(3, '0');
                transStock.Quantity = PosContext.Instance.PosMath.Negate(transItem.Quantity);
                transStock.Transaction_time = DateTime.Now;
                transStock.Add();

                StockBalance stockBalance = new StockBalance();
                stockBalance.Organization_no = PosSettings.Default.Organization;
                stockBalance.Store_no = PosSettings.Default.Store;
                stockBalance.Sku = transItem.Sku;
                stockBalance.Quantity_on_hand = PosContext.Instance.PosMath.Negate(transItem.Quantity);
                stockBalance.AddBalance();

            }

        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {

            return true;
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

        public void ReComputeWholeOrderDiscounts()
        {
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

        public override string Desc
        {
            get
            {
                return transItem.Item_desc;
            }
            set
            {
                transItem.Item_desc = value;
            }

        }

        public override double Quantity
        {
            get
            {
                return this.qty; //transItem.Quantity;
            }
            set
            {
            }
        }

        public override double ExtAmount
        {
            get
            {
                return transItem.Ext_amount;
            }
            set
            {
            }
        }

        public override int LineNo
        {
            get
            {
                //return transItem.Seq_no;
                return transItem.Line_no;
            }
            set
            {
                transItem.Line_no = value;
            }
        }

        public override double TaxAmount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double Change
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double Amount
        {
            get
            {
                return transItem.Amount;
            }
            set
            {
            }
        }

        public override string SKU
        {
            get
            {
                return this.item.Sku;
            }
            set
            {
            }
        }

        public int TaxInclusive
        {
            get
            {
                return transItem.Tax_incl;
            }
            set
            {
                transItem.Tax_incl = value;
            }
        }

        public int TaxExempt
        {
            get
            {
                return transItem.Tax_exempt;
            }
            set
            {
                transItem.Tax_exempt = value;
            }
        }


        public override bool TenderComplete
        {
            get
            {
                return true;
            }

        }

        public override int State
        {
            set
            {

                this.transItem.State = value;
            }
            get
            {
                return this.transItem.State;
            }
        }

        public override int SeqNo
        {
            set
            {
                this.transItem.Seq_no = value;
            }
            get
            {
                return this.transItem.Seq_no;
            }
        }

        public int Text_line_no
        {
            set
            {
                this.text_line_no = value;

            }
            get
            {
                return this.text_line_no;
            }

        }

        public List<EjTax> Taxes
        {
            set
            {
                this.appliedTaxes = value;
            }
            get
            {
                return this.appliedTaxes;
            }
        }

        public int DialogStep
        {
            get
            {
                return this.PeekState();
            }
        }


        #endregion

        public override void PrintEj()
        {
            
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }


            string str1 = transItem.Item_desc;
            if (PosContext.Instance.Training)
                str1 = "<T>" + str1;


            string strQty = string.Format("{0:#####.00}", transItem.Quantity);
            string strPrice = string.Format("{0:#######.00}", transItem.Amount);
            string strAmount = string.Format("{0:########.00}", transItem.Ext_amount);
            try
            {
                int amtStartPos = rWidth - strAmount.Length;
                int priceStartPos = ((int)(rWidth * 3 / 4)) - strPrice.Length;
                int qtyStartPos = ((int)(rWidth * 2 / 4)) - strQty.Length;

                tmpStr.Insert(0, transItem.Sku);
                tmpStr.Insert(qtyStartPos, strQty);
                tmpStr.Insert(priceStartPos, strPrice);
                tmpStr.Insert(amtStartPos, strAmount);

            }
            catch (Exception e)
            {
                Logger.Error("PrintReceipt.cs", e.ToString());
            }

            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
            PosHardware.Instance.PosPrinter.Println(str1);



        }



        private void PrintEjLineBody()
        {

            

        }
    }
    public enum EjItemStates
    {
        ENTER_QTY = 1,
        GET_QTY = 2,
        ENTER_AMOUNT = 3,
        GET_AMOUNT = 4,
        ITEM_FINAL = 5,
        LOAD_FROM_EJ = 91
    }
}
