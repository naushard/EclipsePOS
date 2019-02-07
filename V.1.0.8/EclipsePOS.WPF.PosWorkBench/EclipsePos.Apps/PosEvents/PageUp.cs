using System;
using System.Windows;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PageUp.
	/// </summary>
	public class PageUp: PosEvent		
	{
		public PageUp()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
           // MessageBox.Show("Deleted code");
            //PnlInvoice pnlInvoice = PosContext.Instance.ReceiptDetails as PnlInvoice;			
			//pnlInvoice.PageUp();
            PosContext.Instance.CurrentPosDisplay.PageUp();
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
