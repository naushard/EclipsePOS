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
    public class CashDrawerWrapper : HardwareSupport, IDisposable
    {
        #region Variable
        private string deviceText = null;
        private string statusText = "Error";
        private string healthText = "Unknown";
        private Microsoft.PointOfService.CashDrawer cashDrawer = null;
        public delegate void StausChangedEventHandler(object sender, int deviceStatus);
        public event StausChangedEventHandler StatusEvent;
		
        #endregion

        public CashDrawerWrapper(CashDrawer pCashDrawer)
        {

            this.cashDrawer = pCashDrawer;
        }

        #region Open

        public void Open()
        {

            try
            {
                this.cashDrawer.Open();
                this.cashDrawer.Claim(1000);
                this.cashDrawer.DeviceEnabled = true;
                deviceText = this.cashDrawer.DeviceDescription;
                statusText = this.cashDrawer.State.ToString();
                this.RaiseStatusChangedEvent();
                
            }
            catch (PosControlException e)
            {
                this.RaiseStatusChangedEvent();
                Logger.Error("CashDrawerWrapper.cs", "CashDrawerWrapper.cs :" + "Pos Exception, open : " + e.StackTrace);
            
            }
            catch (Exception e)
            {
                this.RaiseStatusChangedEvent();
                Logger.Error("CashDrawerWrapper.cs", e.StackTrace);
            }

        }



       

        public void OpenDrawer()
        {
            this.cashDrawer.OpenDrawer();
        }


        


        #endregion

        public bool CheckHealth()
        {
           
            if (!this.cashDrawer.Claimed)
            {
                this.Reset();
            }

            if (this.cashDrawer.Claimed)
            {


                return true;
            }

            return false;

        }


        public bool Reset()
        {
            try
            {
                if (this.cashDrawer.DeviceEnabled)
                {
                    this.cashDrawer.DeviceEnabled = false;
                }

                if (this.cashDrawer.Claimed)
                {
                    this.cashDrawer.Release();
                }

                this.cashDrawer.Close();

            }
            catch (PosControlException pce)
            {
                Logger.Error("CashDrawerWrrapper.cs", pce.ToString());

            }
            finally
            {
                Open();

            }
            if (this.cashDrawer.Claimed)
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
                if (this.cashDrawer.DeviceEnabled)
                {
                    this.cashDrawer.DeviceEnabled = false;
                }

                if (this.cashDrawer.Claimed)
                {
                    this.cashDrawer.Release();
                }

                this.cashDrawer.Close();


            }
            catch (Exception e)
            {
                Logger.Error("CashDrawerWrapper.cs", e.ToString());

            }
        }


        #region Raise Status Event
        protected virtual void RaiseStatusChangedEvent()
        {
            if (this.cashDrawer.Claimed)
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
                Logger.Error("CashDrawerWrapper.cs", e.ToString());

            }
        }

        #endregion


    }
}
