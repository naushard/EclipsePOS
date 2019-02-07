using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class LeftMenuNavigator : PosEvent
    {

        public override void Engage(int keyValue)
        {
            if (PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen)
            {
                PosContext.Instance.CurrentPosDisplay.LoadMenu(keyValue );
            }
            else
            {
                PosEventStack.Instance.PushEvent( new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
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
