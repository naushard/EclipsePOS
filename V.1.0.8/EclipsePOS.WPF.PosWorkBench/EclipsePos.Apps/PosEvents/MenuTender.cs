//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: August, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================

using System;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for TenderMenu.
	/// </summary>
	public class MenuTender : PosEvent
	{
		public MenuTender()
		{
		}

		public override void  Engage(int keyValue)
		{
			
			PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.ClearInput();
			PosContext.Instance.CurrentPosDisplay.LoadMenu(1);
			
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
