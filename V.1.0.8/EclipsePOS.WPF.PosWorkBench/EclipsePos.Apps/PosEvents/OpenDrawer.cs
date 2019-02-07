using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Hardware;



namespace EclipsePos.Apps.PosEvents
{
    public class OpenDrawer : PosEvent
    {

        public override void Engage(int keyValue)
        {
            try
            {
                if (PosHardware.Instance.PosPrinter != null)
                {
                    PosHardware.Instance.PosPrinter.OpenCashDrawer();
                }

            }
            catch
            {
            }
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
