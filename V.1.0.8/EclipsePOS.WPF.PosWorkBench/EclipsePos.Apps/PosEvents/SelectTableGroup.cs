using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class SelectTableGroup : PosEvent
    {
        public SelectTableGroup()
        {
        }


        public override void Engage(int keyValue)
        {

           // MessageBox.Show( keyValue.ToString() );
            PosContext.Instance.CurrentPosDisplay.LoadTable(keyValue);

        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }
    }
}
