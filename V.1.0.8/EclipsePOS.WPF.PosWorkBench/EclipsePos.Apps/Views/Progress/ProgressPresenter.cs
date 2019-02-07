using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Views.LeftMenu;
using EclipsePos.Apps.Views.BottomMenu;
using EclipsePos.Apps.Views.Invoice;
using EclipsePos.Apps.Views.InvoiceTotals;
using EclipsePos.Apps.Constants;
using EclipsePos.Apps.Views.Progress;
using EclipsePos.Apps;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents; 

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Views.Progress
{
    public class ProgressPresenter
    {
        private IProgress _view;

        public IProgress View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

       
        /*
        public void Initialize2()
        {
            //Cursor = System.Windows.cur.Forms.Cursors.WaitCursor;
            // this.ShowProgressBar();
            //Pos Explorer 
            this.View.SetProgressStep(50, "Creating PosExplorer");
            MessageBox.Show("OK");
            try
            {

                Logger.Info("FrmMain.cs", "Creating PosExplorer");
                PosContext.Instance.PosExplorer = new PosExplorer();

                // Handle the ApplicationExit event to know when the application is exiting.
                //Application.ApplicationExit += new EventHandler(PosHardware.Instance.Close);

            }
            catch (Exception e)
            {
                Logger.Error("FrmMain.cs", e.ToString());
                //Application.Exit();
            }

            // Initaialize EJournals
            //this.SetProgress(10, "Creating PosExplorer");
            //try
            //{
            //	Logger.Info("FrmMain.cs", "Initializing EJournals");
            //	PosContext.Instance.CurrentEj.Clear();
            //}
            //catch (Exception e) 
            //{
            //	Logger.Error("FrmMain.cs", e.ToString() );
            //	Application.Exit();
            //}

            //this.SetProgress(30); //, "Initializing Hardware");
            //Initilize Hardware
            try
            {
                Logger.Info("FrmMain.cs", "FrmMain.cs: " + "Calling PosHardware/Initialize", PosSettings.Default.Debug);
                PosHardware.Instance.Initialize();
                // Handle the ApplicationExit event to know when the application is exiting.
                //Application.ApplicationExit += new EventHandler(PosHardware.Instance.Close);


            }
            catch (Exception e)
            {
                Logger.Error("FrmMain.cs", e.StackTrace);
                //Application.Exit();
            }

            //Check database connection 
            this.View.SetProgressStep(60, "Database setup");
            MessageBox.Show("OK");

            try
            {
                Logger.Info("FrmMain.cs", "FrmMain.cs: " + "Calling PosConfig", PosSettings.Default.Debug);

                PosConfig posConfig = new PosConfig();
                posConfig.ConfigNo = PosSettings.Default.ConfigNo;
                //posConfig.LoadByConfigName();

                //Load configuration setting via PocConfig
                posConfig.Organization_id = PosSettings.Default.Organization;
                posConfig.Relations();
                //Cash the config code in the PosContext
                PosContext.Instance.Config = posConfig;

                //Load parameter setting;
                PosParameters parms = new PosParameters(PosContext.Instance.Config.ConfigNo);
                PosContext.Instance.Parameters = parms;

                //Retatil store group
                RetailStore retailStore = new RetailStore();
                retailStore.Retail_store_no = PosSettings.Default.RetailStoreNo;
                retailStore.Organization_no = PosSettings.Default.Organization;
                retailStore.Load();

                // Store RetailStore object in PosContext for easy reference
                PosContext.Instance.RetailStore = retailStore;

            }
            catch (Exception e)
            {
                Logger.Error("FrmMain.cs", e.StackTrace);
                //Application.Exit();
            }



            //Load panel classes
            this.View.SetProgressStep(70, "Loading display panels");
            MessageBox.Show("OK");
            //LoadPanels();


            //Load Main Menu
            //LoadMenu((int)POSMenu.CommonTasks);


            //End
            this.View.SetProgressStep(100, "Loading Startup events");
            MessageBox.Show("OK");
            //Create pos context and Open for input
            //PosContext.Instance.PosInit("Logon");



            //Cursor = System.Windows.Forms.Cursors.Arrow;
            this.View.CloseDialog();

        }
         * */

    }
}
