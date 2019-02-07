using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Data;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows;
using System.Reflection;
using System.Collections;
using System.Windows.Media;

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Views.LeftMenu;
using EclipsePos.Apps.Views.BottomMenu;
using EclipsePos.Apps.Views.Invoice;
using EclipsePos.Apps.Views.AlphaKeyPad;
using EclipsePos.Apps.Views.InvoiceTotals;
using EclipsePos.Apps.Views.InvoiceHeader;
using EclipsePos.Apps.Views.ItemSearch;
using EclipsePos.Apps.Views.KeyPad;
using EclipsePos.Apps.Views.TableGroupSelect;
using EclipsePos.Apps.Constants;
using EclipsePos.Apps.Views.Progress;
using EclipsePos.Apps.Views.TableSelect;
using EclipsePos.Apps.Views.CustomerSearch;
using EclipsePos.Apps.Views.OrderList;
using EclipsePos.Apps;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Views.ItemGroup;
using EclipsePos.Apps.Views.ItemGroupDetails;
using EclipsePos.Apps.Views.TransactonHistory;
using EclipsePos.Apps.Views.Employees;


using Microsoft.PointOfService;


namespace EclipsePos.Apps
{
    public class EclipsePosAppsModule: IModule, PosDisplays
    {

        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;
        private IProgress progressView;

       // public delegate void InitPos();
       
        public delegate void InitPosDelegate();
        private bool status = false;
        
       

        public EclipsePosAppsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;

            PosContext.Instance.CurrentPosDisplay = this;
        }

