
using System;
using EclipsePos.Data;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for EnterKey.
	/// </summary>
	public class EnterKey : PosEvent
	{
		public EnterKey()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** EnterKey ***");
			if(PosEventStack.Instance.CurrentEvent is PosError)
			{
				PosError posError = PosEventStack.Instance.CurrentEvent as PosError;
				if (posError.ErrorCode == PosErrorCode.HARDWARE_PROBLEM)
				{
					new CheckHardware().Engage(0);  
				}
				else
				{
					//posError.Engage(0);
				}

				return;
			}

            if(PosEventStack.Instance.CurrentEvent is TerminalReport)
			{
                PosError posError = new PosError(PosErrorCode.TERMINAL_REPORT);
                posError.Engage(0);
                return;
			}
           

			if ( PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen )
			{	
			 	 if (PosContext.Instance.InputLine.Length > 0 )
				 {						 
					//new LookupItem().Engage(0);
                     if (PosContext.Instance.Parameters.getParam("PromptForTableNo").ToUpper() == "TRUE"  &&
                          PosContext.Instance.TransactionType == (int)Transaction.Types.DINE_IN  )
                     {
                        // PosEventStack.Instance.LoadDialog("FindItem");

                         PosEventStack.Instance.PushEvent(new LookupItem());

                         // Request to select or enter table number
                         SelectTable posEvent = new SelectTable();
                         posEvent.PushState(posEvent.StartState);

                         PosEventStack.Instance.PushEvent(posEvent);
                        
                         PosEventStack.Instance.NextEvent();
                     }
                     else
                     {
                        // new LookupItem().Engage(0);
                         PosEventStack.Instance.PushEvent(new LookupItem());
                         PosEventStack.Instance.NextEvent();
                     }
				 }
			}
			else
			{	
				// Get the next event
				PosEventStack.Instance.NextEvent();
				PosContext.Instance.InputLine  = "";

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
