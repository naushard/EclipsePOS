using System;
using System.Diagnostics;
using System.Windows;

using EclipsePos.Apps.Context;



namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for SystemManager.
	/// </summary>
	public class SystemManager: PosEvent
	{
		public SystemManager()
		{
			//
			// TODO: Add constructor logic here
			//

		}

		public override void  Engage(int keyValue)
		{
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("SystemManager"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }


			//essageBox.Show("*** Exit ***");
			if ( (PosContext.Instance.CurrentEj != null) && (PosContext.Instance.CurrentEj.SeqNo > 0) )
			{
				PosError error = new PosError(PosErrorCode.SHUTDOWN_NOT_ALLOWED);
				error.Engage(0);
			}
			else 
			{
                try
                {
                    Process.Start(@"..\EclipsePosSystemManager\EclipsePOS.WPF.SystemManager.exe");
                 
                    PosContext.Instance.Dispose();
                    Application.Current.Shutdown();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Run System Manager", MessageBoxButton.OK, MessageBoxImage.Error);
                }

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
