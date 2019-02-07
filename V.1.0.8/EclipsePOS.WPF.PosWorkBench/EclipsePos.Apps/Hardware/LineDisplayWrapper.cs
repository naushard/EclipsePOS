using System;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Threading;

using EclipsePos.Apps.Context;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Hardware
{
	/// <summary>
	/// Summary description for PosLineDisplayWrapper.
	/// </summary>
	/// 

	public class LineDisplayWrapper: HardwareSupport, IDisposable
	{

		#region Variable
		
		//private string deviceName;
		private string deviceText = null;
		private string statusText = "Error";
		//private LineDisplayStatus status = LineDisplayStatus.inactive;
		private string healthText = "Unknown";

	//	private Microsoft.PointOfService.PosExplorer posExplorer=null ;
	//	private Microsoft.PointOfService.DeviceInfo device;
		private Microsoft.PointOfService.LineDisplay lineDisplay=null;

        public delegate void StausChangedEventHandler(object sender, int deviceStatus);
        public event StausChangedEventHandler StatusEvent;
		

		
		#endregion


		#region Constructor
		
		public LineDisplayWrapper(LineDisplay pLineDisplay)//string pDeviceName, PosExplorer explorer )
		{
			this.lineDisplay = pLineDisplay;
           
		//	this.deviceName = pDeviceName; 
		//	posExplorer = explorer;
		//	System.Resources.ResourceManager resources = new System.Resources.ResourceManager("EclipsePos.Hardware.LineDisplayWrapper", Assembly.GetExecutingAssembly());
		//	healthText = resources.GetString("HealthText");
		// 	Open();		
		}

       

		#endregion


		#region Clear
		public void Clear()
		{
			
			try 
			{
				if ( lineDisplay.Claimed)
				{
					lineDisplay.ClearText();
				}	
			}
			catch (PosException px)
			{
				Logger.Error( "LineDisplayWrapper.cs", "LineDisplayWrapper.cs :" + " Pos Exception in LineDisplay :" + px.ToString());
			}


		
		}
		#endregion

		#region Idle

		public void Idle (string line1, string line2)
		{

			if (!lineDisplay.Claimed)
			{
				return;
			}

			StringBuilder s = new StringBuilder();
			s.Append(line1);
			s.Append(line2);

			try
			{
				//lineDisplay.MarqueeType = DisplayMarqueeType.Init; 
				//lineDisplay.ClearText ();
				//lineDisplay.CharacterSet = 105;
				//lineDisplay.DisplayText(s.ToString(), 0);
				//lineDisplay.MarqueeUnitWait =200;
				//lineDisplay.MarqueeFormat = DisplayMarqueeFormat.Walk;
				//lineDisplay.MarqueeType = DisplayMarqueeType.Left;
               
                //createWindow(int viewportRow, int viewportColumn, int viewportHeight,
                //int viewportWidth, int windowHeight, int windowWidth);
                lineDisplay.CreateWindow(1, 10, 1, 10, 1, 34);

                //When "MarqueeFormat" is "DisplayMarqueeFormat.Walk",
                //put a character on the display one by one from the reverse of the side that
                //you selected as The direction of "Marquee".
                //The direction of "Marquee" is that you selected as "MarqueeType".
                lineDisplay.MarqueeFormat = DisplayMarqueeFormat.Walk;

                //When the "MarqueeType" is "DisplayMarqueeType.Init",
                //  The change of the setting from "DisplayMarqueeType.Init" permits that the setting of "String data" and
                //  "MarqueeFormat" becomes effective.
                lineDisplay.MarqueeType = DisplayMarqueeType.Init;

                //It is 1.0 second that the next head of "String data" starts
                //  after the end of "String data" was displayed.
                lineDisplay.MarqueeRepeatWait = 1000;

                //It takes 0.1 second that the next moving satarts
                //  after the end of the one moving of unit.
                lineDisplay.MarqueeUnitWait = 100;

                lineDisplay.DisplayText(s.ToString(), DisplayTextMode.Normal);

                //For set the direction as "MarqueeType". For example, the left and the right, the dawn and so on.
                //disp.setMarqueeType(LineDisplayConst.DISP_MT_LEFT);
                lineDisplay.MarqueeType = DisplayMarqueeType.Left;

                //MessageBox.Show("When pressing OK, it ends.", "DisplaySample_Step6"
                //    , MessageBoxButtons.OK);

                lineDisplay.MarqueeType = DisplayMarqueeType.None;
                lineDisplay.DestroyWindow();
			}
			catch (Exception e)
			{
                MessageBox.Show(e.ToString());
				Logger.Error("LineDisplayWrapper.cs" , "LineDisplayWrapper.cs :" + "Exception in LineDisplay idle " + e.ToString ());
			}
		}


        



		#endregion 

		#region SetText

		public void SetText (string text)
		{
			if (!lineDisplay.Claimed)
			{
				this.Reset();
			}
			if (lineDisplay.Claimed)
			{

				DisplayText(text, 0, 0);
			}
		}


		public void SetText (String text, int row, int column)
		{
            try
            {
                if (lineDisplay.Claimed) DisplayText(text, row, column);
            }
            catch
            {
                this.Reset();
                if (lineDisplay.Claimed) DisplayText(text, row, column);
            }
	
		}

		#endregion

		#region PromptWidth

		public int PromptWidth()
		{

			if (!lineDisplay.Claimed) return 0; 
			
			int columns = 0;
			
			try
			{
				columns = lineDisplay.Columns;
			}
			catch (Exception e)
			{
			}
			return columns;
		}

		#endregion


		#region DisplayText

		private void DisplayText (string t, int row, int column)
		{

			if (!lineDisplay.Claimed) return;
			
			if (PromptWidth() == 0)
			{
				return;
			}
		 
			string tmp;
			if (t.Length > PromptWidth ())
			{
				tmp = t.Substring(0, PromptWidth () - 1);
			}
			else
			{
				tmp = t;
			}

			try
			{
      
				lineDisplay.DisplayTextAt(row, column, tmp, 0);
			}
			catch (Exception e)
			{
				Logger.Error("LineDisplayWrapper.cs", "LineDisplayWrapper.cs :" + e.ToString ());
			}
		}

		#endregion


		#region Open	 
		
		public void Open ()
		{
			
			try
			{
				lineDisplay.Open();
				lineDisplay.Claim(1000);
				lineDisplay.DeviceEnabled =true;
                deviceText = lineDisplay.DeviceDescription;
				statusText = lineDisplay.State.ToString();
                this.RaiseStatusChangedEvent();
        	}
			catch (PosControlException e)
			{
                MessageBox.Show(e.ToString());
				Logger.Error("LineDisplayWrapper.cs", "LineDisplayWrapper.cs :" + "Pos Exception, open : " +  e.StackTrace);
                this.RaiseStatusChangedEvent();
            }
			catch (Exception e)
			{
                MessageBox.Show(e.ToString());
				Logger.Error("LineDisplayWrapper.cs" , e.StackTrace);
                this.RaiseStatusChangedEvent();
			}
			
		}
		
		#endregion


		#region CheckHealth

		public bool CheckHealth ()
		{
		//	String deviceHealthText = null;
			if ( !lineDisplay.Claimed)
			{
				this.Reset();
			}

			if ( lineDisplay.Claimed )
			{
				//try
				//{
				//	//lineDisplay.CheckHealth(HealthCheckLevel.Internal);
				//	return true;
				//}
				//catch (PosControlException pce)
				//{ 
				//	Logger.Error("LineDisplayWrapper.cs", pce.ToString() );
				//	return false;
				//}
				//catch (Exception e)
				//{
				//	Logger.Error("LineDisplayWrapper.cs", e.ToString());
				//	return false;
				//}

                return true;
			}

			return false;

						
		}

		#endregion


		#region Reset

		public bool Reset ()
		{
			
			try
			{
				if (lineDisplay.DeviceEnabled )
				{
					lineDisplay.DeviceEnabled = false;
				}

				if (lineDisplay.Claimed )
				{
					lineDisplay.Release();
				}
				
				lineDisplay.Close();
				
			}
			catch ( PosControlException pce)
			{
				Logger.Error( "PosPrinterWrapper.cs", pce.ToString() );
			
			}
			finally
			{
				Open ();
				
			}
			if( lineDisplay.Claimed)
			{
				return true;
			}
			else
			{
				return false;
			}

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
			try 
			{
				if (lineDisplay.DeviceEnabled)
				{
					lineDisplay.DeviceEnabled = false;
				}
			
				if ( lineDisplay.Claimed)
				{
					lineDisplay.Release();
				}
				
				lineDisplay.Close();

                
			}
			catch (Exception e )
			{
				Logger.Error("PosPrinterWrapper.cs" , e.ToString ());
						  
			}
	
		}
	
		#endregion

        #region Raise Status Event
        protected virtual void RaiseStatusChangedEvent()
        {
            if (lineDisplay.Claimed)
            {
                StatusEvent(this, 1);
            }
            else
            {
                StatusEvent(this, 0);
            }
        }
        #endregion

		#region IDisposable Members

		public void Dispose()
		{
			try 
			{
				this.Close();
			}
			catch(Exception e) 
			{
				Logger.Error("PosPrinterWrapper.cs" , e.ToString ());
				
			}
		}

		#endregion


	}

	
	
}
