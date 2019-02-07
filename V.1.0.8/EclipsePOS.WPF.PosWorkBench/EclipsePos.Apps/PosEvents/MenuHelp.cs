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
	/// Summary description for HelpMenu.
	/// </summary>
	public class MenuHelp : PosEvent	
	{
		public MenuHelp()
		{
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.CurrentPosDisplay.LoadMenu(4);
			
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
