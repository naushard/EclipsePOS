using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class LoadQuickSalesDialog : PosEvent
    {

        public override void Engage(int keyValue)
        {

            try
            {
                PosEventStack.Instance.LoadDialog("FastSale");
                PosEventStack.Instance.NextEvent();
            }
            catch
            {
            }

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
