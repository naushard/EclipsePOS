using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Devices;


namespace EclipsePos.Apps.PosEvents
{
    public class CustomerLookupEvent : PosEvent	
    {

        /** Event logic is implemented here */
        public override void Engage(int keyValue)
        {
            PosContext.Instance.CustomerLookupDevice.LookupFunction((CustomerLookupDeviceFunctions)keyValue);

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
