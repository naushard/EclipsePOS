using System;
using System.Windows;

using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PickUp.
	/// </summary>
	public class PickUp: PosEvent
	{
		public PickUp()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			MessageBox.Show("*** PickUp ***");

			PosEventStack.Instance.LoadDialog("Pickup");
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
