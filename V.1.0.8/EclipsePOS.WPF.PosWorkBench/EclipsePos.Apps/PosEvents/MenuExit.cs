//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: March, 2007
//===============================================================================
// Changes/Fixes
//
//===============================================================================


using System;

//using EclipsePos.Apps.Gui;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ExitMenu.
	/// </summary>
	public class MenuExit : PosEvent
	{
		public MenuExit()
		{
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.CurrentPosDisplay.LoadMenu(3);
			
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
