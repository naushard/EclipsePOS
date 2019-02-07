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

using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.Views.InvoiceHeader
{
    /// <summary>
    /// Interaction logic for InvoiceHeaderView.xaml
    /// </summary>
    public partial class InvoiceHeaderView : UserControl, IInvoiceHeader, PosTicketHeader
    {
        private InvoiceHeaderPresenter _presenter;

        public InvoiceHeaderView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InvoiceHeaderView_Loaded);
        }

        void InvoiceHeaderView_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtBlockOperatorPrompt.Text = PosContext.Instance.Parameters.getParam("EmpTag");
            this.txtBlockTransactionPrompt.Text = PosContext.Instance.Parameters.getParam("TrxTag");
            this.txtBlockTerminalPrompt.Text = PosContext.Instance.Parameters.getParam("PosTag");
          
           
        }

        public InvoiceHeaderView(InvoiceHeaderPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
        }

        #region Properties
        public string TrxNo
        {
            set
            {
                this.txtBlockTrxNo.Text = value;
            }
            get
            {
                return this.txtBlockTrxNo.Text;
            }
        }

        public string PosNo
        {
            set
            {
                this.txtBlockPosNo.Text = value;
            }
            get
            {
                return this.txtBlockPosNo.Text;
            }
        }

        public string Operator
        {
            set
            {
                this.txtBlockPosOperator.Text = value;
            }
            get
            {
                return this.txtBlockPosOperator.Text;
            }
        }

        public string PosDate
        {
            set
            {
                this.txtBlockPosDate.Text = value;

            }
            get
            {
                return this.txtBlockPosDate.Text;
            }
        }



        public string TransactionType
        {
            set
            {
                this.txtBlockTrxType.Text = value;
            }
            get
            {
                return this.txtBlockTrxType.Text;
            }
        }

        public string CustomerInfo
        {
            set
            {
                this.txtBlockCustomerData.Text = value;
            }
            get
            {
                return this.txtBlockCustomerData.Text;
            }
        }


        #endregion

    }
}
