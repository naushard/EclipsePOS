using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Data;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PaidOut.
	/// </summary>
	public class PaidOut : PosEvent	
	{
		public PaidOut()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public override void  Engage(int keyValue)
		{
            

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("PaidOut"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }
            if (PosContext.Instance.CurrentEj == null ||  PosContext.Instance.CurrentEj.EjBalance() == 0)
            {

			    PosEventStack.Instance.LoadDialog("PaidOut");

                PosContext.Instance.TransactionType = (int)Transaction.Types.PAID_OUT;
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
