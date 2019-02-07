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


namespace EclipsePos.Apps.Views.ItemSearch
{
    /// <summary>
    /// Interaction logic for ItemSearchView.xaml
    /// </summary>
    public partial class ItemSearchView : UserControl, IItemSearch, ItemLookup
    {
        private ItemSearchPresenter _presenter;
        private SearchBy defaultSerchBy = SearchBy.Description;

        private Item item;
        private DataSet itemDataSet;

        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;
        private static bool dataSrc = false;

        public ItemSearchView()
        {
           
            InitializeComponent();
          //  this.SetDataSource();
           
            this.Loaded += new RoutedEventHandler(ItemSearchView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.71);
            this.Height = Application.Current.MainWindow.ActualHeight - 60; 
        }

        void ItemSearchView_Loaded(object sender, RoutedEventArgs e)
        {
           // if (!dataSrc)
            if(itemDataSet == null)
            {
                this.SetDataSource();
               // dataSrc = true;
            }
            PosContext.Instance.ItemLookupDevice = this;
            
        }

        public ItemSearchView(ItemSearchPresenter presenter, IUnityContainer container, IRegionManager regionManager)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
           
            _regionManager = regionManager;
            _container = container;


            AddPosKeys();
        }



        public void AddPosKeys()
        {

            //this.txtBlockMenuName.Text = menuName;


            //Find               
            RegisterPosKeyAndEvent(0, 231142, "*Find", new Thickness(5, 5, 5, 0), 2, 0, 231142, "EclipsePos.Apps.PosEvents.LookupEvent");
            //RegisterEvent("EclipsePos.Apps.PosEvents.PageUp", 33);

            //Resize
            RegisterPosKeyAndEvent(5, 231155, "*Sele", new Thickness(0, 5, 5, 0), 2, 1, 231155, "EclipsePos.Apps.PosEvents.LookupEvent");
            //RegisterEvent("EclipsePos.Apps.PosEvents.PageDown", 34);

            //PageUp
            RegisterPosKeyAndEvent(8, 231140, "*Dtls", new Thickness(0, 5, 5, 0), 2, 2, 231140, "EclipsePos.Apps.PosEvents.LookupEvent");

            //PageDown
            RegisterPosKeyAndEvent(7, 231139, "*Clr", new Thickness(0, 5, 5, 0), 2, 3, 131139, "EclipsePos.Apps.PosEvents.LookupEvent");

            //More
            //RegisterPosKeyAndEvent(2, 231110, "|<", new Thickness(5, 5, 5, 0), 3, 0, 131110, "EclipsePos.Apps.PosEvents.LookupEvent");

            //Select
            RegisterPosKeyAndEvent(4, 231109, "<", new Thickness(0, 5, 5, 0), 2, 4, 131109, "EclipsePos.Apps.PosEvents.LookupEvent");

            //Cancel
            RegisterPosKeyAndEvent(3, 231111, ">", new Thickness(0, 5, 5, 0), 2, 5, 131111, "EclipsePos.Apps.PosEvents.LookupEvent");

            //Previous
           // RegisterPosKeyAndEvent(1, 231112, ">|", new Thickness(0, 5, 5, 0), 3, 3, 131112, "EclipsePos.Apps.PosEvents.LookupEvent");
 
        }


