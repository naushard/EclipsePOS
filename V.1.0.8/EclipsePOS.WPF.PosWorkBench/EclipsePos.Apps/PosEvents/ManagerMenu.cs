using System;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ManagerMenu.
	/// </summary>
	public class ManagerMenu : PosEvent
	{
		public ManagerMenu()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** CashTender ***");
			//PosEventStack.Instance.LoadDialog("CashTender");
			//PosEventStack.Instance.NextEvent();
			PosContext.Instance.CurrentPosDisplay.LoadMenu(8);
			
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
