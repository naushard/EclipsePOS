using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Threading;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;

using Microsoft.PointOfService;



namespace EclipsePos.Apps.Hardware
{
    public class ScannerWrapper : HardwareSupport, IDisposable
    {
        #region Variable
        private string deviceText = null;
        private string statusText = "Error";
        private string healthText = "Unknown";
        private Microsoft.PointOfService.Scanner scanner = null;
        public delegate void StausChangedEventHandler(object sender, int deviceStatus);
        public event StausChangedEventHandler StatusEvent;
		
        #endregion

       
        
        #region Constructor
		
		public ScannerWrapper(Scanner pScanner)
		{
			this.scanner = pScanner;
            
           
		}
        #endregion


        #region Open

        public void Open()
        {

            try
            {
                this.scanner.Open();
                this.scanner.Claim(1000);
                this.scanner.DeviceEnabled = true;
                deviceText = this.scanner.DeviceDescription;
                statusText = this.scanner.State.ToString();
                this.scanner.DataEventEnabled = true;
                this.scanner.DecodeData = true;
                this.RaiseStatusChangedEvent();
               

                this.scanner.DataEvent += new DataEventHandler(scanner_DataEvent);

            }
            catch (PosControlException e)
            {
                //MessageBox.Show(e.ToString());
                this.RaiseStatusChangedEvent();
                Logger.Error("ScannerWrapper.cs", "ScannerWrapper.cs :" + "Pos Exception, open : " + e.StackTrace);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                this.RaiseStatusChangedEvent();
                Logger.Error("ScannerWrapper.cs", e.StackTrace);
            }

        }



        void scanner_DataEvent(object sender, DataEventArgs e)
        {
            
            string str = null;
            byte[] b = scanner.ScanDataLabel;
            for (int i = 0; i < b.Length; i++)
                str += (char)b[i];
           // str += "\r\n";

            this.Process(str);

            this.scanner.DataEventEnabled = true;
           
        }

        public void Process(string scannedCode)
        {
            PosContext.Instance.InputLine = scannedCode;
            new EnterKey().Engage(0);

        }



        #endregion

        public bool CheckHealth()
        {
            String deviceHealthText = null;
            if (!this.scanner.Claimed)
            {
                this.Reset();
            }

            if (this.scanner.Claimed)
            {
                

                return true;
            }

            return false;

        }


        public bool Reset()
        {
            try
            {
                if (this.scanner.DeviceEnabled)
                {
                    this.scanner.DeviceEnabled = false;
                }

                if (this.scanner.Claimed)
                {
                    this.scanner.Release();
                }

                this.scanner.Close();

            }
            catch (PosControlException pce)
            {
                Logger.Error("ScannerWrrapper.cs", pce.ToString());

            }
            finally
            {
                Open();

            }
            if (this.scanner.Claimed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public string DeviceText()
        {
            return deviceText;
        }


        public string StatusText()
        {
            return statusText;
        }


        public void Close()
        {

            try
            {
                if (this.scanner.DeviceEnabled)
                {
                    this.scanner.DeviceEnabled = false;
                }

                if (this.scanner.Claimed)
                {
                    this.scanner.Release();
                }

                this.scanner.Close();


            }
            catch (Exception e)
            {
                Logger.Error("ScannerWrapper.cs", e.ToString());

            }
        }

        #region Raise Status Event
        protected virtual void RaiseStatusChangedEvent()
        {
            if (this.scanner.Claimed)
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
            catch (Exception e)
            {
                Logger.Error("ScannerWrapper.cs", e.ToString());

            }
        }

        #endregion

    }
}
