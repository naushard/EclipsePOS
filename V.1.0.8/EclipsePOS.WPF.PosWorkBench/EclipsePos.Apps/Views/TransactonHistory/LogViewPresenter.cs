using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.TransactonHistory
{
    public class LogViewPresenter
    {
        private ILogView _view;

        public ILogView View
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
