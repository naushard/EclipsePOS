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
	/// Summary description for LookupItemMenu.
	/// </summary>
	public class MenuItemLookupSelection:PosEvent	
	{
		private string promptText;

		public MenuItemLookupSelection()
		{
			//
			// TODO: Add constructor logic here
			//
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


		#region Properties

		public string PromptText
		{
			get 
			{
				return promptText;
			}
			set 
			{
				promptText= value;
			}
		}

		#endregion
	}
}
