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
using EclipsePos.Apps.EJournal;


namespace EclipsePos.Apps.Views.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl, IEmplyee, PosKeyEnable
    {

        private EmployeeViewPresenter _presenter;
        private IUnityContainer _container;
        private int panelId = 996;


        public EmployeeView()
        {
            InitializeComponent();
        }

         public EmployeeView(EmployeeViewPresenter presenter, IUnityContainer container)
            : this()
        {
            this._presenter = presenter;
            this._presenter.EmployeeView = this;
            this._container = container;
            
            this.AddPosKeys(996, "Emplyees");

           // this.KeyDisable();

            PosContext.Instance.Guis.Add(this);

            this.SizeChanged += new SizeChangedEventHandler(EmployeeView_SizeChanged);
        
            
        }

         void EmployeeView_SizeChanged(object sender, SizeChangedEventArgs e)
         {
             this.Height = Application.Current.MainWindow.ActualHeight - 275;
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
                 EclipsePos.Data.Employee  emp = new EclipsePos.Data.Employee();
                 emp.Organization_no = PosSettings.Default.Organization;
                 DataSet data = emp.LoadAllEmployees();
                 DataTable dt = data.Tables[0];
                 int rowNum = 0;
                 int colNum = 0;
                 foreach (DataRow dr in dt.Rows)
                 {
                     ++rowNum;
                     PosButton btn = new PosButton();
                     btn.Width = 60;
                     btn.Width = 100;
                     btn.Style = (Style)FindResource("GlassyButtonStyle");
                     btn.Content = dr["fname"].ToString();
                     btn.ItemGroup  = dr["employee_no"].ToString();
                     btn.FontSize = 12;

                     //  btn.AccessKeyValue = int.Parse(dr["attr"].ToString());
                     btn.Margin = new Thickness(5, 0, 5, 7);
                     btn.Focusable = false;
                     // btn.KeyText = dr["param"].ToString();
                     Grid.SetRow(btn, rowNum);

                     Grid.SetColumn(btn, colNum);

                     if (rowNum == 7)
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
             PosContext.Instance.InputLine = posButton.ItemGroup;
             EjSalesPerson ej = new EjSalesPerson();
             ej.States().PushState(EjSalesPerson.GET_SALES_PERSON);
             PosEventStack.Instance.PushEvent(ej);
             PosEventStack.Instance.NextEvent();
             //new EnterKey().Engage(0);
             
         }
         #endregion



    }
}
