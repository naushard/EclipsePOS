using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using System.Collections;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Operators;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;


 

namespace EclipsePos.Apps.Hardware
{
	/*
	#region HidMsr Class

	//[HardwareId("HID\\Vid_0801&amp;Pid_0002","HID\\Vid_0801&amp;Pid_0002")]


	//[ServiceObject(	DeviceType.Msr, 
	//	 "HidMsr", 
	//	 "Service object for Hid MSR", 
	//	 1, 8 )]
	public class HidMsr : MsrBase
	{
		private MsrHidReader ReadThread;
		private const string PollingStatistic = "Polling Interval";
		private ResourceManager	rm;

		public HidMsr()
		{
			// Initialize ResourceManager for loading localizable strings
			//rm = new ResourceManager("Strings",  Assembly.GetExecutingAssembly() );

			// Initialize device properties
			Properties.CapIso = true;
			Properties.CapTransmitSentinels = true;
			Properties.DeviceDescription = "HidMsr"; //rm.GetString("IDS_MSR_DEVICE_DESCRIPTION");
		}


		// Finalizer
		~HidMsr()
		{
			Dispose(false);
		}

		
		// We must override dispose so we can close and release our reference 
		// to the ReadThread when the device is closed.  
		//
		// The Base/Basic class implementation of Close() calls the virtual
		// Dispose(bool) method so we don't need to override Close().
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					// Release managed resources
					if (ReadThread != null)
					{
						ReadThread.Dispose();
						ReadThread = null;
					}
				}
			}
			finally
			{
				// Must call base class Dispose
				base.Dispose (disposing);
			}
		}

		protected override MsrFieldData ParseMsrFieldData(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, CardType cardType)
		{
			string Track1Data = ByteArrayToString(RemoveSentinels(track1Data, '%', '?'));
			string Track2Data = ByteArrayToString(RemoveSentinels(track2Data, ';', '?'));

			// Parse Iso data
			return MsrDataParser.ParseIsoData(Track1Data, Track2Data);
		}

		protected override MsrTrackData ParseMsrTrackData(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, CardType cardType)
		{
			MsrTrackData data = new MsrTrackData();

			if (TransmitSentinels)
			{
				// Raw data contains sentinels so just pass it through
				data.Track1Data = (byte[]) track1Data.Clone();
				data.Track2Data = (byte[]) track2Data.Clone();
				data.Track3Data = (byte[]) track3Data.Clone();
			}
			else
			{
				/// remove sentinels
				data.Track1Data = RemoveSentinels(track1Data, '%', '?');
				data.Track2Data = RemoveSentinels(track2Data, ';', '?');
				data.Track3Data = RemoveSentinels(track3Data, ';', '?');;
			}
			data.Track4Data = null;

			return data;
		}


		private string ByteArrayToString(byte[] data)
		{
			if (data == null || data.Length == 0)
				return "";

			StringBuilder sb = new StringBuilder(data.Length);
			for (int i = 0; i < data.Length; i++)
			{
				sb.Append((char) data[i]);
			}

			return sb.ToString();
		}

		private byte[] RemoveSentinels(byte [] trackData, char startSentinel, char endSentinel)
		{
			if (trackData == null || trackData.Length == 0)
				return new byte[0];

			byte [] ReturnArray ;
			if (trackData[0] == Convert.ToByte(startSentinel) && trackData[trackData.Length-1] == Convert.ToByte(endSentinel))
			{
				ReturnArray = new byte[trackData.Length-2];
				for (int i=0; i<trackData.Length-2; i++)
					ReturnArray[i] = trackData[i+1];
			}
			else
			{
				ReturnArray = (byte[]) trackData.Clone();
			}

			return ReturnArray;
		}

		private string GetHardwareInfo(string name)
		{
			if (name == StatisticFirmwareRevision)
				return ByteArrayToString(ReadThread.GetUSBProperty(0));
			if (name == StatisticSerialNumber)
				return ByteArrayToString(ReadThread.GetUSBProperty(1));
			if (name == PollingStatistic)
			{
				byte [] data = ReadThread.GetUSBProperty(2);
				if (data != null && data.Length == 1)
					return ((int)data[0]).ToString(CultureInfo.CurrentCulture);
			}
	
			return "";
		}

		internal void OnCardSwipe(byte[] data)
		{
			byte [] Track1Data = null;
			byte [] Track2Data = null;
			byte [] Track3Data = null;
			int Track1Status = 0, Track2Status = 0, Track3Status = 0;
			int Track1Length, Track2Length, Track3Length;
			int cardType;

			// Ignore input if we're in the Error state
			if (State == ControlState.Error)
			{
				Logger.Warn(DeviceName, "Input data ignored because device is in the Error state.");
				return;
			}

			// decode data
			if (data == null || data.Length != 338)
			{
				UnreadableCard(ErrorCode.Failure, 0);
				return;
			}
			
			cardType     = data[7];

			int i;
			if ((TracksToRead & MsrTracks.Track1) == MsrTracks.Track1)
			{
				Track1Status = data[1];
				Track1Length = data[4];
				Track1Data = new byte[Track1Length];
				for (i=0; i< Track1Length; i++)
					Track1Data[i] = data[i+8];
			}

			if ((TracksToRead & MsrTracks.Track2) == MsrTracks.Track2)
			{
				Track2Status = data[2];
				Track2Length = data[5];
				Track2Data = new byte[Track2Length];
				for (i=0; i< Track2Length; i++)
					Track2Data[i] = data[i+118];
			}

			if ((TracksToRead & MsrTracks.Track3) == MsrTracks.Track3)
			{
				Track3Status = data[3];
				Track3Length = data[6];
				Track3Data = new byte[Track3Length];
				for (i=0; i< Track3Length; i++)
					Track3Data[i] = data[i+228];
			}

			// If bit 0 is set an error occurred
			if ((Track1Status & 1) == 0 && (Track2Status & 1) == 0 && (Track3Status & 1) == 0)
			{
				// Success
				GoodRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ? CardType.Iso : CardType.Unknown);
				return;
			}
			else
			{
				// Failure decoding one or more tracks
				int ExtendedErrCode = 0;
				if (ErrorReportingType == MsrErrorReporting.Track)
				{
					byte b1, b2, b3;
					
					if ((Track1Status & 1) == 0)
						b1 = (byte) ExtendedErrorSuccess;
					else 
						b1 = (byte) ExtendedErrorFailure;

					if ((Track2Status & 1) == 0)
						b2 = (byte) ExtendedErrorSuccess;
					else 
						b2 = (byte) ExtendedErrorFailure;

					if ((Track3Status & 1) == 0)
						b3 = (byte) ExtendedErrorSuccess;
					else 
						b3 = (byte) ExtendedErrorFailure;

					ExtendedErrCode = b1 + (b2 << 8) + (b3 << 16);

					// Track-level error reporting should update the tracks that were read successfully
					FailedRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ? CardType.Iso : CardType.Unknown, ErrorCode.Extended, ExtendedErrCode);
				}
				else // card-level error reporting
				{
					// Card-level reporting does not update track data properties
					ExtendedErrCode = (int) ExtendedErrorFailure;
					UnreadableCard(ErrorCode.Failure, 0);
				}
			}
			return;
		}


		#region UPOS Members

		public override void Open()
		{
			// Device State checking done in base class
			//base.Open();

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-10-23");
			SetStatisticValue(StatisticModelName, "Msr Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "USB");

			// Create a new manufacturer statistic
			CreateStatistic(PollingStatistic, false, "milliseconds");

			// Set handlers for statistics stored in hardware
			SetStatisticHandlers(PollingStatistic, new GetStatistic(GetHardwareInfo), null);
			SetStatisticHandlers(StatisticSerialNumber, new GetStatistic(GetHardwareInfo), null);
			SetStatisticHandlers(StatisticFirmwareRevision, new GetStatistic(GetHardwareInfo), null);

			// Create instance of USB reader class
			ReadThread = new MsrHidReader(this);
		}

		private string checkhealthtext;
		public override string CheckHealthText
		{
			get
			{
				// Verify that device is open
				VerifyState(false, false);

				return checkhealthtext;
			}
		}


		public override string	CheckHealth( HealthCheckLevel level)
		{
			// Verify that device is open, claimed and enabled
			VerifyState(true, true);

			// TODO: check the health of the device and return a descriptive string 

			// Cache result in the CheckHealthText property
			checkhealthtext = "Ok";
			return checkhealthtext;
		}

		public override DirectIOData	DirectIO( int command, int data, object obj )
		{
			// Verify that device is open
			VerifyState(false, false);
			
			return new DirectIOData(data, obj);
		}

		public override bool DeviceEnabled
		{
			// Device State checking done in base class

			get { return base.DeviceEnabled; }

			set 
			{
				if (value != base.DeviceEnabled)
				{
					// Call base class first because it will handle cases such as the
					// device isn't claimed etc.
					base.DeviceEnabled = value;

					// Start/Stop reading from the device
					if (value == false)
						ReadThread.CloseMsr();
					else
					{
						try
						{
							ReadThread.OpenMsr(@"\\?\hid#vid_0801&pid_0002#7&2bd1f007&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}");//DevicePath);
						}
						catch (Exception e)
						{
							// disable device
							base.DeviceEnabled = false;
						
							// rethrow PosControlExceptions
							if (e is PosControlException)
								throw;

							// Wrap other exceptions in PosControlExceptions
							throw new PosControlException(rm.GetString("IDS_UNABLE_TO_ENABLE_DEVICE"), ErrorCode.Failure, e);
						}
					}
				}
			}
		}
	
		#endregion

	}

	#endregion
	
	*/
	#region deleted code 2

	
	public class HidMsr :HardwareSupport
	{

