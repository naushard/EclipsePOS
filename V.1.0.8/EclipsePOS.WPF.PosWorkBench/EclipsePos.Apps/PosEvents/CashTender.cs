using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
//using EclipsePos

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for CashTender.
	/// </summary>
	public class CashTender : PosEvent
	{
		public CashTender()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
          
		//	MessageBox.Show("*** CashTender ***");

            // if there are input in buffer 
            if (PosContext.Instance.InputLine.Length > 0)
            {
                PosError posError = new PosError(PosErrorCode.INVALID_FUNCTION_KEY);
                posError.Engage(0);
                return;
            }


            if (( PosContext.Instance.Sign > 0 && PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.EjBalance() > 0.0) || 
            (PosContext.Instance.Sign < 0 && PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.EjBalance() < 0.0) )
			{
				PosEventStack.Instance.LoadDialog("CashTender");
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
