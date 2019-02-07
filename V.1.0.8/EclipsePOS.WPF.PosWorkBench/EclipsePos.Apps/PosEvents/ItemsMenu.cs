using System;
using System.Windows;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ItemLookupMenu.
	/// </summary>
	public class ItemsMenu : PosEvent
	{
		public ItemsMenu()
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
			PosContext.Instance.CurrentPosDisplay.LoadItemSearch(keyValue);	
			
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
