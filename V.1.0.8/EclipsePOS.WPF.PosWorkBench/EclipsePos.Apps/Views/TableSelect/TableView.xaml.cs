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
using System.Collections;
using System.Data;

using EclipsePos.Apps.Views.Invoice;
using EclipsePos.Apps.Views.InvoiceTotals;
using EclipsePos.Apps.Constants;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;

using Microsoft.Practices.Unity;

namespace EclipsePos.Apps.Views.TableSelect
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl, ITable
    {
        private TablePresenter _presenter;
        private int lastUsedtableGroup = 0;
      

        public TableView()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(TableView_Loaded);
        }

        void TableView_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.lastUsedtableGroup > 0) this.DrawTableModel(this.lastUsedtableGroup);
        }

        public TableView(TablePresenter presenter) 
            : this()
        {
            this._presenter = presenter;
         
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.98);
            this.Height = Application.Current.MainWindow.ActualHeight - 220;
        }

       

        public void SetTableDataContext(object data)
        {
           
            this.DataContext = data;

        }

        public void DrawTableModel(int tableGroupNo )
        {
            this.lastUsedtableGroup = tableGroupNo;

            Hashtable invHashtable  = GetCurrentOrders();
           
            gridTableModel.Children.Clear();
            TableDetails tableDetails = new TableDetails();
            tableDetails.Organization_no = PosSettings.Default.Organization;
            tableDetails.Store_no = PosSettings.Default.Store;
            tableDetails.Table_group_no = tableGroupNo;

            DataSet dataSet = tableDetails.LoadTable();
            DataTable dt = dataSet.Tables[0];
            
            foreach (DataRow dr in dt.Rows)
            {
                TableButtonData bData = new TableButtonData();
                bData.Display_row_no = int.Parse(dr["display_row_no"].ToString());
                bData.Display_column_no = int.Parse(dr["display_column_no"].ToString());
                bData.Table_no = int.Parse(dr["table_no"].ToString());
                bData.Table_name = dr["table_name"].ToString();
                bData.Picture_name =  dr["picture_name"].ToString();

                Button tableBtn = new Button();
                tableBtn.DataContext = bData;
               
                if (invHashtable.ContainsKey(bData.Table_name))
                {
                    DataRow dr1 = invHashtable[bData.Table_name] as DataRow;
                    bData.Pos_no = int.Parse( dr1["pos_no"].ToString() );
                    bData.Trans_no = int.Parse(dr1["trans_no"].ToString());
                    tableBtn.Style = (Style)FindResource("btnXLSActive");
                }
                else
                {
                    tableBtn.Style = (Style)FindResource("btnXLS");
                }
                
                
                gridTableModel.Children.Add(tableBtn);

                tableBtn.Click += new RoutedEventHandler(tableBtn_Click);
               
               
            }
            
            
        }


        public Hashtable GetCurrentOrders()
        {
            
            Hashtable invHashtable  = new  Hashtable();
            Transaction trans = new Transaction(0);
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
           // trans.Pos_no = PosSettings.Default.Station;
            trans.State = (int)Transaction.Status.SUSPEND;

            try
            {
                DataSet dataSet = trans.LoadByStatus();
                DataTable dt = dataSet.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        invHashtable.Add(dr["table_name"].ToString(), dr);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString() ); 
            }

            return invHashtable;
            

        }

        void tableBtn_Click(object sender, RoutedEventArgs e)
        {
           

          //  PosContext.Instance.CurrentPosDisplay.UnloadTableSelect();

            Button btn = sender as Button;
            TableButtonData bData = btn.DataContext as TableButtonData;
            PosContext.Instance.InputLine = bData.Table_name;
            /*if (bData.Trans_no > 0)
            {

                this.LoadEj(bData);
            }
            */
            PosEventStack.Instance.NextEvent();
            
        }


        public void LoadEj(TableButtonData bData)
        {

            Transaction trans = new Transaction(bData.Trans_no);
            trans.Pos_no = bData.Pos_no;
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosSettings.Default.Store;
            trans.Load();
            if (trans.State == (int)Transaction.Status.SUSPEND)
            {  // was this a suspended transaction?

                PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);

                if (PosContext.Instance.CurrentEj.EjArrayList.Count > 0)
                {  // finally make sure there are records

                    PosContext.Instance.TableName = trans.Table_name;
                    trans.State = (int)Transaction.Status.IN_PROGRESS;
                    foreach (Object obj in PosContext.Instance.CurrentEj.EjArrayList)
                    {
                        EjLine line = (EjLine)obj;
                        PosContext.Instance.Receipt.Update(line);
                    }

                    //	context ().homeGuis ();
                    //	context ().eventStack ().setEvent (new FirstItem (context ()));
                    //this.States().Clear();
                    //	PosEventStack.Instance.NextEvent();
                }
            }
                    
            

        }

        

       

      
    }
}