        public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass)
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("GlassyButtonStyle1");
            btn.Height = 75;
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.Content = content;
         //   btn.FontSize = 12;
            btn.Margin = margin;
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Focusable = false;
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



        public void SetDataSource()
        {
            item = new Item();
            item.Organization_no = PosSettings.Default.Organization;
            item.Short_Desc = "%"; 
            itemDataSet = item.LoadByDesc();

            this.DataContext  = itemDataSet.Tables[0].DefaultView;
      
        }


        #region ItemLookup Members

        public void LookupFunction(ItemLookupDeviceFunctions key)
        {
            switch (key)
            {
                case ItemLookupDeviceFunctions.MoveCurrentToNext:
                
                    BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(itemDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view1.MoveCurrentToNext();
                    this.itemSerchListView.ScrollIntoView(this.itemSerchListView.Items.CurrentItem);
                 
                    break;

                case ItemLookupDeviceFunctions.MoveCurrentToFirst:
                    
                    BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(itemDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view2.MoveCurrentToFirst();
                    this.itemSerchListView.ScrollIntoView(this.itemSerchListView.Items.CurrentItem);
                   
                    break;

                case ItemLookupDeviceFunctions.MoveCurrentToLast:
                 
                    BindingListCollectionView view3 = CollectionViewSource.GetDefaultView(itemDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view3.MoveCurrentToLast();
                    this.itemSerchListView.ScrollIntoView(this.itemSerchListView.Items.CurrentItem);
                    break;

                case ItemLookupDeviceFunctions.Cancel:
                   /* this.Clear();
                    PosContext.Instance.CurrentPosDisplay.LoadMenu((int)POSMenu.ItemLookupSeletion);
                   
                    * */break;

                case ItemLookupDeviceFunctions.Select:
                    PosContext.Instance.InputLine = this.SelectedItem();
                    new EnterKey().Engage(0);
                    break;

                case ItemLookupDeviceFunctions.MoveCurrentToPrevious:
                  
                    BindingListCollectionView view4 = CollectionViewSource.GetDefaultView(itemDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view4.MoveCurrentToPrevious();
                    this.itemSerchListView.ScrollIntoView(this.itemSerchListView.Items.CurrentItem);
                
                    break;

                case ItemLookupDeviceFunctions.Find:
                   // if (PosContext.Instance.InputLine.Trim().Length > 0)
                  //  {
                        this.LoadItemByDescription("%" + PosContext.Instance.InputLine + "%");
                        PosContext.Instance.ClearInput();
                        PosContext.Instance.Operprompt.Clear();
                   // }
                    break;

                case ItemLookupDeviceFunctions.Clear:
                    PosContext.Instance.ClearInput();
                    PosContext.Instance.Operprompt.Clear();
                    break;

                case ItemLookupDeviceFunctions.ItemDetails:
                   
                    PosContext.Instance.KeysByControl.Clear();

                    object view = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
                    if (view != null)
                    {
                        _regionManager.Regions[Regions.LogRegion].Remove(view);
                    }

                    ItemView itemView = _container.Resolve<ItemView>();
                    _regionManager.Regions[Regions.LogRegion].Add(itemView, "ActiveView");
                     itemView.SetDataContext(itemDataSet.Tables[0].DefaultView);
                    itemView.LoadControls();

                    object viewBottom = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
                    if (viewBottom != null)
                    {
                        _regionManager.Regions[Regions.NavigatorRegion].Remove(viewBottom);
                    }

                    BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>("996");
                    _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu, "ActiveView");
                    bottomMenu.LoadControls();

                   // BottomMenuView bottomMenu = _container.Resolve<BottomMenuView>();
                   // bottomMenu.LoadControls();

                    
                    KeyPadView keyPad = _container.Resolve<KeyPadView>();
                    keyPad.LoadControls();

                    //InvoiceTotalView invTot = _container.Resolve<InvoiceTotalView>();
                    //invTot.LoadControls();

                
                    break;

                case ItemLookupDeviceFunctions.CancelFromItemDetails:
                    
                    PosContext.Instance.KeysByControl.Clear();

                    object view9 = _regionManager.Regions[Regions.LogRegion].GetView("ActiveView");
                    if (view9 != null)
                    {
                        _regionManager.Regions[Regions.LogRegion].Remove(view9);
                    }

                    ItemSearchView itemSearchView = _container.Resolve<ItemSearchView>("ItemSearch");
                    _regionManager.Regions[Regions.LogRegion].Add(itemSearchView, "ActiveView");
                    itemSearchView.LoadControls();

                   // BottomMenuView bottomMenu9 = _container.Resolve<BottomMenuView>();
                   // bottomMenu9.LoadControls();
                    object viewBottom9 = _regionManager.Regions[Regions.NavigatorRegion].GetView("ActiveView");
                    if (viewBottom9 != null)
                    {
                        _regionManager.Regions[Regions.NavigatorRegion].Remove(viewBottom9);
                    }

                    BottomMenuView bottomMenu1 = _container.Resolve<BottomMenuView>("995");
                    _regionManager.Regions[Regions.NavigatorRegion].Add(bottomMenu1, "ActiveView");
                    bottomMenu1.LoadControls();

                    KeyPadView keyPad9 = _container.Resolve<KeyPadView>();
                    keyPad9.LoadControls();

                    InvoiceTotalView invTot9 = _container.Resolve<InvoiceTotalView>();
                   // invTot9.LoadControls();
                    break;


            }
        }


        public string SelectedItem()
        {
            DataRowView data = this.itemSerchListView.SelectedItem as DataRowView;
            return data["sku"].ToString();
        }


        #endregion

        private void LoadItemByDescription(string searchString)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(itemDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                 
            switch (this.defaultSerchBy)
            {
                case (SearchBy.Description):
                    view1.CustomFilter = "short_desc like " + "'" + searchString + "'";
                    break;

                case (SearchBy.Sku):
                    view1.CustomFilter = "sku like " + "'" + searchString + "'";
                    break;

                case (SearchBy.Department):
                    view1.CustomFilter = "dept like " + "'" + searchString + "'";
                    break;

                case (SearchBy.ItemGroup):
                    view1.CustomFilter = "item_group like " + "'" + searchString + "'";
                    break;

            }
           
           

        }

        private void LoadItemBySKU(string searchString)
        {
            this.itemSerchListView.Items.Clear();

           
            Item item = new Item();

            item.Sku = searchString;
            DataSet data = item.LoadAllSKUs();

            this.DataContext = data.Tables[0].DefaultView;

            
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


        public SearchBy SearchKey
        {
            set
            {
                this.defaultSerchBy = value;
            }
            get
            {
                return this.defaultSerchBy;
            }
        }





    }
}
