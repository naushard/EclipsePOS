using System;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Total.
	/// </summary>
	public class Total:PosEvent		
	{
		private double amount;

		public Total()
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
			//MessageBox.Show("*** CashTender ***");
            // If tried to display total without any sales, just return
            if (PosContext.Instance.CurrentEj == null) return;

			this.PromptText = PosContext.Instance.Parameters.getParam("Total");
			amount = PosContext.Instance.CurrentEj.EjTotal();
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
