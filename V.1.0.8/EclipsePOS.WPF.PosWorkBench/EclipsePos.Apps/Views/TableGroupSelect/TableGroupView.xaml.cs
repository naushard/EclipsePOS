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

using EclipsePos.Data;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Views.TableGroupSelect
{
    /// <summary>
    /// Interaction logic for TableGroupView.xaml
    /// </summary>
    public partial class TableGroupView : UserControl, ITableGroup
    {
        private TableGroupPresenter _presenter;
       

        public TableGroupView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.AddPosKeys();
          // this.AddClearPosKey();
          //  this.AddPosKeysTemp();
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          //  this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.71);
        }

        public TableGroupView(TableGroupPresenter presenter):this()
        {
            this._presenter = presenter;
            this.Loaded += new RoutedEventHandler(TableGroupView_Loaded);
        }

        void TableGroupView_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public void AddPosKeysTemp()
        {
            PosButton btn = new PosButton();
         //   btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.FontSize = 12;
            btn.Name = "F1";
            btn.Content = "Banquet";
           // btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            btn.Margin = new Thickness(2, 2, 2, 2);
            btn.Height = 75;
            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, 0);
            this.TableGroupGrid.Children.Add(btn);
        }

        public void AddPosKeys()
        {

            //this.txtBlockMenuName.Text = menuName;

           
            TableGroup tableGroup = new TableGroup();
            tableGroup.Organization_no = PosSettings.Default.Organization;
            tableGroup.Store_no = PosSettings.Default.Store;
            DataSet dataSet = tableGroup.LoadTableGroup();
            DataTable dt = dataSet.Tables[0];
            int col = 0;
            int row = 0;
            foreach (DataRow dr in dt.Rows)
            {

                RegisterPosKeyAndEvent(int.Parse(dr["table_group_no"].ToString()), 1931184 + col, dr["table_group_name"].ToString(), new Thickness(5, 5, 5, 0), col, row, 1931184 + col, "EclipsePos.Apps.PosEvents.SelectTableGroup");
                col++;
                if (col == 6)
                {
                    row++;
                    col = 0;
                }
            }


        }

        public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int col, int row, int accessKey, string eventClass)
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.AccessKeyValue = accessKey;
            btn.Content = content;
           // btn.Name = content;
            btn.KeyText = content;
            btn.HorizontalAlignment = HorizontalAlignment.Stretch;
           
            
            btn.FontSize = 12;
            btn.Margin = new Thickness(2,2,2,2); 
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Height = 75;
           // btn.Width = 70;
            
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, col);

            this.TableGroupGrid.Children.Add(btn);

           
            btn.Click += new RoutedEventHandler(btn_Click);

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                PosContext.Instance.KeysById.Add(btn.KeyCode, posEvent);
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

        
        public void AddClearPosKey()
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("ClearKeyButtonStyle");
            btn.KeyValue = 0;
            btn.KeyCode = 32;
            btn.Content = " ";
            btn.FontSize = 14;
            btn.Margin = new Thickness(10, 0, 12, 12);
            btn.AccessKeyValue = 46;
            btn.KeyClass = "EclipsePos.Apps.PosEvents.ClearKey";
            btn.Height = 47;
            btn.Width = 80;
            btn.Content = "Clear";

            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 0);

            this.TableGroupGrid.Children.Add(btn);

            
            

            btn.Click += new RoutedEventHandler(btn_Click);

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                PosEvent posEvent = assembly.CreateInstance("EclipsePos.Apps.PosEvents.ClearKey") as PosEvent;
                PosContext.Instance.KeysById.Add(btn.KeyCode, posEvent);
            }
            catch (System.NullReferenceException exNull)
            {
                //Logger.Error("FrmMain.cs", "Invalid class name " + eventClass);
            }
            catch (Exception ex)
            {
                //Logger.Error("FrmMain.cs", ex.ToString());
            }



        }
        



        void btn_Click(object sender, RoutedEventArgs e)
        {

            PosButton posButton = sender as PosButton;

            //MessageBox.Show(posButton.KeyCode.ToString());

           // string keyCode = posButton.KeyCode.ToString();

            Hashtable table = PosContext.Instance.KeysById;
            PosEvent posEvent = (PosEvent)table[posButton.KeyCode];
            
            /*if (posEvent1 != null)
            {
                PosContext.Instance.PosKeyValue = posButton.KeyValue;
                PosEventStack.Instance.PushEvent(posEvent1);
                PosEventStack.Instance.NextEvent();
                //posEvent1.Engage(posButton.KeyValue);
            }
             * */

            if (posEvent != null)
            {

                if (posEvent.isDialog)
                {
                    PosContext.Instance.PosKeyValue = posButton.KeyValue;
                    PosDialogEvent posDialog = posEvent as PosDialogEvent;
                    posDialog.PushState(posDialog.StartState); //Assume "0" as the default state
                    PosEventStack.Instance.NextEvent();
                }
                else
                {
                    posEvent.Engage(posButton.KeyValue);
                }

            }

            //PnlInput input = PosContext.Instance.PosPrompt as PnlInput;
            //input.InputControl.Focus();
        }


        public void LoadControls()
        {
            // PosContext.Instance.KeysByControl.Clear();

            int count = VisualTreeHelper.GetChildrenCount(this.TableGroupGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.TableGroupGrid, i);
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
