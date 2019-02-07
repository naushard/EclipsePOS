using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for CreditTender.
	/// </summary>
	public class CreditTender :PosEvent
	{
		public CreditTender()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("CreditTender"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }
			//MessageBox.Show("*** CreditTender ***");
			if (PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
                PosContext.Instance.PosKeyValue = keyValue;
                PosEventStack.Instance.LoadDialog("CreditTender");
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
