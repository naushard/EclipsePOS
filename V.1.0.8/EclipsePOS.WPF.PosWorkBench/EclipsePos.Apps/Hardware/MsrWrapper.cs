using System;
using System.Windows;
using System.Reflection;
using System.Text;
using System.Collections;
using System.Windows.Threading;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Operators;
using EclipsePos.Data;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Hardware
{ 
	/// <summary>
	/// Summary description for MsrWrapper.
	/// </summary>
	public class MsrWrapper: HardwareSupport, IDisposable	
	{

		#region Variable
		
		private string deviceName;
		private string deviceText = null;
		private string statusText = "Error";
		private MsrStatus status = MsrStatus.Inactive;
		private string healthText = "Unknown";

	//	private Microsoft.PointOfService.PosExplorer posExplorer=null ;
	//	private Microsoft.PointOfService.DeviceInfo device;
		private Microsoft.PointOfService.Msr msr=null;
		//POS.Devices.OPOSMSR msr;

        private ArrayList tracks = new ArrayList();
        public delegate void updateViewDelegate();

        public delegate void StausChangedEventHandler(object sender, int deviceStatus);
        public event StausChangedEventHandler StatusEvent;
		
		
		#endregion


		public MsrWrapper(Msr pMsr)//string pDeviceName, PosExplorer explorer)
		{
			this.msr = pMsr;
			// Load MSR Filters
			PosContext.Instance.MsrFilters = new Filters(
				1);
			//this.deviceName = pDeviceName;
			//posExplorer = explorer;
			//	System.Resources.ResourceManager resources = new System.Resources.ResourceManager("EclipsePos.Hardware.LineDisplayWrapper", Assembly.GetExecutingAssembly());
			//	healthText = resources.GetString("HealthText");
			//	Open();		

		}

		public void Open()
		{

			try
			{
				//Microsoft.PointOfService.DeviceInfo devices = posExplorer.GetDevice(DeviceType.Msr, "Msr");;

				//msr = (Msr)posExplorer.CreateInstance(devices);
				
				this.AddDataEvent(msr);
			
				msr.ErrorEvent +=new DeviceErrorEventHandler(msr_ErrorEvent);
											
				msr.Open();
				msr.Claim(1000);
				msr.DeviceEnabled =true;
				deviceText = msr.DeviceDescription;
				statusText = msr.ToString();
				msr.DataEventEnabled =  true;
				status = MsrStatus.Active;
                this.RaiseStatusChangedEvent();
			
			}
			catch (PosControlException e1)
			{
				status = MsrStatus.Inactive;
				//MessageBox.Show(e1.ToString());
                this.RaiseStatusChangedEvent();
			}
			catch (Exception e2)
			{
				status = MsrStatus.Inactive;
				//MessageBox.Show(e2.ToString() );
                this.RaiseStatusChangedEvent();
			}
		
		}


		public bool CheckHealth()
		{
			msr.CheckHealth(HealthCheckLevel.Internal);

			return true;
		}


		public bool Reset()
		{
			return true;
		}


		public string DeviceText()
		{
			return this.DeviceText();
		}
		
		
		public string StatusText()
		{
			return null;
		}
		
		
		public void Close()
		{
			try 
			{
			
				msr.Release();
				msr.Close();
				this.status= MsrStatus.Inactive;
			}
			catch 
			{
				status = MsrStatus.Inactive;
						  
			}
			
		}


        #region Raise Status Event
        protected virtual void RaiseStatusChangedEvent()
        {
            if (StatusEvent != null)
                StatusEvent(this, (int)status);
        }
        #endregion

		#region IDisposable Members

		public void Dispose()
		{
			
			this.Close(); 
		}

		#endregion

		protected void AddDataEvent(object eventSource)
		{
			//<<<step1>>>--Start
			EventInfo dataEvent = eventSource.GetType().GetEvent( "DataEvent" );
			
			if( dataEvent != null )
			{
				dataEvent.AddEventHandler( eventSource,
					new DataEventHandler(OnDataEvent) );
			}
			//<<<step1>>>--End
		}

		// <summary>
		/// Data Event.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		protected  void OnDataEvent(object source, DataEventArgs e)
		{		
			//<<<step1>>>--Start
			//AccuntNumber
			string accuntNumber = msr.AccountNumber;
		//	MessageBox.Show(accuntNumber);

			//ExpirationDate
			string  expirationDate = msr.ExpirationDate;
		//	MessageBox.Show(expirationDate);
			//First Name
			string firstName = msr.FirstName;

			//Family Name
			string surName = msr.Surname;
		//	MessageBox.Show(msr.ServiceCode);

			//Middle Initial
			string middleinitials = msr.MiddleInitial;
			string track1  =Encoding.ASCII.GetString(msr.Track1Data);
			string track2 = Encoding.ASCII.GetString(msr.Track2Data);
			string track3 = Encoding.ASCII.GetString(msr.Track3Data);
			string track4 = Encoding.ASCII.GetString(msr.Track4Data);
			msr.DataEventEnabled = true;
			
            
			//tracks = new ArrayList();
            tracks.Clear();
			tracks.Add(track1);
			tracks.Add(track2);
		//	tracks.Add(track3);
		//	tracks.Add(track4);
			//this.Process(tracks);
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new updateViewDelegate(Process));
			//<<<step1>>>--End
	
		/*	if (PosEventStack.Instance.CurrentEvent is EjCCTender )
			{
				EjCCTender tender = PosEventStack.Instance.CurrentEvent as EjCCTender;
				//tender.Desc = msr.ServiceCode; //((String) results.get (Filter.DISPLAY_NAME));
				tender.CCNumber = accuntNumber; //.setCcNumber ((String) results.get (Filter.ACCT_NO));
				tender.ExprDate = expirationDate; //((String) results.get (Filter.EXPR_MONTH) + (String) results.get (Filter.EXPR_YEAR));
				tender.FirstName = firstName;
				tender.LastName = surName;
				tender.Mi = middleinitials;
				tender.Track1Data =  track1; //.setTrack1Data (new String (control.getTrack1Data ()));
				tender.Track2Data = track2; //.setTrack2Data (new String (control.getTrack2Data ()));
				
				while (!tender.States().Peek().Equals(EjCCTender.TENDER_FINAL))
				{
					tender.States().PopPending();
				}

				tender.Engage(0);  // complete the tender

			} */
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

	

		
		
		private void msr_ErrorEvent(object sender, DeviceErrorEventArgs e)
		{
			MessageBox.Show("Error event activated");
		}

		private void Process()//Process(ArrayList tracks)
		{
			Hashtable results =  new Hashtable();

			if ( !(PosEventStack.Instance.CurrentEvent is EjCCTender)) return;  

			foreach( object obj  in tracks)
			{
				try
				{
					string xTrack = obj as string;

					foreach (object obj1  in PosContext.Instance.MsrFilters)
					{
						Filter filter = obj1 as Filter;
						filter.Apply(xTrack, results);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}

			}

			if (results.Count > 0)
			{
				try
				{
					EjCCTender tender = (EjCCTender) PosEventStack.Instance.CurrentEvent;
					tender.Desc = (string) results[Filter.DISPLAY_NAME];
					tender.CCNumber = (string) results[Filter.ACCT_NO];
					tender.ExprDate = (string) results[Filter.EXPR_MONTH]+ (string)results[Filter.EXPR_YEAR];
					tender.Track1Data = Encoding.ASCII.GetString(msr.Track1Data);
					tender.Track2Data = Encoding.ASCII.GetString(msr.Track2Data);
					tender.FirstName = msr.FirstName;
					tender.LastName = msr.Surname;
					tender.Mi = msr.MiddleInitial;
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
	}

	public enum  MsrStatus
	{
		Inactive=0, 
		Active=1
	}
}
