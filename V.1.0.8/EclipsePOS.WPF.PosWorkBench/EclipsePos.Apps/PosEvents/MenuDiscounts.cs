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
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Function.
	/// </summary>
	public class MenuDiscounts :PosEvent
	{
		public MenuDiscounts()
		{
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.Operprompt.Update(this);
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
