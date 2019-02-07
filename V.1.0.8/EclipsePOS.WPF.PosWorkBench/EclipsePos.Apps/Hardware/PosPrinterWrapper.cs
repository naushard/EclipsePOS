using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Threading;

using Microsoft.PointOfService;

using EclipsePos.Apps.Util;
using EclipsePos.Apps.Context;



namespace EclipsePos.Apps.Hardware
{

	/// <summary>
	/// Summary description for PosPrinter.
	/// </summary>
	
	public class PosPrinterWrapper :HardwareSupport	 
	{


		#region Variables 

		//	private POS.Devices.OPOSPOSPrinterClass control = null;
		//	private StringBuffer scratch;
		private string quantity;
		private string plu; 
		private string item;
		private string desc;
		private string price;
		private string amount;
		private string trx;
		private string pos;
		private string user;
		private string date;
		private int qtyWidth = 4;
		private int itemWidth = 5;
		private int amountWidth = 12;
		private int totalWidth = 40;
		private int cutPercent = 90;
		private int characterSet = 858;
//		private char [] boldSeq = null;

		private string deviceName;
		private string deviceText = "PosPrinter";
		private string statusText = "Error";
		private PosPrinterStatus status = PosPrinterStatus.Inactive;
		private string deviceHealthText = "Unknown";
	//	private enum healthCheckLevel = HealthCheckLevel.External;
	//	private int printMode = PRINT_IMMEDIATE;
	//	private const int	PRINT_IMMEDIATE=1;
	//	private const int	PRINTT_BUFFERED = 2;
	//	private Microsoft.PointOfService.PosExplorer posExplorer;
	//	private Microsoft.PointOfService.DeviceInfo device;
		private Microsoft.PointOfService.PosPrinter posPrinter;
		private int receiptWidth;

        public delegate void StausChangedEventHandler(object sender, int deviceStatus);
        public event StausChangedEventHandler StatusEvent;
		
		#endregion


		#region Constructor
			public PosPrinterWrapper(PosPrinter pPosPrinter) //string pDeviceName, PosExplorer explorer)
			{
				this.posPrinter = pPosPrinter;
			//	this.posExplorer = explorer; 
			//	this.deviceName = pDeviceName;
			//	System.Resources.ResourceManager resources = new System.Resources.ResourceManager("EclipsePos.Hardware.PosPrinterWrapper", Assembly.GetExecutingAssembly());
				cutPercent = 90; //int.Parse(resources.GetString("CutPercent"));
				totalWidth = 10; //int.Parse(resources.GetString("TotalWidth"));
				qtyWidth =  10; //int.Parse(resources.GetString("QtyWidth"));
				itemWidth = 16; //int.Parse(resources.GetString("ItemWidth"));
				deviceHealthText =  "HealthText"; // resources.GetString("HealthText");
	
			
			}
		#endregion 

		
		#region Properties
	
		public int QtyWidth
		{
			get { return qtyWidth; }
			set { qtyWidth = value; }
			
			
		}

		public int ItemWidth
		{
			get { return itemWidth; }
			set { itemWidth=value;  } 
		}

		
		public int AmountWidth
		{
			get { return amountWidth;	}
			set { amountWidth = value;  }
		}

		
		public int TotalWidth 
		{
			get { return totalWidth; }
			set { totalWidth=value; }  
		}


	//	public int PrintMode 
	//	{
	//		get { return printMode;}
	//		set { printMode=value; }
	//	}

		public string Qty
		{
			set {quantity = value;}
			get { return quantity;}
		}
    
		public string PLU 
		{
			get { return plu; }
			set { plu = value;}

		}

		public string Item 
		{
			get { return item; }
			set { item = value; }
		}

		
		public string Desc 
		{
			get { return desc; }
			set { desc = value; }
		}
    
		public string Price 
		{
			get { return price; }
			set { price = value; }

		}


		public string Amount 
		{
			get { return amount; }
			set { amount = value; }
		}


		public string TrxNo 
		{
			get { return trx; }
			set { trx = value; }
		}


		public string PosNo 
		{
			get { return pos; }
			set { pos = value; }
		}


		public string  Operator 
		{
			get { return user; }
			set { user = value; }
		}

		public string Date 
		{
			get { return date; }
			set { date = value; }
		}
		
		public string HealthText 
		{
			get { return deviceHealthText; }
			set { deviceHealthText = value; }
		}

		public int CutPercent 
		{
			get { return cutPercent; }
			set { cutPercent = value; }
		}

		public int ReceiptLineChars
		{
			get 
			{
				return posPrinter.RecLineChars;
			}
		}


		public int RecLinesToPaperCut
		{
			get
			{
				return posPrinter.RecLinesToPaperCut;
			}
		}
		
		#endregion

				
		#region Cut 
		
		public void Cut ()
		{
			 
			Logger.Info( "PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Receipt> cut-----", PosSettings.Default.Debug);	
						

			if (status == PosPrinterStatus.Inactive) return;

			
			try
			{
					posPrinter.CutPaper(cutPercent);
								
			}
			catch (PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", "Printer error in cut " + pce.ToString());
				
					 
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", "Uknown exception in PosPrinter, cut : " + e.ToString());
				
			}
		}

