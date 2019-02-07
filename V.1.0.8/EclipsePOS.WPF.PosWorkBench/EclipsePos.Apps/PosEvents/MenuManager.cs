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
	/// Summary description for ManagerMenu.
	/// </summary>
	public class MenuManager : PosEvent
	{
		public MenuManager()
		{
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.CurrentPosDisplay.LoadMenu(2);
			
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
