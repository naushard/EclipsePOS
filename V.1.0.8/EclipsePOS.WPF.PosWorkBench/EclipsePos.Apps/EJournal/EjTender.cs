using System;
using System.Windows;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.Properties;

using System.Globalization;


namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjTender.
	/// </summary>
	public class EjTender:EjLine 
	{

        /** Prompt for amount. */
        public const int ENTER_AMOUNT = 0;
        /** Get Amount */
        public const int GET_AMOUNT = 1;
        /** Complete the transaction. */
        public const int TENDER_FINAL = 2;

		//	private double tenderTotal = 0;
		private double tenderAmount = 0;
		//private double change = 0;
		private TransTender transTender;
		private bool tenderComplete = false;

		public EjTender():base()
		{
			//
			// TODO: Add constructor logic here
			//
            this.LineType = (int) EjLineType.TENDER;
            
           
		}

		public EjTender(TransTender trans)
		{
			this.transTender = trans; 
			this.LineType = (int) EjLineType.TENDER;
		
		}
 
		#region Properties

		public override bool TenderComplete
		{
			get 
			{
				return tenderComplete;
			}
			
		}

		public override string Desc
		{
			get
			{ 
				return transTender.Tender_desc;
			}
			set
			{
				transTender.Tender_desc = value;
			}
		}

		public override double Amount
		{
			get
			{
				return transTender.Amount;
			}
			set
			{
			}
		}

		public override double ExtAmount
		{
			get
			{
				return this.Amount;
			}
			set
			{
			}
		}

		public override int LineNo
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}


		public override int State
		{
			get
			{
				return this.transTender.State;
			}
			set
			{
				this.transTender.State = value;
			}
		}

		public override string SKU
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		
		public override double Quantity
		{
			get
			{
				return 0;
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
				return transTender.Change_amount;
			}
			set
			{
			}
		}

		public override int SeqNo
		{
			set
			{
				this.transTender.Seq_no = value;
			}
			get
			{
				return this.transTender.Seq_no;
			}
		}

 
		#endregion


		public override  void UpdateTotals ()
		{
			//return null;
			if (PosContext.Instance.Training)
				return;

            EclipsePos.Data.Total total1 = new EclipsePos.Data.Total();
            total1.AddToTotal(
            PosSettings.Default.Organization,
            PosContext.Instance.RetailStore.Retail_store_no,
            PosSettings.Default.Station,
            EclipsePos.Data.TotalName.DAILY_BASE,
            TotalType.CASH_SALES,
            Amount-Change);


			EclipsePos.Data.Total total2 = new EclipsePos.Data.Total();
			total2.AddToTotal(
            PosSettings.Default.Organization,
            PosContext.Instance.RetailStore.Retail_store_no,
            PosSettings.Default.Station,
            EclipsePos.Data.TotalName.DAILY_BASE,
			TotalType.CASH_IN_DRAWER,
			Amount-Change);


            int count = PosContext.Instance.CurrentEj.SalesPerson.Count;
            PosContext.Instance.CurrentEj.SalesPerson.ForEach(delegate(EjSalesPerson ejSalesPerson) {

                TransSalesPerson transSalesPerson = (TransSalesPerson)ejSalesPerson.DataRecord();
                string employee_id = transSalesPerson.Employee_no;

                EclipsePos.Data.PosEmployeeTotal empTotal = new EclipsePos.Data.PosEmployeeTotal();
                empTotal.AddToEmployeeTotalAndCount(
                PosSettings.Default.Organization,
                PosContext.Instance.RetailStore.Retail_store_no,
                PosSettings.Default.Station,
                employee_id,
                0,
                EclipsePos.Data.TotalName.DAILY_BASE,
                TotalType.CASH_IN_DRAWER,
                1,
                (Amount - Change)/count
                );

            
            });

            

            this.transTender.State = (int)EjLineStates.PAID;
            this.transTender.UpdateState();
	
		}


		public override bool Save()
		{
			if (!PosContext.Instance.Training)
			{
				try 
				{
					transTender.Add();
				}
				catch ( Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			}
			return true;
		}


        public override void SaveState(EjLineStates state)
        {
            transTender.State = (int)state;
            transTender.UpdateState();
        }


		

		public  override void Engage(int keyValue)
		{

            

            switch (this.PeekState())
            {


                case ENTER_AMOUNT:
                    //Try to load media prompt
                    try
                    {
                        int menuNo = int.Parse(PosContext.Instance.Parameters.getParam("CashMediaMenuNo"));
                        PosContext.Instance.CurrentPosDisplay.LoadMenu(menuNo);
                    }
                    catch
                    {
                    }


                    if (PosContext.Instance.CurrentEj.EjBalance() > 0)
                    {

                        PosContext.Instance.ClearInput();
                        this.PromptText = PosContext.Instance.Parameters.getParam("PromptAmount");
                        PosContext.Instance.Operprompt.Update(this);

                        //Wait for the Enter key after after input amount 
                        this.PopState();
                        this.PushState(GET_AMOUNT);
                        return;
                    }
                    else
                    {
                        this.PopState();
                        this.tenderAmount = PosContext.Instance.CurrentEj.EjBalance();
                        PosContext.Instance.ClearInput();
                        this.PushState(TENDER_FINAL);
                        PosEventStack.Instance.NextEvent();
                    }



                    break;

                case GET_AMOUNT:

                    this.PopState();

                    if (PosContext.Instance.InputLine.Length > 0)
                    {
                        this.tenderAmount = PosContext.Instance.PosMath.GetAmount(PosContext.Instance.InputDouble()  );
                    }
                    else
                    {
                        this.tenderAmount = PosContext.Instance.CurrentEj.EjBalance();
                    }
                    
                    PosContext.Instance.ClearInput();
                    this.PushState(TENDER_FINAL);
                    PosEventStack.Instance.NextEvent();
                    break;

                case TENDER_FINAL:


                   
                    //double tenderTotal = 0;
                    //double tenderAmount = 0;
                    double change = 0;

                    this.PopState();
                    transTender = new TransTender();
                    

                   /* if (PosContext.Instance.InputLine.Length > 0)
                    {
                        tenderAmount = Math.Round(double.Parse(PosContext.Instance.InputLine) / 100.00, 2);
                    }
                    else
                    {
                        tenderAmount = PosContext.Instance.CurrentEj.EjBalance();
                    }
                    * */

                    

                    transTender = new TransTender();

                    transTender.Trans_no = PosContext.Instance.TrxNo;
                    transTender.Organization_no = PosSettings.Default.Organization;
                    transTender.Store_no = PosSettings.Default.Store;
                    transTender.Pos_no = PosSettings.Default.Station;
                    transTender.Locale_country = RegionInfo.CurrentRegion.TwoLetterISORegionName;
                    transTender.Locale_language = PosContext.Instance.Organization.Home_currency;
                    transTender.Tendertype = (int)TransTender.TenderTypes.CASH;
                    transTender.Data_capture = "";
                    transTender.Amount = tenderAmount;
                    transTender.Tender_desc = PosContext.Instance.Parameters.getParam("CashTender");
                    transTender.Change_desc = "";
                    transTender.Change_amount = 0;
                    transTender.State = (int)EjLineStates.IN_PROGRESS;
                    //Check for balance due

                    if (PosContext.Instance.CurrentEj.EjBalance() > tenderAmount)
                    {
                        change = 0;
                        transTender.Change_amount = 0; //(PosContext.Instance.CurrentEj.EjBalance() - tenderAmount);
                        transTender.Change_desc = PosContext.Instance.Parameters.getParam("Balance");
                        this.PromptText = PosContext.Instance.Parameters.getParam("BalanceDue");

                        // Show balance due on prompt

                        tenderComplete = false;
                        PosContext.Instance.Operprompt.Update(this);
                    }
                    else
                    {
                        tenderComplete = true;
                        change = tenderAmount - PosContext.Instance.CurrentEj.EjBalance();
                        transTender.Change_amount = change;
                        transTender.Change_desc = PosContext.Instance.Parameters.getParam("Change");
                    }
                    
                    PosContext.Instance.CurrentEj.EjAdd(this);
                    transTender.Seq_no = PosContext.Instance.CurrentEj.SeqNo;
                    
                    // if not training mode
                    if (!PosContext.Instance.Training)
                    {
                        transTender.Add();
                    }

                   


                    //	MessageBox.Show(this.PromptText+ string.Format("{0:##########.00}", change));//  = "Balance due";

                    // PosContext.Instance.Operprompt.Update(this);
                    PosContext.Instance.Receipt.Update(this);
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.InputLine = "";
                    PosContext.Instance.HomeGUI();
                    PosEventStack.Instance.NextEvent();

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

		public override IRelatable DataRecord()
		{
			return transTender;
		}


		//public override double Change
		//{
		//	get
		//	{
		//		return null;
		//	}
		//}

        public override void PrintEj()
        {
            
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            
            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            string strAmount = string.Format("{0:############.00}", transTender.Amount );
            tmpStr.Insert(0, transTender.Tender_desc);
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);

            //PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
			
        }

        

	}
}
