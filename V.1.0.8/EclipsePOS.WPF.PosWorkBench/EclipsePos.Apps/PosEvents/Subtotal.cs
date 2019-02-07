using System;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Subtotal.
	/// </summary>
	public class Subtotal: PosEvent		
	{
		private double amount;
		public Subtotal()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public double Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount = value;
			}
		}


		public override void  Engage(int keyValue)
		{
            // If tried to subtotal without any sales, just return
            if (PosContext.Instance.CurrentEj == null) return;

			this.PromptText = PosContext.Instance.Parameters.getParam("SubTotal");
			amount = PosContext.Instance.CurrentEj.EjSubTotal();
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
