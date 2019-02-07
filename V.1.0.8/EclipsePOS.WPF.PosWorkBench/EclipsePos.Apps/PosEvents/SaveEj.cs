using System;
//using System.Windows.Forms;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for SaveEj.
	/// </summary>
	public class SaveEj : PosEvent 
	{
		private string promptText=null;
		private string messageText=null;
		//private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;
	
		public SaveEj()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Store"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            // If tried to save without any sales, just return
            if (PosContext.Instance.CurrentEj == null) return;

            //Tried to recall in a middle of a dialog
            if (!(PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen))
            {

                PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
                return;
            }



            // Print receipt

            PosContext.Instance.Receipt.Update(this);


            PosContext.Instance.CurrentEj.Complete((int)Transaction.Status.SUSPEND);
         /*  PosContext.Instance.TableName = "";
			PosContext.Instance.ReceiptHeader.TrxNo = "";
			PosContext.Instance.ReceiptDetails.Clear();
			PosContext.Instance.ReceiptTotal.Clear();
            if (PosContext.Instance.AlphaKeyEntryDisplay != null)
            {
                PosContext.Instance.AlphaKeyEntryDisplay.KeyReset();
            }
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
