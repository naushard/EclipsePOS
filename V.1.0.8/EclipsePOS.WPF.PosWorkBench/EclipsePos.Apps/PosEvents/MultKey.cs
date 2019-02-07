using System;
//using System.Windows.Forms;
using EclipsePos.Apps.Context;

//using EclipsePos.Apps.Gui;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for MultKey.
	/// </summary>
	public class MultKey : NumKey
	{
		public MultKey():base()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** MultKey ***");.
			PosContext.Instance.MultByInput(keyValue);
			base.Engage(-1);
	
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
