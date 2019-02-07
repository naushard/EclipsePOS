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


namespace EclipsePos.Apps.Views.AlphaKeyPad
{
    /// <summary>
    /// Interaction logic for AlphaKeyView.xaml
    /// </summary>
    public partial class AlphaKeyView: UserControl, IAlphaKey 

    {
        public AlphaKeyView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(AlphaKeyView_Loaded);

            this.AddPosKeys(899, "AlphaKeyPad");
        }

        void AlphaKeyView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        public void AddPosKeys(int panelID, string panelName)
        {


            //Space
            this.RegisterPosKeyAndEvent(18, 32, "Space", new Thickness(3, 0, 7, 7), 2, 0, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 2);
            //A
            this.RegisterPosKeyAndEvent(44, 65, "A", new Thickness(3, 0, 7, 7), 1, 1, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //B
            this.RegisterPosKeyAndEvent(45, 66, "B", new Thickness(3, 0, 7, 7), 2, 6, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //C
            this.RegisterPosKeyAndEvent(46, 67, "C", new Thickness(3, 0, 7, 7), 2, 4, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //D
            this.RegisterPosKeyAndEvent(47, 68, "D", new Thickness(3, 0, 7, 7), 1, 3, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //E
            this.RegisterPosKeyAndEvent(48, 69, "E", new Thickness(3, 0, 7, 7), 0, 2, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //F
            this.RegisterPosKeyAndEvent(49, 70, "F", new Thickness(3, 0, 7, 7), 1, 4, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //G
            this.RegisterPosKeyAndEvent(50, 71, "G", new Thickness(3, 0, 7, 7), 1, 5, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //H
            this.RegisterPosKeyAndEvent(51, 72, "H", new Thickness(3, 0, 7, 7), 1, 6, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //I
            this.RegisterPosKeyAndEvent(52, 73, "I", new Thickness(3, 0, 7, 7), 0, 7, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //J
            this.RegisterPosKeyAndEvent(53, 74, "J", new Thickness(3, 0, 7, 7), 1, 7, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //K
            this.RegisterPosKeyAndEvent(54, 75, "K", new Thickness(3, 0, 7, 7), 1, 8, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //L
            this.RegisterPosKeyAndEvent(55, 76, "L", new Thickness(3, 0, 7, 7), 1, 9, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //M
            this.RegisterPosKeyAndEvent(56, 77, "M", new Thickness(3, 0, 7, 7), 2, 8, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //N
            this.RegisterPosKeyAndEvent(57, 78, "N", new Thickness(3, 0, 7, 7), 2, 7, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //O
            this.RegisterPosKeyAndEvent(58, 79, "O", new Thickness(3, 0, 7, 7), 0, 8, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //P
            this.RegisterPosKeyAndEvent(59, 80, "P", new Thickness(3, 0, 7, 7), 0, 9, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //Q
            this.RegisterPosKeyAndEvent(60, 81, "Q", new Thickness(3, 0, 7, 7), 0, 0, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //R
            this.RegisterPosKeyAndEvent(61, 82, "R", new Thickness(3, 0, 7, 7), 0, 3, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //S
            this.RegisterPosKeyAndEvent(62, 83, "S", new Thickness(3, 0, 7, 7), 1, 2, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //T
            this.RegisterPosKeyAndEvent(63, 84, "T", new Thickness(3, 0, 7, 7), 0, 4, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //U
            this.RegisterPosKeyAndEvent(64, 85, "U", new Thickness(3, 0, 7, 7), 0, 6, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //V
            this.RegisterPosKeyAndEvent(65, 86, "V", new Thickness(3, 0, 7, 7), 2, 5, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //W
            this.RegisterPosKeyAndEvent(66, 87, "W", new Thickness(3, 0, 7, 7), 0, 1, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //X
            this.RegisterPosKeyAndEvent(67, 88, "X", new Thickness(3, 0, 7, 7), 2, 3, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //Y
            this.RegisterPosKeyAndEvent(68, 89, "Y", new Thickness(3, 0, 7, 7), 0, 5, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //Z
            this.RegisterPosKeyAndEvent(69, 90, "Z", new Thickness(3, 0, 7, 7), 2, 2, 19, "EclipsePos.Apps.PosEvents.AlphaKey", "AlphaButtonStyle", 1);
            //Backspace
            this.RegisterPosKeyAndEvent(71, 8, "<-", new Thickness(3, 0, 7, 7), 0, 10, 19, "EclipsePos.Apps.PosEvents.ClearPreviousKeyStroke", "AlphaButtonStyle", 1);
            //Enter               
            this.RegisterPosKeyAndEvent(0, 13, " ", new Thickness(0, 0, 7, 7), 2, 9, 13, "EclipsePos.Apps.PosEvents.EnterKey", "ButtonStyle_Enter", 2);
            //Num
            this.RegisterPosKeyAndEvent(0, 12345566, "Num", new Thickness(0, 0, 7, 7), 1, 0, 12345566, "EclipsePos.Apps.PosEvents.KeyboardUtility", "ButtonStyle_Num", 1);
            //Num
            this.RegisterPosKeyAndEvent(0, 12345567, "Clr", new Thickness(0, 0, 7, 7), 1, 10, 12345566, "EclipsePos.Apps.PosEvents.ClearKey", "ButtonStyle_Clear", 1);


        }
                                                   //     1             2             3                   4           5       6       7                   8               9           
  
        public void RegisterPosKeyAndEvent(int keyValue, int keyCode, string content, Thickness margin, int row, int col, int accessKey, string eventClass, string buttonStyle, int span)
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
           // btn.Width = ;
            btn.Height = 77;

            Grid.SetColumnSpan(btn, span);
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            this.KeyPadGrid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(btn_Click);

            this.RegisterEvent(keyCode, eventClass);


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



        public void btn_Click(object sender, RoutedEventArgs e)
        {
            PosButton posButton = sender as PosButton;
            string keyCode = posButton.KeyCode.ToString();

            Hashtable table = PosContext.Instance.KeysById;
            PosEvent posEvent1 = (PosEvent)table[keyCode];
            if (posEvent1 != null)
            {
                posEvent1.Engage(posButton.KeyValue);
            }


        }


    }
}
