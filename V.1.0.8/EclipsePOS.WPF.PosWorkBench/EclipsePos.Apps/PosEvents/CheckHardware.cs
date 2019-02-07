using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for CheckHardware.
	/// </summary>
	public class CheckHardware:PosEvent	
	{
		public CheckHardware()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{

		//	MessageBox.Show("*** Check Hardware ***");
			/*
			// Test Hardware 
			HardwareSupport hardwareSupport = PosHardware.Instance.CheckHealth();
			//If in error 
			if (hardwareSupport != null )
			{
				
				//If the h ardwate error in not trapped before 
				if (!(PosEventStack.Instance.CurrentEvent is PosError ) )
				{
					 HardwareError hardwareError = new HardwareError(); 
					PosEventStack.Instance.ClearPending();
					if (PosEventStack.Instance.CurrentEvent is RegisterOpen)
					{
						RegisterOpen rOpen = (RegisterOpen) PosEventStack.Instance.CurrentEvent;
						rOpen.HardwareTested = true;
					} 
				
					 PosEventStack.Instance.PushEvent(hardwareError);
					PosContext.Instance.Operprompt.Update(hardwareError);	
				}
			}
			*/
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
