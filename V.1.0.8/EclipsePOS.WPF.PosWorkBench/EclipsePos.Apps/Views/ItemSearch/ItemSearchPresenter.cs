using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.ItemSearch
{
    public class ItemSearchPresenter
    {
        private IItemSearch _view;

        public IItemSearch View
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
