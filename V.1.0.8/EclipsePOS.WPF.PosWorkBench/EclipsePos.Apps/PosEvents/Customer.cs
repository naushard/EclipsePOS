using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.PosEvents
{
    public class Customer : PosEvent
    {

        public override void Engage(int keyValue)
        {
           //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Customer"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

			if (PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.EjBalance() != 0.0)
			{
				PosEventStack.Instance.LoadDialog("Customer");
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
