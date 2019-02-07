using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for LogOff.
	/// </summary>
	public class LogOff : PosEvent	
	{
		public LogOff()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			
			//Transaction	t = ((EjHeader) PosContext.Instance.CurrentEj.[0]).;
			//t.setTransType (Transaction.LOGOFF);
			//t.updateStateAndType (Transaction.COMPLETE, Transaction.LOGOFF);

			// Close any guis that might exist.

			//for (int i=0;i<context ().guis ().size (); i++)
			//{
			//	PosGui gui = (PosGui) context ().guis ().elementAt (i);
			//	gui.close ();
			//
			//}
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("LogOff"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }


            if ((PosContext.Instance.CurrentEj != null) && (PosContext.Instance.CurrentEj.SeqNo > 0))
            {
                PosError error = new PosError(PosErrorCode.INVALID_FUNCTION_KEY);
                error.Engage(0);
            }
            else
            {
                PosContext.Instance.DisableKeys(); 
                PosEventStack.Instance.LoadDialog("Logon");
                PosEventStack.Instance.NextEvent();
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
