using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace EclipsePos.Apps.Views.TransactonHistory
{
    public class LogViewStyleSelector : StyleSelector
    {
        private int i;

        public override Style SelectStyle(object item, DependencyObject container)
        {
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(container);
            DataRowView drw = item as DataRowView;
            int state = int.Parse ( drw["state"].ToString());
            string key = "";
            switch (state)
            {
                case 1:
                    key = "LstVwItmStyleProgress";
                    break;
                case 2:
                    key = "LstVwItmStyleComp";
                    break;
                case 3:
                    key = "LstVwItmStyleSuspended";
                    break;
                case 4:
                    key = "LstVwItmStyleVoid";
                    break;
                default:
                    key = "LstVwItmStyleComp";
                    break;
            }

            return (Style)(ic.FindResource(key));
        }
    }
}
