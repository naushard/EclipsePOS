using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for NewLogon.
	/// </summary>
	public class NewLogon :PosEvent 
	{
		public NewLogon()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
		//	MessageBox.Show("*** New Logon ***");
			PosContext.Instance.EnableKeys();
			PosContext.Instance.Receipt.Update(this);
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
