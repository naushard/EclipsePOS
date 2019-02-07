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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace EclipsePos.Apps.Views.Progress
{
    /// <summary>
    /// Interaction logic for ProgressView.xaml
    /// </summary>
    public partial class ProgressView : Window,IProgress
    {
        private ProgressPresenter _presenter;
        public delegate void InitPos();
 
        public ProgressView()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(ProgressView_Closing);
            this.progressBar1.IsIndeterminate = false;
            /*Duration duration = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            this.progressBar1.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            */
        }

        public ProgressView(ProgressPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(ProgressView_Loaded);
        }

        void ProgressView_Loaded(object sender, RoutedEventArgs e)
        {
           // Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, 
           //     new InitPos(_presenter.Initialize2) );
        }


        void ProgressView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            //work around for not being able to hide a window during closing. This behavior was needed in WPF to ensure consistent window
            //visiblity state
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);
        }

        public void ShowProgressDialog()
        {

            if (this.Owner == null)
            {
                this.Owner = Application.Current.MainWindow;
            }

            //this.ShowDialog();
            this.Show();
           // return response;



        }

        public void CloseDialog()
        {
            this.Close();
        }

        public void SetProgressStep(int value, string progressText)
        {
           this.progressBar1.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Render,
                    new Action(
                        delegate()
                                {
                                this.progressBar1.Value = value;
                                this.txtBlockProgressText.Text = progressText;
                                }
                              )  
                );
           
           // this.progressBar1.Value= value;
           // this.txtBlockProgressText.Text = progressText;
        }

        public void SetMaximum(int value)
        {
            this.progressBar1.Maximum = value;
        }

        public ProgressBar ProControl()
        {
            return this.progressBar1;
        }


    }
}
