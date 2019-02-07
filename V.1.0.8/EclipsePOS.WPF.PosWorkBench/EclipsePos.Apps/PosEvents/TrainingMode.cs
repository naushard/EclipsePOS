using System;
//using System.Windows.Forms;
using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for TrainingMode.
	/// </summary>
	public class TrainingMode : PosEvent
	{
		public TrainingMode()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("TrainingMode"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            PosContext.Instance.Training = true;
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
