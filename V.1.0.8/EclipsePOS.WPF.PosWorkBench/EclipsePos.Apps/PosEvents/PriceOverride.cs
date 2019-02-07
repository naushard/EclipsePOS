using System;
using System.Data;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PriceOverride.
	/// </summary>
	public class PriceOverride:PosNumberDialog
	{
		public const int GET_AMOUNT = 1;
		private string promptText=null;
		private string messageText=null;
		private double amount;
		private PosNumberDialogTypes type = PosNumberDialogTypes.Clear;

		public PriceOverride()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void Engage(int keyValue)
		{
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("ChangePrice"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }
            EjPriceOverride ejPriceOverride = new EjPriceOverride();
            ejPriceOverride.States().PushState((int)EjPriceOverride.ENTER_LINE_NUMBER);
            PosEventStack.Instance.PushEvent(ejPriceOverride);
            PosEventStack.Instance.NextEvent();
		}


		public bool AmountIsValid()
		{
			return true;
		}


		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}


		#region Properties

		public override string PromptText
		{
			get 
			{
				return promptText;
			}
			set
			{
				promptText = value;
			}

		}
 
		public override string MessageText
		{
			get 
			{
				return messageText;
			}
			set
			{
				messageText = value;
			}

		}

		public override PosNumberDialogTypes Type
		{
			set
			{
				type = value;
			}
			get
			{
				return type;
			}
		}

		public double Amount
		{
			set
			{
				amount = value;
			}

			get
			{
				return amount;
			}
		}

		#endregion 
	}
}