		private MsrHidReader ReadThread;


        public HidMsr()
        {
            PosContext.Instance.MsrFilters = new Filters(
                1);
			
        }


		#region HardwareSupport Members

		public bool CheckHealth()
		{
			// TODO:  Add HidMsr.CheckHealth implementation
			return true;
		}

		public void Open()
		{
			// Create instance of USB reader class
			ReadThread = new MsrHidReader(this);
			try
			{
				//ReadThread.OpenMsr(@"\\?\hid#vid_0801&pid_0002#7&2bd1f007&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}");
               // ReadThread.OpenMsr(@"\\?\hid#vid_0801&pid_0002#7&33ffe657&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}");
                ReadThread.OpenMsr(@"\\?\hid#vid_0801&pid_0002#7&320df8bf&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}");
            }  

			catch (Exception e)
			{
				// disable device
				//base.DeviceEnabled = false;
						
				// rethrow PosControlExceptions
				//if (e is PosControlException)
				//	throw;

				// Wrap other exceptions in PosControlExceptions
				//throw new PosControlException("IDS_UNABLE_TO_ENABLE_DEVICE", ErrorCode.Failure, e);
                MessageBox.Show(e.ToString());
			}
		
		}


		public bool Reset()
		{
			// TODO:  Add HidMsr.Reset implementation
			return true;
		}

