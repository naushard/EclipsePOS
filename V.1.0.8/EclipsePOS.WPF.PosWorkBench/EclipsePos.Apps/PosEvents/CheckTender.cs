using System;
//using System.Windows.Forms;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for CheckTender.
	/// </summary>
	public class CheckTender : PosEvent
	{
		public CheckTender()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Check Tender ***");

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("CheckTender"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

			if (PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				PosEventStack.Instance.LoadDialog("ChequeTender");
				PosEventStack.Instance.NextEvent();

			}
			else
			{
				PosError posError = new PosError(PosErrorCode.INVALID_FUNCTION_KEY);
				posError.Engage(0);
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
