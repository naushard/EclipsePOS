using System;
//using System.Windows.Forms;
using System.Collections;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for VoidSale.
	/// </summary>
	public class VoidSale:PosEvent	
	{
		public VoidSale()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			
			

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("VoidSale"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
		    }


            
            // If tried to void without any sales, just return
            if (PosContext.Instance.CurrentEj == null ) return ;
            if (PosContext.Instance.CurrentEj.SeqNo == 0) return;

            //Tried to void while in a dialog
            if ( !(PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen) )
            {
           
                PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
                return;
            }

            PosContext.Instance.Receipt.Update(this);

            PosContext.Instance.CurrentEj.Complete((int)Transaction.Status.VOIDED);
			if (PosContext.Instance.AlphaKeyEntryDisplay != null)
            {
                PosContext.Instance.AlphaKeyEntryDisplay.KeyReset();
            }


            /*
            PosContext.Instance.TableName = "";
            PosContext.Instance.EjCustomer = null;
            if (PosContext.Instance.Sign < 0)
            {
                PosContext.Instance.ToggleSign();
            }
            PosContext.Instance.SaleMode = null;
			PosEventStack.Instance.ClearPending();
			PosEventStack.Instance.SetEvent(new RegisterOpen());
             */

            new FinishTransaction().Engage(0);

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