		public string DeviceText()
		{
			// TODO:  Add HidMsr.DeviceText implementation
			return null;
		}

		public string StatusText()
		{
			// TODO:  Add HidMsr.StatusText implementation
			return null;
		}

		public void Close()
		{
			// TODO:  Add HidMsr.Close implementation

           // ReadThread.CloseMsr();
		}

		internal void OnCardSwipe(byte[] data)
		{
			
			byte [] Track1Data = null;
			byte [] Track2Data = null;
			byte [] Track3Data = null;
			int Track1Status = 0, Track2Status = 0, Track3Status = 0;
			int Track1Length, Track2Length, Track3Length;
			int cardType;
			cardType     = data[7];
			int i =0;
			//
			Track1Status = data[1];
			Track1Length = data[4];
			Track1Data = new byte[Track1Length];
			for (i=0; i< Track1Length; i++)
				Track1Data[i] = data[i+8];
			//

			Track2Status = data[2];
			Track2Length = data[5];
			Track2Data = new byte[Track2Length];
			for (i=0; i< Track2Length; i++)
				Track2Data[i] = data[i+118];
			//
			Track3Status = data[3];
			Track3Length = data[6];
			Track3Data = new byte[Track3Length];
			for (i=0; i< Track3Length; i++)
				Track3Data[i] = data[i+228];
		
			string track1 = this.ByteArrayToString(Track1Data);
			string track2 = this.ByteArrayToString(Track2Data);
			string track3 = this.ByteArrayToString(Track3Data);

			MessageBox.Show(track1);
			MessageBox.Show(track2);
			MessageBox.Show(track3);

            ArrayList aryTraks = new ArrayList();
            aryTraks.Add(track1);
            aryTraks.Add(track2);
            aryTraks.Add(track3);
            this.Process(aryTraks);

			// string cardData = Encoding.ASCII.GetString(data);
			//MessageBox.Show(data.Length.ToString());
			/*
			byte [] Track1Data = null;
			byte [] Track2Data = null;
			byte [] Track3Data = null;
			int Track1Status = 0, Track2Status = 0, Track3Status = 0;
			int Track1Length, Track2Length, Track3Length;
			int cardType;

			// Ignore input if we're in the Error state
			if (State == ControlState.Error)
			{
				Logger.Warn(DeviceName, "Input data ignored because device is in the Error state.");
				return;
			}

			// decode data
			if (data == null || data.Length != 338)
			{
				UnreadableCard(ErrorCode.Failure, 0);
				return;
			}
			
			cardType     = data[7];

			int i;
			if ((TracksToRead & MsrTracks.Track1) == MsrTracks.Track1)
			{
				Track1Status = data[1];
				Track1Length = data[4];
				Track1Data = new byte[Track1Length];
				for (i=0; i< Track1Length; i++)
					Track1Data[i] = data[i+8];
			}

			if ((TracksToRead & MsrTracks.Track2) == MsrTracks.Track2)
			{
				Track2Status = data[2];
				Track2Length = data[5];
				Track2Data = new byte[Track2Length];
				for (i=0; i< Track2Length; i++)
					Track2Data[i] = data[i+118];
			}

			if ((TracksToRead & MsrTracks.Track3) == MsrTracks.Track3)
			{
				Track3Status = data[3];
				Track3Length = data[6];
				Track3Data = new byte[Track3Length];
				for (i=0; i< Track3Length; i++)
					Track3Data[i] = data[i+228];
			}

			// If bit 0 is set an error occurred
			if ((Track1Status & 1) == 0 && (Track2Status & 1) == 0 && (Track3Status & 1) == 0)
			{
				// Success
				GoodRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ? CardType.Iso : CardType.Unknown);
				return;
			}
			else
			{
				// Failure decoding one or more tracks
				int ExtendedErrCode = 0;
				if (ErrorReportingType == MsrErrorReporting.Track)
				{
					byte b1, b2, b3;
					
					if ((Track1Status & 1) == 0)
						b1 = (byte) ExtendedErrorSuccess;
					else 
						b1 = (byte) ExtendedErrorFailure;

					if ((Track2Status & 1) == 0)
						b2 = (byte) ExtendedErrorSuccess;
					else 
						b2 = (byte) ExtendedErrorFailure;

					if ((Track3Status & 1) == 0)
						b3 = (byte) ExtendedErrorSuccess;
					else 
						b3 = (byte) ExtendedErrorFailure;

					ExtendedErrCode = b1 + (b2 << 8) + (b3 << 16);

					// Track-level error reporting should update the tracks that were read successfully
					FailedRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ? CardType.Iso : CardType.Unknown, ErrorCode.Extended, ExtendedErrCode);
				}
				else // card-level error reporting
				{
					// Card-level reporting does not update track data properties
					ExtendedErrCode = (int) ExtendedErrorFailure;
					UnreadableCard(ErrorCode.Failure, 0);
				}
			}
			*/
			return;
		}


