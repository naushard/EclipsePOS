using System;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for MainMenu.
	/// </summary>
	public class MainMenu : PosEvent
	{
		public MainMenu()
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
			PosContext.Instance.CurrentPosDisplay.LoadMenu(0);
			
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
