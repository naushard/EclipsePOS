using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.CustomerSearch
{
    public class CustomerSearchPresenter
    {
        private ICustomerSearch _view;

        public ICustomerSearch View
        {
            get { return _view; }
            set { _view = value; }
        }

        
    }
}
