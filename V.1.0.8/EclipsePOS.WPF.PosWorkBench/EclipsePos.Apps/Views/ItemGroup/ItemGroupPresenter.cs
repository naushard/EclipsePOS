using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.ItemGroup
{
    public class ItemGroupPresenter
    {
        private IItemGroup _view;

        public IItemGroup View
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
