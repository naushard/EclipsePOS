using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Microsoft.PointOfService;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
    public class EjPriceOverride : EjLine
    {
        private TransItem transItem=null;
		private Item item=null;
		private int qty;
        private double newAmount=0;
        private int lineNumber = 0;
        private EjItem ejItem = null;

        /** Prompt for line number. */
        public const int ENTER_LINE_NUMBER = 1;
        /** Get line number. */
        public const int GET_LINE_NUMBER = 2;
     
        /** Prompt for amount. */
        public const int ENTER_AMOUNT = 3;
        /** Get Amount */
        public const int GET_AMOUNT = 4;
        /** Complete the transaction. */
        public const int ITEM_FINAL = 5;

        private int state=0;

 
		public EjPriceOverride()
		{
			//
			// TODO: Add constructor logic here
            this.LineType = (int)EjLineType.ITEM_PRICE_OVERRIDE;
			//
		}
		
		
		public override  void UpdateTotals ()
		{
            if (transItem.State == (int)EjLineStates.IN_PROGRESS )
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
			if ( !PosContext.Instance.Training)
			{
				try 
				{

					transItem.Add();
				}
				catch (Exception e)
				{
					Logger.Error("EjItem.cs", e.ToString() );
				}
			}
			return true;
		}


        public override void SaveState(EjLineStates state)
        {
            transItem.State = (int)state;
            transItem.UpdateState();
        }



		public  override void Engage(int keyValue)
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

                        this.PushState(ENTER_AMOUNT);
                    }
                    else
                    {
                        this.PushState(ENTER_LINE_NUMBER);
                        PosContext.Beep(500, 50);
                    }
                    PosEventStack.Instance.NextEvent();
                    break;

               

                case ENTER_AMOUNT:
                    
                        PosContext.Instance.ClearInput();
                        this.PromptText = PosContext.Instance.Parameters.getParam("PromptItemPrice");
                        PosContext.Instance.Operprompt.Update(this);
                        
                        //Wait for the Enter key after after input amount 
                        this.PopState();
                        this.States().PushState(GET_AMOUNT);
                        PosContext.Beep(500, 50);
                        return;
                       
                    

                    break;
                
                case GET_AMOUNT:
                    
                    this.PopState();
                    this.newAmount = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble());
                    PosContext.Instance.ClearInput();
                    this.States().PushState(ITEM_FINAL);
                    PosEventStack.Instance.NextEvent();
                    break;

                case ITEM_FINAL:

              
                    this.ChangePrice(this.lineNumber);

                    this.ReComputeWholeOrderDiscounts(this.ejItem);

                    this.ReComputeSurchrge();

                    this.Amount = 0.0;
                    PosEventStack.Instance.ClearPending(); 


                    break;


            }
						
		}
 
		public override void Clear ()
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


        public void ChangePrice(int lineNumber)
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

                        this.transItem  = (TransItem)ejLine.DataRecord();

                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {
                            //transItem = PosContext.Instance.CurrentEjItem.TransItem;


                            //Create a price oveeride audit ( New line )
                            EclipsePos.Data.TransItem transItemAudit = new TransItem();
                            transItemAudit.Trans_no = transItem.Trans_no;
                            transItemAudit.Organization_no = transItem.Organization_no;
                            transItemAudit.Store_no = transItem.Store_no;
                            transItemAudit.Pos_no = transItem.Pos_no;
                            transItemAudit.Sku_link = transItem.Sku_link;
                            transItemAudit.Sku = transItem.Sku;
                            transItemAudit.Item_desc = transItem.Item_desc;
                            transItemAudit.Quantity = transItem.Quantity;

                            transItemAudit.Amount = transItem.Amount;
                            transItemAudit.Ext_amount = transItem.Ext_amount; //PosContext.Instance.PosMath.Mult(transItem.Quantity, changedTransItem.Amount);
                            transItemAudit.State = (int)EjLineStates.PRICE_OVERRIDE;



                            transItemAudit.Tax_exempt = transItem.Tax_exempt;
                            transItemAudit.Tax_incl = transItem.Tax_incl;
                            transItemAudit.State = (int)EjLineStates.PRICE_OVERRIDE;

                            EjItem ejItem = new EjItem(transItemAudit);

                            // Add to Ej to set the seq no and line no's  
                            PosContext.Instance.CurrentEj.EjAdd(ejItem);

                            transItemAudit.Line_no = PosContext.Instance.CurrentEj.LineNo;
                            transItemAudit.Seq_no = PosContext.Instance.CurrentEj.SeqNo;

                            transItemAudit.Add();




                            //Now change the current line to reflect the price change
                            transItem.Amount = newAmount;

                            transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Quantity, newAmount);
                            transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Ext_amount, PosContext.Instance.Sign);

                            transItem.UpdateAmounts();

                            this.ejItem.Desc  = "*" + ejItem.Desc;
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
                         //itemTax.ApplyTax();
                        
                       
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
				return  item;
			}
		}

		public override string Desc
		{
			get 
			{
				return "*" + transItem.Item_desc;
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
				return (int) transItem.Quantity;
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
				return transItem.Seq_no;
			}
			set
			{
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
				return transItem.Sku;
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
				
				transItem.State = value;
			}
			get
			{
				return transItem.State;
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

		
		#endregion

        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.ToString());
        }


	}

    



    
}
