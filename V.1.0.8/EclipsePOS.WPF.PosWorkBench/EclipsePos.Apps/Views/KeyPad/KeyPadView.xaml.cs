using System;
using System.Windows.Threading;
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


namespace EclipsePos.Apps.Views.KeyPad
{
    /// <summary>
    /// Interaction logic for KeyPadView.xaml
    /// </summary>
    public partial class KeyPadView : UserControl, PosTicketTotal, PosKeyEnable, PosHardwareStatusDisplay,AlphaKeyEntry
    {

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
        private PosButton savedPosButton = null;
       // private DispatcherTimer dispatcherTimer;
        private ArrayList alphaPosConrols = null;

        public KeyPadView()
        {
            InitializeComponent();
            this.AddPosKeys(997, "test");

            this.Loaded += new RoutedEventHandler(KeyPadView_Loaded);

            this.alphaPosConrols = new ArrayList();
            this.AddAlphaControlKeys();

            this.KeyDisable();

            PosContext.Instance.PosHardwareStatusDevice2 = this;

            // dispatcherTimer.
           // dispatcherTimer = new DispatcherTimer();
           // dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
           // dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            
            
           
        }

        void KeyPadView_Loaded(object sender, RoutedEventArgs e)
        {

           // this.txtBlockSubTotalPrompt.Text = PosContext.Instance.Parameters.getParam("SubtotalTag");
           // this.txtBlockTaxPrompt.Text = PosContext.Instance.Parameters.getParam("TotalTaxTag");
           // this.txtBlockTotalPrompt.Text = PosContext.Instance.Parameters.getParam("GrandTotal");
           // this.txtBlockTendaredPrompt.Text = PosContext.Instance.Parameters.getParam("TenderedTag");

            PosContext.Instance.AlphaKeyEntryDisplay = this;
        }

