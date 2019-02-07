using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.PosEvents
{
    public class SalesLog : PosEvent
    {
        public SalesLog()
        {
        }

        public override void Engage(int keyValue)
        {
            //MessageBox.Show("*** CashTender ***");
            //PosEventStack.Instance.LoadDialog("CashTender");
            //PosEventStack.Instance.NextEvent();
            PosContext.Instance.CurrentPosDisplay.LoadTransactionLog();

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
