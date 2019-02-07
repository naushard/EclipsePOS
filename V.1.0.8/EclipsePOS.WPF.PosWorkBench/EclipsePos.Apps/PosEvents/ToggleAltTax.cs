using System;
using System.Windows;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ToggleAltTax.
	/// </summary>
	public class ToggleAltTax :PosEvent
	{
		public ToggleAltTax()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			MessageBox.Show("*** ToggleAltTax ***");
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
