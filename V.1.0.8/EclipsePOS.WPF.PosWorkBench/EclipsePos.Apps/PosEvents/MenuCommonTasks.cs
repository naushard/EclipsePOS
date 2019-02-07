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
using EclipsePos.Apps.Context;

//using EclipsePos.Apps.Gui;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for MainMenu.
	/// </summary>
	public class MenuCommonTasks : PosEvent
	{
		public MenuCommonTasks()
		{
			//
			// TODO: Add constructor logic here
			//
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
