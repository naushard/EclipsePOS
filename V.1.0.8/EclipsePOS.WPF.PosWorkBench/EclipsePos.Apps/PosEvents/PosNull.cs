using System;
using System.Windows;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Null.
	/// </summary>
	public class PosNull : PosEvent
	{
		public PosNull()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			MessageBox.Show(keyValue.ToString());
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
