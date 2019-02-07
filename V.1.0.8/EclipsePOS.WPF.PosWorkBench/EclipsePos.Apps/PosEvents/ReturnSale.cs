using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Data; 

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ReturnSale.
	/// </summary>
	public class ReturnSale : PosEvent
	{
		public ReturnSale()
		{
			//
			// TODO: Add constructor logic here
			//
			this.PromptText = PosContext.Instance.Parameters.getParam("ReturnSalePrompt");
		}


		/**
			* Gets the current header EJ record, sets the type to RETURN and
			* toggles the sign in the context.
		*/
   
		public override void  Engage(int keyValue)
		{
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("ReturnSale"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            // if in a middle of a dialog just return
            if (!(PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen))
            {

                PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
                return;
            }

            // if in a middle of a dialog just return
            if ( (PosContext.Instance.CurrentEj != null) && (PosContext.Instance.CurrentEj.SeqNo > 0) )
            {

                PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
                return;
            }


			PosContext.Instance.ToggleSign();
            PosContext.Instance.TransactionType = (int)Transaction.Types.RETURN;
			PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.Receipt.Update(this);

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
