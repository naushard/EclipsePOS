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




namespace EclipsePos.Apps.Views.OrderList
{
    /// <summary>
    /// Interaction logic for OpenOrderView.xaml
    /// </summary>
    public partial class OpenOrderView : UserControl, IOpenOrders
    {
        private OpenOrdersPresenter _presenter;

        private EclipsePos.Data.Transaction trans;
        private DataSet transDataSet;



        public OpenOrderView()
        {
            InitializeComponent();
        }

        public OpenOrderView(OpenOrdersPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

          //  this.AddPosKeys();

            this.Loaded += new RoutedEventHandler(OpenOrderView_Loaded);

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
             this.rootControl.Height = Application.Current.MainWindow.ActualHeight -60;
        }

        void OpenOrderView_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetDataSource();   
        }

        public void SetDataSource()
        {
            trans = new EclipsePos.Data.Transaction(0);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.Pos_no = PosSettings.Default.Station;
            trans.State = (int)Transaction.Status.SUSPEND;
            transDataSet =  trans.LoadByStatus();
            
            this.DataContext = transDataSet.Tables[0].DefaultView;

        }

        
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Select");
            System.Data.DataRowView dataRow  = this.OpenOrdersListView.Items.CurrentItem as DataRowView;
            try
            {
                int transNo = int.Parse(dataRow[0].ToString());
                //this.LoadEj(transNo);
                PosContext.Instance.PosPrompt.InputText = transNo.ToString();
                PosContext.Instance.InputLine = transNo.ToString();
                PosEventStack.Instance.NextEvent();
            }
            catch(Exception e1)
            {
               // MessageBox.Show(e1.ToString());
            }
        }



        private void btnDineIn_Click(object sender, RoutedEventArgs e)
        {
          this.FilterTransByTransType(8);
           
        }

        private void btnTakeAway_Click(object sender, RoutedEventArgs e)
        {
            this.FilterTransByTransType(9);
        }

        private void btnAllOrders_Click(object sender, RoutedEventArgs e)
        {
           
            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.transDataSet.Tables[0].DefaultView) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = null;
            }
        }


        public void FilterTransByTransType(int type)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.transDataSet.Tables[0].DefaultView ) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "trans_type= " + type.ToString();
            }

        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
             BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
            view1.MoveCurrentToFirst();
            this.OpenOrdersListView.ScrollIntoView(this.OpenOrdersListView.Items.CurrentItem);
        
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
            view1.MoveCurrentToPrevious();
            this.OpenOrdersListView.ScrollIntoView(this.OpenOrdersListView.Items.CurrentItem);
       
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
            view1.MoveCurrentToNext();
            this.OpenOrdersListView.ScrollIntoView(this.OpenOrdersListView.Items.CurrentItem);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
           
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
            view1.MoveCurrentToLast();
            this.OpenOrdersListView.ScrollIntoView(this.OpenOrdersListView.Items.CurrentItem);
        }


      

        private bool LoadEj(int transNo)
        {
            //PrintJobQueue.Instance.Clear();

            Transaction trans = new Transaction(transNo);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.Pos_no = PosSettings.Default.Station;
         //   trans.State = (int)Transaction.Status.SUSPEND;
            
            trans.Load();

            if (trans.Trans_no != 0)
            {  // was this a suspended transaction?

                PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);
                PosContext.Instance.TransactionType = trans.Trans_type;
                PosContext.Instance.TableName = trans.Table_name;

                if (PosContext.Instance.CurrentEj.EjArrayList.Count > 0)
                {  // finally make sure there are records

                    PosContext.Instance.TableName = trans.Table_name;
                    PosContext.Instance.TrxNo = trans.Trans_no;
                    trans.State = (int)Transaction.Status.IN_PROGRESS;

                    foreach (Object obj in PosContext.Instance.CurrentEj.EjArrayList)
                    {
                        EjLine line = (EjLine)obj;
                        PosContext.Instance.Receipt.Update(line);
                    }
                }

                if (trans.Customer_tax_id.Length > 0)
                {
                    EclipsePos.Data.Customer cus = new EclipsePos.Data.Customer();
                    cus.Organization_no = PosSettings.Default.Organization;
                    cus.Tax_id = trans.Customer_tax_id;
                    cus.LoadByTaxID();
                    EjCustomer ejCus = new EjCustomer(cus);
                    PosContext.Instance.Receipt.Update(ejCus);
                    PosContext.Instance.EjCustomer = ejCus;

                }

                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
