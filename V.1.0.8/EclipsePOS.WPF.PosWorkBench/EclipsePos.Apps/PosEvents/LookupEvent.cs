using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.Devices;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for LookupEvent.
	/// </summary>
	public class LookupEvent: PosEvent		
	{
		public LookupEvent()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/** Event logic is implemented here */
		public override void Engage(int keyValue)
		{
            if(PosContext.Instance.ItemLookupDevice != null )
            {
			    PosContext.Instance.ItemLookupDevice.LookupFunction((ItemLookupDeviceFunctions)keyValue);		
		    }
		}

		/** Class specific clear (key) implementation */
		public override void Clear()
		{
		}


		/*  ** Sublcasses implement event validation. */
		public override bool ValidTransition (string pEventName)
		{
			return true;
		}

	}
}
