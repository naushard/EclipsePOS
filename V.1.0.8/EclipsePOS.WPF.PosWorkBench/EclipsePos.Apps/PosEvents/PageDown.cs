using System;
using System.Windows;
using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PageDown.
	/// </summary>
	public class PageDown: PosEvent
	{
		public PageDown()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
            //MessageBox.Show("Deleted code");
			//PnlInvoice pnlInvoice = PosContext.Instance.ReceiptDetails as PnlInvoice;			
			//pnlInvoice.PageDown();
            PosContext.Instance.CurrentPosDisplay.PageDown();
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
