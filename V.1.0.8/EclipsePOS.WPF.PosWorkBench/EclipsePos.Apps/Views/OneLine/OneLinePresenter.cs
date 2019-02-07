using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.Views.OneLine
{
    public class OneLinePresenter
    {
        private IOneLine _view;

        public IOneLine View
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
