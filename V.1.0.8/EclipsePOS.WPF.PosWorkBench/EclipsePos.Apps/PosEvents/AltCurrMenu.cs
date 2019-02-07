using System;

using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for AltCurrMenu.
	/// </summary>
	public class AltCurrMenu : PosEvent
	{
		public AltCurrMenu()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.CurrentPosDisplay.LoadMenu(6);
			
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
