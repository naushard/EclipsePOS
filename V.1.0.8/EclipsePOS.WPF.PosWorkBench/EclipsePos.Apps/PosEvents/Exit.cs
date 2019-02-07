using System;
using System.Windows;
using EclipsePos.Apps.Context;
using System.Diagnostics;
using EclipsePos.Apps.Hardware;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Exit.
	/// </summary>
	public class Exit : PosEvent
	{
		public Exit()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
		//essageBox.Show("*** Exit ***");
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Shutdown"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

			if ( (PosContext.Instance.CurrentEj != null) && (PosContext.Instance.CurrentEj.SeqNo > 0) )
			{
				PosError error = new PosError(PosErrorCode.SHUTDOWN_NOT_ALLOWED);
				error.Engage(0);
			}
			else 
			{
                PosHardware.Instance.Close();

				PosContext.Instance.Dispose();
				//Environment.Exit(1);
				//Process.


				Application.Current.Shutdown();
                //MessageBox.Show("Delteed code");
			}
			
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
