using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class PrintEj:PosEvent
    {

        public PrintEj()
        {
        }

        public override void Engage(int keyValue)
        {
            PosContext.Instance.Receipt.Update(this);  
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