        public void AddPosKeys(int panelID, string panelName)
        {


            //PageUp               
            RegisterPosKeyAndEventMenu(0, 33, "Up", new Thickness(3, 0, 7, 7), 0, 2, 19, "EclipsePos.Apps.PosEvents.PageUp", "ButtonStyle_Up", 1);

            //PageDown
            RegisterPosKeyAndEventMenu(0, 34, "Down", new Thickness(3, 0, 7, 7), 1, 2, 20, "EclipsePos.Apps.PosEvents.PageDown", "ButtonStyle_Down", 1);

            //Clear
            RegisterPosKeyAndEventMenu(0, 46, "Clear", new Thickness(3, 0, 7, 7), 2, 2, 32, "EclipsePos.Apps.PosEvents.ClearKey", "ButtonStyle_Clear",  0 );
           
            //Quick Sales Dialog
            RegisterPosKeyAndEventMenu(9001, 10567105, "Quick Sales", new Thickness(0, 0, 7, 7), 0, 0, 83, "EclipsePos.Apps.PosEvents.LoadQuickSalesDialog", "ButtonStyle_Home", 1);    //HomeGUI", "ButtonStyle_Home");
       
            //Search
            RegisterPosKeyAndEventMenu(0, 10614587, "Search", new Thickness(0, 0, 7, 7), 1, 0, 83, "EclipsePos.Apps.PosEvents.ItemsMenu", "ButtonStyle_Search", 1);

            //Log
            RegisterPosKeyAndEventMenu(0, 100145566, "Log", new Thickness(3, 0, 7, 7), 2, 0, 20, "EclipsePos.Apps.PosEvents.SalesLog", "ButtonStyle_Log", 1);


            //Print
            RegisterPosKeyAndEventMenu(9, 10561119, "Print", new Thickness(0, 0, 7, 7), 0, 1, 83, "EclipsePos.Apps.PosEvents.PrintEj", "ButtonStyle_Print", 1); 

            //Alpha
            RegisterPosKeyAndEventMenu(0, 10561120, "Alpha", new Thickness(0, 0, 7, 7), 1, 1, 83, "EclipsePos.Apps.PosEvents.KeyboardUtility", "ButtonStyle_Alpha", 0);

            //Backspace
            RegisterPosKeyAndEventMenu(0, 10561121, "Backspace", new Thickness(3, 0, 7, 7), 2, 1, 20, "EclipsePos.Apps.PosEvents.ClearPreviousKeyStroke", "ButtonStyle_Backspace", 0);
            


            //Enter               
            RegisterPosKeyAndEventNumPad(0, 13, "", new Thickness(0, 0, 7, 7), 2, 3, 13, "EclipsePos.Apps.PosEvents.EnterKey", "ButtonStyle_Enter", 0);

            //.
            RegisterPosKeyAndEventNumPad(100, 36, "", new Thickness(0, 0, 7, 7), 0, 3, 36, "EclipsePos.Apps.PosEvents.DecimalKey", "ButtonStyle_Decimal", 0);


            //0
            RegisterPosKeyAndEventNumPad(0, 96, "", new Thickness(0, 0, 7, 7), 1, 3, 74, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_0", 0);

            //1               
            RegisterPosKeyAndEventNumPad(1, 97, "", new Thickness(0, 0, 7, 7), 2, 0, 75, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_1", 0);

            //2
            RegisterPosKeyAndEventNumPad(2, 98, "", new Thickness(0, 0, 7, 7), 2, 1, 76, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_2", 0);

            //3
            RegisterPosKeyAndEventNumPad(3, 99, "", new Thickness(0, 0, 7, 7), 2, 2, 77, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_3", 0);

            //4               
            RegisterPosKeyAndEventNumPad(4, 100, "", new Thickness(0, 0, 7, 7), 1, 0, 78, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_4", 0);

            //5
            RegisterPosKeyAndEventNumPad(5, 101, "", new Thickness(0, 0, 7, 7), 1, 1, 79, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_5", 0);


            //6
            RegisterPosKeyAndEventNumPad(6, 102, "", new Thickness(0, 0, 7, 7), 1, 2, 80, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_6", 0);

            //7               
            RegisterPosKeyAndEventNumPad(7, 103, "", new Thickness(0, 0, 7, 7), 0, 0, 81, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_7", 0);

            //8
            RegisterPosKeyAndEventNumPad(8, 104, "", new Thickness(0, 0, 7, 7), 0, 1, 82, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_8", 0);

            //9
            RegisterPosKeyAndEventNumPad(9, 105, "", new Thickness(0, 0, 7, 7), 0, 2, 95, "EclipsePos.Apps.PosEvents.NumKey", "ButtonStyle_9", 0 );

           
        }

        public void RegisterPosKeyAndEventNumPad(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass, string buttonStyle, int disable )
        {
            PosButton btn = new PosButton();
            //btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.Style = (Style)FindResource(buttonStyle);
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.Content = content;
            btn.FontSize = 14;
            btn.Margin = new Thickness(1, 1, 1, 1); //margin;
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Focusable = false;
            btn.Width = 75;
            btn.Height = 75;
            btn.LogoutDisable = disable;

            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.RightGrid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(btn_Click);

             this.RegisterEvent(keyCode, eventClass);


        }

        public void RegisterPosKeyAndEventMenu(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass, string buttonStyle, int disable)
        {
            PosButton btn = new PosButton();
            //btn.Style = (Style)FindResource("GlassyButtonStyle");
            btn.Style = (Style)FindResource(buttonStyle);
            btn.KeyValue = keyValue;
            btn.KeyCode = keyCode;
            btn.Content = content;
            btn.FontSize = 14;
            btn.Margin = new Thickness(1, 1, 1, 1); //margin;
            btn.AccessKeyValue = accessKey;
            btn.KeyClass = eventClass;
            btn.Focusable = false;
            btn.Width = 75;
            btn.Height = 75;
            btn.LogoutDisable = disable;


            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.LeftGrid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(btn_Click);

            this.RegisterEvent(keyCode, eventClass);


        }


        public void AddAlphaControlKeys()
        {
            //Space
            //this.RegisterControlEvent(32, 32, "EclipsePos.Apps.PosEvents.AlphaKey");
            this.RegisterControlEvent(18,  32, "EclipsePos.Apps.PosEvents.AlphaKey");


           
            //A
            this.RegisterControlEvent(44, 65, "EclipsePos.Apps.PosEvents.AlphaKey");
            //B
            this.RegisterControlEvent(45, 66, "EclipsePos.Apps.PosEvents.AlphaKey");
            //C
            this.RegisterControlEvent(46, 67, "EclipsePos.Apps.PosEvents.AlphaKey");


            //D
            this.RegisterControlEvent(47, 68, "EclipsePos.Apps.PosEvents.AlphaKey");
            //E
            this.RegisterControlEvent(48, 69, "EclipsePos.Apps.PosEvents.AlphaKey");
            //F
            this.RegisterControlEvent(49, 70, "EclipsePos.Apps.PosEvents.AlphaKey");




            //G
            this.RegisterControlEvent(50, 71, "EclipsePos.Apps.PosEvents.AlphaKey");
            //H
            this.RegisterControlEvent(51, 72, "EclipsePos.Apps.PosEvents.AlphaKey");
            //I
            this.RegisterControlEvent(52, 73, "EclipsePos.Apps.PosEvents.AlphaKey");



            //J
            this.RegisterControlEvent(53, 74, "EclipsePos.Apps.PosEvents.AlphaKey");
            //K
            this.RegisterControlEvent(54, 75, "EclipsePos.Apps.PosEvents.AlphaKey");
            //L
            this.RegisterControlEvent(55, 76, "EclipsePos.Apps.PosEvents.AlphaKey");



            //M
            this.RegisterControlEvent(56, 77, "EclipsePos.Apps.PosEvents.AlphaKey");
            //N
            this.RegisterControlEvent(57, 78, "EclipsePos.Apps.PosEvents.AlphaKey");
            //O
            this.RegisterControlEvent(58, 79, "EclipsePos.Apps.PosEvents.AlphaKey");




            //P
            this.RegisterControlEvent(59, 80, "EclipsePos.Apps.PosEvents.AlphaKey");
            //Q
            this.RegisterControlEvent(60, 81, "EclipsePos.Apps.PosEvents.AlphaKey");
            //R
            this.RegisterControlEvent(61, 82, "EclipsePos.Apps.PosEvents.AlphaKey");
            //S
            this.RegisterControlEvent(62, 83, "EclipsePos.Apps.PosEvents.AlphaKey");



            //T
            this.RegisterControlEvent(63, 84, "EclipsePos.Apps.PosEvents.AlphaKey");
            //U
            this.RegisterControlEvent(64, 85, "EclipsePos.Apps.PosEvents.AlphaKey");
            //V
            this.RegisterControlEvent(65, 86, "EclipsePos.Apps.PosEvents.AlphaKey");



            //W
            this.RegisterControlEvent(66, 87, "EclipsePos.Apps.PosEvents.AlphaKey");
            //X
            this.RegisterControlEvent(67, 88, "EclipsePos.Apps.PosEvents.AlphaKey");
            //Y
            this.RegisterControlEvent(68, 89, "EclipsePos.Apps.PosEvents.AlphaKey");
            //Z
            this.RegisterControlEvent(69, 90, "EclipsePos.Apps.PosEvents.AlphaKey");
            //.
            this.RegisterControlEvent(70, 110, "EclipsePos.Apps.PosEvents.DecimalKey");
            //Backspace
            this.RegisterControlEvent(71, 8, "EclipsePos.Apps.PosEvents.ClearPreviousKeyStroke");
           //Delete
            this.RegisterControlEvent(72, 46, "EclipsePos.Apps.PosEvents.ClearKey");
            

        }





        public void RegisterEvent(int keyCode, string eventClass)
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


        public void RegisterControlEvent(int keyValue, int keyCode, string eventClass)
        {
           
            PosButton posBtn = new PosButton();
            posBtn.KeyValue = keyValue;
            posBtn.KeyCode = keyCode;
            posBtn.KeyClass = eventClass;
            alphaPosConrols.Add(posBtn);


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


        }

        


        public void LoadControls()
        {
            // PosContext.Instance.KeysByControl.Clear();

            int count = VisualTreeHelper.GetChildrenCount(this.RightGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.RightGrid, i);
                    if (child is PosButton)
                    {
                        PosButton posBtn = child as PosButton;
                        try
                        {
                            PosContext.Instance.KeysByControl.Add(posBtn.KeyCode, posBtn);
                        }
                        catch (Exception e)
                        {
                          //  MessageBox.Show(e.ToString());
                        }

                    }
                }
            }

            foreach (Object obj in alphaPosConrols)
            {
                PosButton btn = obj as PosButton;
                try
                {
                    PosContext.Instance.KeysByControl.Add(btn.KeyCode, btn);
                }
                catch
                {
                }
            }


        }



        #region POsKeyEnable members

        public void KeyEnable()
        {
            
            int count = VisualTreeHelper.GetChildrenCount(this.RightGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.RightGrid, i);
                    if (child is Button)
                    {
                        ((Button)child).IsEnabled = true;
                    }


                }
            }

            int countL = VisualTreeHelper.GetChildrenCount(this.LeftGrid);
            if (countL > 0)
            {
                for (int i = 0; i < countL; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.LeftGrid, i);
                    if (child is PosButton)
                    {
                        ((PosButton)child).IsEnabled = true;
                    }


                }
            }
            

           

        }

        public void KeyDisable()
        {
           
            int count = VisualTreeHelper.GetChildrenCount(this.RightGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.RightGrid, i);
                    if (child is PosButton)
                    {
                        if (((PosButton)child).LogoutDisable == 1)
                        {
                            ((PosButton)child).IsEnabled = false;
                        }
                    }

                }
            }

            int countL = VisualTreeHelper.GetChildrenCount(this.LeftGrid);
            if (countL > 0)
            {
                for (int i = 0; i < countL; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.LeftGrid, i);
                    if (child is PosButton)
                    {
                        if (((PosButton)child).LogoutDisable == 1)
                        {
                            ((PosButton)child).IsEnabled = false;
                        }
                    }

                }
            }

            
        }


       public int PanelId
        {
            get
            {
                return 997;
            }

        }

        #endregion


       //SubTotal
        private string txtBlockSubTotal = null;
       public string SubTotal
       {
           set
           {
               txtBlockSubTotal = value;
           }

           get
           {
               return txtBlockSubTotal;
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
        string txtBlockTax = null;
       public string Tax
       {
           set
           {

               txtBlockTax = value;
           }
           get
           {
               return txtBlockTax;
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
        string txtBlockTotal = null;
       public string Total
       {
           set
           {
               txtBlockTotal = value;
           }
           get
           {
               return txtBlockTotal;
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
        private string txtBlockTendared = null;
       public string Tendared
       {
           set
           {
               txtBlockTendared = value;
           }
           get
           {
               return txtBlockTendared;
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

       private string txtBlockBalanceDue = null;
       // Balance due
       public string BalanceDue
       {
           set
           {
               txtBlockBalanceDue = value;
           }
           get
           {
               return txtBlockBalanceDue;
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
       private string txtBlockBalanceDueText = null;
       public string BalanceDueText
       {
           set
           {
               this.txtBlockBalanceDueText = value;

           }
           get
           {
               return this.txtBlockBalanceDueText;
           }
       }

       public void Status(object sender, int deviceStatus)
       {
           
           
       }
       
       public void Clear()
       {
           this.txtBlockBalanceDue = "";
           this.txtBlockSubTotal = "";
           this.txtBlockTax = "";
           this.txtBlockTendared = "";
           this.txtBlockTotal = "";

       }


       public void KeyReset()
       {
           this.Clear();
       }



       
    }
}
