 //===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: June, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================

using System;
using System.Windows;
using System.Threading;
using System.Text;
using System.Windows.Threading;
using System.Data;

using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for Receipt.
	/// </summary>
	public class Receipt: IDisposable	
	{
		#region Variables

		private	bool totalPrinted = false;
		private bool headerPrinted = false;
		private bool trailerPrinted = false;
        private bool lineHeaderPrinted = false;
		private PosTicket operDisplay; 
		private PosTicketHeader operDisplayHeader; 
        private PosTicketTotal operDisplayTotals; 
        private AlphaKeyEntry alphaKeyEntry; 

        private bool surchargePrinted = false;
        private bool orderDiscountPrinted = false;

        
		//private Thread t1;
		private bool printImmediate;
        private DispatcherTimer timer;

		#endregion

		#region Constructor

		public Receipt()
		{
			
			 
			operDisplay = PosContext.Instance.ReceiptDetails;
			operDisplayHeader = PosContext.Instance.ReceiptHeader; 
			operDisplayTotals = PosContext.Instance.ReceiptTotal; 
			printImmediate = PosSettings.Default.PrintReceiptImmediate;
            alphaKeyEntry = PosContext.Instance.AlphaKeyEntryDisplay;
			
            this.operDisplayHeader.PosDate = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
 
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
		}

        void timer_Tick(object sender, EventArgs e)
        {
            this.operDisplayHeader.PosDate = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();//DateTime.Today.ToLongDateString(); 
        }

		#endregion

 		#region Properties
	//	public OperDisplay OperDisplay
		public PosTicket OperDisplay
		{
			set
			{
				operDisplay = value;
			}
			get
			{
				return operDisplay;
			}

		}

        public PosTicketTotal OperDisplayTotals
        {
            get { return operDisplayTotals; }
            set {
                operDisplayTotals = value;
                this.UpdateTotals();
                if (PosContext.Instance.EjCustomer != null)
                {
                    this.Update(PosContext.Instance.EjCustomer);
                }
            }
        }

        public bool TotalPrinted
        {
            get
            {
                return this.totalPrinted;
            }
            set
            {
                this.totalPrinted = value;
            }
        }

		#endregion


		#region print receipt
 
		private void AddOperLine(int line, double qty, string plu, string item, string desc, double price,  double amount, bool trainingMode)
		{
            if (trainingMode)
                desc = "<T>" + desc;

            Logger.Info(
                        this.GetType().FullName, 
                        this.GetType().FullName + "\n" +
                        "Qty :" + string.Format("{0:##########}", qty) + "\n" +
                         "Plu :" + plu + "\n" +
                         "Item :" + item + "\n" +
                         "Desc :" + desc + "\n" +
                          "Price: " + string.Format("{0:#########0.00}", price)+ "\n" +
                           "Amount: " + string.Format("{0:#########0.00}", amount)  ,
                            PosSettings.Default.Debug
                        ); 
 
			if (operDisplay == null)
				return;

			

			operDisplay.Qty =  string.Format( "{0:#######0.00}", qty);
			operDisplay.PLU = plu;
			operDisplay.Item = item;
			operDisplay.Desc = desc;
			operDisplay.Price = string.Format( "{0:#########0.00}", price );
			operDisplay.Amount =  string.Format( "{0:#########0.00}", amount);
            operDisplay.LineNumber = line;
			operDisplay.Println();
			
			//if ( PosHardware.Instance.PosPrinter != null )
			//{
			//	
			//	if (!this.headerPrinted) 
			//	{
			//		PrintJobQueue.Instance.AddJob(new PrintReceiptHeader());
			//		this.headerPrinted = true;
			//	}
            //    if (!this.lineHeaderPrinted)
            //    {
            //        PrintJobQueue.Instance.AddJob(new PrintReceiptLineHeading());
            //        this.lineHeaderPrinted = true;
            //    }
			//	
			//	PrintJobQueue.Instance.AddJob(new PrintReceipt(qty, plu, item, desc, price, amount, trainingMode));
			//}

			this.UpdateTotals();
		}

		private void AddOperLine (string desc, double amount, bool trainingMode)
		{
            if (trainingMode)
                desc = "<T>" + desc;

            Logger.Info(
                        this.GetType().FullName,
                        this.GetType().FullName + "\n" +
                         "Desc :" + desc + "\n" +
                          "Amount: " + string.Format("{0:#########0.00}", amount),
                            PosSettings.Default.Debug
                        ); 

			if (operDisplay != null)
			{
				operDisplay.Qty =  " " ;
				operDisplay.PLU = " ";
				operDisplay.Item = " ";
				operDisplay.Desc = desc;
				operDisplay.Price = " ";
                operDisplay.Employee_no = "";
                operDisplay.LineNumber = 0;
                if (amount != 0)
                {
                    operDisplay.Amount = string.Format("{0:#########0.00}", amount);
                }
                else
                {
                    operDisplay.Amount = "";
                }
				operDisplay.Println();
			
			}
			
		 //	if ( PosHardware.Instance.PosPrinter != null )
		 //	{
		 //		if (!this.headerPrinted) 
		 //		{ 
		 // 			PrintJobQueue.Instance.AddJob(new PrintReceiptHeader());
		 //			this.headerPrinted = true;
		 //		}
         //
		 // 		PrintJobQueue.Instance.AddJob(new PrintReceipt(desc, amount, trainingMode));
		 //	}

			this.UpdateTotals();
		}

     //   private void PrintOperClearLine(int index)
     //   {
     //       operDisplay.Clearln(index);
    //
    //    }

        private void PrintOperSurcharge(int lineNumber, string desc, double amt, bool trainingMode)
        {
            if (trainingMode)
                desc = "<T>" + desc;

            operDisplay.Qty = "";
            operDisplay.PLU = "";
            operDisplay.Item = "";
            operDisplay.Desc = desc;
            operDisplay.Price = "";
            if (amt != 0)
            {
                operDisplay.Amount = string.Format("{0:#########0.00}", amt);
            }
            else
            {
                operDisplay.Amount = null;
            }
            operDisplay.LineNumber = lineNumber;
            operDisplay.PrintlnSurcharge();

            this.UpdateTotals();
        }


        private void PrintOperDiscount(string desc, double amt, bool trainingMode)
        {
            if (trainingMode)
                desc = "<T>" + desc;

            operDisplay.Qty = "";
            operDisplay.PLU = "";
            operDisplay.Item = "";
            operDisplay.Desc = desc;
            operDisplay.Price = "";
            if (amt != 0)
            {
                operDisplay.Amount = string.Format("{0:#########0.00}", amt);
            }
            else
            {
                operDisplay.Amount = null;
            }
            operDisplay.LineNumber = 0;
            operDisplay.PrintlnDiscount();

            this.UpdateTotals();
        }


        private void PrintOperSalesPerson(string emplpyee_no, string desc, bool trainingMode)
        {
            if (trainingMode)
                desc = "<T>" + desc;

            operDisplay.Qty = "";
            operDisplay.PLU = "";
            operDisplay.Item = "";
            operDisplay.Desc = desc;
            operDisplay.Price = "";
            operDisplay.Amount = "";
            operDisplay.Employee_no = emplpyee_no;
            operDisplay.Println();

        }


        private void PrintSurcharges()
        {
            /*
            if (PosHardware.Instance.PosPrinter != null)
            {
                if (!this.headerPrinted)
                {
                    PrintJobQueue.Instance.AddJob(new PrintReceiptHeader());
                    this.headerPrinted = true;
                }
                foreach (Object obj in PosContext.Instance.CurrentEj.EjArrayList)
                {
                    if (obj is EjSurcharge)
                    {
                        EjSurcharge ejSur = obj as EjSurcharge;
                        string desc = ejSur.Desc;
                        double amt = ejSur.ExtAmount;
                        PrintJobQueue.Instance.AddJob(new PrintReceipt(desc, amt, PosContext.Instance.Training));
                    }
                }
            }
             * */
        }

        private void PrintOrderDiscoutns()
        {

            if (PosHardware.Instance.PosPrinter != null)
            {
                /*
                if (!this.headerPrinted)
                {
                    PrintJobQueue.Instance.AddJob(new PrintReceiptHeader());
                    this.headerPrinted = true;
                }
                double amt = PosContext.Instance.CurrentEj.EjWholeOrderDiscountTotal();
                if (amt != 0 )
                {
                        Promotion  promotion  = PosContext.Instance.SaleMode;
                        string desc = promotion.PromotionString + " " + promotion.PromotionDval1 + "%";
                        PrintJobQueue.Instance.AddJob(new PrintReceipt(desc, amt, PosContext.Instance.Training));
                }
                 * */
            }
        }



        
        private void ChangeOperLinePrice(double price, double extAmt)
        {
            operDisplay.ChangeLinePrice(string.Format("{0:#########0.00}", price), string.Format("{0:#########0.00}", extAmt));
            this.UpdateTotals();
        }

        


        private void ChangeOperLineQuantity(double qty, double extAmt)
        {
            operDisplay.ChangeLineQuantity(string.Format("{0:#######0.00}", qty), string.Format("{0:#######0.00}", extAmt));

            this.UpdateTotals();
        }

        private void ChangeOperLineText(string desc)
        {
            operDisplay.Desc = desc;
			
        }


		#endregion



		#region Print receipt total

		private void OperPrintTotal ( )
		{
			//PrintOper (PosContext.Instance.Parameters.getParam("SubTotal"), PosContext.Instance.CurrentEj.EjSubTotal() , PosContext.Instance.Training);
			//string currency = System.Environment.GetEnvironmentVariable("Currency");
			//PrintOper (PosContext.Instance.Parameters.getParam("Total") + " " +currency, PosContext.Instance.CurrentEj.EjTotal(),  PosContext.Instance.Training);
			//string subtotal = PosContext.Instance.Parameters.getParam("SubTotal");
			//string currency = System.Environment.GetEnvironmentVariable("Currency");
			string totalText  = PosContext.Instance.Parameters.getParam("Total");
			double totalAmount = PosContext.Instance.CurrentEj.EjTotal();

            if (PosContext.Instance.Training)
                totalText = "<T>" + totalText;


            Logger.Info(
                       this.GetType().FullName,
                       this.GetType().FullName + "\n" +
                        "tatalText" + ":" + string.Format("{0:#########0.00}", totalAmount),
                           PosSettings.Default.Debug
                       ); 


			if (operDisplay != null)
			{
				
				operDisplay.Qty =  " " ;
				operDisplay.PLU = " ";
				operDisplay.Item = " ";
				operDisplay.Desc = totalText;
				operDisplay.Price = " ";
                operDisplay.Employee_no = "";
				operDisplay.Amount =  string.Format( "{0:#########0.00}", totalAmount);
				operDisplay.Println();
			}
			
           

			this.UpdateTotals();
			
		}


        private void OperPrintSubTotal()
        {
            string totalText = PosContext.Instance.Parameters.getParam("SalesTotal");
            double totalAmount = PosContext.Instance.CurrentEj.EjGrossTotal();

            if (PosContext.Instance.Training)
                totalText = "<T>" + totalText;


            Logger.Info(
                       this.GetType().FullName,
                       this.GetType().FullName + "\n" +
                        "tatalText" + ":" + string.Format("{0:#########0.00}", totalAmount),
                           PosSettings.Default.Debug
                       );


            if (operDisplay != null)
            {

                operDisplay.Qty = " ";
                operDisplay.PLU = " ";
                operDisplay.Item = " ";
                operDisplay.Desc = totalText;
                operDisplay.Price = " ";
                operDisplay.Employee_no = "";
                operDisplay.Amount = string.Format("{0:#########0.00}", totalAmount);
                operDisplay.Println();
            }

           

            this.UpdateTotals();

        }


		#endregion

		#region Print Buffer
		
		public void PrintBuffer ()
		{
            if (PosHardware.Instance.PosPrinter != null)
            {

                PrintJobQueue.Instance.AddJob(new ReceiptPrintJob(
                                            PosSettings.Default.Organization,
                                            PosSettings.Default.Store,
                                            PosSettings.Default.Station,
                                            PosContext.Instance.TrxNo));

                PrintJobQueue.Instance.PrintReceiptStart();
            }
            
		}

		#endregion


        #region Clear Buffer

        public void ClearBuffer()
        {
            if (!printImmediate)
            {
                PrintJobQueue.Instance.Clear();
            }
        }

        #endregion


		#region Update - StartTransaction

		public void Update (StartTransaction posEvent)
		{
			totalPrinted = false;
			headerPrinted = false;
			trailerPrinted = false;
            orderDiscountPrinted = false;
            surchargePrinted = false;
            lineHeaderPrinted = false;
			
			
			if (operDisplay != null)
			{
				operDisplay.Clear();
			}
			if( this.operDisplayTotals != null)
			{
				this.operDisplayTotals.Clear();
			}
            if (alphaKeyEntry != null)
            {
                this.alphaKeyEntry.KeyReset();
            }

            

		}

		#endregion


        #region Update - Void Sale

        public void Update(VoidSale posEvent)
        {
            this.VoidSale();

            totalPrinted = false;
            headerPrinted = false;
            trailerPrinted = false;
            surchargePrinted = false;
            orderDiscountPrinted = false;
            lineHeaderPrinted = false;

            if (operDisplay != null)
            {
                operDisplay.Clear();
            }
            if (this.operDisplayTotals != null)
            {
                this.operDisplayTotals.Clear();
            }

            if (this.operDisplayHeader != null)
            {
                this.operDisplayHeader.TrxNo = ""; //string.Format("{0:000000}", posEvent.TrxNo); //PosContext.Instance.TrxNo;
                //this.operDisplayHeader.TransactionType = PosContext.Instance.Parameters.getParam("SalePrompt");
            }

            if (this.alphaKeyEntry != null)
            {
                this.alphaKeyEntry.KeyReset();
            }

           

        }

        #endregion



		#region Update - RecallEj 

		public void Update (RecallEj posEvent)
		{
			
			if (this.operDisplayHeader != null)
			{
				this.operDisplayHeader.TrxNo =  string.Format("{0:000000}", posEvent.TrxNo); 
			}
			
		}
		#endregion 

        
        #region Update - RecallEjFromLog

        public void Update(RecallEjFromLog posEvent)
        {

            if (this.operDisplayHeader != null)
            {
                this.operDisplayHeader.TrxNo = string.Format("{0:000000}", posEvent.TrxNo);
            }

        }
        #endregion 


		#region Update - FinishTransaction

		public void Update (FinishTransaction posEvent)
		{
			PosContext.Instance.Sign = 1.0;

			if (operDisplay != null)
			{
				operDisplay.Clear();
			}
			if( this.operDisplayTotals != null)
			{
				this.operDisplayTotals.Clear();
			}
			if(this.operDisplayHeader != null)
			{
				this.operDisplayHeader.TrxNo =" ";
				//this.operDisplayHeader.TransactionType = PosContext.Instance.Parameters.getParam("SalePrompt");
                this.operDisplayHeader.CustomerInfo = " ";
			}

            if (PosContext.Instance.AlphaKeyEntryDisplay != null)
            {
                PosContext.Instance.AlphaKeyEntryDisplay.KeyReset();
            }
        }

        #endregion

        #region Update - Logon
        public void Update(LogOn posEvent)
        {
            //Start with sales mode
           // if (this.operDisplayHeader != null)
           // {
           //     this.operDisplayHeader.TransactionType = PosContext.Instance.Parameters.getParam("SalePrompt");
           // }
        }



        #endregion

        #region Update - ReturnSale

        public void Update (ReturnSale posEvent)
		{
			//if(this.operDisplayHeader != null)
			//{
			//	this.operDisplayHeader.TransactionType = PosContext.Instance.Parameters.getParam("ReturnSalePrompt");
			//}
		}

		#endregion
	


		#region RegisterOpen
  
		public void Update (RegisterOpen posEvent)
		{
			if (operDisplay != null)
			{
				this.operDisplayHeader.PosNo = string.Format("{0,7:D7}", PosSettings.Default.Station.ToString());
				this.operDisplayHeader.Operator = PosContext.Instance.Employee.FName;
          //      this.operDisplayHeader.PosDate = DateTime.Today.ToLongDateString()+ " " +DateTime.Now.ToShortTimeString();//DateTime.Today.ToLongDateString();
			} 
		}
		#endregion


		#region Update - EjItem

		public void Update(EjItem ejItem)
		{
			string desc = ejItem.Desc.Trim();
			double amt = ejItem.ExtAmount;
			double qty =  ejItem.Quantity;

			Item item = ejItem.Item;
		//	string plu = item.Plu.ToString();
			string sku =  item.Sku;
			double price = ejItem.Amount;
            int line = ejItem.LineNo;
			
			TransItem transItem = (TransItem) ejItem.DataRecord();
            if (transItem.State == (int)EjLineStates.VOID_ITEM)
            {
                //	amt = PosContext.Instance.PosMath.Negate(amt);
                //	qty = PosContext.Instance.PosMath.Negate(qty);
                this.operDisplay.Clearln(line);
                return;
            }

            if (ejItem.DialogStep == (int)EjItem.ITEM_CLEAR)
            {
                this.operDisplay.Clearln(line);
                return; 
            }

            if (ejItem.DialogStep == (int)EjItemStates.ENTER_AMOUNT)
            {
                this.ChangeOperLineQuantity(ejItem.Quantity, ejItem.ExtAmount);
            }

            if (ejItem.DialogStep == (int)EjItemStates.ITEM_FINAL)
            {
                this.ChangeOperLinePrice(ejItem.Amount, ejItem.ExtAmount);
            }


            if (ejItem.DialogStep == (int)EjItemStates.ENTER_QTY)
            {
                this.AddOperLine(line, qty, null, sku, desc, price, amt, false);
            }

            if (ejItem.DialogStep == (int)EjItemStates.LOAD_FROM_EJ)
            {
                this.AddOperLine(line, qty, null, sku, desc, price, amt, false);
            }

            		
		}

		#endregion


        #region Update - EjPriceOverride

        public void Update(EjPriceOverride ejPriceOvr)
        {
           this.ChangeOperLinePrice(ejPriceOvr.Amount, ejPriceOvr.ExtAmount);
        }

        #endregion

        #region Update - ChangeQuanity

        public void Update(ChangeQuantity pEvent)
        {
            operDisplay.ChangeLineQuantity(string.Format("{0:#########0.00}", pEvent.Quantity), string.Format("{0:#########0.00}", pEvent.ExtAmount));
            this.UpdateTotals();
        }

        #endregion




        #region Update - EjSurcharge

        public void Update(EjSurcharge ejSurcharge)
        {
            string desc = ejSurcharge.Desc;
            double amt = ejSurcharge.ExtAmount;
            int qty = (int)  ejSurcharge.Quantity;
            int line = ejSurcharge.LineNo;

           Surcharge surcharge = ejSurcharge.Surcharge;
            //	string plu = item.Plu.ToString();
            string surchargeCode = surcharge.Surcharge_code;
            double price = ejSurcharge.Amount;

           TransItem transItem = (TransItem)ejSurcharge.DataRecord();
           if (transItem.State == (int)EjLineStates.VOID_ITEM)
           {
               amt = 0;// PosContext.Instance.PosMath.Negate(amt);
               qty = 0;// PosContext.Instance.PosMath.Negate(qty);
           }
           
            
            //If recomputation, then remove from display
            this.PrintOperSurcharge(line, desc, amt, PosContext.Instance.Training);
           


        }

        #endregion



		


		#region Update NewLogon
 
		public void Update(NewLogon posEvent)
		{
			//try
			//{
			//	PosContext.Instance.CurrentPosKeyPanel.KeyDisable();
			//} 
			//catch (Exception e)
			//{
			//	MessageBox.Show(e.ToString());
			//}

		}

		#endregion


		#region Update - ClearKey
		public void Update(ClearKey posEvent)
		{
			if( (PosContext.Instance.CurrentEj == null) || (PosContext.Instance.CurrentEj.EjArrayList.Count == 0) )
			{
				this.OperDisplay.Clear();
				this.operDisplayTotals.Clear();
			}
		}
		#endregion
	
		
		#region Update - EjTender 

		public void Update(EjTender pEvent)
		{
			//nlines = 0;
			TransTender transTender = (TransTender) pEvent.DataRecord();

            //this.OperPrintSubTotal();
            

            //Print Discount, surcharges
            if (!this.orderDiscountPrinted) this.PrintOrderDiscoutns();
            if (!this.surchargePrinted) this.PrintSurcharges();

			if (!totalPrinted)
			{
				OperPrintTotal ();
                if (PosContext.Instance.CurrentEj.TransHeader.State == 1)
                {
                    OpenDrawer();
                }
				totalPrinted = true;
			}
           


			//MessageBox.Show(transTender.Tender_desc.Trim());
			this.AddOperLine(transTender.Tender_desc.Trim(), transTender.Amount, PosContext.Instance.Training);
			if (PosHardware.Instance.LineDisplay != null )
			{
				//PosHardware.Instance.LineDisplay.Open();
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(transTender.Tender_desc.Trim(), 0, 0);
				PosHardware.Instance.LineDisplay.SetText(string.Format("{0:##########.00}", transTender.Amount), 1, 0);
				//	PosHardware.Instance.LineDisplay.Close();
			}

			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				AddOperLine (PosContext.Instance.Parameters.getParam("BalanceDue"), PosContext.Instance.CurrentEj.EjBalance(),  PosContext.Instance.Training );
			}
			else 
				if (transTender.Change_amount != 0.0)
			{
				//MessageBox.Show(transTender.Amount + transTender.Change_desc);
				AddOperLine (transTender.Change_desc, transTender.Change_amount, PosContext.Instance.Training);
			}

			this.Complete(pEvent);
			
			
		}

		#endregion


		#region Update EjPromotion
		public void Update(EjPromotion pEvent)
		{
            double amt = pEvent.Amount;
            if (pEvent.State == (int)EjLineStates.VOID_ITEM)
            {
                amt = PosContext.Instance.PosMath.Negate(amt);
               
            }
            if (pEvent.Promotion.PromotionType == (int)EjPromotionTypes.SKU)
            {
                this.AddOperLine(pEvent.Desc, amt, PosContext.Instance.Training);
            }
            else
            {
                 amt = PosContext.Instance.CurrentEj.EjWholeOrderDiscountTotal();
                this.PrintOperDiscount(pEvent.Desc, amt, PosContext.Instance.Training );
            }

		}
		#endregion



        #region Update EjTax
        /* Refresh the totals on pos display */

        public void Update(EjTax pEvent)
        {
            this.UpdateTotals();
        }
        #endregion




        #region Update EjCCTender
        public void Update(EjCCTender pEvent)
		{
            //Print Discount, surcharges
            if (!this.orderDiscountPrinted) this.PrintOrderDiscoutns();
            if (!this.surchargePrinted) this.PrintSurcharges();

			if (!totalPrinted)
			{
				OperPrintTotal();
				OpenDrawer ();
				totalPrinted = true;
			}
            
			TransTender transTender = (TransTender) pEvent.DataRecord();

			this.AddOperLine(transTender.Tender_desc.Trim(), transTender.Amount, PosContext.Instance.Training);
			if (PosHardware.Instance.LineDisplay != null )
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(transTender.Tender_desc.Trim(), 0, 0);
				PosHardware.Instance.LineDisplay.SetText(string.Format("{0:##########.00}", transTender.Amount), 1, 0);
			}

		
			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				AddOperLine (PosContext.Instance.Parameters.getParam("BalanceDue"), PosContext.Instance.CurrentEj.EjBalance(),  PosContext.Instance.Training );
			}
			else 
			
			if (transTender.Change_amount != 0.0)
			{
				//MessageBox.Show(transTender.Amount + transTender.Change_desc);
				AddOperLine (transTender.Change_desc, transTender.Change_amount, PosContext.Instance.Training);
			}

			this.Complete(pEvent);
			
			//StringTokenizer st = new StringTokenizer (transTender.dataCapture (), ",");
			//String tmp = "";
			//if (st.hasMoreTokens ()) 
			//{
			//	tmp = st.nextToken ();
			//}
			//if (tmp.length () == 16)
			//{
			//	tmp = "************" + tmp.substring (12, 16);
			//}
			//else if (tmp.length () == 15)
			//{
			//	tmp = "***********" + tmp.substring (10, 15);
			//}

			//printOper (tmp, line.context ().trainingMode ());
			//printOper ("Approval Code", line.authCode (), line.context ().trainingMode ());
			//complete (line);

		}
		#endregion


        #region Update EjDebtTender
        public void Update(EjDebtTender pEvent)
        {
            //Print Discount, surcharges
            if (!this.orderDiscountPrinted) this.PrintOrderDiscoutns();
            if (!this.surchargePrinted) this.PrintSurcharges();


            if (!totalPrinted)
            {
                OperPrintTotal();
                OpenDrawer();
                totalPrinted = true;
            }

           
            TransTender transTender = (TransTender)pEvent.DataRecord();

            this.AddOperLine(transTender.Tender_desc.Trim(), transTender.Amount, PosContext.Instance.Training);
            if (PosHardware.Instance.LineDisplay != null)
            {
                PosHardware.Instance.LineDisplay.Clear();
                PosHardware.Instance.LineDisplay.SetText(transTender.Tender_desc.Trim(), 0, 0);
                PosHardware.Instance.LineDisplay.SetText(string.Format("{0:##########.00}", transTender.Amount), 1, 0);
            }


            if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
            {
                AddOperLine(PosContext.Instance.Parameters.getParam("BalanceDue"), PosContext.Instance.CurrentEj.EjBalance(), PosContext.Instance.Training);
            }
            else

                if (transTender.Change_amount != 0.0)
                {
                    //MessageBox.Show(transTender.Amount + transTender.Change_desc);
                    AddOperLine(transTender.Change_desc, transTender.Change_amount, PosContext.Instance.Training);
                }

            EclipsePos.Data.Customer cus = PosContext.Instance.EjCustomer.DataRecord() as EclipsePos.Data.Customer;

            AddOperLine(PosContext.Instance.Parameters.getParam("MaxDebt"), pEvent.MaxDebt, PosContext.Instance.Training);
            AddOperLine(PosContext.Instance.Parameters.getParam("CurrentDebt"), pEvent.CurrentDebt, PosContext.Instance.Training);

            if (cus.Customer_first_name != null && cus.Customer_first_name.Trim().Length > 0)
            {
                AddOperLine(cus.Customer_first_name, 0, PosContext.Instance.Training);
            }
            if (cus.Customer_last_name != null && cus.Customer_last_name.Trim().Length > 0)
            {
                AddOperLine(cus.Customer_last_name, 0, PosContext.Instance.Training);
            }
            if (cus.Addr1 != null && cus.Addr1.Trim().Length > 0)
            {
                AddOperLine(cus.Addr1, 0, PosContext.Instance.Training);
            }
            if (cus.Addr2 != null && cus.Addr2.Trim().Length > 0)
            {
                AddOperLine(cus.Addr2, 0, PosContext.Instance.Training);
            }
            if (cus.Country != null && cus.Country.Length > 0)
            {
                AddOperLine(cus.Country, 0, PosContext.Instance.Training);
            }
            if ( cus.Postel_code !=null && cus.Postel_code.Length > 0)
            {
                AddOperLine(cus.Postel_code, 0, PosContext.Instance.Training);
            }
            
            this.Complete(pEvent);

            

        }
        #endregion



		#region Update EjCheckTender

		public void Update(EjChequeTender pEvent)
		{
            //Print Discount, surcharges
            if (!this.orderDiscountPrinted) this.PrintOrderDiscoutns();
            if (!this.surchargePrinted) this.PrintSurcharges();


			if (!totalPrinted)
			{
				OperPrintTotal();
				OpenDrawer ();
				totalPrinted = true;
			}

			TransTender transTender = (TransTender) pEvent.DataRecord();
          
            this.AddOperLine(transTender.Tender_desc.Trim(), transTender.Amount, PosContext.Instance.Training);

			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				AddOperLine (PosContext.Instance.Parameters.getParam("BalanceDue"), PosContext.Instance.CurrentEj.EjBalance(),  PosContext.Instance.Training );
			}
			else 
			
				if (transTender.Change_amount != 0.0)
				{
					AddOperLine (transTender.Change_desc, transTender.Change_amount, PosContext.Instance.Training);
				}

			this.Complete(pEvent);
			
			
		}

		#endregion


        #region Update EjDebitCardTender

        public void Update(EjDebitCardTender pEvent)
        {
            //Print Discount, surcharges
            if (!this.orderDiscountPrinted) this.PrintOrderDiscoutns();
            if (!this.surchargePrinted) this.PrintSurcharges();


            if (!totalPrinted)
            {
                OperPrintTotal();
                OpenDrawer();
                totalPrinted = true;
            }

            
            TransTender transTender = (TransTender)pEvent.DataRecord();

            this.AddOperLine(transTender.Tender_desc.Trim(), transTender.Amount, PosContext.Instance.Training);

            if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
            {
                AddOperLine(PosContext.Instance.Parameters.getParam("BalanceDue"), PosContext.Instance.CurrentEj.EjBalance(), PosContext.Instance.Training);
            }
            else

                if (transTender.Change_amount != 0.0)
                {
                    AddOperLine(transTender.Change_desc, transTender.Change_amount, PosContext.Instance.Training);
                }

            this.Complete(pEvent);


        }

        #endregion


		#region Update SaveEj

		public void Update(SaveEj pEvent)
		{
			  PrintSavedReceiptTrailer ();
		
		}

		#endregion


        #region Update EjHeader

        public void Update(EjHeader pEvent)
        {
            totalPrinted = false;
            headerPrinted = false;
            trailerPrinted = false;
            surchargePrinted = false;
            orderDiscountPrinted = false;
            lineHeaderPrinted = false;
           
            if (this.operDisplayHeader != null)
            {
                this.operDisplayHeader.TrxNo = string.Format("{0:000000}", PosContext.Instance.TrxNo); //PosContext.Instance.TrxNo;
                //this.operDisplayHeader.TransactionType = PosContext.Instance.Param eters.getParam("SalePrompt");
            }

            if (!String.IsNullOrEmpty(PosContext.Instance.TableName.Trim()))
            {
                string tableText = PosContext.Instance.Parameters.getParam("TableText") + PosContext.Instance.TableName;
                this.AddOperLine(tableText, 0.0, PosContext.Instance.Training);
            }

        }

        #endregion



		#region Update - EjLine

		public void Update (EjLine pEvent)
		{

			int nlines = 0;
			switch (pEvent.LineType)
			{

				case (int) EjLineType.TRANS_HEADER:
                    Update((EjHeader)pEvent);
                    break;

				case (int) EjLineType.ITEM:
					Update( (EjItem)pEvent );
					break;

				case (int) EjLineType.PROMOTION:
					Update ( (EjPromotion)pEvent );
					break;

				case (int) EjLineType.TAX:
					break;

				case (int) EjLineType.TENDER:
					Update( (EjTender)pEvent );
					break;

				case (int) EjLineType.BANK:
			//		Update( (EjBank)pEvent );
					break;

				case (int) EjLineType.ACCOUNT:
					break;

				case (int) EjLineType.ALT_CURRENCY_TENDER:
					Update( (EjAltCurrTender)pEvent);
					break;

				case (int)EjLineType.CHECK_TENDER:
					Update((EjChequeTender)pEvent );
					break;

				case (int)EjLineType.DEBIT_TENDER:
			//		Update ( (EjDebitTender)pEvent );
					break;

				case (int)EjLineType.CC_TENDER:
					Update( (EjCCTender)pEvent );
					break;

				case (int)EjLineType.COUPON:
			//		Update ((EjCoupon) pEvent );
					break;

                case (int)EjLineType.FREE_TEXT:
                    Update ((EjFreeText) pEvent );
                    break;

                case (int)EjLineType.SURCHARGE:
                    Update((EjSurcharge)pEvent);
                    break;

                case (int)EjLineType.ITEM_PRICE_OVERRIDE:
                    Update((EjPriceOverride)pEvent);
                    break;
                case (int)EjLineType.SALES_PERSON:
                    Update((EjSalesPerson)pEvent);
                    break;

				default:
				//	Log.warning ("Unhandled ej type in Receipt " + line.toString ());
					break;
			}
		}

		#endregion


        #region Update - EjFreeText

        public void Update(EjFreeText pEvent)
        {
            TransText transText = (TransText)pEvent.DataRecord();

            this.AddOperLine(transText.Extended_text.Trim(), 0, PosContext.Instance.Training);
           
        }

        #endregion

        #region Update - EjBank ( Pain in/ Paid Out/Petty Cash etc.)

        public void Update(EjBank pEvent)
        {
           
            this.AddOperLine(pEvent.Desc, pEvent.Amount, PosContext.Instance.Training);

        }

        #endregion



        #region Update - EjSalesPerson

        public void Update(EjSalesPerson pEvent)
        {
           // TransSalesPerson transSalesPerson = (TransSalesPerson)pEvent.DataRecord();

            string salesText = PosContext.Instance.Parameters.getParam("SalesStaff")+ pEvent.Desc;    
            this.PrintOperSalesPerson(pEvent.Employee.Employee_no, salesText, PosContext.Instance.Training);

        }

        #endregion


        #region Update - RemoveSalesPerson

        public void Update(RemoveSalesPerson pEvent)
        {
            OperDisplay.ClearEmployeeLine(pEvent.Employee_no);

        }

        #endregion
        


        #region EjAltCurrTender

        public void Update(EjAltCurrTender pEvent)
		{

			if (!this.totalPrinted)
			{
				this.OperPrintTotal();
				this.OpenDrawer();
				this.totalPrinted = true;
			}

			
			// Make sure the record is complete

			TransTender transTender = (TransTender) pEvent.DataRecord();

			// get the locale

		//	Locale altLocale;
		//	if (line.context ().altCurrency ().currencyCode ().language ().equals ("NL"))
		//	{
		//		altLocale = new java.util.Locale (line.context ().altCurrency ().currencyCode ().language (), line.context ().altCurrency ().currencyCode ().country (), "EURO");
		//	}
		//	else
		//	{
		//		altLocale = new java.util.Locale (line.context ().altCurrency ().currencyCode ().language (), line.context ().altCurrency ().currencyCode ().country ());
		//	}

			// output the amount tendered in local currency

			string desc = pEvent.Desc.Trim();
	
			this.AddOperLine(pEvent.TenderDesc.Trim()+ " " + PosContext.Instance.AltCurrency.Home_currency,
				pEvent.SplitAmount, PosContext.Instance.Training);
			//if (pEvent.States().PeekState() == EjAltCurrTender.GET_ALT_CURR_AMOUNT)
			//{

			//	double total = PosContext.Instance.CurrentEj.EjTotal();
			//	double tax = PosContext.Instance.CurrentEj.EjTaxTotal();

			desc = pEvent.ConvertText.Trim() + " @ " + string.Format("{0:####.######}", PosContext.Instance.AltCurrency.Conversion_rate);
				//operDisplay.Desc = desc+ " @ " +  ;
				if (PosContext.Instance.Training )
					desc = "<T>" + desc;

				//operDisplay.Amount = pEvent.ConvertedAmount.ToString();
				//operDisplay.Println();
				this.AddOperLine(	desc, pEvent.ConvertedAmount, PosContext.Instance.Training);	
			//}
		//	else
		//	{
		//		this.OperPrintTotal();
		//		operDisplay.Desc = PosContext.Instance.Parameters.getParam("TenderTotal").Trim();
		//		this.PrintOper (
		//			PosContext.Instance.Parameters.getParam("TenderTotal").Trim(),
		//			transTender.Amount,
		//	}		PosContext.Instance.Training );

			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				this.AddOperLine(
					PosContext.Instance.Parameters.getParam("BalanceDue"),
					PosContext.Instance.CurrentEj.EjBalance(),
					PosContext.Instance.Training);
			}
			else if (transTender.Change_amount != 0.0)
			{
				this.AddOperLine(
					transTender.Change_desc,
					transTender.Change_amount,
					PosContext.Instance.Training);
			}
			

			this.Complete(pEvent);
		}

		#endregion



		#region Update - TerminalReport

		public void Update(TerminalReport report)
		{

			int nlines = 0;
            this.headerPrinted = false;


			int start = 0;
			int end = 0;
			string header = null;

			switch (report.ReportType)
			{
				case XZReportType.X_DAILY:
					header = PosContext.Instance.Parameters.getParam("DailyXHeader");
					start = (int)TotalType.DAILY_BASE;
					end = (int)TotalType.WEEKLY_BASE;
					break;
				case XZReportType.Z_DAILY:
					header = PosContext.Instance.Parameters.getParam("DailyZHeader");
					start = (int)TotalType.DAILY_BASE;
					end = (int)TotalType.WEEKLY_BASE;
					break;
				case XZReportType.X_WEEKLY:
					header = PosContext.Instance.Parameters.getParam("WeeklyXHeader");
					start = (int)TotalType.WEEKLY_BASE;
					end = (int)TotalType.MONTHLY_BASE;
					break;
				case XZReportType.Z_WEEKLY:
					header = PosContext.Instance.Parameters.getParam("WeeklyZHeader");
					start = (int)TotalType.WEEKLY_BASE;
					end = (int)TotalType.MONTHLY_BASE;
					break;
				case XZReportType.X_MONTHLY:
					header = PosContext.Instance.Parameters.getParam("MonthlyXHeader");
					start = (int)TotalType.MONTHLY_BASE;
					end = (int)TotalType.YEARLY_BASE;
					break;
				case XZReportType.Z_MONTHLY:
					header = PosContext.Instance.Parameters.getParam("MonthlyZHeader");
					start = (int)TotalType.MONTHLY_BASE;
					end = (int)TotalType.YEARLY_BASE;
					break;
				default:
					header = "";
					break;
			}

			
            // Print sequence number and start date and time
            this.AddOperLine(PosContext.Instance.Parameters.getParam("SequenceNo"), report.PosTotal.Sequence_no, PosContext.Instance.Training);
            this.AddOperLine(PosContext.Instance.Parameters.getParam("StartDate") + report.PosTotal.Start_date.ToString(), 0, PosContext.Instance.Training);
            this.AddOperLine(PosContext.Instance.Parameters.getParam("StartReceiptNo") + report.PosTotal.Start_receipt_no, 0, PosContext.Instance.Training);
            this.AddOperLine(PosContext.Instance.Parameters.getParam("EndReceiptNo") + report.PosTotal.End_receipt_no, 0, PosContext.Instance.Training);

            if ( PosContext.Instance.Parameters.getParam("PromptForEmployee") == "TRUE")
            {
                this.TerminalReportBySalesman(report);
            }

            this.TerminalReportByCollections(report, start, end);

            this.TerminalReportForCashInDrawer(report, start, end);

           

            if (PosHardware.Instance.PosPrinter != null) 
            {
                PrintJobQueue.Instance.AddJob(new TerminalPrintJob(report));
                PrintJobQueue.Instance.PrintReceiptStart(); 
         
            }
		}


        private void TerminalReportBySalesman(TerminalReport terminalReport)
        {
            this.AddOperLine(PosContext.Instance.Parameters.getParam("SalesBySalesman"), 0, PosContext.Instance.Training);
            PosEmployeeTotal employeeTotal = new PosEmployeeTotal();
            employeeTotal.Organization_no = PosSettings.Default.Organization;
            employeeTotal.Store_no = PosSettings.Default.Store;
            employeeTotal.Pos_no = PosSettings.Default.Station;
            employeeTotal.Sequence_no = terminalReport.PosTotal.Sequence_no;
            double totalSales = 0;
            DataSet empData = employeeTotal.LoadEmployeeTotal();
            int seq = 0;
            try
            {
                DataTable empTable = empData.Tables[0];

                foreach (DataRow dr in empTable.Rows)
                {
                    string employee_no = dr["employee_no"].ToString();
                    Employee emp = new Employee();
                    emp.Organization_no = PosSettings.Default.Organization;
                    emp.Employee_no = employee_no;
                    emp.LoadByEmployeeNo();

                    seq++;
                    string strEmp = string.Format("{0:##\\.}", seq) + emp.FName;

                    double salesAmt = double.Parse(dr["total_amount"].ToString());
                    this.AddOperLine(strEmp, salesAmt, PosContext.Instance.Training);
                    totalSales += salesAmt;
                }

                string strSalesTotal = PosContext.Instance.Parameters.getParam("SalesTotal");
                this.AddOperLine(strSalesTotal, totalSales, PosContext.Instance.Training);
            }

            catch (Exception e)
            {
                Logger.Error(this.GetType().FullName, e.StackTrace, e);
            }



        }

        private void TerminalReportByCollections(TerminalReport report, int start, int end)
        {
            
            this.AddOperLine(PosContext.Instance.Parameters.getParam("Collections"), 0, PosContext.Instance.Training);
            double totalCollection = 0;

            foreach (object obj in report.PosTotal.Totals)
            {
                EclipsePos.Data.Total total = obj as EclipsePos.Data.Total;


                String countLit = null;
                String amountLit = null;


                if ((total.Total_type > start) && (total.Total_type < end))
                {
                    int type = total.Total_type - start;
                    switch (type)
                    {

                        case (int)TotalType.CASH_SALES:

                            countLit = PosContext.Instance.Parameters.getParam("CashSalesCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashSalesAmount");
                            break;

                     
                        case (int)TotalType.GIFT_CERTIFICATE:

                            countLit = PosContext.Instance.Parameters.getParam("GiftCertCount");
                            amountLit = PosContext.Instance.Parameters.getParam("GiftCertAmount");
                            break;

                        case (int)TotalType.CHECK:
                        case (int)TotalType.CHECK_IN_DRAWER:

                            countLit = PosContext.Instance.Parameters.getParam("CheckCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CheckAmount");
                            break;

                        default:
                            break;
                    }

                    if (type > 400 && type < 500)
                    {
                        object objCard = PosContext.Instance.Config.CardMediaByTotalType[type];
                        if (objCard is CardMedia)
                        {
                            CardMedia cMedia = objCard as CardMedia;
                            countLit = cMedia.Media_name;
                            amountLit = cMedia.Media_name;
                        }

                    }

                    if (countLit != null)
                    {
                        this.AddOperLine(amountLit.Trim(), total.Total_amount, PosContext.Instance.Training);
                        totalCollection += total.Total_amount;
                    }

                    
                }
            }

            string strCollectionTotal = PosContext.Instance.Parameters.getParam("CollectionTotal");
            this.AddOperLine(strCollectionTotal, totalCollection, PosContext.Instance.Training);



        }


        private void TerminalReportForCashInDrawer(TerminalReport report, int start, int end)
        {


            this.AddOperLine(PosContext.Instance.Parameters.getParam("CashInDrawer"), 0, PosContext.Instance.Training);
            double cashInDrawer = 0;

			foreach (object obj in report.PosTotal.Totals)
			{
				EclipsePos.Data.Total total = obj as EclipsePos.Data.Total;

				
				String countLit = null;
				String amountLit = null;


				if ( (total.Total_type > start) && (total.Total_type < end) )
				{
					int type = total.Total_type - start;
					switch (type)
					{

						case (int) TotalType.CASH_SALES:

                            countLit = PosContext.Instance.Parameters.getParam("CashSalesCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashSalesAmount");
                            break;

					//	case (int) TotalType.CASH_IN_DRAWER:

					//		countLit = PosContext.Instance.Parameters.getParam("CashInDrCount");
					//		amountLit = PosContext.Instance.Parameters.getParam("CashInDrAmount");
					//		break;



                        case (int)TotalType.CASH_BACK:

                            countLit = PosContext.Instance.Parameters.getParam("CashBackCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashBackAmount");
                            break;

					
					
						case (int)TotalType.PAID_IN:

							countLit = PosContext.Instance.Parameters.getParam("PaidInCount");
							amountLit = PosContext.Instance.Parameters.getParam("PaidInAmount");
							break;

						case (int) TotalType.PAID_OUT:

							countLit = PosContext.Instance.Parameters.getParam("PaidOutCount");
							amountLit = PosContext.Instance.Parameters.getParam("PaidOutAmount");
							break;

						case (int)TotalType.LOAN:

							countLit = PosContext.Instance.Parameters.getParam("LoanCount");
							amountLit = PosContext.Instance.Parameters.getParam("LoanAmount");
							break;

						case (int)TotalType.PICK_UP:

							countLit = PosContext.Instance.Parameters.getParam("PickupCount");
							amountLit = PosContext.Instance.Parameters.getParam("PickupAmount");
							break;

			
						default:
							break;
					}
                    
                    
					if (countLit != null)
					{
						this.AddOperLine(amountLit.Trim(), total.Total_amount, PosContext.Instance.Training);
                        cashInDrawer += total.Total_amount;
                    }
				}
			}

            string strCashInDrawer = PosContext.Instance.Parameters.getParam("CashInDrAmount");
            this.AddOperLine(strCashInDrawer, cashInDrawer, PosContext.Instance.Training);


        }
		#endregion



		#region Clear line

		public void ClearLine()
		{
			//if (this.operDisplay != null)
			//{
			//	operDisplay.Clearln(0);
		    //}

            throw new Exception("Not implimented");
		}
		#endregion

	
		


        

		#region Print Receipt Immediate


		public void PintReceiptImmediate()
		{

		/*	while (true)
			{
				try 
				{

					  Thread.Sleep(Timeout.Infinite);

				}
				catch (ThreadInterruptedException e )
				{
					
					lock (this)
					{

				
						if ( ! this.headerPrinted)
						{
							PrintReceiptHeader();
							this.headerPrinted = true;
						}
					//	PosHardware.Instance.PosPrinter.Open();
					//	PosHardware.Instance.PosPrinter.CheckHealth();

						//---------------------------//
						int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
						StringBuilder tmpStr = new StringBuilder(rWidth);
						for (int i=0;i<rWidth;i++)
						{
							tmpStr.Append(" ");
						}

						if (OperDisplay.Qty.Trim().Length != 0 )
						{
							int Qty = int.Parse(OperDisplay.Qty);
							string str1 = OperDisplay.Item + "  " + OperDisplay.Desc;
				

							string strQty = string.Format("{0:#######}", Qty);
							string strPrice = string.Format("{0:##########.00}", OperDisplay.Price);
							string strAmount = string.Format("{0:############.00}", OperDisplay.Amount);
							try
							{
								tmpStr.Insert(4, strQty);
								tmpStr.Insert(10, "@");
								tmpStr.Insert(12, strPrice);
								tmpStr.Insert((rWidth-strAmount.Length), strAmount);
								//	MessageBox.Show(tmpStr.ToString());
							}
							catch (Exception e2)
							{
								MessageBox.Show(e2.ToString());
							}
			
							PosHardware.Instance.PosPrinter.Println(str1);
							PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0,rWidth));
			
						}
						else
						{
							string strAmount = string.Format("{0:############.00}", OperDisplay.Amount);
							tmpStr.Insert(1, OperDisplay.Desc);
							
							tmpStr.Insert((rWidth-strAmount.Length), strAmount);
							PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0,rWidth));
						}

						//---------------------------//
						//int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
						//string str1 = operDisplay.Item + "  " + operDisplay.Desc;
						//StringBuilder tmpStr = new StringBuilder(rWidth);
 						//if(operDisplay.Qty.Length < 7)
						//{
						//	tmpStr.Append(OperDisplay.Qty.PadLeft(7-OperDisplay.Qty.Length));
						//}
	
						//tmpStr.Append( " @ ");
						//if (operDisplay.Price.Length < 10 )
						//{
						//	tmpStr.Append(OperDisplay.Price.PadLeft(10-OperDisplay.Price.Length));
						//}
						//tmpStr.Append(OperDisplay.Amount.PadLeft(rWidth-tmpStr.Length));

						//string str2 = operDisplay.Qty +
						//				"@" +
						//			  string.Format( "{0:#######.00}", operDisplay.Price ) +
						//			  string.Format( "{0:#######.00}", operDisplay.Amount)+ "\n";	
						//PosHardware.Instance.PosPrinter.Println(str1);
						//PosHardware.Instance.PosPrinter.Println(tmpStr.ToString());
					//	PosHardware.Instance.PosPrinter.Close();
					}
				}
			}
			*/

           // PosContext.Instance.CurrentEj.PrintEj(new Ej.PrintEjDelegate(EjPrintHeading(ej)));

            //PosContext.Instance.CurrentEj.PrintEj();//(new Ej.PrintEjDelegate(this.PosPrintGeneric));

		}


        
		#endregion

	
		#region Open Drawer

		private void OpenDrawer ()
		{
           // lock (this)
           // {

                try
                {
                    if (PosHardware.Instance.CashDrawer != null)
                    {
                        PosHardware.Instance.CashDrawer.OpenDrawer();
                        return;
                    }
                }
                catch
                {
                }
           // }
            
            
            if (PosHardware.Instance.PosPrinter == null) return;
		
		//	PrintJobQueue.Instance.AddJob(new PrintReceiptOpenDrawer());
            

		//	lock (this)
		//	{

				try
				{
					PosHardware.Instance.PosPrinter.OpenCashDrawer();
				    
					}
					catch (Exception e)
					{
						  Logger.Error("Receipt.cs", e.ToString() ); 
					}
		
		//	}
			
		}

		#endregion


		#region Complete 

		private void Complete(EjLine pEvent)
		{
			//if (! this.printImmediate ) return;

			if (PosHardware.Instance.PosPrinter != null )
			{
			
				if (pEvent.TenderComplete )
				{
					//lock(this)
					//{
					//	PrintReceiptTrailler();
					//}
                    //PrintJobQueue.Instance.AddJob(new PrintReceiptTrailler(PosContext.Instance.CurrentEj.EjTaxTotal(),
                    //PosContext.Instance.CurrentEj.EjQtyTotal(), PosContext.Instance.TrxNo, PosSettings.Default.Station,
                    //PosContext.Instance.CurrentEj.SalesPerson.Desc));
					//	PrintJobQueue.Start();
            //        this.headerPrinted = false;
				}
			}

		}

		#endregion


		#region Update display totals
 
		public void UpdateTotals()
		{

			if( (PosContext.Instance.CurrentEj == null) || (PosContext.Instance.CurrentEj.SeqNo == 0) ) return;

			this.operDisplayTotals.SubTotal = string.Format( "{0:##########.00}", PosContext.Instance.CurrentEj.EjSubTotal());
			this.operDisplayTotals.Tax = string.Format( "{0:##########.00}",PosContext.Instance.CurrentEj.EjTaxTotal());
			this.operDisplayTotals.Total = string.Format( "{0:##########.00}", PosContext.Instance.CurrentEj.EjTotal() );
			this.operDisplayTotals.Tendared = string.Format( "{0:##########.00}", PosContext.Instance.CurrentEj.EjTotalTender());
			
			if (PosContext.Instance.CurrentEj.EjBalance() > 0 )
			{
				this.operDisplayTotals.BalanceDue = string.Format( "{0:##########.00}",PosContext.Instance.CurrentEj.EjBalance());
				this.operDisplayTotals.BalanceDueText = PosContext.Instance.Parameters.getParam("BalanceDue"); 
			}
			
			if (PosContext.Instance.CurrentEj.EjBalance() < 0 )
			{
				this.operDisplayTotals.BalanceDue = string.Format( "{0:##########.00}",PosContext.Instance.CurrentEj.EjBalance() * (-1));
				this.operDisplayTotals.BalanceDueText = PosContext.Instance.Parameters.getParam("Change"); 
			}
			
			if (PosContext.Instance.CurrentEj.EjBalance() == 0 )
			{
				this.operDisplayTotals.BalanceDue = ""; 
				this.operDisplayTotals.BalanceDueText = ""; 
			}
		
		}
	
		#endregion


		#region Print receipt trailer

		protected void PrintSavedReceiptTrailer()
		{
			/*
			if (PosHardware.Instance.PosPrinter == null) return;

			PosHardware.Instance.PosPrinter.Println("\n");
			PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.Parameters.getParam("SavedReceipt"));
			PosHardware.Instance.PosPrinter.Println( "\x1B|ca" +	
					PosContext.Instance.Parameters.getParam("TrxNo")+PosContext.Instance.TrxNo );
			PosHardware.Instance.PosPrinter.Println( "\x1B|ca" +
				PosContext.Instance.Parameters.getParam("PosNo") +
				Settings.Instance.PosNumber);
			
			
				this.PrintDate ();

				PosHardware.Instance.PosPrinter.FeedLines(5);
				PosHardware.Instance.PosPrinter.Cut();
				*/
			if (PosHardware.Instance.PosPrinter != null )
			{
                //PrintJobQueue.Instance.AddJob(new PrintReceiptTrailler(PosContext.Instance.CurrentEj.EjTaxTotal(),
                //    PosContext.Instance.CurrentEj.EjQtyTotal(), PosContext.Instance.TrxNo, PosSettings.Default.Station,
                //    PosContext.Instance.CurrentEj.SalesPerson.Desc));
		
			}

            this.headerPrinted = false;
            this.lineHeaderPrinted = false;

            
		}

		#endregion



		#region Void Sale 
		public void VoidSale()
		{

			if (PosHardware.Instance.PosPrinter == null) return;

			//PosHardware.Instance.PosPrinter.Println("\x1B|cA" +PosContext.Instance.Parameters.getParam("VoidSaleText"));

           // this.AddOperLine("\x1B|cA" + PosContext.Instance.Parameters.getParam("VoidSaleText"), 0, PosContext.Instance.Training);
            
           //  this.PrintReceiptTrailler();

           // if (!PosSettings.Default.PrintReceiptImmediate)
           // {
               // PrintJobQueue.Instance.PrintReceiptStart();
           //     PrintJobQueue.Instance.Clear();
           //  }
		
		}
		#endregion

        #region Update EjCustmer
        public void Update(EjCustomer pEvent)
        {

            if (pEvent == null)
            {
                this.operDisplayHeader.CustomerInfo = " ";  
                return; 
            }

            EclipsePos.Data.Customer cus = pEvent.DataRecord() as EclipsePos.Data.Customer;
            if (cus != null)
            {
              
                this.operDisplayHeader.CustomerInfo = cus.Customer_first_name + "/" + cus.Customer_last_name + "/" +
                                cus.Addr1 + cus.Addr2;
            }

        }
        #endregion

        #region Update EjReceiveOnAccount
        public void Update(EjReceiveOnAccount pEvent)
        {
            EclipsePos.Data.Customer cus = pEvent.DataRecord() as EclipsePos.Data.Customer;
            if (cus != null)
            {
                this.operDisplayHeader.CustomerInfo = cus.Customer_first_name + "/" + cus.Customer_last_name + "/" +
                                cus.Addr1 + cus.Addr2;

                this.AddOperLine(PosContext.Instance.Parameters.getParam("MaxDebt"), cus.Max_debt, PosContext.Instance.Training);
                this.AddOperLine(PosContext.Instance.Parameters.getParam("CurrentDebt"), cus.Current_debt, PosContext.Instance.Training);

            }

        }
        #endregion

        #region Print Order Ticket
        public void Update(PrintOrderTicket pEvent)
        {

            if (PosHardware.Instance.PosPrinter == null) return;

            /*
            PrintJobQueue.Instance.Backup();

            //Print subtotal
            //this.OperPrintSubTotal();

            string totalText = PosContext.Instance.Parameters.getParam("BalanceDue");
            double totalAmount = PosContext.Instance.CurrentEj.EjBalance();
            
            //Print discounts and surcharges
            this.PrintOrderDiscoutns();
            this.PrintSurcharges();

           // PrintJobQueue.Instance.AddJob(new PrintReceiptTotal(totalText, totalAmount));


           // PrintJobQueue.Instance.AddJob(new PrintReceiptTrailler(PosContext.Instance.CurrentEj.EjTaxTotal(),
           //         PosContext.Instance.CurrentEj.EjQtyTotal(), PosContext.Instance.TrxNo, PosSettings.Default.Station));

           
            PrintJobQueue.Instance.PintReceipt();
            
            PrintJobQueue.Instance.Restore();
             * */
            
        }
        #endregion


        #region Print Order Ticket
        public void Update(PrintEj pEvent)
        {
            if (PosHardware.Instance.PosPrinter != null)
            {

                PrintJobQueue.Instance.AddJob(new ReceiptPrintJob(
                                            PosSettings.Default.Organization,
                                            PosSettings.Default.Store,
                                            PosSettings.Default.Station,
                                            PosContext.Instance.TrxNo));

                PrintJobQueue.Instance.PrintReceiptStart();
            }


        }
        #endregion



      
        #region Print Trailer
        public void PrintReceiptTrailler()
        {
            //PosHardware.Instance.PosPrinter.FeedLines(1);


            // Print Tax
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            double _tax = PosContext.Instance.CurrentEj.EjTaxTotal();
            //string strAmount = string.Format("{0:############.00}", PosContext.Instance.CurrentEj.EjTaxTotal());
            string strAmount = string.Format("{0:############.00}", _tax);
            tmpStr.Insert(0, PosContext.Instance.Parameters.getParam("TaxIncludedText"));
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));

            StringBuilder tmpLnStr = new StringBuilder(rWidth);
            for (int i5 = 0; i5 < rWidth; i5++)
            {
                tmpLnStr.Append("-");
            }
            PosHardware.Instance.PosPrinter.Println(tmpLnStr.ToString());


            // Print total item count
            double _numberOfItems = PosContext.Instance.CurrentEj.EjQtyTotal();
            StringBuilder tmpStr1 = new StringBuilder(rWidth);
            for (int i1 = 0; i1 < rWidth; i1++)
            {
                tmpStr1.Append(" ");
            }
            string strQty = string.Format("{0:###############}", _numberOfItems);
            tmpStr1.Insert(0, PosContext.Instance.Parameters.getParam("TotalItemCountText"));
            tmpStr1.Insert((rWidth - strQty.Length), strQty);
            PosHardware.Instance.PosPrinter.Println(tmpStr1.ToString().Substring(0, rWidth));



            // Print Transaction No, POS etc
            string _trxNo = PosContext.Instance.TrxNo.ToString();
            string _posNo = PosSettings.Default.Station.ToString();
            StringBuilder tmp = new StringBuilder();
            StringBuilder trxInfo = new StringBuilder();

            trxInfo.Append(PosContext.Instance.Parameters.getParam("TrxNo"));
            //trxInfo.Append(PosContext.Instance.TrxNo);
            trxInfo.Append(_trxNo);
            trxInfo.Append(" ");
            trxInfo.Append(PosContext.Instance.Parameters.getParam("PosNo"));
            //trxInfo.Append(PosSettings.Default.Station);
            trxInfo.Append(_posNo);
            trxInfo.Append("\n");
            trxInfo.Append(PosContext.Instance.Parameters.getParam("ReceiptBottomMOD"));

            //PosHardware.Instance.PosPrinter.Open();
            PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(trxInfo.ToString());
            PosHardware.Instance.PosPrinter.Println(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            PosHardware.Instance.PosPrinter.FeedLines(PosHardware.Instance.PosPrinter.RecLinesToPaperCut);  //5);
            PosHardware.Instance.PosPrinter.Cut();
            //	PosHardware.Instance.Close();

        }
    #endregion  
        



        #region IDisposable Members

        public void Dispose()
		{
			// TODO:  Add Receipt.Dispose implementation
			//t1.Abort();
			try
			{
				
				PrintJobQueue.Instance.Dispose();
				if (PosHardware.Instance.PosPrinter != null)
				{
					PosHardware.Instance.PosPrinter.Close();
				}

			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString()); 
			}

            try
            {
                timer.Stop();
                
            }
            catch
            {
            }
		}

		#endregion
	}	
}	 