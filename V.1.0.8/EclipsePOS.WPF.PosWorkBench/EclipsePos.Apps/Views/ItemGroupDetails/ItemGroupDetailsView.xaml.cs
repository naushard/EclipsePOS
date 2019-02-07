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




namespace EclipsePos.Apps.Views.ItemGroupDetails
{
    /// <summary>
    /// Interaction logic for ItemGroupDetailsView.xaml
    /// </summary>
    public partial class ItemGroupDetailsView : UserControl, PosKeyEnable, IItemGroupDetails
    {
        private IUnityContainer _container;
        private ItemGroupDetailsPresenter _presenter;
        private int panelId = 0;
        private string itemGroup;
        // private 

        public ItemGroupDetailsView()
        {
            InitializeComponent();
            PosContext.Instance.Guis.Add(this);
        }

        public ItemGroupDetailsView(ItemGroupDetailsPresenter presenter, IUnityContainer container)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this._container = container;
            this.SizeChanged += new SizeChangedEventHandler(ItemGroupDetailsView_SizeChanged);

        }

        void ItemGroupDetailsView_SizeChanged(object sender, SizeChangedEventArgs e)
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
            EclipsePos.Data.Item item = new EclipsePos.Data.Item();
            item.Organization_no = PosSettings.Default.Organization;
            item.Item_group = this.ItemGroup;

            DataSet data = item.LoadByItemGroup(this.ItemGroup);
            DataTable dt = data.Tables[0];
            int rowNum = 0;
            int colNum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                ++rowNum;
                PosButton btn = new PosButton();
                btn.Style = (Style)FindResource("GlassyButtonStyle");
                btn.Content = dr["short_Desc"].ToString();
                btn.FontSize = 12;
                // btn.AccessKeyValue = int.Parse(dr["plu"].ToString());
                btn.Sku = dr["sku"].ToString();
                btn.Margin = new Thickness(3, 0, 3, 5);
                btn.Focusable = false;
                btn.Height = 60;
               // btn.Width = 100;

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

            }


            

        }



        void btn_Click(object sender, RoutedEventArgs e)
        {

            PosButton posButton = sender as PosButton;
            PosContext.Instance.InputLine = posButton.Sku;
            new EnterKey().Engage(0);


        }
        #endregion



        public string ItemGroup
        {
            set
            {
                itemGroup = value;
            }
            get
            {
                return itemGroup;
            }

        }


        public int PanelId
        {
            get
            {
                return panelId;
            }

        }


    }


}