        private void Process(ArrayList tracks)
        {
            Hashtable results = new Hashtable();

            if (!(PosEventStack.Instance.CurrentEvent is EjCCTender)) return;

            foreach (object obj in tracks)
            {
                try
                {
                    string xTrack = obj as string;

                    foreach (object obj1 in PosContext.Instance.MsrFilters)
                    {
                        Filter filter = obj1 as Filter;
                        filter.Apply(xTrack, results);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            if (results.Count > 0)
            {
                try
                {
                    EjCCTender tender = (EjCCTender)PosEventStack.Instance.CurrentEvent;
                    tender.Desc = (string)results[Filter.DISPLAY_NAME];
                    tender.CCNumber = (string)results[Filter.ACCT_NO];
                    tender.ExprDate = (string)results[Filter.EXPR_MONTH] + (string)results[Filter.EXPR_YEAR];
                    tender.Track1Data = tracks[0].ToString(); //Encoding.ASCII.GetString(msr.Track1Data);
                    tender.Track2Data = tracks[1].ToString(); // Encoding.ASCII.GetString(msr.Track2Data);
                    tender.FirstName = Filter.FIRSTNAME; //Filter.msr.FirstName;
                    tender.LastName = Filter.SURNAME; //msr.Surname;
                    tender.Mi =  "";  //msr.MiddleInitial;
                    tender.Results = results;
                    while (!tender.States().Peek().Equals(EjCCTender.TENDER_FINAL))
                    {
                        tender.States().PopPending();
                    }

                    tender.Engage(0);  // complete the tender
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

        }

		private string ByteArrayToString(byte[] data)
		{
			if (data == null || data.Length == 0)
				return "";

			StringBuilder sb = new StringBuilder(data.Length);
			for (int i = 0; i < data.Length; i++)
			{
				sb.Append((char) data[i]);
			}

			return sb.ToString();
		}

	

		#endregion

	}
	
	#endregion 


	#region MsrHidReader Class
	internal class MsrHidReader : IDisposable
	{
		private Thread				ReadThread;
		private IntPtr				HidHandle	= IntPtr.Zero;				// file handle for a Hid devices
		private	WeakReference		wr;
		private int					InputReportByteLength;
		private int					FeatureReportByteLength;
		private string				SOName;
		private ManualResetEvent	ThreadTerminating;
		private ManualResetEvent	ThreadStarted;
		private ResourceManager		rm;

		public MsrHidReader(HidMsr Msr)
		{
			// Initialize ResourceManager for loading localizable strings
			rm = new ResourceManager("Strings",  Assembly.GetExecutingAssembly() );

			// Cache device name for logging
			//SOName = Msr.DeviceName;

			// Create an event to signal that the thread is up and running
			ThreadStarted = new ManualResetEvent(false);

			// Create a new event to signal the thread to terminate
			ThreadTerminating = new ManualResetEvent(false);

			// Keep a weak reference to the service object so we can signal it when data is avaliable.
			// We need this to be a weak reference so the garbage collector can collect the service object
			// if the calling application loses its reference to the service object without calling Close().
			wr = new WeakReference(Msr);

			// We need to be notified if the app shuts down so we can terminate gracefully.
           // System.Windows.Application.Current.Exit += new ExitEventHandler(Current_Exit);
            //MessageBox.Show("Deleted code");
            Application.Current.Dispatcher.ShutdownStarted += new EventHandler(Dispatcher_ShutdownStarted);
        }

        void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            if (ThreadTerminating != null)
                ThreadTerminating.Set(); // signal the thread to end because the app is shutting down

        }

        

		~MsrHidReader()
		{
			Dispose(false);
		}
		
		public void OpenMsr(string DevicePath)
		{
			try
			{
				if (disposed)
					throw new ObjectDisposedException("USBReadThread");

				// close the device (OK to call if it's already closed)
				CloseMsr();

				// (Re)Open the device
				HidHandle = NativeMethods.CreateFile(
					DevicePath,
					NativeMethods.GENERIC_READ | NativeMethods.GENERIC_WRITE,
					0,  // No sharing
					IntPtr.Zero,
					NativeMethods.OPEN_EXISTING,
					NativeMethods.FILE_FLAG_OVERLAPPED, 
					IntPtr.Zero);
				if ((int)HidHandle == -1)
				{
					HidHandle = IntPtr.Zero;
					Logger.Error(SOName, "Error opening file: " + DevicePath);
					throw new Win32Exception( Marshal.GetLastWin32Error() );
				}

				
				IntPtr PtrToPreparsedData = IntPtr.Zero;
				if (NativeMethods.HidD_GetPreparsedData( HidHandle,	ref PtrToPreparsedData) == (byte) 0)
				{
					Logger.Error(SOName, "Error reading HID preparsed data.");
					throw new PosControlException(rm.GetString("IDS_DEVICE_COMMUNICATION_FAILURE"), ErrorCode.Failure);
				}
				
				NativeMethods.HIDP_CAPS DeviceCaps = new NativeMethods.HIDP_CAPS();
				int retVal = NativeMethods.HidP_GetCaps(PtrToPreparsedData, ref DeviceCaps);
				if (retVal < 0)
				{
					Logger.Error(SOName, "Error reading HID capabilities: " + retVal.ToString(CultureInfo.InvariantCulture));
					throw new PosControlException(rm.GetString("IDS_DEVICE_COMMUNICATION_FAILURE"), ErrorCode.Failure);
				}

				InputReportByteLength = DeviceCaps.InputReportByteLength;
				FeatureReportByteLength = DeviceCaps.FeatureReportByteLength;

				Logger.Info(SOName, "InputReportByteLength = " + InputReportByteLength.ToString(CultureInfo.InvariantCulture), PosSettings.Default.Debug);
				Logger.Info(SOName, "FeatureReportByteLength = " + FeatureReportByteLength.ToString(CultureInfo.InvariantCulture), PosSettings.Default.Debug);

				// Reset events
				ThreadTerminating.Reset();
				ThreadStarted.Reset();

				// start thread for getting input
				ReadThread = new Thread(new ThreadStart(ThreadMethod));
				ReadThread.Name = "Example Msr USB thread";
				ReadThread.Start();

				// If the thread doesn't start in 30 seconds throw an exception
				if (!ThreadStarted.WaitOne(30000, false))
				{
					Logger.Error(SOName, "USB read thread failed to start in 30 seconds.");
					throw new PosControlException(rm.GetString("IDS_THREAD_FAILED_TO_START"), ErrorCode.Failure);
				}

				Logger.Info(SOName, "USB read thread started successfully.", PosSettings.Default.Debug);
			}
			catch(Exception e)
			{
				Logger.Error(SOName, "An exception occurred while attempting to open the device.", e);
				CloseMsr();
				throw;
			}
		}

		public byte [] GetUSBProperty(int propId)
		{
			if (HidHandle == IntPtr.Zero)
				return null;

			byte[] FtrRptTrxBfr = new byte[FeatureReportByteLength];
			
			FtrRptTrxBfr[1] = (byte) 0;			// 0 = get
			FtrRptTrxBfr[2] = (byte) 1;			// data size = 1 byte
			FtrRptTrxBfr[3] = (byte) propId;	// property to fetch


			if (NativeMethods.HidD_SetFeature(HidHandle, FtrRptTrxBfr, FeatureReportByteLength) != (byte)0)
			{
				byte[] FtrRptRcvBfr = new byte[FeatureReportByteLength];
				if ((int) NativeMethods.HidD_GetFeature(HidHandle, FtrRptRcvBfr, FeatureReportByteLength) > 0 && (int) FtrRptRcvBfr[1] == 0)
				{
					byte [] result = new byte[(int) FtrRptRcvBfr[2]];
					for (int i=0; i< (int) FtrRptRcvBfr[2]; i++)
						result[i] = FtrRptRcvBfr[i+3];

					return result;
				}
			}

			Logger.Warn(SOName, "Unable to read USB property: " + propId.ToString(CultureInfo.InvariantCulture));

			return null;
		}
		
		public void CloseMsr()
		{
			// Kill thread
			if (ReadThread != null)
			{
				ThreadTerminating.Set(); // signal thread to exit
				ReadThread = null;
			}

			// close device
			if (HidHandle != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(HidHandle);
				HidHandle = IntPtr.Zero;
			}
		}
		
	
		private void ThreadMethod() 
		{
			HidMsr Msr;
			IntPtr UnmanagedBuffer = IntPtr.Zero;
			ManualResetEvent IOComplete = null;

			try
			{
				// Allocate a buffer in unmanaged memory so the garbage collector won't
				// move it around while we're waiting for async input.  Since this is 
				// allocated on the unmanaged heap we must free it before the function returns.
				UnmanagedBuffer = Marshal.AllocHGlobal(InputReportByteLength);

				IOComplete = new ManualResetEvent(false); 
				byte[] MsrData = new byte[InputReportByteLength];
				NativeMethods.OVERLAPPED Overlapped = new NativeMethods.OVERLAPPED();
				Overlapped.Offset = 0;
				Overlapped.OffsetHigh = 0;
				Overlapped.hEvent = IOComplete.SafeWaitHandle.DangerousGetHandle();

				// We need to wait for either IO to complete or the read to be signaled
				WaitHandle [] IOCompleteOrThreadTerminating = {IOComplete, ThreadTerminating};

				// Signal the openning thread that we're up and running.
				if (ThreadStarted != null)
					ThreadStarted.Set();

				// start reading data from Hid device
				while(true)
				{
					int BytesRead;

					try
					{
						NativeMethods.ReadFile(HidHandle, UnmanagedBuffer, InputReportByteLength, out BytesRead, ref Overlapped);
					
						int LastErr = Marshal.GetLastWin32Error();
						if (LastErr == NativeMethods.ERROR_IO_PENDING)
						{
							// Wait for data or thread termination
							WaitHandle.WaitAny(IOCompleteOrThreadTerminating);
							
							// test for thread termination
							if (ThreadTerminating.WaitOne(0, false))
								break;

							// Cancel any pending IO if we didn't read any data 
							if (!NativeMethods.GetOverlappedResult(HidHandle, ref Overlapped, out BytesRead, false))
							{
								NativeMethods.CancelIo(HidHandle);  
								break;
							}
						}
		
					}
					catch (Exception e)
					{
						Logger.Error(SOName, "Exception occurred while reading data from the USB port.", e);
						throw;
					}
				
					// test for thread termination
					if (ThreadTerminating.WaitOne(0, false))
						break;
				
					// get strong ref to base class
					Msr = wr.Target as HidMsr;
					if (Msr == null)
						break;

					try
					{
						if (BytesRead == InputReportByteLength)
						{	
							// report data
							Marshal.Copy(UnmanagedBuffer, MsrData, 0, InputReportByteLength);
							Msr.OnCardSwipe(MsrData);
						}
						else
						{
							Logger.Error(SOName, "Unexpected number of bytes returned from device.");
						}
					}
					finally
					{
						// release strong ref to base class
						Msr = null;
					}
				
				}
			}
			catch (Exception e)
			{
				Logger.Error(SOName, "Exception occurred in USB read thread.", e);
				throw;
			}
			finally
			{
				// free unmanaged buffer
				if (UnmanagedBuffer != IntPtr.Zero)
					Marshal.FreeHGlobal(UnmanagedBuffer);

				if (IOComplete != null)
					IOComplete.Close();
			}
		}
		
	
 		#region Win32 Interop

		internal class NativeMethods
		{
			private NativeMethods() {}

			[DllImport("kernel32.dll", SetLastError=true)]
			internal static extern IntPtr CreateFile(
				string lpFileName,							// file name
				uint dwDesiredAccess,						// access mode
				uint dwShareMode,							// share mode
				IntPtr lpSecurityAttributes,					// SD
				uint dwCreationDisposition,					// how to create
				uint dwFlagsAndAttributes,					// file attributes
				IntPtr hTemplateFile							// handle to template file
				);

			[DllImport("kernel32.dll", SetLastError=true)]
			internal static extern bool ReadFile(
				IntPtr hFile,						// handle to file
				IntPtr lpBuffer,				// data buffer
				int nNumberOfBytesToRead,		// number of bytes to read
				out int lpNumberOfBytesRead,	// number of bytes read
				ref OVERLAPPED lpOverlapped		// overlapped buffer
				);

			[DllImport("kernel32.dll", SetLastError=true)]
			internal static extern bool GetOverlappedResult(
				IntPtr hFile,
				ref OVERLAPPED  lpOverlapped,
				out int lpNumberOfBytesTransferred,
				bool bWait
				);

			[DllImport("kernel32.dll", SetLastError=true)]
			internal static extern int CloseHandle(IntPtr hObject);

			[DllImport("kernel32.dll", SetLastError=true)] 
			internal static extern bool CancelIo(IntPtr hFile);

			[DllImport("hid.dll", SetLastError=true)]
			internal static extern byte HidD_GetPreparsedData(
				IntPtr hObject,								// IN HANDLE  HidDeviceObject,
				ref IntPtr pPHIDP_PREPARSED_DATA);				// OUT PHIDP_PREPARSED_DATA  *PreparsedData

			[DllImport("hid.dll", SetLastError=true)]
			internal static extern int HidP_GetCaps(
				IntPtr pPHIDP_PREPARSED_DATA,					// IN PHIDP_PREPARSED_DATA  PreparsedData,
				ref HIDP_CAPS myPHIDP_CAPS);				// OUT PHIDP_CAPS  Capabilities

			[DllImport("hid.dll", SetLastError=true)]
			internal static extern byte	HidD_SetFeature(
				IntPtr  HidDeviceObject,
				byte []  ReportBuffer,
				int  ReportBufferLength  );

			[DllImport("hid.dll", SetLastError=true)]
			internal static extern byte	HidD_GetFeature(
				IntPtr  HidDeviceObject,
				byte []  ReportBuffer,
				int  ReportBufferLength
				);

			[StructLayout(LayoutKind.Sequential)]
				internal struct OVERLAPPED 
			{
				public int Internal;  
				public int InternalHigh;  
				public uint Offset;  
				public uint OffsetHigh;  
				public IntPtr hEvent;
			}


			[StructLayout(LayoutKind.Sequential)]
				internal struct HIDP_CAPS 
			{
				public System.UInt16  Usage;					// USHORT
				public System.UInt16   UsagePage;				// USHORT
				public System.UInt16   InputReportByteLength;
				public System.UInt16   OutputReportByteLength;
				public System.UInt16   FeatureReportByteLength;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst=17)]
				public System.UInt16[] Reserved;				// USHORT  Reserved[17];			
				public System.UInt16  NumberLinkCollectionNodes;
				public System.UInt16  NumberInputButtonCaps;
				public System.UInt16  NumberInputValueCaps;
				public System.UInt16  NumberInputDataIndices;
				public System.UInt16  NumberOutputButtonCaps;
				public System.UInt16  NumberOutputValueCaps;
				public System.UInt16  NumberOutputDataIndices;
				public System.UInt16  NumberFeatureButtonCaps;
				public System.UInt16  NumberFeatureValueCaps;
				public System.UInt16  NumberFeatureDataIndices;
			}

			internal const uint GENERIC_READ				= 0x80000000;
			internal const uint GENERIC_WRITE			= 0x40000000;
			internal const uint FILE_SHARE_READ			= 0x00000001;
			internal const uint FILE_SHARE_WRITE			= 0x00000002;
			internal const int  OPEN_EXISTING			= 3;
			internal const uint FILE_FLAG_OVERLAPPED		= 0x40000000;
			internal const uint ERROR_IO_INCOMPLETE		= 996;
			internal const uint ERROR_IO_PENDING			= 997;
		}


		#endregion

		#region IDisposable Members

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					// Close the USB port
					CloseMsr();

					if (disposing)
					{
						// free managed objects
						if (ThreadStarted != null)
						{
							ThreadStarted.Close();
							ThreadStarted = null;
						}

						if (ThreadTerminating != null)
						{
							ThreadTerminating.Close();
							ThreadTerminating = null;
						}
					}

					// free unmanaged objects

				}
				finally
				{
					disposed = true;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}

	#endregion

	


}
