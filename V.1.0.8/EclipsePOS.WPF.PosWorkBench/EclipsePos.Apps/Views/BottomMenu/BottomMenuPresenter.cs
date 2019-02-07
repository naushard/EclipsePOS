using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.BottomMenu
{
    public class BottomMenuPresenter
    {
        public IBottomMenu _view;

        public IBottomMenu View
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