		#endregion

		#region FeedLines
		public void FeedLines( int lines)
		{

			
			if (status == PosPrinterStatus.Inactive) return;

			try
			{
				posPrinter.PrintNormal( PrinterStation.Receipt, "\x1B|" + lines + "lF" ); //+ +"\x1B|1lF");
			}
			catch (PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + pce.ToString());
				
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Uknown exception in PosPrinter, printNormal : " + e.ToString());
				
			}

		}

		#endregion


		
		#region PrintBold

		public void PrintBold (string text) 
		{
           	Logger.Info("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Receipt> " + text, PosSettings.Default.Debug);

			if ( status == PosPrinterStatus.Inactive ) return;

            
			try
			{
               // this.FeedLines(1);
				string formatedText = "\x1B|cA\x1B|2C"+text.Replace("ESC", ((char) 27).ToString()) + "\x1B|1lF";
                posPrinter.PrintNormal( PrinterStation.Receipt, formatedText);
			}
			catch (ThreadInterruptedException tx)
			{
				// Attempt to print again
                string formatedText = "\x1B|cA\x1B|2C" + text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
				posPrinter.PrintNormal( PrinterStation.Receipt, formatedText);
			}
			catch (PosControlException pce)
			{
				Logger.Error( "PosPrinterWrapper.cs", pce.ToString());
				
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", e.ToString());
		
			}


			
		
		}

		#endregion

        #region PrintEmphasized

        public void PrintEmphasized(string text)
        {

            Logger.Info("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Receipt> " + text, PosSettings.Default.Debug);

            if (status == PosPrinterStatus.Inactive) return;

            try
            {
                string formatedText = "\x1B|bC" + text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
                posPrinter.PrintNormal(PrinterStation.Receipt, formatedText);
            }
            catch (ThreadInterruptedException tx)
            {
                // Attempt to print again
                string formatedText = "\x1B|45" + text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
                posPrinter.PrintNormal(PrinterStation.Receipt, formatedText);
            }
            catch (PosControlException pce)
            {
                Logger.Error("PosPrinterWrapper.cs", pce.ToString());

            }
            catch (Exception e)
            {
                Logger.Error("PosPrinterWrapper.cs", e.ToString());

            }




        }

        #endregion


		#region Println 

		public void Println (String text)
		{

			Logger.Info("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Receipt> " + text, PosSettings.Default.Debug);

			if (status == PosPrinterStatus.Inactive) return;

			try
			{
				//System.out.println("text length at PosPrinter " + text.length() );
				//	char[] leftAlignSeq = {27 , 97, 48};
				//	text = new String(leftAlignSeq)+text;
				
				posPrinter.PrintNormal( PrinterStation.Receipt, text+"\x1B|1lF");
			}
			catch (PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", pce.ToString());
				
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", "Uknown exception in PosPrinter, printNormal : " + e.ToString());
				
			}
		}

		#endregion



        #region PrintLineCenter

        public void PrintLineCenter(String text)
        {

            Logger.Info("PosPrinterWrapper.cs", "PosPrinterWrapper.cs :" + "Receipt> " + text, PosSettings.Default.Debug);

            if (status == PosPrinterStatus.Inactive) return;

            try
            {
                string formatedText = "\x1B|cA" + text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
                posPrinter.PrintNormal(PrinterStation.Receipt, formatedText);
                                      
                
            }
            catch (PosControlException pce)
            {
                Logger.Error("PosPrinterWrapper.cs", pce.ToString());

            }
            catch (Exception e)
            {
                Logger.Error("PosPrinterWrapper.cs", "Uknown exception in PosPrinter, printNormal : " + e.ToString());

            }
        }

        #endregion



		#region PrintLogo
		public void PrintLogo (string fileName)
		{

			Logger.Info( "PosPrinterWrapper.cs", "PosPrinterWrapper.cs : Receipt> logo --- fileName", PosSettings.Default.Debug);

			if (status == PosPrinterStatus.Inactive ) return;
			//  fileName = "F:\\pos2\\pos\\pdb\\pics\\logo.bmp";

            int bitmapWidth = 150;

            try
            {
                bitmapWidth = int.Parse(PosContext.Instance.Parameters.getParam("LogoBitmapWidth"));
            }
            catch(Exception e)
            {

            }
			try
			{
				posPrinter.PrintBitmap(PrinterStation.Receipt, 
					fileName, 
					bitmapWidth,
					PosPrinter.PrinterBitmapCenter);
				
			}
			catch (ThreadInterruptedException tx)
			{
				// Attempt to print again
				//posPrinter.PrintBitmap(PrinterStation.Receipt, 
				//	fileName, 
				//	30,
				//	PosPrinter.PrinterBitmapCenter);
			
			}
			catch (PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", "Pos Control Exception in PosPrinter, printLogo : " + pce.ToString ());
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", "Uknown exception in PosPrinter, printLogo : " + e.ToString ());
			}
		}

