using System;
using System.Collections;
using System.Windows;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.Devices;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.Hardware
{
	/// <summary>
	/// Summary description for PosHardware.
	/// </summary>
	public sealed class PosHardware:IDisposable
	{

		#region Variables
		private static ArrayList deviceCollection; 
		private static PosPrinterWrapper posPrinter=null;	
		private static LineDisplayWrapper lineDisplay=null;
		private static PosKeyboardWrapper keyboard=null;
		private static MsrWrapper msr=null;
		//private static HidMsr hidMsr = null;
        private static ScannerWrapper scanner = null;
        private static CashDrawerWrapper drawer = null;
		private static string errorText;
		//private static PosExplorer posExplorer;
		private static PosHardware posHardware;

      //  public delegate void MsrRead();



		#endregion  

		static PosHardware()
		{
			posHardware = new PosHardware();

		}

		private PosHardware()
		{
            deviceCollection = new ArrayList();
            deviceCollection.Clear();
		}

	//	~PosHardware()
	//	{
	//		this.Close();
	//	}

        //Singleton implimentation
        //  public static PosHardware GetInstance()
		//		{
		//	if (posHardware == null ) posHardware = new PosHardware();
		//	return posHardware;
		//
		//}

		#region Properties

		public static PosHardware Instance
		{
			get 
			{
				return posHardware;
			}
		}

		public LineDisplayWrapper LineDisplay
		{
			get 
			{
				return lineDisplay;
			}
		}

		public PosPrinterWrapper PosPrinter
		{
			get 
			{
				return posPrinter;
			}
		}


        public CashDrawerWrapper CashDrawer
        {
            get
            {
                return drawer;
            }
        }

		public string ErrorText
		{
			get
			{
				return errorText;
			}
		}

        public ArrayList DeviceList
        {
            get
            {
                return deviceCollection;
            }
        }

		#endregion

		public void Initialize()
		{
           
			#region Original pos initialization code 
			/* Original code 
			// Create a new Pos Explorer
			posExplorer = new PosExplorer();
			devices = new ArrayList();

			customerDisplayDevice ="TMLineDisplay"; // EclipsePosSettings.CustomerDisplay;
			printerDevice = "TMPrinter"; //EclipsePosSettings.Printer;
			cashDrawerDevice = null; //EclipsePosSettings.CashDrawer;
			keyboardDevice = "PREHKeyboard";
			//keyboardDevice =  null; //"PCKeyboard"; //EclipsePosSettings.KeyBoard;
			msrDevice = "Msr"; //EclipsePosSettings.MSR;
			custIdle1 = null; //EclipsePosSettings.LineDisplayIdle1;
			custIdle2 = null; //EclipsePosSettings.LineDisplayIdle2;
		//	operatorDevice = EclipsePosSettings.(string) ConfigurationManager.GetConfiguration("Operator");
			
			// Add device support
			if  (printerDevice != null  )
			{
				posPrinter = new PosPrinterWrapper(printerDevice, posExplorer);
				posPrinter.Open();
				if (posPrinter.CheckHealth())
				{
					DeviceInfo device = posExplorer.GetDevice("PosPrinter", "TMPrinter");
					PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.Printer, device.ServiceObjectName);
				}
				posPrinter.Close();
				devices.Add(posPrinter);

			}

			if  (customerDisplayDevice != null )
			{
				lineDisplay = new LineDisplayWrapper(customerDisplayDevice, posExplorer);
			//	lineDisplay.Open();
			//	if (lineDisplay.CheckHealth()) 
				//	{using System.Text;

					DeviceInfo device = posExplorer.GetDevice(DeviceType.LineDisplay, customerDisplayDevice);
					PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.LineDisplay, device.ServiceObjectName);
			//	}
			//	lineDisplay.Close();
				devices.Add(lineDisplay);
			} 

			if ( keyboardDevice != null )
			{	 
				keyboard = new PosKeyboardWrapper(keyboardDevice, posExplorer);
				devices.Add(keyboard);
				if (keyboard.CheckHealth()) 
				{
					DeviceInfo device = posExplorer.GetDevice(DeviceType.PosKeyboard, keyboardDevice);
					PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.PosKeyboard, device.ServiceObjectName);
				}
				
			}

			if ( msrDevice != null )
			{	 
				msr = new MsrWrapper(msrDevice, posExplorer);
				devices.Add(msr);
				if (msr.CheckHealth()) 
				{
					DeviceInfo device = posExplorer.GetDevice(DeviceType.Msr, msrDevice); //, keyboardDevice);
				//	string deviceText = msr.DeviceText();
					PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.Msr,  device.ServiceObjectName);
				}
				
			}

			*/
			#endregion
		//	deviceCollection  = new ArrayList();
		//	deviceCollection.Clear();
			//posExplorer = new PosExplorer(PosContext.Instance.CurrentPosDisplay as Form);
		
			//posExplorer.DeviceAddedEvent +=  new DeviceChangedEventHandler(DeviceAdded);
			//posExplorer.DeviceRemovedEvent += new DeviceChangedEventHandler(DeviceRemoved);
			
			
			DeviceCollection devices = PosContext.Instance.PosExplorer.GetDevices();
			foreach( DeviceInfo device in devices )
			{


			    
                if (device.LogicalNames.Length == 0) continue;
 
				
				try
				{
					PosCommon posCommon = PosContext.Instance.PosExplorer.CreateInstance(device) as PosCommon;
					
					//Printer
				    if (posCommon is PosPrinter)
					{

						if (posPrinter == null)
						{
							posPrinter = new PosPrinterWrapper(posCommon as PosPrinter); //printerDevice, posExplorer);
							//Register the pos printer to device status display
                            if (PosContext.Instance.PosHardwareStatusDevice1 != null)
                            {
                                posPrinter.StatusEvent +=   new PosPrinterWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice1.Status);
                            }
                            if (PosContext.Instance.PosHardwareStatusDevice2 != null)
                            {
                                posPrinter.StatusEvent += new PosPrinterWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice2.Status);
                            }

                            posPrinter.Open();
							if (posPrinter.CheckHealth())
							{
                             //   MessageBox.Show(device.ServiceObjectName);

								deviceCollection.Add(posPrinter);
							}
							else
							{
								posPrinter.Close();
								posPrinter = null;
							}
						}
					}
                
			
					//LineDisplay
					if (posCommon is Microsoft.PointOfService.LineDisplay)
					{
                        
						if (lineDisplay == null )
						{

                           	lineDisplay = new LineDisplayWrapper(posCommon as LineDisplay);
                            //Register the Line Display to device status display
                            if (PosContext.Instance.PosHardwareStatusDevice1 != null)
                            {
                                lineDisplay.StatusEvent += new LineDisplayWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice1.Status);
                            }
                            if (PosContext.Instance.PosHardwareStatusDevice2 != null)
                            {
                                lineDisplay.StatusEvent += new LineDisplayWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice2.Status);
                            }

                            
                            lineDisplay.Open();
                         	if (lineDisplay.CheckHealth()) 
							{
                         		deviceCollection.Add(lineDisplay);
								PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.LineDisplay, device.ServiceObjectName);
							}
							else
							{
								lineDisplay.Close();
								lineDisplay = null;
							}
						}

					}
                
								
					//Msr
					if (posCommon is Microsoft.PointOfService.Msr)
					{
						if (msr == null ) 
						{
							msr = new MsrWrapper(posCommon as Msr);
                           
                            //Register the MSR to device status display
                            if (PosContext.Instance.PosHardwareStatusDevice1 != null)
                            {
                                msr.StatusEvent += new MsrWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice1.Status);
                            }
                            if (PosContext.Instance.PosHardwareStatusDevice2 != null)
                            {
                                msr.StatusEvent += new MsrWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice2.Status);
                            }


							msr.Open();
							if (msr.CheckHealth()) 
							{
                         		deviceCollection.Add(msr);
								PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.Msr,  device.ServiceObjectName);
							}
							else
							{
								msr.Close();
								msr = null;
							}
						}
					}
                
						
					//Keyboard
                   
					if (posCommon is Microsoft.PointOfService.PosKeyboard)
					{
						if (keyboard == null )
						{
							keyboard = new PosKeyboardWrapper(posCommon as PosKeyboard);
							keyboard.Open();
							if (keyboard.CheckHealth()) 
							{
                         		deviceCollection.Add(keyboard);
								PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.PosKeyboard, device.ServiceObjectName);
							}
							else
							{
								keyboard.Close();
								keyboard = null;
							}
						}
					}
                  

					// Scanner
					if (posCommon is Microsoft.PointOfService.Scanner)
					{
                        if (scanner == null)
                        {
                            scanner = new ScannerWrapper(posCommon as Scanner);
                            //Register the Scanner to device status display
                            if (PosContext.Instance.PosHardwareStatusDevice1 != null)
                            {
                                scanner.StatusEvent += new ScannerWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice1.Status);
                            }
                            if (PosContext.Instance.PosHardwareStatusDevice2 != null)
                            {
                                scanner.StatusEvent += new ScannerWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice2.Status);
                            }

                            scanner.Open();
                            if (scanner.CheckHealth())
                            {
                                deviceCollection.Add(scanner);
                                PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus(HardwareStatusPanelId.Scanner,  device.ServiceObjectName);
                            }
                            else
                            {
                                scanner.Close();
                                scanner = null;
                            }
                        }
					}
                  

					//Scale
					if (posCommon is Microsoft.PointOfService.Scale)
					{
					}

					// Cash Drawer
					if (posCommon is Microsoft.PointOfService.CashDrawer)
					{
                        if (drawer == null)
                        {
                            drawer = new CashDrawerWrapper(posCommon as CashDrawer);
                            //Register the Cash drawer to device status display
                            if (PosContext.Instance.PosHardwareStatusDevice1 != null)
                            {
                                drawer.StatusEvent += new CashDrawerWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice1.Status);
                            }
                            if (PosContext.Instance.PosHardwareStatusDevice2 != null)
                            {
                                drawer.StatusEvent += new CashDrawerWrapper.StausChangedEventHandler(PosContext.Instance.PosHardwareStatusDevice2.Status);
                            }
                            
                            drawer.Open();
                            if (drawer.CheckHealth())
                            {
                                deviceCollection.Add(drawer);
                              //  PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus(HardwareStatusPanelId.Scanner, device.ServiceObjectName);
                            }
                            else
                            {
                                drawer.Close();
                                drawer = null;
                            }
                        }
					}

					//Pin Pad
					if (posCommon is Microsoft.PointOfService.PinPad)
					{
					}
				}
				catch (Exception e)
				{
					Logger.Error("PosHardware.cs" , e.ToString() );
				}
			}
			
			/*		
			posExplorer = new PosExplorer(PosContext.Instance.CurrentPosDisplay as Form);
			DeviceCollection devices = posExplorer.GetDevices();
			foreach( DeviceInfo device in devices )
			{
				MessageBox.Show(device.ServiceObjectName);
				PosCommon posCommon = posExplorer.CreateInstance(device) as PosCommon;
				if (posCommon is PosPrinter)
			    {
					posPrinter = new PosPrinterWrapper(printerDevice, posExplorer);
					posPrinter.Open();
					MessageBox.Show(device.HardwareDescription);
					if (posPrinter.CheckHealth())
					{
						//DeviceInfo device = posExplorer.GetDevice("PosPrinter", "TMPrinter");
						//PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.Printer, device.ServiceObjectName);
					}
					posPrinter.Close();
					deviceCollection.Add(posPrinter);
			    }
			}
			*/
			
			//if there aren't any Pos keyboard, start the Keyboard hook
			/*if ( keyboard == null && PosSettings.Default.PCKeyBoard )
			{
               // MessageBox.Show("Deleted code");
				
                PCKeyboard pcKeyboard = new PCKeyboard();
				pcKeyboard.Open();
				if( pcKeyboard.CheckHealth()) 
				{
					deviceCollection.Add(pcKeyboard);
					PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus( HardwareStatusPanelId.PosKeyboard, "PCKeyboard");
				}
				else
				{
					pcKeyboard.Close();
					pcKeyboard = null; 
				}
                
			}
             */
            /*
			if ( msr == null && PosSettings.Default.HidMsr)
			{
                try
                {

                    HidMsr msr1 = new HidMsr();
                    msr1.Open();
                   // Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new MsrRead( msr1.Open ) );
                    if (msr1.CheckHealth())
                    {
                        deviceCollection.Add(msr1);
                        PosContext.Instance.CurrentPosDisplay.DisplayHardwareStatus(HardwareStatusPanelId.Msr, "Msr");
                    }
                    else
                    {
                        msr1.Close();
                        msr1 = null;
                    }
                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
				
			}
          
           */
           

		
		}

      //  void posPrinter_StatusEvent(object sender)
      //  {
      //      throw new NotImplementedException();
      //  }

		public HardwareSupport CheckHealth()
		{
			IEnumerator enumerator = deviceCollection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HardwareSupport device1 = (HardwareSupport)enumerator.Current;  
				bool ok = device1.CheckHealth(); 
	
				if (!ok)
				{
					errorText = device1.DeviceText() + device1.StatusText();
					MessageBox.Show("Hardware error" +errorText); 
					return device1;
				}
				 
			}
		
			return null;		
		}


		public void Reset ()
		{
			
			IEnumerator enumerator = deviceCollection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HardwareSupport device1 = (HardwareSupport)enumerator.Current;  
				device1.Reset(); 
				
			}
			
			
		}

		public  void Close()
		{
			
			try
			{
				IEnumerator enumerator = deviceCollection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					HardwareSupport device1 = (HardwareSupport)enumerator.Current;  
					device1.Close(); 				
				}
				deviceCollection.Clear();
			}
			catch
			{
			}
			
			
			
		}

		public  void Close(Object sender, EventArgs e)
		{
			Close();
			
		}
		#region IDisposable Members

		public void Dispose()
		{
			this.Close();
		}

		#endregion

		#region Device added or removed
		public void DeviceAdded(object sender, Microsoft.PointOfService.DeviceChangedEventArgs e)
		{
			MessageBox.Show("Device added");
		}
 

		public void DeviceRemoved(object sender, Microsoft.PointOfService.DeviceChangedEventArgs e)
		{	
			MessageBox.Show("Device removed");
           
		}
		#endregion


	}
}
