using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

using EclipsePos.Apps.Devices;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using Microsoft.PointOfService;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps.Util;



namespace EclipsePos.Apps.Hardware
{
	/// <summary>
	/// Summary description for PCKeybord.
	/// </summary>
	/// 
	
	public class PCKeyboard:HardwareSupport	
	{

		private PCKeyboardHook keyboardHook;
		private string checkhealthtext;
		private bool deviceEnabled;
		private delegate void MenuLoadEvent(PosButton btn); 
		private int modifier=0;
		

		public PCKeyboard()
		{
			//
			// TODO: Add constructor logic here
			//
			//Properties.DeviceDescription = "PCKeyboard simulator";
			//Properties.CapKeyUp = true;
	
		}

		~PCKeyboard()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("PCKeyboardSimulator", "Disposing class: " + this.ToString(), PosSettings.Default.Debug);
					// Release the managed resources you added in
					// this derived class here.
				}
				// Release the native unmanaged resources
				// WindowThread needs to be treated as an unmanaged resource because
				// it is a class that contain threads and windows and won't get collected
				// by the GC
				if (keyboardHook != null)
					keyboardHook.Stop();
				keyboardHook = null;
				
			}
			finally
			{
				// Call Dispose on your base class.
				//base.Dispose(disposing);
			}
		}


		#region UPOS Members

		public string CheckHealthText
		{
			get
			{
				// Verify that device is open
			//	VerifyState(false, false);

				return checkhealthtext;
			}
		}


		public  bool CheckHealth()
		{
			return true;
		}

	/*	public override DirectIOData	DirectIO( int command, int data, object obj )
		{
			// Verify that device is open
			VerifyState(false, false);
			
			return new DirectIOData(data, obj);
		}

	*/

		public void Open()
		{
			this.DeviceEnabled = true;
		}

		
		public bool DeviceEnabled
		{
			get
			{
				return deviceEnabled;
			}
			set
			{
				if (value != deviceEnabled)
				{
					deviceEnabled = value;
					if (value)
					{
						//Window = new PosKeyboardWindow(this);
						keyboardHook = new PCKeyboardHook();
					//	keyboardHook.KeyDown +=new System.Windows.Forms.KeyEventHandler(keyboardHook_KeyDown);
                        keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);  //+=new System.Windows.Forms.KeyPressEventHandler(keyboardHook_KeyPress);
						//	keyboardHook.KeyUp +=new System.Windows.Forms.KeyEventHandler(keyboardHook_KeyUp);
						keyboardHook.Start();
					}
					else
					{
						if (keyboardHook != null)
						{
							keyboardHook.Stop();
							keyboardHook = null;
						}
						
					}
				}
			}
		}

        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
           // MessageBox.Show("Key Press" + e.KeyChar.ToString());
            AlphaKey posEvent = new AlphaKey();
            posEvent.Update(e.KeyChar);
        }

		#endregion

        public void KeyPressed(int key)
        {

            AlphaKey posEvent = new AlphaKey();
            posEvent.Engage(key);

        }
        /*
		public void KeyPressed(int key)
		{
          //  MessageBox.Show("Key Down" );
			//.KeyDown(key);
			//if (EventTypes == KeyboardEventType.DownUp)
			//	KeyUp(key);
		//	System.Windows.Forms.Keys keys = (Keys)key;
			//if (key == 131072 ) return;

			int keyCode = key; //posKeyboard.PosKeyData;
			//MessageBox.Show("ON data event" + key.ToString());
			if (key == 162 || key == 163 )
			{
				modifier = 131072;
				return;
			}
			else
			{
				key += modifier;
				modifier = 0; 
			}


			try 
			{
				Hashtable table = PosContext.Instance.KeysByControl;  
									
				if (table.ContainsKey(keyCode) )
				{
					object obj  = table[keyCode];
					if (obj is PosButton )
					{
						PosButton btn = obj as PosButton;
                       
						//btn.Invoke(new MenuLoadEvent(this.MenuLoadHandler), new object[]{btn} );
                        if (btn.IsEnabled) 
                        {
                            if (btn.KeyClass.Trim().Length > 0 )
                            {
                                Assembly assembly = Assembly.GetExecutingAssembly();
                                PosEvent posEvent = assembly.CreateInstance(btn.KeyClass) as PosEvent;
                                //posEvent.Engage(btn.KeyValue);
                                posEvent.PromptText = btn.KeyText;
                                if (posEvent != null)
                                {

                                    if (posEvent.isDialog)
                                    {
                                        PosContext.Instance.PosKeyValue = btn.KeyValue;
                                        PosDialogEvent posDialog = posEvent as PosDialogEvent;
                                        posDialog.PushState(posDialog.StartState); //Assume "0" as the default state
                                        PosEventStack.Instance.PushEvent(posEvent);
                                        PosEventStack.Instance.NextEvent();
                                    }
                                    else
                                    {
                                        posEvent.Engage(btn.KeyValue);
                                    }
                                   
                                }
                            }
                        }
                        else
                        {
                            PosContext.Beep(500, 500);
                        }
                    }
				}
				else
				{
					PosContext.Beep(500, 500);
				}
			}
			catch(Exception e2)
			{
				MessageBox.Show(e2.ToString());
			}

		}
         */




		//Event handler for platform invoke
		public void MenuLoadHandler(PosButton btn)
		{
		//	btn.PerformClick();
			
		}


		private void keyboardHook_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//MessageBox.Show("Key Down" + e.KeyData.ToString());
						
			//this.ClearInput();
			//this.dataEventEnabled = true;
			int sendKeyValue = e.KeyValue;
			if (keyboardHook.IsKeyDown(Keys.ControlKey)) 
			{
				sendKeyValue += 131072;
			}
			this.KeyPressed(sendKeyValue);
		}

        

		public void Close()
		{
			this.Dispose(true);
		}

		public string DeviceText()
		{
			return "Eclipse PC Keyboard Hook";
		}

		public bool Reset()
		{
			return true;
		}


		public string StatusText()
		{
			return "ok";
		}
		
	}
}