		#endregion


		#region Open	 
		public void Open ()
		{
	 	//	posExplorer = new PosExplorer();	
		//	control =  new OPOSPOSPrinterClass();//new jpos.POSPrinter ();
			try
			{
				
				//device = posExplorer.GetDevice(DeviceType.PosPrinter ,this.deviceName );
				//Logger.Info("PosPrinterWrapper.cs", device.Description, Settings.Instance.Debug);
				//posPrinter = (Microsoft.PointOfService.PosPrinter) posExplorer.CreateInstance(device);
				posPrinter.Open();
				posPrinter.Claim(1000);
				posPrinter.DeviceEnabled = true;
				deviceText = posPrinter.DeviceDescription;
				statusText = posPrinter.State.ToString();
               
			
			
				string healthText = posPrinter.CheckHealth( HealthCheckLevel.Internal);
				Logger.Info( "PosPrinterWrapper.cs", "CheckHealthText INTERNAL    : " + healthText, PosSettings.Default.Debug);
						
				status = PosPrinterStatus.Active;
                this.RaiseStatusChangedEvent();

                
			}
			catch (PosControlException e1)
			{
                //MessageBox.Show("ex1" + e1.ToString() );
				Logger.Error( "PosPrinterWrapper.cs", e1.ToString() );
				status = PosPrinterStatus.Inactive;
                this.RaiseStatusChangedEvent();
                
			}
			catch (Exception e2)
			{
              //  MessageBox.Show("Ex2" + e2.ToString() );
				Logger.Error( "PosPrinterWrapper.cs", e2.ToString ());
				status = PosPrinterStatus.Inactive;
                this.RaiseStatusChangedEvent();
                
			}
			
		}
		
		#endregion


		#region CheckHealth

		public bool CheckHealth ()
		{
			deviceHealthText = null;

			if ( status == PosPrinterStatus.Inactive )
			{
				Reset();
			}

			try
			{
				posPrinter.CheckHealth(HealthCheckLevel.Internal);
				deviceHealthText = posPrinter.CheckHealthText;
				status = PosPrinterStatus.Active;
                this.RaiseStatusChangedEvent();
				return true;
			}
			catch (PosControlException pce)
			{ 
				Logger.Error("PosPrinterWrapper.cs", pce.ToString());
				statusText = "Failed";
				status = PosPrinterStatus.Inactive;
                this.RaiseStatusChangedEvent();
				return false;
			}
			catch (Exception e)
			{
				Logger.Error("PosPrinterWrapper.cs", e.ToString());
				statusText = "Failed";
				status = PosPrinterStatus.Inactive;
                this.RaiseStatusChangedEvent();
				return false;
			}
			
		}

		#endregion


		#region Reset

		public bool Reset ()
		{
			
			try
			{
				if (posPrinter.DeviceEnabled )
				{
					posPrinter.DeviceEnabled = false;
				}

				if (posPrinter.Claimed )
				{
					posPrinter.Release();
				}
				
				posPrinter.Close();
			//	posPrinter = null;
				
			}
			catch ( PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", pce.ToString ());
				//return false;
			}

			Open ();
			return true;
		}

		#endregion

		
		#region DeviceText
		public string DeviceText()
		{
			return deviceText;
		}
		#endregion

		#region StatusText
		public string StatusText()
		{
			return statusText;
		}
		#endregion

			
		#region Close

		public void Close()
		{
			//if (status == PosPrinterStatus.Inactive) return;
	
			try 
			{
			
				posPrinter.Release();
				posPrinter.Close();
				status = PosPrinterStatus.Inactive;
			//	posPrinter = null;
			//	MessageBox.Show("Release and Closed");

			}
			catch (Exception e )
			{
				Logger.Error( "PosPrinterWrapper.cs", e.ToString ());
				status = PosPrinterStatus.Inactive;
						  
			}
	

		
		}
	
		#endregion

		#region Open attached Cash Drawer  
		
		public void OpenCashDrawer()
		{
			Logger.Info("PosPrinterWrapper.cs", "Receipt> " + "---", PosSettings.Default.Debug);

            //if ( PosHardware.Instance.ca
			if (status == PosPrinterStatus.Inactive) return;

			try
			{
				posPrinter.PrintNormal( PrinterStation.Receipt, "\x1B"+"\x70"+"\x0"+"\x19"+ "\xFA"); //+"\x1B|1lF");
			}
			catch (PosControlException pce)
			{
				Logger.Error("PosPrinterWrapper.cs", pce.ToString());
			
			}
			catch (Exception e)
			{
				Logger.Error( "PosPrinterWrapper.cs" , e.ToString());
			}

		}
		#endregion


        #region Raise Status Event
        protected virtual void RaiseStatusChangedEvent()
        {
            if (StatusEvent != null)
                StatusEvent(this, (int)status);
        }
        #endregion

    }

	public enum PosPrinterStatus
	{
		Inactive = 0, Active = 1
	}


	
}
