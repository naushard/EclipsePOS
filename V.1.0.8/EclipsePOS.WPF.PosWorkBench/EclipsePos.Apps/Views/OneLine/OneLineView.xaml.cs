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
using System.Windows.Media.Animation;

using EclipsePos.Apps.Devices;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;





namespace EclipsePos.Apps.Views.OneLine
{
    /// <summary>
    /// Interaction logic for OneLineView.xaml
    /// </summary>
    public partial class OneLineView : UserControl, IOneLine, PosPrompt 
    {
        private OneLinePresenter _presenter;

        public OneLineView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(OneLineView_Loaded);
            
           
        }


        void OneLineView_Loaded(object sender, RoutedEventArgs e)
        {
           // throw new NotImplementedException();
            //StartSyncAnimation();
        }

        public OneLineView(OneLinePresenter presenter):this()
        {
            this._presenter = presenter;
            _presenter.View = this;
            
        }

        #region PosPrompt implementiotions
        public void SetText(string text)
        {
        }

        public void SetText(string text, int row, int col)
        {
        }


        public void EnableInput()
        {
        }

        public void DisableInput()
        {
        }

        public string PromptText
        {
            get
            {
                return oneLineText.Text;
            }
            set
            {
                oneLineText.Text = value;
            }

        }

        public int PromptWidth
        {
            get
            {
                return (int) oneLineText.Width;
            }
            //	set 
            //	{
            //		oneLineText.Text = value; 
            //	}

        }

        public string InputText
        {

            get
            {
                return oneLineInput.Text;
            }
            set
            {
                oneLineInput.Text = value;
            }
        }

        public int InputWidth
        {
            get
            {
                return (int) oneLineInput.Width;
            }
            //	set 
            //	{
            //		oneLineText.Text = value; 
            //	}

        }

       
        public string MessageText
        {

            get
            {
                return null; // oneLineMessages.Text; //oneLineMessages.Text;
            }
            set
            {
                // oneLineMessages.Text = value; //oneLineMessages.Text = value; 
            }
        }

        public int MessageWidth
        {
            get
            {
                return 0; // (int)oneLineMessages.ActualWidth;
            }
            //	set 
            //	{
            //		oneLineText.Text = value; 
            //	}

        }
         

        public void Clear()
        {
            oneLineInput.Text = "";
            oneLineText.Text = "";
           // oneLineMessages.Text = "";
        }
        #endregion


        /// <summary>
        /// This method is used to start Synchronization Animation
        /// </summary>
        public void StartErrorAnimation()
        {
            imageError.Visibility = Visibility.Visible;
            Storyboard storyboardErrorAnimation = (Storyboard)FindResource("StoryboardStartErrorAnimaion");
            storyboardErrorAnimation.Begin(rootControl, true);

        }
         

        /// <summary>
        /// This method is used to end Synchronization Animation
        /// </summary>
        public void EndErrorAnimation()
        {
            imageError.Visibility = Visibility.Hidden;
            Storyboard storyboardErrorAnimation = (Storyboard)FindResource("StoryboardStartErrorAnimaion");
            storyboardErrorAnimation.Stop();
        }

        /// <summary>
        /// This method is used to start Synchronization Animation
        /// </summary>
        public void StartInputAnimation()
        {

            imageInput.Visibility = Visibility.Visible;
            Storyboard storyboardInputAnimation = (Storyboard)FindResource("StoryboardStartInputAnimaion");
            storyboardInputAnimation.Begin(rootControl, true);
        }


        /// <summary>
        /// This method is used to end Synchronization Animation
        /// </summary>
        public void EndInputAnimation()
        {
            imageInput.Visibility = Visibility.Hidden;
            Storyboard storyboardInputAnimation = (Storyboard)FindResource("StoryboardStartInputAnimaion");
            storyboardInputAnimation.Stop();

        }
         

    }
}
