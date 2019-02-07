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

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePos.Data;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps;
using EclipsePos.Apps.Util;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.Views.BottomMenu
{
    /// <summary>
    /// Interaction logic for BottomMenuView.xaml
    /// </summary>
    public partial class BottomMenuView : UserControl, PosKeyEnable, IBottomMenu
    {
        private BottomMenuPresenter _presenter;

        private int panelId=7;

       
  

        public BottomMenuView()
        {
            InitializeComponent();
        }

        public BottomMenuView(BottomMenuPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
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

            //this.txtBlockMenuName.Text = menuName;


            PosKey posKey = new PosKey();
            posKey.Panel_id = subMenuID;
            posKey.Config_no = PosSettings.Default.Configuration; //PosContext.Instance.Config.ConfigNo;
            DataSet data = posKey.LoadBySubMenu();
            DataTable dt = data.Tables[0];
            int colNum = 0;
            int rowNum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                
                PosButton btn = new PosButton();
                btn.Style = (Style)FindResource("GlassyButtonStyle1");

                btn.Height = 75;
                btn.KeyValue = int.Parse(dr["key_val"].ToString());
                btn.KeyCode = int.Parse(dr["key_code"].ToString());
                btn.AccessKeyValue = int.Parse( dr["attr"].ToString() );
                btn.Content = dr["key_text"].ToString();
                btn.KeyClass = dr["key_class"].ToString();
                btn.Tag  =  "..\\..\\Images\\" + dr["image"].ToString().Trim();
                btn.Margin = new Thickness(2, 2, 2, 2);
                btn.Focusable = false;
                Grid.SetRow(btn, rowNum);
                Grid.SetColumn(btn, colNum++);

                this.MyGrid.Children.Add(btn);

                if (colNum > 5)
                {
                    colNum = 0;
                    ++rowNum;
                }

           
                btn.Click += new RoutedEventHandler(btn_Click);

                //Register key in PosContext;
                //Create events
                string eventClass = dr["key_class"].ToString();
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                    if (! PosContext.Instance.KeysById.ContainsKey(dr["key_code"].ToString()) )
                    {
                     PosContext.Instance.KeysById.Add(dr["key_code"].ToString(), posEvent);
                    }                   
                }
                catch (System.NullReferenceException exNull)
                {
                    Logger.Error(this.GetType().ToString(), "Invalid class name " + eventClass);
                }
                catch (Exception ex)
                {
                    Logger.Error(this.GetType().ToString(), ex.ToString());
                }

           


            }
            
            this.KeyDisable();

        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
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
               // posEvent1.Engage(posButton.KeyValue);

                if (posEvent1.isDialog)
                {
                    PosContext.Instance.PosKeyValue = posButton.KeyValue;
                    PosDialogEvent posDialog = posEvent1 as PosDialogEvent;
                    posDialog.PushState(posDialog.StartState);
                    PosEventStack.Instance.PushEvent(posEvent1);
                    PosEventStack.Instance.NextEvent();
                }
                else
                {
                    posEvent1.Engage(posButton.KeyValue);
                }
                
            }

        }
        #endregion

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
                        if (!PosContext.Instance.KeysByControl.ContainsKey(posBtn.AccessKeyValue))
                        {
                            PosContext.Instance.KeysByControl.Add(posBtn.KeyCode, posBtn);
                        }

                    }
                }
            }


        }




    }
}
