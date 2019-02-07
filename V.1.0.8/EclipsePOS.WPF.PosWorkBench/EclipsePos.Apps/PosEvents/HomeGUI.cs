using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

using EclipsePos.Apps.EJournal;

using Microsoft.PointOfService;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class HomeGUI : PosEvent
    {

        public override void Engage(int keyValue)
        {
            PosContext.Instance.HomeGUI();
            return;
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
