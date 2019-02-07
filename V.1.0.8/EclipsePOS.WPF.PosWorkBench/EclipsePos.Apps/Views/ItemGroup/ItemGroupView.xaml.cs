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
using EclipsePos.Apps.Views.ItemGroupDetails;

using Microsoft.PointOfService;




namespace EclipsePos.Apps.Views.ItemGroup
{
    /// <summary>
    /// Interaction logic for ItemGroupView.xaml
    /// </summary>
    public partial class ItemGroupView : UserControl, PosKeyEnable,  IItemGroup
    {
        private ItemGroupPresenter _presenter;
        private IUnityContainer _container;
        private int panelId = 995;

        public ItemGroupView()
        {
            InitializeComponent();
            PosContext.Instance.Guis.Add(this);
        }

         public ItemGroupView(ItemGroupPresenter presenter, IUnityContainer container)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this._container = container;
            
            this.AddPosKeys(994, "Item Groups");

            this.KeyDisable();

            PosContext.Instance.Guis.Add(this);

            this.SizeChanged += new SizeChangedEventHandler(ItemGroupView_SizeChanged);
        
            
        }

         void ItemGroupView_SizeChanged(object sender, SizeChangedEventArgs e)
         {
             this.Height = Application.Current.MainWindow.ActualHeight - 220;
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


         #region AddPosKeys
         /// <summary>
         /// </summary>
         public void AddPosKeys(int subMenuID, string menuName)
         {

                this.txtBlockMenuName.Text = menuName;


            // PosKey posKey = new PosKey();
           //  posKey.Panel_id = subMenuID;
           //  posKey.Config_no = PosSettings.Default.Configuration; //PosContext.Instance.Config.ConfigNo;

            // try
            // {
                 EclipsePos.Data.ItemGroup itemGroup = new EclipsePos.Data.ItemGroup();
                 itemGroup.Organization_no = PosSettings.Default.Organization;
                 DataSet data = itemGroup.LoadByOrganization();
                 DataTable dt = data.Tables[0];
                 int rowNum = 0;
                 int colNum = 0;
                 foreach (DataRow dr in dt.Rows)
                 {
                     ++rowNum;
                     PosButton btn = new PosButton();
                     btn.Height = 60;
                    // btn.Width = 95;
                     btn.Style = (Style)FindResource("GlassyButtonStyle");
                     btn.Content = dr["group_name"].ToString();
                     btn.ItemGroup = dr["group_id"].ToString();
                     btn.FontSize = 12;

                     //  btn.AccessKeyValue = int.Parse(dr["attr"].ToString());
                     btn.Margin = new Thickness(3, 0, 3, 5);
                     btn.Focusable = false;
                     // btn.KeyText = dr["param"].ToString();
                     Grid.SetRow(btn, rowNum);

                     Grid.SetColumn(btn, colNum);

                     if (rowNum == 8)
                     {
                         ++colNum;
                         rowNum = 0;
                     }



                     this.MyGrid.Children.Add(btn);

                     
                      btn.Click += new RoutedEventHandler(btn_Click);

                     /*
                      string eventClass = dr["key_class"].ToString();

                      try
                      {
                          Assembly assembly = Assembly.GetExecutingAssembly();
                          PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                          PosContext.Instance.KeysById.Add(dr["key_code"].ToString(), posEvent);
              
                      }
                      catch (System.NullReferenceException exNull)
                      {
                          Logger.Error(this.GetType().ToString(), "Invalid class name " + exNull.ToString() + exNull);
                      }
                      catch (Exception ex)
                      {
                          Logger.Error(this.GetType().ToString(), ex.ToString(), ex);
                      }
                      * 
                      */

                   


                 }


                // this.KeyDisable();
           //  }
           //  catch
           //  {
           //  }

         }



         void btn_Click(object sender, RoutedEventArgs e)
         {

             PosButton posButton = sender as PosButton;
            // ItemGroupDetailsView itemGroupDetails = new ItemGroupDetailsView();
           //  LeftMenuView leftMenu = _container.Resolve<LeftMenuView>();
             ItemGroupDetailsView itemGroupDetails = _container.Resolve<ItemGroupDetailsView>();            
             itemGroupDetails.ItemGroup = posButton.ItemGroup;
             itemGroupDetails.AddPosKeys(999, "Items");
             PosContext.Instance.CurrentPosDisplay.LoadItemGroupDetailPanel(itemGroupDetails);
             _container.Teardown(itemGroupDetails);
         }
         #endregion


    }
}
