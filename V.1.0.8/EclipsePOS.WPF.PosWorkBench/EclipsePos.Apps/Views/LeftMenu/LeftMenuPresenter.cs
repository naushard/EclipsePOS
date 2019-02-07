using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.LeftMenu
{
    public class LeftMenuPresenter
    {

        private ILeftMenu _view;

        public ILeftMenu View
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
