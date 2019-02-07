using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.PosEvents
{
    public class FreeText : PosEvent		
    {
        public FreeText()
        {
        }

        public override void Engage(int keyValue)
        {
            EjFreeText lineText  = new EjFreeText();
            PosEventStack.Instance.PushEvent(lineText);
            PosEventStack.Instance.NextEvent();
        }

        /** Class specific clear (key) implementation */
        public override void Clear()
        {
        }


        /*  ** Sublcasses implement event validation. */
        public override bool ValidTransition(string pEventName)
        {
            return true;
        }


    }
}
