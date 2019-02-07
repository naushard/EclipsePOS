using System;
using System.Windows;
using System.Text;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;

namespace EclipsePos.Apps.EJournal
{
	/// <summary>
	/// Summary description for EjHeader.
	/// </summary>
	public class EjHeader:EjLine	
	{
		private Transaction trans;
		private int transNo;
		private int seqNo = 0;
        private string tableName = "";

		public EjHeader()
		{
			//
			// TODO: Add constructor logic here
			//
			this.LineType = (int)EjLineType.TRANS_HEADER;
            this.seqNo = 0;
            this.ExtAmount = 0;
            this.LineNo = 0;
            this.MessageText = "";
            this.NumberType = 0;
            this.PromptText = "";
            this.Quantity = 0;
            this.Amount = 0;

		}

		public EjHeader(Transaction trans1):this()
		{
			trans = trans1;
            this.Desc = "Trans Header";
            this.TransNo = trans1.Trans_no;
            this.Amount = 0.0;
            this.Change = 0.0;
            this.ExtAmount = 0.0;
            //this.isDialog = false;
            this.LineNo = 0;
            this.LineType = (int)EjLineType.TRANS_HEADER;
            this.MessageText = "Trans Header";
            this.NumberType = 0;
            this.PromptText = "Trans Headr";
            this.Quantity = 0;
            this.seqNo = 0;
            this.SKU = "";
            this.State = trans1.State;
            this.TaxAmount = 0.0;
            this.TableName = trans1.Table_name;
            
        }



		public override void UpdateTotals ()
		{
		}

        public override void Engage(int keyValue)
        {
            PosContext.Instance.RetailStore.GetNextTransNo();
            int newTransNo = PosContext.Instance.RetailStore.Last_trans_no;
            PosContext.Instance.TrxNo = newTransNo;
            trans = new Transaction(newTransNo);
            trans.Config_no = PosContext.Instance.Config.ConfigNo;
            trans.Store_no = PosSettings.Default.Store;
            trans.Organization_no = PosSettings.Default.Organization;
            //trans.Trans_no = newTransNo;
            trans.Pos_no = PosSettings.Default.Station;
            trans.Employee_login_no = PosContext.Instance.Employee.Logon_no;
            trans.Drawer_no = PosContext.Instance.DrawerNo;
            trans.Table_name = PosContext.Instance.TableName;
            if ( string.IsNullOrEmpty(PosContext.Instance.RetailStore.Customer_tax_id))
            {
                trans.Customer_tax_id = PosSettings.Default.Store;
            }
            else
            {
                trans.Customer_tax_id = PosContext.Instance.RetailStore.Customer_tax_id;
            }
            //PosContext.Instance.RetailStore.Customer_tax_id;

            trans.State = (int)Transaction.Status.IN_PROGRESS;
            
           
            trans.Trans_type = PosContext.Instance.TransactionType;

            //Training mode
            if (PosContext.Instance.Training)
            {
                trans.Training_mode = 1;
            }
            else
            {
                trans.Training_mode = 0;
            }

            this.Save();

            PosContext.Instance.Receipt.Update(this);
        }

            

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

		public override bool Save()
		{
			trans.Add();
			return true;
		}

		public bool UpdateState(int state)
		{
            trans.State = state;
            trans.Complete_time = System.DateTime.Now;
            trans.UpdateState();
			return true;
		}

        public override void SaveState(EjLineStates state)
        {
            trans.State = (int)state;
            trans.Complete_time = System.DateTime.Now;
            trans.UpdateState();
        }

		public override IRelatable DataRecord()
		{
			return trans;
		}



		#region Properties

		public Transaction Transaction
		{
			set
			{
				trans = value;
			}
			get
			{
				return trans;
			}
		
		}

        public int PosNo
        {
            get
            {
                return this.trans.Pos_no;
            }
        }

		public int TransNo
		{
			get
			{
				return this.trans.Trans_no;
			}
			set 
			{
				transNo= value;
			}
		}

