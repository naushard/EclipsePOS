using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
//using EclipsePos.Apps.Gui;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for FinishTransaction.
	/// </summary>
	public class FinishTransaction :PosEvent	
	{
		public FinishTransaction()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Finish Transaction ***");

			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				PosContext.Instance.ClearInput();
				PosContext.Instance.InputLine = "";
				PosEventStack.Instance.ClearPending();
				return;
			}
			else
			{
                PosContext.Instance.TableName = " ";
				PosContext.Instance.CurrentEj.Complete( (int)Transaction.Status.COMPLETE );
                
                if (PosContext.Instance.Sign < 0)
                {
                    PosContext.Instance.ToggleSign();
                }
                PosContext.Instance.SaleMode = null;

                PosContext.Instance.EjCustomer = null;
                PosContext.Instance.CurrentEj = null;
				PosContext.Instance.Receipt.Update(this);
                PosContext.Instance.Operprompt.Update(this);
                PosContext.Instance.TransactionType = int.Parse(PosContext.Instance.Parameters.getParam("DefaultTransactionType")); //(int)Transaction.Types.SALES;  
                
				
			}
            PosEventStack.Instance.ClearPending();
            PosEventStack.Instance.PushEvent(new RegisterOpen()); 
			
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
