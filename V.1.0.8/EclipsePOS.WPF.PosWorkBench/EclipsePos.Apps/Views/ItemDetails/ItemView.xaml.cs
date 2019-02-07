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

using EclipsePos.Apps.Devices;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Views.Controls;
//using EclipsePos.Apps..Data;
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

using Microsoft.PointOfService;

 

namespace EclipsePos.Apps.Views.ItemDetails
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl, IItem
    {
        private ItemPresenter _presenter;

        public ItemView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.AddPosKeys();
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.71);
            this.Height = Application.Current.MainWindow.ActualHeight - 60; 
        }

        public ItemView(ItemPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
        }

        public void SetDataContext(Object obj)
        {
            this.DataContext = obj;
        }


        public void AddPosKeys()
        {

            //Find               
            RegisterPosKeyAndEvent(5, 131155, "*Sele", new Thickness(5, 5, 5, 0), 0, 0, 19, "EclipsePos.Apps.PosEvents.LookupEvent");
          
            //Cancel
            RegisterPosKeyAndEvent(9, 131139, "*Canc", new Thickness(0, 5, 5, 0), 0, 1, 20, "EclipsePos.Apps.PosEvents.LookupEvent");
          
            //Previous
            RegisterPosKeyAndEvent(4, 131109, "<", new Thickness(0, 5, 5, 0), 0, 2, 21, "EclipsePos.Apps.PosEvents.LookupEvent");

            //Next
            RegisterPosKeyAndEvent(3, 131111, ">", new Thickness(0, 5, 5, 0), 0, 3, 22, "EclipsePos.Apps.PosEvents.LookupEvent");

          
        }


        public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass)
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.Content = content;
           // btn.FontSize = 12;
            btn.Height = 75;
            btn.Margin = margin;
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Focusable = false;
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.ItemGrid.Children.Add(btn);

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

            int count = VisualTreeHelper.GetChildrenCount(this.ItemGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.ItemGrid, i);
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
