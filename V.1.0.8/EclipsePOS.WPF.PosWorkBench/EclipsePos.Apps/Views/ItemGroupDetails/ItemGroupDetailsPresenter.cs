using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.ItemGroupDetails
{
    public class ItemGroupDetailsPresenter
    {
        private ItemGroupDetailsView _view;

        public ItemGroupDetailsView View
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