        private string desc;
		public override string Desc
		{
			get
			{
				return this.desc;
			}
			set
			{
				this.desc = value;
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

		public override double ExtAmount
		{
			get
			{
				return 0;
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
				return 0;
			}
			set
			{
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

		public override int State
		{
			get
			{
				return this.trans.State;
			}
			set
			{
				this.trans.State = value;
			}
		}

		public override bool TenderComplete
		{
			get
			{
				return true;
			}
		}

		public override int SeqNo
		{
			set
			{
				seqNo  = value;
			}
			get
			{
				return this.seqNo;
			}
		}

        public string TableName
        {
            get
            {
                return trans.Table_name;
            }
            set
            {
                this.trans.Table_name = value;
            }
        }



		

		#endregion
       
        
        public override void PrintEj()
        {
            PrintEjHeading();
            if ((trans.Trans_type == (int)Transaction.Types.SALES) ||
                (trans.Trans_type == (int)Transaction.Types.RETURN))
            {
                PrintEjLineHeading();
            }
            else
            {
                PrintReportHeading();
            }
        }

        private void PrintEjHeading()
        {
           // PosHardware.Instance.PosPrinter.Println(this.ToString());

             // PosHardware.Instance.PosPrinter.Println("\x1B|cA" + " ");
            PosHardware.Instance.PosPrinter.FeedLines(1);


			string logoFileName = PosContext.Instance.Parameters.getParam("ReceiptLogo");

            int recWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            try
            {
                PosHardware.Instance.PosPrinter.PrintLogo(logoFileName);
            }
            catch { }
            
            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.RetailStoreName.Trim()) && PosContext.Instance.RetailStore.RetailStoreName.Trim().Length > 0)
                {
                    PosHardware.Instance.PosPrinter.PrintBold(PosContext.Instance.RetailStore.RetailStoreName.Trim());
                  //  PosHardware.Instance.PosPrinter.PrintLineCenter(  PosContext.Instance.RetailStore.RetailStoreName.Trim());
                }
            }
            catch { }

			
            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.Address1.Trim()) && PosContext.Instance.RetailStore.Address1.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.RetailStore.Address1.Trim() );

