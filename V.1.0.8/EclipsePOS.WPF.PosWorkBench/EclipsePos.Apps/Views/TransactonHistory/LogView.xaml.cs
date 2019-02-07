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
using System.Data;

using System.Reflection;
using System.Collections;
using Microsoft.PointOfService;



using Microsoft.Practices.Unity;

using EclipsePos.Data;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.Views.TransactonHistory
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl, ILogView
    {
        private LogViewPresenter _presenter;
        private IUnityContainer _container;
        private DataSet transDataSet = null;


        public LogView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(LogView_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(LogView_SizeChanged);
        }

        public LogView(LogViewPresenter presenter, IUnityContainer container)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this._container = container;

        }

        void LogView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = Application.Current.MainWindow.ActualHeight - 60; 
        }

        void LogView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (transDataSet == null)
                {
                    this.SetDataSource();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }

            this.AddPosKeys();

            

        }

        private void SetDataSource()
        {
            Transaction trans = new Transaction(0);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.Pos_no = PosSettings.Default.Station;
            transDataSet = trans.LoadByStartDate();
            this.DataContext = transDataSet.Tables[0].DefaultView;

            DataTable table = transDataSet.Tables[0];
            double tot = 0;
            bool repeat = false;
            int transno = 0;
            foreach (DataRow dr in table.Rows)
            {
                try
                {
                    int transno1 = int.Parse( dr["trans_no"].ToString());
                    if (transno != transno1)
                    {
                        tot += double.Parse(dr["sales_amt"].ToString());
                    }
                    else
                    {

                    }
                    transno = transno1;
                }
                catch (Exception ex)
                {
                }
            }
    
            //MessageBox.Show(tot.ToString());
    
            this.txtBlockTatalAmt.Text = string.Format("{0:###,###,###,##0.00}", tot);
           
        }

        public void AddPosKeys()
        {

            //Load               
            RegisterPosKeyAndEvent(1,  "Recall", new Thickness(5, 5, 5, 0), 3, 0);

            //X-Report
            RegisterPosKeyAndEvent(2, "X-Rep", new Thickness(0, 5, 5, 0), 3, 1);

            //First
            RegisterPosKeyAndEvent(3, "<<", new Thickness(0, 5, 5, 0), 3, 2);

            //Up
            RegisterPosKeyAndEvent(4,   "<",    new Thickness(0, 5, 5, 0), 3, 3);

            //Down
            RegisterPosKeyAndEvent(5,   ">",    new Thickness(0, 5, 5, 0), 3, 4);

            //Last
            RegisterPosKeyAndEvent(6, ">>", new Thickness(0, 5, 5, 0), 3, 5);

            

        }



        public void RegisterPosKeyAndEvent(int keyValue, string content, Thickness margin, int row, int col)
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.KeyValue = keyValue;
            btn.Content = content;
            btn.Height = 75;
            btn.Margin = margin;
            btn.Focusable = false;
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.MyGrid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(btn_Click);
        }


        public void LogViewFunctions(int key)
        {
            switch (key)
            {
                case 1: // RecallEj

                    DataRowView data = this.logListView.SelectedItem as DataRowView;
                    int transNo = int.Parse( data["trans_no"].ToString() );
                    RecallEjFromLog recall = new RecallEjFromLog();
                    recall.PosNo = PosSettings.Default.Station;
                    recall.TrxNo = transNo;
                    recall.Engage(0);
                    
                    break;

                case 2: // X - Report
                    PosContext.Instance.PosKeyValue = 1;
                    new TerminalReport().Engage(1);

                    break;

                case 3: //First

                    BindingListCollectionView view3 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view3.MoveCurrentToFirst();
                    this.logListView.ScrollIntoView(this.logListView.Items.CurrentItem);

                    break;

                case 4: //Previois

                    BindingListCollectionView view4 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view4.MoveCurrentToPrevious();
                    this.logListView.ScrollIntoView(this.logListView.Items.CurrentItem);

                    break;

                case 5: //Next

                    BindingListCollectionView view5 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view5.MoveCurrentToNext();
                    this.logListView.ScrollIntoView(this.logListView.Items.CurrentItem);
                    break;

                case 6: //Last

                    BindingListCollectionView view6 = CollectionViewSource.GetDefaultView(transDataSet.Tables[0].DefaultView) as BindingListCollectionView;
                    view6.MoveCurrentToLast();
                    this.logListView.ScrollIntoView(this.logListView.Items.CurrentItem);
                    break;


               
            }
        }


//        public string SelectedItem()
//        {
//            DataRowView data = this.logListView.SelectedItem as DataRowView;
//            return data["sku"].ToString();
//        }


        void btn_Click(object sender, RoutedEventArgs e)
        {

            PosButton posButton = sender as PosButton;

            this.LogViewFunctions(posButton.KeyValue);



            //MessageBox.Show(posButton.KeyCode.ToString());
            /*
            string keyCode = posButton.KeyCode.ToString();

            Hashtable table = PosContext.Instance.KeysById;
            PosEvent posEvent1 = (PosEvent)table[keyCode];
            if (posEvent1 != null)
            {
                posEvent1.Engage(posButton.KeyValue);
            }

            //PnlInput input = PosContext.Instance.PosPrompt as PnlInput;
            //input.InputControl.Focus();
             * */
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
                        PosContext.Instance.KeysByControl.Add(posBtn.KeyCode, posBtn);

                    }
                }
            }


        }



        


    }
}
