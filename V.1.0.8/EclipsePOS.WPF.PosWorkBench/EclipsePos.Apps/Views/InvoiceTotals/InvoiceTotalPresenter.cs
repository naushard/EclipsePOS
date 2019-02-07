using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.InvoiceTotals
{
    public class InvoiceTotalPresenter
    {
        private InvoiceTotalView _view;

        public InvoiceTotalView View
        {
            set
            {
                _view = value;
            }
            get
            {
                return _view;
            }

        }
    }
}
