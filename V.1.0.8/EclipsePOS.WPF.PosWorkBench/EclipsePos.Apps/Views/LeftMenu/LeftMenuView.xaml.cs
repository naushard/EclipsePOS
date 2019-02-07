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
using System.Globalization;
using System.Windows.Media;

using Microsoft.Practices.Unity;

using EclipsePos.Data;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps.Views.OneLine;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.Views.LeftMenu
{
    /// <summary>
    /// Interaction logic for LeftMenuView.xaml
    /// </summary>
    public partial class LeftMenuView : UserControl, PosKeyEnable, ILeftMenu
    {
        private int panelId = 1;
        private LeftMenuPresenter _presenter;
        private IUnityContainer _container;

        public LeftMenuView()
        {
            InitializeComponent();

            this.SizeChanged += new SizeChangedEventHandler(LeftMenuView_SizeChanged);
        }

        void LeftMenuView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = Application.Current.MainWindow.ActualHeight - 220; 
        }

        
        public LeftMenuView(LeftMenuPresenter presenter, IUnityContainer container)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this._container = container;
        
        }


        #region POsKeyEnable members
        public void KeyEnable()
        {
            int count = VisualTreeHelper.GetChildrenCount(this.MyGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.MyGrid, i);
                    if (child is Button)
                    {
                        ((Button)child).IsEnabled = true; 
                    }

                }
            }
        }

        public void KeyDisable()
        {
            int count = VisualTreeHelper.GetChildrenCount(this.MyGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.MyGrid, i);
                    if (child is Button)
                    {
                        ((Button)child).IsEnabled = false;   
                    }
                }
            }
           
                        
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
                        try
                        {
                            PosContext.Instance.KeysByControl.Add(posBtn.AccessKeyValue, posBtn);
                        }
                        catch
                        {
                            MessageBox.Show("Unable to add poskey " + posBtn.KeyClass.ToString()); 
                        }
                        
                    }
                }
            }
           

        }


        public int PanelId
        {
            get
            {
                return panelId;
            }

        }
        #endregion

      
        #region AddPosKeys
        /// <summary>
        /// </summary>
        public void AddPosKeys(int subMenuID, string menuName)
        {

            this.txtBlockMenuName.Text = menuName;
            

            PosKey posKey = new PosKey();
            posKey.Panel_id = subMenuID;
            posKey.Config_no = PosSettings.Default.Configuration; //PosContext.Instance.Config.ConfigNo;
            DataSet data = posKey.LoadBySubMenu(); 
            DataTable dt = data.Tables[0];
            int rowNum = 0;
            int colNum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                ++rowNum;
                PosButton btn = new PosButton();
                btn.Style = (Style)FindResource("GlassyButtonStyle");
              //  btn.Height = 60;
              //  btn.Width = 100;
                btn.KeyValue = int.Parse(dr["key_val"].ToString());
                btn.KeyCode= int.Parse(dr["key_code"].ToString());
                btn.KeyClass = dr["key_class"].ToString();
                btn.Content = dr["param"].ToString(); //dr["image"].ToString();
                btn.AccessKeyValue = int.Parse( dr["attr"].ToString() );
               // btn.FontSize = 12;
                btn.Margin = new Thickness(5, 0, 5, 10);
                btn.Focusable = false;
                btn.KeyText = dr["param"].ToString();
                btn.Tag = "..\\..\\Images\\" + dr["image"].ToString().Trim();
                Grid.SetRow(btn, rowNum);

                Grid.SetColumn(btn, colNum);

                if (rowNum == 8)
                {
                    ++colNum;
                    rowNum = 0;
                }

               // Grid.SetColumn(btn, 3);
               // Grid.SetColumn(btn, 0);
                
                /*
                if (dr["flags"].ToString().Trim().Length > 0)
                {
                    try
                    {
                        Image img = new Image();
                        BitmapImage src = new BitmapImage();
                        src.BeginInit();
                        src.UriSource = new Uri(Environment.CurrentDirectory +"\\Images\\"+dr["flags"].ToString().Trim(), UriKind.RelativeOrAbsolute);
                        src.EndInit();
                        img.VerticalAlignment = VerticalAlignment.Center;
                        img.HorizontalAlignment = HorizontalAlignment.Center;
                        img.Source = src;
                        img.Width = 25;
                        img.Height = 25;
                        Grid.SetRow(img, rowNum);
                        Grid.SetColumn(img, 1);
                        this.MyGrid.Children.Add(img);
                    }
                    catch
                    {
                    }
                }
               
                */
          
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = dr["param"].ToString();
               // txtBlock.FontSize = 16;
                txtBlock.Margin = new Thickness(5, 5, 0, 0);
                txtBlock.TextAlignment = TextAlignment.Justify;
                txtBlock.Foreground = Brushes.White;

                Grid.SetColumn(txtBlock, 0);
                Grid.SetRow(txtBlock, rowNum);
                
                this.MyGrid.Children.Add(btn);
                //this.MyGrid.Children.Add(txtBlock);

                btn.Click += new RoutedEventHandler(btn_Click);

                string eventClass = dr["key_class"].ToString();
              
                try
                {
                   Assembly assembly = Assembly.GetExecutingAssembly();
                   PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                   posEvent.PromptText = txtBlock.Text; 
                   PosContext.Instance.KeysById.Add(dr["key_code"].ToString(), posEvent);
                  // PosContext.Instance.KeysByControl.Add(btn, posEvent);  
                
                }
                catch (System.NullReferenceException exNull)
                {
                    Logger.Error(this.GetType().ToString(), "Invalid class name "+ exNull.ToString() + exNull);
                }
                catch (Exception ex)
                {
                    Logger.Error(this.GetType().ToString(), ex.ToString(), ex);
                }


               
            }
                  
           
            this.KeyDisable();

        }

     

        void btn_Click(object sender, RoutedEventArgs e)
        {
            
            PosButton posButton = sender as PosButton;
           // object keyValue = posButton.Tag;
           // MessageBox.Show(posButton.KeyCode.ToString());
            string keyCode = posButton.KeyCode.ToString();

            Hashtable table = PosContext.Instance.KeysById;
            PosEvent posEvent1 = (PosEvent)table[keyCode];
            if (posEvent1 != null)
            {
                
                //posEvent1.Engage(posButton.KeyValue);
                if (posEvent1.isDialog)
                {
                    PosContext.Instance.PosKeyValue = posButton.KeyValue;
                    PosDialogEvent posDialog = posEvent1 as PosDialogEvent;
                    posDialog.PushState(posDialog.StartState); //Assume "0" as the default state
                    PosEventStack.Instance.PushEvent(posEvent1);
                    PosEventStack.Instance.NextEvent();
                }
                else
                {
                    posEvent1.Engage(posButton.KeyValue);
                }

                
            }

            //PnlInput input = PosContext.Instance.PosPrompt as PnlInput;
            //input.InputControl.Focus();
            //_contrainer.get
        }
        #endregion


    }
}
