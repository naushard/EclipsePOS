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
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Views.Controls;
 
namespace EclipsePOS.WPF.PosWorkBench
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PosWorkBenchShell : Window
    {
        public PosWorkBenchShell()
        {
            InitializeComponent();
           // this.KeyDown += new KeyEventHandler(PosWorkBenchShell_KeyDown);
            HookKeyboard();
        }

        public void  HookKeyboard()
        {
            //    PCKeyboard pcKeyboard = new PCKeyboard();
			// 	pcKeyboard.Open();
			//	if( pcKeyboard.CheckHealth()) 
			//	{
		    //        PosHardware.Instance.DeviceList.Add(pcKeyboard);
            //        
			//	}
			//	else
			//	{
			//		pcKeyboard.Close();
			//		pcKeyboard = null; 
			//	}
               
        }

      

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel= true;

                Exit posEvent = new Exit();
                posEvent.Engage(0);
               // PosHardware.Instance.Close();
            }
            catch
            {
            }
        }
    }
}
