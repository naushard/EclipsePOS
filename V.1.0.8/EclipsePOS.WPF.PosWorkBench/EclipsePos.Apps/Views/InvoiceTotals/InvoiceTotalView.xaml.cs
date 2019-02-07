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
using System.Collections;
using System.Globalization;

using EclipsePos.Apps.Devices;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Views.Controls;
using EclipsePos.Apps.Hardware;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.Views.InvoiceTotals
{
    /// <summary>
    /// Interaction logic for InvoiceTotalView.xaml
    /// </summary>
    public partial class InvoiceTotalView : UserControl, PosTicketTotal 	 
    {
        private InvoiceTotalPresenter _presenter;

        private double subTotal;
        private int subTotalWidth;
        private double tax;
        private int taxWidth;
        private double total;
        private int totalWidth;
        private double tendared;
        private int tendaredWidth;
        private double balanceDue;
        private int balanceDueWidth;
        private int panelId;
        private int keyPressCount = 0;

       

        public InvoiceTotalView()
        {
            InitializeComponent();
            //this.AddPosKeys(994, "Invoice totals");
            //this.AddAllKeys();

           // PosContext.Instance.PosHardwareStatusDevice1 = this;


            this.Loaded += new RoutedEventHandler(InvoiceTotalView_Loaded);

           
        }

        public InvoiceTotalView(InvoiceTotalPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
        }

        void InvoiceTotalView_Loaded(object sender, RoutedEventArgs e)
        {
           // this.txtBlockSubTotalPrompt.Text = PosContext.Instance.Parameters.getParam("SubtotalTag");
            this.txtBlockTaxPrompt.Text = PosContext.Instance.Parameters.getParam("TotalTaxTag");
            this.txtBlockTotalPrompt.Text = PosContext.Instance.Parameters.getParam("GrandTotal");
            this.txtBlockTendaredPrompt.Text = PosContext.Instance.Parameters.getParam("TenderedTag");
        }

        /*
        public void AddPosKeys(int panelID, string panelName)
        {

           
           //PageUp               
            RegisterPosKeyAndEvent(0, 33, "Up", new Thickness(3, 0, 7, 7), 0, 0, 19, "EclipsePos.Apps.PosEvents.PageUp");
            
            //PageDown
            RegisterPosKeyAndEvent(0, 34, "Down", new Thickness(3, 0, 7, 7), 1, 0, 20, "EclipsePos.Apps.PosEvents.PageDown");
        
            //Clear
            RegisterPosKeyAndEvent(0, 46, "Clear", new Thickness(3, 0, 7, 7), 2, 0, 32, "EclipsePos.Apps.PosEvents.ClearKey");
        
            //Enter               
            RegisterPosKeyAndEvent(0, 13, "Enter", new Thickness(0, 0, 7, 7), 2, 4, 13, "EclipsePos.Apps.PosEvents.EnterKey");
        
            //00
            RegisterPosKeyAndEvent(100, 36, "00", new Thickness(0, 0, 7, 7), 0, 4, 36, "EclipsePos.Apps.PosEvents.MultKey");
        
            //0
            RegisterPosKeyAndEvent(0, 96, "0", new Thickness(0, 0, 7, 7), 1, 4, 74, "EclipsePos.Apps.PosEvents.NumKey");
           
            //1               
            RegisterPosKeyAndEvent(1, 97, "1", new Thickness(0, 0, 7, 7), 2, 1, 75, "EclipsePos.Apps.PosEvents.NumKey");
        
            //2
            RegisterPosKeyAndEvent(2, 98, "2", new Thickness(0, 0, 7, 7), 2, 2, 76, "EclipsePos.Apps.PosEvents.NumKey");
        
            //3
            RegisterPosKeyAndEvent(3, 99, "3", new Thickness(0, 0, 7, 7), 2, 3, 77, "EclipsePos.Apps.PosEvents.NumKey");
        
            //4               
            RegisterPosKeyAndEvent(4, 100, "4", new Thickness(0, 0, 7, 7), 1, 1, 78, "EclipsePos.Apps.PosEvents.NumKey");
        
            //5
            RegisterPosKeyAndEvent(5, 101, "5", new Thickness(0, 0, 7, 7), 1, 2, 79, "EclipsePos.Apps.PosEvents.NumKey");
        
            //6
            RegisterPosKeyAndEvent(6, 102, "6", new Thickness(0, 0, 7, 7), 1, 3, 80, "EclipsePos.Apps.PosEvents.NumKey");
        
            //7               
            RegisterPosKeyAndEvent(7, 103, "7", new Thickness(0, 0, 7, 7), 0, 1, 81, "EclipsePos.Apps.PosEvents.NumKey");
        
            //8
            RegisterPosKeyAndEvent(8, 104, "8", new Thickness(0, 0, 7, 7), 0, 2, 82, "EclipsePos.Apps.PosEvents.NumKey");
            
            //9
            RegisterPosKeyAndEvent(9, 105, "9", new Thickness(0, 0, 7, 7), 0, 3, 83, "EclipsePos.Apps.PosEvents.NumKey");
      
        }

        public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass)
        {
            PosButton btn = new PosButton();
            btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.Content = content;
            btn.FontSize = 14;
            btn.Margin = margin;
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Focusable = false;
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.NumPadGrid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(btn_Click);
           
           // this.RegisterEvent(eventClass, keyCode);
           

        }

        public void AddAllKeys()
        {

            //PageUp               
            RegisterEvent(33, "EclipsePos.Apps.PosEvents.PageUp");
            //PageDown
            RegisterEvent(34, "EclipsePos.Apps.PosEvents.PageDown");
            //Clear
            RegisterEvent(46, "EclipsePos.Apps.PosEvents.ClearKey" );
            //Enter               
            RegisterEvent(13, "EclipsePos.Apps.PosEvents.EnterKey");
            //00
            RegisterEvent(36,  "EclipsePos.Apps.PosEvents.MultKey");
            //0
            RegisterEvent(96,  "EclipsePos.Apps.PosEvents.NumKey");
            //1               
            RegisterEvent(97,  "EclipsePos.Apps.PosEvents.NumKey");
            //2
            RegisterEvent(98,  "EclipsePos.Apps.PosEvents.NumKey");
            //3
            RegisterEvent(99,  "EclipsePos.Apps.PosEvents.NumKey");
            //4               
            RegisterEvent(100,  "EclipsePos.Apps.PosEvents.NumKey");
            //5
            RegisterEvent(101,  "EclipsePos.Apps.PosEvents.NumKey");
            //6
            RegisterEvent(102,  "EclipsePos.Apps.PosEvents.NumKey");
            //7               
            RegisterEvent(103,  "EclipsePos.Apps.PosEvents.NumKey");
            //8
            RegisterEvent(104,  "EclipsePos.Apps.PosEvents.NumKey");
            //9
            RegisterEvent(105,  "EclipsePos.Apps.PosEvents.NumKey");
            
        }

      


       
        public void RegisterEvent(int keyCode, string eventClass )
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                PosEvent posEvent = assembly.CreateInstance(eventClass) as PosEvent;
                PosContext.Instance.KeysById.Add(keyCode.ToString(), posEvent);
            }
            catch (System.NullReferenceException exNull)
            {
                Logger.Error("InvoiceTotalView.cs", "Invalid class name " + eventClass);
            }
            catch (Exception ex)
            {
                Logger.Error("InvoiceTotalView.cs", ex.ToString());
            }

        } 

        public void btn_Click(object sender, RoutedEventArgs e)
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

            int count = VisualTreeHelper.GetChildrenCount(this.NumPadGrid);
            if ( count > 0 )
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.NumPadGrid, i);
                    if (child is PosButton)
                    {
                        PosButton posBtn = child as PosButton;
                        try
                        {
                            PosContext.Instance.KeysByControl.Add(posBtn.KeyCode, posBtn);
                        }
                        catch
                        {
                        }


                    }
                }
            }


        }

       

        #region POsKeyEnable members

        public void KeyEnable()
        {
            int count = VisualTreeHelper.GetChildrenCount(this.NumPadGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.NumPadGrid, i);
                    if (child is Button)
                    {
                        ((Button)child).IsEnabled = true;
                    }


                }
            }
        }

        public void KeyDisable()
        {
            int count = VisualTreeHelper.GetChildrenCount(this.NumPadGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.NumPadGrid, i);
                    if (child is Button)
                    {
                        ((Button)child).IsEnabled = false;
                    }

                }
            }


        }
        */

        public int PanelId
        {
            get
            {
                return panelId;
            }

        }

     


     
        //SubTotal
        public string SubTotal
        {
            set
            {
                //txtBlockSubTotal.Text = value;
            }

            get
            {
                //return txtBlockSubTotal.Text; 
                return "";
            }
        }


        public int SubTotalWidth
        {
            set
            {
                subTotalWidth = value;
            }
            get
            {
                return subTotalWidth;
            }
        }

        //TAX
        public string Tax
        {
            set
            {
                
                txtBlockTax.Text = value;
            }
            get
            {
                return txtBlockTax.Text;
            }
        }

        public int TaxWidth
        {
            set
            {
                taxWidth = value;
            }
            get
            {
                return taxWidth;
            }
        }

        // Total
        public string Total
        {
            set
            {
                txtBlockTotal.Text = value;
            }
            get
            {
                return txtBlockTotal.Text;
            }
        }

        public int TotalWidth
        {
            set
            {
                totalWidth = value;
            }
            get
            {
                return totalWidth;
            }
        }

        // Terndared
        public string Tendared
        {
            set
            {
                txtBlockTendared.Text = value;
            }
            get
            {
                return txtBlockTendared.Text;
            }
        }

        public int TendaredWidth
        {
            set
            {
                tendaredWidth = value;
            }
            get
            {
                return tendaredWidth;
            }
        }

        // Balance due
        public string BalanceDue
        {
            set
            {
                txtBlockBalanceDue.Text = value;
            }
            get
            {
                return txtBlockBalanceDue.Text;
            }
        }

        public int BalanceDueWidth
        {
            set
            {
                balanceDueWidth = value;
            }
            get
            {
                return balanceDueWidth;
            }
        }

        public string BalanceDueText
        {
            set
            {
                this.txtBlockBalanceDueText.Text = value;
               
            }
            get
            {
                return this.txtBlockBalanceDueText.Text;
            }
        }


        public void Status(object sender, int deviceStatus)
        {
            /*
            //1.Pinter
            if (sender is PosPrinterWrapper)
            {
                try
                {
                    this.imagePosPrinterStatus.Visibility = Visibility.Visible;
                    if (deviceStatus == 1)
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/tick.ico", UriKind.Absolute));
                        this.imagePosPrinterStatus.Source = image;
                    }
                    else
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/Alert.png", UriKind.Absolute));
                        this.imagePosPrinterStatus.Source = image;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            //2.Line Display
            if (sender is LineDisplayWrapper)
            {
                try
                {
                    this.imageLineDisplayStatus.Visibility = Visibility.Visible;
                    if (deviceStatus == 1)
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/tick.ico", UriKind.Absolute));
                        this.imageLineDisplayStatus.Source = image;
                    }
                    else
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/Alert.png", UriKind.Absolute));
                        this.imageLineDisplayStatus.Source = image;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            //3.Cash drawer
            if (sender is CashDrawerWrapper)
            {
                try
                {
                    this.imageCashDrawerStatus.Visibility = Visibility.Visible;
                    if (deviceStatus == 1)
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/tick.ico", UriKind.Absolute));
                        this.imageCashDrawerStatus.Source = image;
                    }
                    else
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/Alert.png", UriKind.Absolute));
                        this.imageCashDrawerStatus.Source = image;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            //4. MSR
            if (sender is MsrWrapper)
            {
                try
                {
                    this.imageMsrStatus.Visibility = Visibility.Visible;
                    if (deviceStatus == 1)
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/tick.ico", UriKind.Absolute));
                        this.imageMsrStatus.Source = image;
                    }
                    else
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/Alert.png", UriKind.Absolute));
                        this.imageMsrStatus.Source = image;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            //5. Scanner 
            if (sender is ScannerWrapper)
            {
                try
                {
                    this.imageMsrStatus.Visibility = Visibility.Visible;
                    if (deviceStatus == 1)
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/tick.ico", UriKind.Absolute));
                        this.imageScannerStatus.Source = image;
                    }
                    else
                    {
                        ImageSource image = new BitmapImage(new Uri(@"pack://application:,,,/EclipsePos.Apps;component/Images/Alert.png", UriKind.Absolute));
                        this.imageScannerStatus.Source = image;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            */
        }
        

       



        public void Clear()
        {
            this.txtBlockBalanceDue.Text = "";
            //this.txtBlockSubTotal.Text = "";
            this.txtBlockTax.Text = "";
            this.txtBlockTendared.Text = "";
            this.txtBlockTotal.Text = "";
        }

    }
}
