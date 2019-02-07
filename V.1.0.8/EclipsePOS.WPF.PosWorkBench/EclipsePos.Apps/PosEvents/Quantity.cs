using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;



namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Quantity.
	/// </summary>
	public class Quantity :PosEvent		 		
	{
		public Quantity()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public override void  Engage(int keyValue)
		{
			// if in a middle of a dialog just return
            if (!(PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen))
            {

                PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                PosEventStack.Instance.NextEvent();
                return;
            }

			PosContext.Instance.Quantity = PosContext.Instance.Input();
			PosContext.Instance.ClearInput();
			this.PromptText = PosContext.Instance.Parameters.getParam("EnterItem");
			PosContext.Instance.Operprompt.Update(this);
		
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
