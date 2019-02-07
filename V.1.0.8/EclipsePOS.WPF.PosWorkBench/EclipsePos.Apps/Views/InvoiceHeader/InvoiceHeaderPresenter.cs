using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.InvoiceHeader
{
    public class InvoiceHeaderPresenter
    {
        private IInvoiceHeader _view;

        public IInvoiceHeader View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }

        }
    }
}