        public void Initialize()
        {
            try
            {
                
            //    SplashScreen appSplash = new SplashScreen(this.GetType().Assembly, @"\..\..\Images\Eclipse_banner.jpg");
            //    appSplash.Show(false);
                this.InitializePos();
            //    appSplash.Close(TimeSpan.FromSeconds(0.3));

             }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                PosContext.Instance.Dispose();
                Application.Current.Shutdown();
                return;

            }
            
        }

        void oper_Completed(object sender, EventArgs e)
        {  

           // this.progressView.CloseDialog();
           // if (!status) Application.Current.Shutdown();
        }

        

        public void ShowProgressBar()
        {
            progressView = _container.Resolve<ProgressView>();
            progressView.ShowProgressDialog();
        }

        public void InitializePos()
        {
            //Enable Logging
            Logger.Enabled = true;
           
            		
			//Check database connection 
      
          //  try
          //  {
                //Load Organization
                Logger.Info(this.GetType().FullName, this.GetType().FullName + "Reading Organization", PosSettings.Default.Debug);
                Organization organization = new Organization();
                organization.Organization_no = PosSettings.Default.Organization;
                organization.LoadByOrganizationNo();
                PosContext.Instance.Organization = organization;


                Logger.Info(this.GetType().FullName, this.GetType().FullName + "Reading PosConfig", PosSettings.Default.Debug);

                PosConfig posConfig = new PosConfig();
                posConfig.ConfigNo = PosSettings.Default.Configuration;
                posConfig.LoadByConfigNo();

                //Load configuration setting via PocConfig
                posConfig.Organization_id = PosSettings.Default.Organization;
                posConfig.Relations();

                //Cash the config code in the PosContext
                PosContext.Instance.Config = posConfig;

                //Load parameter setting;
                PosParameters parms = new PosParameters(PosContext.Instance.Config.ConfigNo);
                PosContext.Instance.Parameters = parms;

                Application.Current.MainWindow.FontFamily = new FontFamily(PosContext.Instance.Parameters.getParam("FontFamily"));

                //Retatil store group
                RetailStore retailStore = new RetailStore();
                retailStore.Retail_store_no = PosSettings.Default.Store;
                retailStore.Organization_no = PosSettings.Default.Organization;
                retailStore.Load();

                // Store RetailStore object in PosContext for easy reference
                PosContext.Instance.RetailStore = retailStore;

           // }
           // catch (Exception e)
           // {
           //     Logger.Error(this.GetType().FullName, e.StackTrace, e);
           //     MessageBox.Show("Please setup data source" + "\n" + e.ToString());
           //     PosHardware.Instance.Close();
           //     Application.Current.Shutdown();
           //     return;
           // }
	
		
            
           	//Load panel classes
		//	this.progressView.SetProgressStep(50, "Loading menus");
            this.LoadPanels();
          

			//End
	//		this.progressView.SetProgressStep(100, "Loading Startup events");
            this.InitDisplay();


            //Pos Explorer 
            try
            {
                //PropertyInfo info = this.GetType().FullName
                Logger.Info(this.GetType().FullName, this.GetType().FullName + ":" + "Creating PosExplorer", PosSettings.Default.Debug);
                PosContext.Instance.PosExplorer = new PosExplorer();

                Logger.Info(this.GetType().FullName, this.GetType().FullName + ":" + "Initilizing POS Hardware", PosSettings.Default.Debug);
                PosHardware.Instance.Initialize();


            }
            catch (Exception e)
            {
                Logger.Error(this.GetType().FullName, e.ToString(), e);

            }
		
            
            this.status = true;
            
		
        }

       
        private void LoadPanels()
        {
            MenuPanels menuPanels = new MenuPanels();
            menuPanels.Config_no = PosSettings.Default.Configuration;
            DataSet panelData = menuPanels.GetMenuPanels();
            try
            {
                DataTable panelTable = panelData.Tables[0];

                foreach (DataRow dr in panelTable.Rows)
                {
                 
                    string panelClassName = dr["panel_class_name"].ToString();
                    int panelId = int.Parse(dr["panel_id"].ToString());
                    string panelName = dr["panel_name"].ToString();
                    if (panelClassName == "EclipsePos.Apps.Views.LeftMenu.LeftMenuView")
                    {
                        LeftMenuView leftMenu = _container.Resolve<LeftMenuView>();
                        leftMenu.AddPosKeys(panelId, panelName);
                        _container.RegisterInstance<LeftMenuView>(panelId.ToString(), leftMenu);

                        PosContext.Instance.Guis.Add(leftMenu);

                    }

                    if (panelClassName == "EclipsePos.Apps.Views.BottomMenu.BottomMenuView")
                    {
                        BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
                        bottomMenu.AddPosKeys(panelId, panelName);
                        _container.RegisterInstance<BottomMenuView>(panelId.ToString(), bottomMenu);

                        PosContext.Instance.Guis.Add(bottomMenu);
                    }

                 
                    
                }
            }
             
            catch (Exception e)
            {
                Logger.Error(this.GetType().FullName, e.StackTrace, e);
            }

            ItemSearchView itemSearchView = _container.Resolve<ItemSearchView>();
            _container.RegisterInstance<ItemSearchView>("995", itemSearchView);
            PosContext.Instance.Guis.Add(itemSearchView);

            KeyPadView keyPad = _container.Resolve<KeyPadView>();
            _container.RegisterInstance<KeyPadView>("KeyPadView", keyPad);
            PosContext.Instance.Guis.Add(keyPad);

            AlphaKeyView alphaKeyView = _container.Resolve<AlphaKeyView>();
            _container.RegisterInstance<AlphaKeyView>("AlphaKeyView", alphaKeyView);
            PosContext.Instance.Guis.Add(alphaKeyView);



            ItemGroupView itemGroupView = _container.Resolve<ItemGroupView>();
            _container.RegisterInstance<ItemGroupView>("994", itemGroupView);
            //PosContext.Instance.Guis.Add(itemSearchView);

        }



        public void InitDisplay()
        {
            

        //    this.progressView.CloseDialog();
           
            PosContext.Instance.KeysByControl.Clear();
            //_container.
            OneLineView oneLine = _container.Resolve<OneLineView>();
            _regionManager.Regions[Regions.OperatorPromptRegion].Add(oneLine);
            PosContext.Instance.PosPrompt = oneLine;
           // PosContext.Instance.Operprompt = oneLine;

          //  LeftMenuView leftMenu = _container.Resolve<LeftMenuView>(PosContext.Instance.Parameters.getParam("HomeLeftPanelNo"));
          //  _regionManager.Regions[Regions.LeftMenuRegion].Add(leftMenu, "ActiveView");
          //  leftMenu.LoadControls();

            BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
            _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu);
            bottomMenu.LoadControls();

            InvoiceView invView = _container.Resolve<InvoiceView>();
            _container.RegisterInstance<InvoiceView>(invView);
            PosContext.Instance.ReceiptDetails = invView;
            _regionManager.Regions[Regions.InvoiceRegion].Add(invView,"ActiveView");

            InvoiceTotalView invTotalView = _container.Resolve<InvoiceTotalView>();
            PosContext.Instance.ReceiptTotal = invTotalView;
            _container.RegisterInstance<InvoiceTotalView>("InvoiceTotalView", invTotalView);
            _regionManager.Regions[Regions.InvoiceTotalRegion].Add(invTotalView, "ActiveView");
            //invTotalView.LoadControls();
           
            

            KeyPadView keyPadView = _container.Resolve<KeyPadView>("KeyPadView");
            _regionManager.Regions[Regions.KeyPadRegion].Add(keyPadView, "ActiveView");
            keyPadView.LoadControls();
           


            InvoiceHeaderView invHeaderView = _container.Resolve<InvoiceHeaderView>();
            PosContext.Instance.ReceiptHeader = invHeaderView;
           _regionManager.Regions[Regions.InvoiceHeaderRegion].Add(invHeaderView);


           ItemGroupView itemGroupView = _container.Resolve<ItemGroupView>();
           _regionManager.Regions[Regions.LeftMenuRegion].Add(itemGroupView, "ActiveView"); 
            itemGroupView.AddPosKeys(1, "Item Groups");

            
            PosContext.Instance.PosInit("Logon");

            

        }

        public void LoadMenu(int subMenuId)
        {
            
            PosContext.Instance.KeysByControl.Clear();

           
           InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>("InvoiceTotalView");
           //invTot.LoadControls();
           PosContext.Instance.Receipt.OperDisplayTotals = (PosTicketTotal)invTot;

            KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPadView");
            keyPad.LoadControls();

          //  object view1 = _regionManager.Regions[Regions.KeyPadRegion].GetView("ActiveView");
          //  if (view1 is KeyPadView )
          //  {
          //      _regionManager.Regions[Regions.KeyPadRegion].Remove(view1);
          //      _regionManager.Regions[Regions.KeyPadRegion].Add(invTot, "ActiveView");
          //     
          //  }

            MenuConfig menus = (MenuConfig)PosContext.Instance.Config.MenuConfigs[subMenuId];

            //Item Search/Table menu
            object tableView = _regionManager.Regions[Regions.TableRegion].GetView("ActiveView");
            if (tableView != null)
            {
                _regionManager.Regions[Regions.TableRegion].Remove(tableView);
            }

            object logView = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
            if (logView != null)
            {
                _regionManager.Regions[Regions.LogRegion].Remove(logView);
            }

            //Right menu
            object rightView = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
            if (rightView != null)
            {
                _regionManager.Regions[Regions.RightMenuRegion].Remove(rightView);
            }
            if (menus.Right_panel_id > 0)
            {
                LeftMenuView rightMenu = _container.Resolve<LeftMenuView>(menus.Right_panel_id.ToString());
                _regionManager.Regions[Regions.RightMenuRegion].Add(rightMenu, "ActiveView");
            }


            //Left menu
            object view = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (view != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(view);
            }

            if (menus.Left_panel_id == 994)
            {
                ItemGroupView itemMenu = _container.Resolve<ItemGroupView>("994");
                _regionManager.Regions[Regions.LeftMenuRegion].Add(itemMenu, "ActiveView");
            }
            else
            {

                LeftMenuView leftMenu = _container.Resolve<LeftMenuView>(menus.Left_panel_id.ToString());
                _regionManager.Regions[Regions.LeftMenuRegion].Add(leftMenu, "ActiveView");
                // leftMenu.LoadControls();
            }

          //  BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
          //  bottomMenu.LoadControls();
            object viewBottom = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
            if (viewBottom != null)
            {
                _regionManager.Regions[Regions.NavigatorRegion].Remove(viewBottom);
            }

            BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>(menus.Bottom_panel_id.ToString());
            _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu, "ActiveView");

            


        }


        public void LoadItemGroupDetailPanel(object panel)
        {

            if (panel is ItemGroupDetailsView)
            {
                ItemGroupDetailsView itemPanel = panel as ItemGroupDetailsView;

                object view = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
                if (view != null)
                {
                    _regionManager.Regions[Regions.RightMenuRegion].Remove(view);
                }

                _regionManager.Regions[Regions.RightMenuRegion].Add(itemPanel, "ActiveView");

            }

        }



        public void LoadItemSearch(int searchKey)
        {
            PosContext.Instance.KeysByControl.Clear();

            object leftView = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (leftView != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(leftView);
            }


            object rightView = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
            if (rightView != null)
            {
                _regionManager.Regions[Regions.RightMenuRegion].Remove(rightView);
            }

            object tableView = _regionManager.Regions[Regions.TableRegion].GetView("ActiveView");
            if (tableView != null)
            {
                _regionManager.Regions[Regions.TableRegion].Remove(tableView);
            }

            object logView = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
            if (logView != null)
            {
                _regionManager.Regions[Regions.LogRegion].Remove(logView);
            }

            ItemSearchView itemSearchView = _container.Resolve<ItemSearchView>("ItemSearch");
            itemSearchView.SearchKey = SearchBy.Description;
           
            _regionManager.Regions[Regions.LogRegion].Add(itemSearchView, "ActiveView");
            itemSearchView.LoadControls();

            object viewBottom = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
            if (viewBottom != null)
            {
                _regionManager.Regions[Regions.NavigatorRegion].Remove(viewBottom);
            }

            BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>("995");
            _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu, "ActiveView");
            bottomMenu.LoadControls();


           // BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
           // bottomMenu.LoadControls();

            //PosContext.Instance.Receipt.OperDisplayTotals = (PosTicketTotal)keyPad;
            //PosContext.Instance.Receipt.Update(PosContext.Instance.EjCustomer);

            //InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>();
            //invTot.LoadControls();


        }


        public void LoadTransactionLog()
        {

            try
            {

                PosContext.Instance.KeysByControl.Clear();

                object leftView = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
                if (leftView != null)
                {
                    _regionManager.Regions[Regions.LeftMenuRegion].Remove(leftView);
                }


                object rightView = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
                if (rightView != null)
                {
                    _regionManager.Regions[Regions.RightMenuRegion].Remove(rightView);
                }

                object tableView = _regionManager.Regions[Regions.TableRegion].GetView("ActiveView");
                if (tableView != null)
                {
                    _regionManager.Regions[Regions.TableRegion].Remove(tableView);
                }

                object logViewBefore = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
                if (logViewBefore != null)
                {
                    _regionManager.Regions[Regions.LogRegion].Remove(logViewBefore);
                }

                object viewBottom = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
                if (viewBottom != null)
                {
                    _regionManager.Regions[Regions.NavigatorRegion].Remove(viewBottom);
                }


                LogView logView = _container.Resolve<LogView>("LogView");

                _regionManager.Regions[Regions.LogRegion].Add(logView, "ActiveView");
                // itemSearchView.LoadControls();


                /**
                BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>("995");
                _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu, "ActiveView");
                bottomMenu.LoadControls();
                **/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

           


        }





       
        public void PageUp()
        {
            InvoiceView invView = _container.Resolve<InvoiceView>();
            invView.PageUp();
        }


        public void PageDown()
        {
            InvoiceView invView = _container.Resolve<InvoiceView>();
            invView.PageDown();

        }


        public void KeyboardUtility(int utilityCode)
        {
            object view1 = _regionManager.Regions[Regions.KeyPadRegion].GetView("ActiveView");
            if (view1 != null)
            {
                _regionManager.Regions[Regions.KeyPadRegion].Remove(view1);
                if (view1 is AlphaKeyView)
                {
                    KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPadView");
                    _regionManager.Regions[Regions.KeyPadRegion].Add(keyPad, "ActiveView");
           
                }
                else
                {
                    AlphaKeyView alphaKeyView = _container.Resolve<AlphaKeyView>("AlphaKeyView");
                    _regionManager.Regions[Regions.KeyPadRegion].Add(alphaKeyView, "ActiveView");
                }
            }
           
            
        }

        public void LoadTableSelect()
        {
            PosContext.Instance.KeysByControl.Clear();

            object leftView = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (leftView != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(leftView);
            }

            object rightView = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
            if (rightView != null)
            {
                _regionManager.Regions[Regions.RightMenuRegion].Remove(rightView);
            }

            object bottomView = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
            if (bottomView != null)
            {
                _regionManager.Regions[Regions.NavigatorRegion].Remove(bottomView);
            }

            object logView = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
            if (logView != null)
            {
                _regionManager.Regions[Regions.LogRegion].Remove(logView);
            }
            
          
            TableGroupView tableGroupView = _container.Resolve<TableGroupView>();
            _regionManager.Regions[Regions.NavigatorRegion].Add(tableGroupView, "ActiveView");
            tableGroupView.LoadControls();

            /*
            object view1 = _regionManager.Regions[Regions.KeyPadRegion].GetView("ActiveView");
            if (view1 != null)
            {
                _regionManager.Regions[Regions.KeyPadRegion].Remove(view1);
            }

            object view2 = _regionManager.Regions[Regions.InvoiceRegion].GetView("ActiveView");
            if (view2 != null)
            {
                _regionManager.Regions[Regions.InvoiceRegion].Remove(view2);
            }
            */

            TableView tableView= _container.Resolve<TableView>();
            _container.RegisterInstance<TableView>(tableView);
            _regionManager.Regions[Regions.TableRegion].Add(tableView, "ActiveView");

            //Dummy load to enable keys;
           // KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPadView");
           // keyPad.LoadControls();

           // InvoiceTotalView invTotalView = _container.Resolve<InvoiceTotalView>("InvoiceTotalView");
            //invTotalView.LoadControls();        


        }

        public void UnloadTableSelect()
        {
            /*
            PosContext.Instance.KeysByControl.Clear();

            object view1 = _regionManager.Regions[Regions.TableRegion].GetView("ActiveView");
            if (view1 != null)
            {
                _regionManager.Regions[Regions.TableRegion].Remove(view1);
            }


            InvoiceView invView = _container.Resolve<InvoiceView>();
            _regionManager.Regions[Regions.InvoiceRegion].Add(invView, "ActiveView");
           

            InvoiceTotalView invTotView = _container.Resolve<InvoiceTotalView>("InvoiceTotalView");
            _regionManager.Regions[Regions.KeyPadRegion].Add(invTotView, "ActiveView");
            //invTotView.LoadControls();
            PosContext.Instance.Receipt.OperDisplayTotals = (PosTicketTotal)invTotView;



            object view2 = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (view2 != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(view2);
            }

            LeftMenuView leftMenu = _container.Resolve<LeftMenuView>(PosContext.Instance.Parameters.getParam("HomeLeftPanelNo")); //PosSettings.Default.DefaultLeftPanelid.ToString());
            _regionManager.Regions[Regions.LeftMenuRegion].Add(leftMenu, "ActiveView");
            leftMenu.LoadControls();

            //Dummy load to enable keys;
            KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPad");
            keyPad.LoadControls();

            BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
            bottomMenu.LoadControls();

            */

            this.LoadMenu(int.Parse(PosContext.Instance.Parameters.getParam("HomeMenuID")));
        
        }

        public void LoadTable(int tableGroupNo)
        {
            TableView tableView = _container.Resolve<TableView>();
          //  _regionManager.Regions[Regions.TableRegion].Add(tableView, "ActiveView");
            tableView.DrawTableModel(tableGroupNo);
        }


        public void LoadCustomerSearch()
        {
            PosContext.Instance.KeysByControl.Clear();

            object view = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (view != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(view);
            }

            CustomerSearchView customerSearchView = _container.Resolve<CustomerSearchView>("CustomerSearch");
            _regionManager.Regions[Regions.LeftMenuRegion].Add(customerSearchView, "ActiveView");
            customerSearchView.LoadControls();
           
            BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
            bottomMenu.LoadControls();

            object view1 = _regionManager.Regions[Regions.KeyPadRegion].GetView("ActiveView");
            if (view1 != null)
            {
                _regionManager.Regions[Regions.KeyPadRegion].Remove(view1);
            }

            KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPadView");
            _regionManager.Regions[Regions.KeyPadRegion].Add(keyPad, "ActiveView");
            keyPad.LoadControls();
            PosContext.Instance.Receipt.OperDisplayTotals = (PosTicketTotal)keyPad;
          

            InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>();
            //invTot.LoadControls();


        }


        public void LoadOpenOrdersList()
        {

            PosContext.Instance.KeysByControl.Clear();

            object view = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (view != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(view);
            }

            object logView = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
            if (logView != null)
            {
                _regionManager.Regions[Regions.LogRegion].Remove(logView);
            }

            object bottomView = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
            if (bottomView != null)
            {
                _regionManager.Regions[Regions.NavigatorRegion].Remove(bottomView);
            }


            object keyView = _regionManager.Regions[Regions.KeyPadRegion].GetView("ActiveView");
            if (keyView != null)
            {
                _regionManager.Regions[Regions.KeyPadRegion].Remove(keyView);
            }


            OpenOrderView openOrdersView = _container.Resolve<OpenOrderView>();
            _regionManager.Regions[Regions.LogRegion].Add(openOrdersView, "ActiveView");
           // openOrdersView.LoadControls();

          //  BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
          //  bottomMenu.LoadControls();

           
            KeyPadView keyPad = _container.Resolve<KeyPadView>("KeyPadView");
            _regionManager.Regions[Regions.KeyPadRegion].Add(keyPad, "ActiveView");
            keyPad.LoadControls();
            PosContext.Instance.Receipt.OperDisplayTotals = (PosTicketTotal)keyPad;


           //  InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>();
            //invTot.LoadControls();


        }


        // Helper view for sales person entry
        public void LoadEmployeeView()
        {
            PosContext.Instance.KeysByControl.Clear();

            object leftView = _regionManager.Regions[Regions.LeftMenuRegion].GetView("ActiveView");
            if (leftView != null)
            {
                _regionManager.Regions[Regions.LeftMenuRegion].Remove(leftView);
            }


            object rightView = _regionManager.Regions[Regions.RightMenuRegion].GetView("ActiveView");
            if (rightView != null)
            {
                _regionManager.Regions[Regions.RightMenuRegion].Remove(rightView);
            }

            object tableView = _regionManager.Regions[Regions.TableRegion].GetView("ActiveView");
            if (tableView != null)
            {
                _regionManager.Regions[Regions.TableRegion].Remove(tableView);
            }

            

            EmployeeView empView = _container.Resolve<EmployeeView>("EmployeeView");

            _regionManager.Regions[Regions.LeftMenuRegion].Add(empView, "ActiveView");
           

        }




        public void DisplayHardwareStatus(HardwareStatusPanelId panelID, string deviceInfo)
        {
        }

        private string messageText;
        public string MessageText
        {
            set
            {
                messageText = value;
            }
            get
            {
                return messageText;
            }
                
        }

        private Hashtable panelTable;
        public Hashtable PanelHashtable
        {
            set
            {
                panelTable = value;
            }
            get
            {
                return panelTable;
            }
        }




    }
}
