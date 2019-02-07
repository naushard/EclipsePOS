using System;
using System.Windows;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;


using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;

using Microsoft.PointOfService;
//using Microsoft.PointOfService.ExampleServiceObjects;
//using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EclipsePos.Apps.Hardware
{
	/// <summary>
	/// Summary description for PosKeyboardWrapper.
	/// </summary>
	public class PosKeyboardWrapper:HardwareSupport
	{
		#region Variable
		//private PosExplorer posExplorer = null;
		//private string deviceName = null;
		private PosKeyboard posKeyboard = null;
		private PosKeyboardStatus status = PosKeyboardStatus.Inactive;
		//private delegate void MenuLoadEvent(Button btn); 

		#endregion

		#region Constructor
		public PosKeyboardWrapper(PosKeyboard pPosKeyboard) //string device, PosExplorer explorer)
		{
			this.posKeyboard = pPosKeyboard;
			//this.deviceName = device;
			//this.posExplorer = explorer;
			//this.Open();
		}
		#endregion
		
		#region Open
		public void Open()
		{
			try
			{
				//DeviceInfo device = posExplorer.GetDevice(DeviceType.PosKeyboard, deviceName);
				//MessageBox.Show(device.Description);
				//posKeyboard = (PosKeyboard) posExplorer.CreateInstance(device);
				this.AddDataEvent(posKeyboard);
				posKeyboard.ErrorEvent +=new DeviceErrorEventHandler(posKeyboard_ErrorEvent);				
				posKeyboard.Open();
				posKeyboard.Claim(1000);
				posKeyboard.DeviceEnabled = true;
				posKeyboard.DataEventEnabled = true;
				status = PosKeyboardStatus.Active;
			}
			catch (Exception e)
			{
				MessageBox.Show("Exception in opening EclipsePosKeyboard" + e.ToString());
			}
		}
		#endregion 


		
		#region HardwareSupport Members

		public bool CheckHealth()
		{
			// TODO:  Add PosKeyboardWrapper.CheckHealth implementation
			return true;
		}

		public bool Reset()
		{
			// TODO:  Add PosKeyboardWrapper.Reset implementation
			return true;
		}

		public string DeviceText()
		{
			// TODO:  Add PosKeyboardWrapper.DeviceText implementation
			return null;
		}

		public string StatusText()
		{
			// TODO:  Add PosKeyboardWrapper.StatusText implementation
			return "OK";
		}

		public void Close()
		{
			if (status == PosKeyboardStatus.Inactive) return;
 
			posKeyboard.DataEventEnabled = false;
            posKeyboard.DeviceEnabled = false;
			posKeyboard.Release();
			posKeyboard.Close();
			status = PosKeyboardStatus.Inactive;
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
		
		protected  void OnDataEvent(object source, DataEventArgs e)
		{
			int keyCode = posKeyboard.PosKeyData;
			//MessageBox.Show("ON data event" + keyCode.ToString());
			try 
			{
				Hashtable table = PosContext.Instance.KeysByControl;  
				if (table.ContainsKey(keyCode.ToString()) )
				{
					//Button btn = (Button) table[keyCode.ToString()];
					//if ( btn != null )
					//{
					//	btn.Invoke(new MenuLoadEvent(this.MenuLoadHandler), new object[]{btn} );
					//}
                    MessageBox.Show("Deleted code");
				}
				else
				{
					Beep(500, 500);
				}
			}
			catch(Exception e2)
			{
				 MessageBox.Show(e2.ToString());
			}

			posKeyboard.DataEventEnabled = true;
			posKeyboard.ClearInput();
		}


		private void posKeyboard_DataEvent(object sender, DataEventArgs e)
		{
			int keyCode = posKeyboard.PosKeyData;
           MessageBox.Show(keyCode.ToString());
			//Ignore control key press
			if (keyCode == 162) return; 
			Hashtable table = PosContext.Instance.KeysByControl;  
			if (table.ContainsKey(keyCode.ToString()) )
			{
				/*Button btn = (Button) table[keyCode.ToString()];
				if ( btn != null )
				{
					//btn.PerformClick();
					//posEvent.Engage(keyCode);
					btn.Invoke(new MenuLoadEvent(this.MenuLoadHandler), new object[]{btn} );
				}*/
                MessageBox.Show("deleted code");
			}
			else
			{
				Beep(500, 500);
			}
		}

		//Event handler for platform invoke
		public void MenuLoadHandler( object btn) //Button btn)
		{
			//btn.PerformClick();
			
		}

		[DllImport("kernel32.dll")]
		public static extern bool Beep(int freq,int duration);

		

		private void posKeyboard_ErrorEvent(object sender, DeviceErrorEventArgs e)
		{
			MessageBox.Show("Keyboard error");
		}
	}
 
	public enum PosKeyboardStatus
	{
		Inactive = 0, Active = 1
	}

}
