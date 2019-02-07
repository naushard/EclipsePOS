using System;

using System.Windows;

using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PettyCash.
	/// </summary>
	public class PettyCash: PosEvent
	{
		public PettyCash()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			MessageBox.Show("*** Petty cash ***");

			PosEventStack.Instance.LoadDialog("PettyCash");
		
			PosEventStack.Instance.NextEvent();
 
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
