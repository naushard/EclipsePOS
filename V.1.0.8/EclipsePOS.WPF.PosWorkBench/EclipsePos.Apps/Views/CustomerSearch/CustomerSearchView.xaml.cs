using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Data;
using System.Collections;

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;


using EclipsePos.Apps.Devices;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Data;
using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Views.LeftMenu;
using EclipsePos.Apps.Views.BottomMenu;
using EclipsePos.Apps.Views.Invoice;
using EclipsePos.Apps.Views.InvoiceTotals;
using EclipsePos.Apps.Views.InvoiceHeader;
using EclipsePos.Apps.Views.ItemSearch;
using EclipsePos.Apps.Views.KeyPad;
using EclipsePos.Apps.Views.ItemDetails;
using EclipsePos.Apps.Constants;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Views.CustomerSearch
{
    /// <summary>
    /// Interaction logic for CustomerSearchView.xaml
    /// </summary>
    public partial class CustomerSearchView : UserControl, ICustomerSearch, ICustomerLookup
    {
        private CustomerSearchPresenter _presenter;

            
        private EclipsePos.Data.Customer customer;
        private DataSet customerDataSet;

        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;
        private static bool dataSrc = false;


        public CustomerSearchView()
        {
            InitializeComponent();
        }

        public CustomerSearchView(CustomerSearchPresenter presenter)
            : this()
        {
            this._presenter = presenter;

           // regionManager = regionManager;
           // _container = container;


            AddPosKeys();

            this.Loaded += new RoutedEventHandler(CustomerSearchView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.71);
        }



        void CustomerSearchView_Loaded(object sender, RoutedEventArgs e)
        {
           // if (!dataSrc)
           // {
                this.SetDataSource();
              //  dataSrc = true;
            //}

            PosContext.Instance.CustomerLookupDevice = this;
        }



        public void SetDataSource()
        {
            customer = new EclipsePos.Data.Customer();
            customer.Organization_no = PosSettings.Default.Organization;
            customer.Customer_search_key = "%";
            customerDataSet = customer.LoadBySearchKey();

            this.DataContext = customerDataSet.Tables[0].DefaultView;

        }

        public string SelectedCustomer()
        {
            DataRowView data = this.CustomerSerchListView.SelectedItem as DataRowView;
            return data["tax_id"].ToString();
        }



        #region CustomerLookup Members

        public void LookupFunction(CustomerLookupDeviceFunctions key)
        {
            switch (key)
            {
                case CustomerLookupDeviceFunctions.MoveCurrentToNext:

                    BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(customerDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view1.MoveCurrentToNext();
                    this.CustomerSerchListView.ScrollIntoView(this.CustomerSerchListView.Items.CurrentItem);

                    break;

                case CustomerLookupDeviceFunctions.MoveCurrentToFirst:

                    BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(customerDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view2.MoveCurrentToFirst();
                    this.CustomerSerchListView.ScrollIntoView(this.CustomerSerchListView.Items.CurrentItem);

                    break;

                case CustomerLookupDeviceFunctions.MoveCurrentToLast:

                    BindingListCollectionView view3 = CollectionViewSource.GetDefaultView(customerDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view3.MoveCurrentToLast();
                    this.CustomerSerchListView.ScrollIntoView(this.CustomerSerchListView.Items.CurrentItem);

                    break;

                case CustomerLookupDeviceFunctions.Cancel:
                    /* this.Clear();
                     PosContext.Instance.CurrentPosDisplay.LoadMenu((int)POSMenu.ItemLookupSeletion);
                   
                     * */
                    break;

                case CustomerLookupDeviceFunctions.Select:
                   // if (PosContext.Instance.InputLine.Trim().Length > 0  ) 
                   // {
                    PosContext.Instance.InputLine = this.SelectedCustomer();
                    new EnterKey().Engage(0);
                   // }
                    break;

                case CustomerLookupDeviceFunctions.MoveCurrentToPrevious:

                    BindingListCollectionView view4 = CollectionViewSource.GetDefaultView(customerDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view4.MoveCurrentToPrevious();
                    this.CustomerSerchListView.ScrollIntoView(this.CustomerSerchListView.Items.CurrentItem);

                    break;

                case CustomerLookupDeviceFunctions.Find:
                    // if (PosContext.Instance.InputLine.Trim().Length > 0)
                    //  {
                    this.LoadCustomerBySearchKey("%" + PosContext.Instance.InputLine + "%");
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    // }
                    break;

                case CustomerLookupDeviceFunctions.Clear:
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    break;

                case CustomerLookupDeviceFunctions.CustomerDetails:

                 /*   PosContext.Instance.KeysByControl.Clear();

                    object view = _regionManager.Regions[Regions.MenuRegion].GetView("ActiveView");
                    if (view != null)
                    {
                        _regionManager.Regions[Regions.MenuRegion].Remove(view);
                    }

                    ItemView itemView = _container.Resolve<ItemView>();
                    _regionManager.Regions[Regions.MenuRegion].Add(itemView, "ActiveView");
                    itemView.SetDataContext(itemDataSet.Tables[0].DefaultView);
                    itemView.LoadControls();

                    BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
                    bottomMenu.LoadControls();


                    KeyPadView keyPad = _container.Resolve<KeyPadView>();
                    keyPad.LoadControls();

                    InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>();
                    invTot.LoadControls();
                    */

                    break;

                case CustomerLookupDeviceFunctions.CancelFromCustomerDetails:
                    /*
                    PosContext.Instance.KeysByControl.Clear();

                    object view9 = _regionManager.Regions[Regions.MenuRegion].GetView("ActiveView");
                    if (view9 != null)
                    {
                        _regionManager.Regions[Regions.MenuRegion].Remove(view9);
                    }

                    ItemSearchView itemSearchView = _container.Resolve<ItemSearchView>("ItemSearch");
                    _regionManager.Regions[Regions.MenuRegion].Add(itemSearchView, "ActiveView");
                    itemSearchView.LoadControls();

                    BottomMenuView bottomMenu9 = _container.Resolve<BottomMenuView>();
                    bottomMenu9.LoadControls();


                    KeyPadView keyPad9 = _container.Resolve<KeyPadView>();
                    keyPad9.LoadControls();

                    InvoiceTotalView invTot9 = _container.Resolve<InvoiceTotalView>();
                    invTot9.LoadControls();
                     */
                    break;


            }
        }


       


        #endregion


         private void LoadCustomerBySearchKey(string searchString)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(customerDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                 
            view1.CustomFilter = "customer_search_key like " + "'" + searchString + "'";
            
        }


         public void AddPosKeys()
         {

             //this.txtBlockMenuName.Text = menuName;


             //Find               
             RegisterPosKeyAndEvent(0, 731142, "*Find", new Thickness(5, 5, 5, 0), 2, 0, 131142, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");
             //RegisterEvent("EclipsePos.Apps.PosEvents.PageUp", 33);

             //Resize
             RegisterPosKeyAndEvent(5, 731155, "*Sele", new Thickness(0, 5, 5, 0), 2, 1, 131155, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");
             //RegisterEvent("EclipsePos.Apps.PosEvents.PageDown", 34);

             //PageUp
             RegisterPosKeyAndEvent(8, 731140, "*Dtls", new Thickness(0, 5, 5, 0), 2, 2, 131140, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

             //PageDown
             RegisterPosKeyAndEvent(7, 731139, "*Clr", new Thickness(0, 5, 5, 0), 2, 3, 131139, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

             //More
             RegisterPosKeyAndEvent(2, 731110, "|<", new Thickness(5, 5, 5, 0), 3, 0, 131110, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

             //Select
             RegisterPosKeyAndEvent(4, 731109, "<", new Thickness(0, 5, 5, 0), 3, 1, 131109, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

             //Cancel
             RegisterPosKeyAndEvent(3, 731111, ">", new Thickness(0, 5, 5, 0), 3, 2, 131111, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

             //Previous
             RegisterPosKeyAndEvent(1, 731112, ">|", new Thickness(0, 5, 5, 0), 3, 3, 131112, "EclipsePos.Apps.PosEvents.CustomerLookupEvent");

         }


         public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass)
         {
             PosButton btn = new PosButton();
             btn.Style = (Style)FindResource("GlassyButtonStyle");
             btn.KeyValue = keyValue;
             btn.KeyCode = keyCode;
             btn.Content = content;
             btn.FontSize = 12;
             btn.Margin = margin;
             btn.AccessKeyValue = accessKey;
             btn.KeyClass = eventClass;
             Grid.SetRow(btn, row);
             Grid.SetColumn(btn, col);
             this.MyGrid.Children.Add(btn);

             btn.Click += new RoutedEventHandler(btn_Click);

             try
             {
                 Assembly assembly = Assembly.GetExecutingAssembly();
                 PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                 PosContext.Instance.KeysById.Add(keyCode.ToString(), posEvent);
             }
             catch (System.NullReferenceException exNull)
             {
                 Logger.Error(this.GetType().ToString(), "Invalid class name " + eventClass, exNull);
             }
             catch (Exception ex)
             {
                 Logger.Error(this.GetType().ToString(), ex.ToString(), ex);
             }



         }

         void btn_Click(object sender, RoutedEventArgs e)
         {

             PosButton posButton = sender as PosButton;

             //MessageBox.Show(posButton.KeyCode.ToString());

             string keyCode = posButton.KeyCode.ToString();

             Hashtable table = PosContext.Instance.KeysById;
             PosEvent posEvent1 = (PosEvent)table[keyCode];
             if (posEvent1 != null)
             {
                 posEvent1.Engage(posButton.KeyValue);
             }

             //PnlInput input = PosContext.Instance.PosPrompt as PnlInput;
             //input.InputControl.Focus();
         }


         public void LoadControls()
         {
             // PosContext.Instance.KeysByControl.Clear();

             int count = VisualTreeHelper.GetChildrenCount(this.MyGrid);
             if (count > 0)
             {
                 for (int i = 0; i < count; i++)
                 {
                     UIElement child = (UIElement)VisualTreeHelper.GetChild(this.MyGrid, i);
                     if (child is PosButton)
                     {
                         PosButton posBtn = child as PosButton;
                         PosContext.Instance.KeysByControl.Add(posBtn.AccessKeyValue, posBtn);

                     }
                 }
             }


         }   



    }
}
