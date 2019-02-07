using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;

using EclipsePos.Data;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.Views.TableSelect
{
    public class TablePresenter
    {

        private ITable _view;

        public TablePresenter()
        {
            
        }



        public ITable View
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
