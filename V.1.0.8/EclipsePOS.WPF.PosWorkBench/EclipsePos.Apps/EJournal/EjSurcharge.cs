using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Collections;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.EJournal
{
    public class EjSurcharge : EjLine	
    {
        private TransItem transItem = null;
        private Surcharge surcharge = null;
        private int qty;
        private double amount = 0;
        private int method;
        private bool recompute=false;


        public EjSurcharge()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int) EjLineType.SURCHARGE;
		}
		
		public EjSurcharge(TransItem trans)
		{
			this.transItem  = trans; 
			this.LineType = (int) EjLineType.SURCHARGE;
            this.surcharge = new Surcharge();
            this.surcharge.Organization_no = PosSettings.Default.Organization;
            this.surcharge.Surcharge_code = transItem.Sku;
            this.surcharge.LoadBySurchargeCode();
            this.Method = this.surcharge.Method;
		
		}

        public EjSurcharge(Surcharge surcharge)
		{
			this.surcharge  = surcharge;
			this.LineType = (int) EjLineType.SURCHARGE;
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



        public override void Engage(int keyVal)
        {

            if (this.surcharge == null) return;


            // Created trans Header just before the first item
            if (PosContext.Instance.CurrentEj == null || PosContext.Instance.CurrentEj.SeqNo == 0)
            {
                new StartTransaction().Engage(0);
                return;
            }

            this.States().Clear();
            PosEventStack.Instance.ClearPending();

            if (this.transItem == null)
            {
                this.transItem = new TransItem();
            }

            // double amount = item.Amount;
            transItem.Trans_no = PosContext.Instance.TrxNo;
            transItem.Organization_no = PosSettings.Default.Organization;
            transItem.Store_no = PosSettings.Default.Store;
            transItem.Pos_no = PosSettings.Default.Station;
            transItem.Sku_link = " ";
            transItem.Sku = surcharge.Surcharge_code; //item.Sku;
            transItem.Item_desc = surcharge.Surcharge_desc;  //item.Short_Desc;
            transItem.Quantity = 1;

            //Initialize Amt
            amount = 0;
           
            //Amt based on purcentage
            if (surcharge.Method == 0 ) 
            {
                double percent = surcharge.Amount / 100;
                this.amount  = PosContext.Instance.PosMath.Mult(PosContext.Instance.CurrentEj.EjSaleTotal(), percent);
                this.Method = 0;
            }
            // Amt based on Fixed sum
            if (surcharge.Method == 1)
            {
                this.amount  = surcharge.Amount;
                this.Method = 1;

            }

            transItem.Amount = amount; //item.Amount;
            transItem.Ext_amount = (float)Math.Round(amount * transItem.Quantity, 2);
          //  transItem.Ext_amount = PosContext.Instance.PosMath.Mult(transItem.Ext_amount, PosContext.Instance.Sign);
            transItem.Tax_exempt = surcharge.Tax_exempt;
            transItem.Tax_incl = surcharge.Tax_inclusive;
            transItem.State = (int)EjLineStates.IN_PROGRESS;
            transItem.Reason_code = (int)EjItemReasonCodes.SURCHARGE;

           // PosContext.Instance.CurrentEjItem = this;

            PosContext.Instance.CurrentEj.EjAdd(this);
            transItem.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
            transItem.Line_no = PosContext.Instance.CurrentEj.LineNo;

            // if not traning mode
            if (!PosContext.Instance.Training)
            {
                transItem.Add();
            }

            if (!(surcharge.Tax_exempt == 1))
            {
                try
                {
                    string taxGroupId = surcharge.Tax_group_id;
                    TaxGroup taxGroup = (TaxGroup)PosContext.Instance.Config.TaxGroups[taxGroupId];
                    ArrayList taxes = taxGroup.Taxes;
                    foreach (Object obj in taxes)
                    {
                       Tax tax = (Tax)obj;
                       EjTax ejTax = new EjTax(tax, this);
                       ejTax.Engage(0);
                    }
                }
                catch (Exception e)
                {
                    Logger.Error("EjItem.cs", e.ToString());
                }
            }



            //	Print the item at this point, discounts are printed in any modifiers
            this.ReCompute = false;
            PosContext.Instance.Receipt.Update(this);

            // add any modifiers that we find.

            

            // Display item details in Customer display after any discount 		
            PosContext.Instance.Operprompt.Update(this);
            PosContext.Instance.Quantity = 0;

            // PosEventStack.Instance.NextEvent();


           
 

        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {

            return true;
        }

        public void ReApplySurcharge()
        {
            if (this.Method == 0)
            {
                double percent = surcharge.Amount / 100;
                this.transItem.Amount = PosContext.Instance.PosMath.Mult(PosContext.Instance.CurrentEj.EjSaleTotal(), percent);
                this.transItem.Ext_amount = transItem.Amount;
                transItem.UpdateAmounts();
                this.ReCompute = true;
                PosContext.Instance.Receipt.Update(this);

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

        public Surcharge Surcharge
        {
            set
            {
                this.surcharge = value;
            }
            get
            {
                return this.surcharge;
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
                return (int)transItem.Quantity;
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

        public int Method
        {
            set
            {
                this.method = value;

            }
            get
            {
                return this.method;
            }

        }

        public bool ReCompute
        {
            set
            {
                this.recompute = value;
            }
            get
            {
                return this.recompute;
            }
        }
       


        #endregion

        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.ToString());
        }

    }
}
