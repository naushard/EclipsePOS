using System;
//using System.Windows.Forms;


using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for AltCurrMenu.
	/// </summary>
	public class MenuAltCurrency : PosEvent
	{
		public MenuAltCurrency()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("MenuAltCurency" );
			PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.CurrentPosDisplay.LoadMenu(5);
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