                    string address1 = PosContext.Instance.RetailStore.Address1.Trim();
                    if (address1.Length > recWidth)
                    {
                        address1.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(address1);
                }
            }
            catch { }

            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.Address2.Trim()) && PosContext.Instance.RetailStore.Address2.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.RetailStore.Address2.Trim());
                    string address2 = PosContext.Instance.RetailStore.Address2.Trim();
                    if (address2.Length > recWidth)
                    {
                        address2.Substring(0, recWidth);
                    }


                    PosHardware.Instance.PosPrinter.PrintLineCenter(address2);
                }
            }
            catch { }



            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.Address3.Trim()) && PosContext.Instance.RetailStore.Address3.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.RetailStore.Address3.Trim());
                    string address3 = PosContext.Instance.RetailStore.Address3.Trim();
                    if (address3.Length > recWidth)
                    {
                        address3.Substring(0, recWidth);
                    }


                    PosHardware.Instance.PosPrinter.PrintLineCenter(address3);
                }
            }
            catch { }



            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.Address4.Trim()) && PosContext.Instance.RetailStore.Address4.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.RetailStore.Address4.Trim());
                    string address4 = PosContext.Instance.RetailStore.Address4.Trim();
                    if (address4.Length > recWidth)
                    {
                        address4.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(address4);
                }
            }
            catch { }



            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.City.Trim()) && PosContext.Instance.RetailStore.City.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" + PosContext.Instance.RetailStore.Address5.Trim() +PosContext.Instance.RetailStore.PostalCode);
                    string city = PosContext.Instance.RetailStore.City.Trim();
                    if (city.Length > recWidth)
                    {
                        city.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(city);
                }
            }
            catch { }


            try
            {
                if (!String.IsNullOrEmpty(PosContext.Instance.RetailStore.Phone.Trim()) && PosContext.Instance.RetailStore.Phone.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA" +"TEL: "+ PosContext.Instance.RetailStore.Phone.Trim() );
                    string phone = PosContext.Instance.RetailStore.Phone.Trim();
                    if (phone.Length > recWidth)
                    {
                        phone.Substring(0, recWidth);
                    }


                    PosHardware.Instance.PosPrinter.PrintLineCenter(phone);
                }
            }
            catch { }


			
			int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
			StringBuilder sb = new StringBuilder();
			for ( int i = 1; i <= rWidth; i++ )
			{
				sb.Append("-");
			}
			
			//PosHardware.Instance.PosPrinter.Println("\x1B|cA"+sb.ToString());
            PosHardware.Instance.PosPrinter.PrintLineCenter(sb.ToString());
			bool printEndLine = false;	
			
			//1
            try
            {
                string receiptTopMod1 = PosContext.Instance.Parameters.getParam("ReceiptTopMOD1");
                if (!receiptTopMod1.Equals("ReceiptTopMOD1") && receiptTopMod1.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA"+receiptTopMod1  );
                    if (receiptTopMod1.Length > recWidth)
                    {
                        receiptTopMod1.Substring(0, recWidth);
                    }


                    PosHardware.Instance.PosPrinter.PrintLineCenter(receiptTopMod1);

                    printEndLine = true;
                }
            }
            catch
            {
            }
			
			//2
            try
            {
                string receiptTopMod2 = PosContext.Instance.Parameters.getParam("ReceiptTopMOD2");
                if (!receiptTopMod2.Equals("ReceiptTopMOD2") && receiptTopMod2.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA"+receiptTopMod2);
                    if (receiptTopMod2.Length > recWidth)
                    {
                        receiptTopMod2.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(receiptTopMod2);
                    printEndLine = true;
                }
            }
            catch { }
			
			//3
            try
            {
                string receiptTopMod3 = PosContext.Instance.Parameters.getParam("ReceiptTopMOD3");
                if (!receiptTopMod3.Equals("ReceiptTopMOD3") && receiptTopMod3.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA "+receiptTopMod3);
                    if (receiptTopMod3.Length > recWidth)
                    {
                        receiptTopMod3.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(receiptTopMod3);
                    printEndLine = true;
                }
            }
            catch { }

			
			//4
            try
            {
                string receiptTopMod4 = PosContext.Instance.Parameters.getParam("ReceiptTopMOD4");
                if (!receiptTopMod4.Equals("ReceiptTopMOD4") && receiptTopMod4.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA"+receiptTopMod4);
                    if (receiptTopMod4.Length > recWidth)
                    {
                        receiptTopMod4.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(receiptTopMod4);
                    printEndLine = true;
                }
            }
            catch { }

			//5
            try
            {
                string receiptTopMod5 = PosContext.Instance.Parameters.getParam("ReceiptTopMOD5");
                if (!receiptTopMod5.Equals("ReceiptTopMOD5") && receiptTopMod5.Trim().Length > 0)
                {
                    //PosHardware.Instance.PosPrinter.Println("\x1B|cA"+receiptTopMod5);
                    if (receiptTopMod5.Length > recWidth)
                    {
                        receiptTopMod5.Substring(0, recWidth);
                    }

                    PosHardware.Instance.PosPrinter.PrintLineCenter(receiptTopMod5);
                    printEndLine = true;
                }
            }
            catch { }
			
			//if( printEndLine ) PosHardware.Instance.PosPrinter.Println("\x1B|cA"+sb.ToString());
            if (printEndLine) PosHardware.Instance.PosPrinter.PrintLineCenter(sb.ToString());

			//string currency = System.Environment.GetEnvironmentVariable("Currency");
			//PosHardware.Instance.PosPrinter.Println("\x1B|rA"+currency.PadRight(6,' ')) ;
		}



        private void PrintEjLineHeading()
        {
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= rWidth; i++)
            {
                sb.Append("-");
            }

            string itemHeading = "Item/Desc.";
            string qtyHeading = "Qty";
            string priceHeading = "U.Price";
            string amtHeading = "Amount";

            int amtStartPos = rWidth - amtHeading.Length;
            int priceStartPos = ((int)(rWidth * 3 / 4)) - priceHeading.Length;
            int qtyStartPos = ((int)(rWidth * 2 / 4)) - qtyHeading.Length;

            tmpStr.Insert(0, itemHeading);
            tmpStr.Insert(qtyStartPos, qtyHeading);
            tmpStr.Insert(priceStartPos, priceHeading);
            tmpStr.Insert(amtStartPos, amtHeading);

            // PosHardware.Instance.PosPrinter.PrintEmphasized(tmpStr.ToString());
            PosHardware.Instance.PosPrinter.PrintEmphasized(tmpStr.ToString().Substring(0, rWidth));
            PosHardware.Instance.PosPrinter.Println(sb.ToString());

        }


        private void PrintReportHeading()
        {
            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= rWidth; i++)
            {
                sb.Append("-");
            }

            string reportHeading = "";

            switch (trans.Trans_type)
            {
                case 1:
                    reportHeading = "Sales";
                    break;
                case 2:
                    reportHeading = "Logon";
                    break;
                case 3:
                    reportHeading = "Logoff";
                    break;
                case 4:
                    reportHeading = "Return";
                    break;
                case 5:
                    reportHeading = "Blance";
                    break;
                case 6:
                    reportHeading = "Count";
                    break;
                case 7:
                    reportHeading = "Adjustment";
                    break;
                case 8:
                    reportHeading = "Dine In";
                    break;
                case 9:
                    reportHeading = "Carry Out";
                    break;
                case 10:
                    reportHeading = "Paid In";
                    break;
                case 11:
                    reportHeading = "Paid Out";
                    break;
                case 12:
                    reportHeading = "Loan";
                    break;
                case 13:
                    reportHeading = "Petty Cash In";
                    break;
                case 14:
                    reportHeading = "Petty Cash Out";
                    break;
                case 15:
                    reportHeading = "Bank In";
                    break;
                case 16:
                    reportHeading = "Pick Up";
                    break;
                default:
                    reportHeading  = " ";
                    break;
            }


            tmpStr.Insert(5, reportHeading);
            
            PosHardware.Instance.PosPrinter.PrintLineCenter(tmpStr.ToString().Substring(0, rWidth));
            //PosHardware.Instance.PosPrinter.PrintBold(tmpStr.ToString().Substring(0, rWidth));

        }





	}
}
