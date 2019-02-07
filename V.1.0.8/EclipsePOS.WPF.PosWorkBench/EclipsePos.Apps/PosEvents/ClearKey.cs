using System;
//using System.Windows.Forms;
using EclipsePos.Apps.Context;
using EclipsePos.Data;

using EclipsePos.Apps.EJournal;

using Microsoft.PointOfService;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ClearKey.
	/// </summary>
	public class ClearKey :PosEvent
	{
		private string promptText;

		public ClearKey()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Properties

		/*public string PromptText
		{
			get 
			{
				return promptText;
			}
			set 
			{
				promptText= value;
			}
		}*/

		#endregion

	/**
	 * Customized for event type on top of stack 
	 * - PosError, pop the next event and update dialogs.
	 * - If there is input line data, (i.e. user is in the
	 *   middle inputing a number, remove the last number.
	 * - else, clear input, pops the stack and update dialogs.
	 */
    
		public override void  Engage(int keyValue)
		{
            Logger.Info(
                       this.GetType().FullName,
                       this.GetType().FullName + "Key value:"+PosContext.Instance.InputLine.ToString(),
                           PosSettings.Default.Debug
                       ); 

		//	MessageBox.Show("*** ClearKey ***");
			//PosContext.Instance.InputLine = "";
			//PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.PosPrompt.EnableInput();

			PosEvent posEventCurrent = PosEventStack.Instance.Peek() as PosEvent;

        // Clear the error event, update dialogs and return

			 if (posEventCurrent is PosError)
			{

				PosEventStack.Instance.PopEvent();

				PosEvent posEventNext = PosEventStack.Instance.Peek() as PosEvent;
				if (posEventNext is FinishTransaction)
				{
					PosEventStack.Instance.NextEvent();
				}

                

				if ( posEventNext is LogOn) 
				{
					LogOn logOn = posEventNext as LogOn;
                    PosContext.Instance.Operprompt.Update(this);
                    logOn.States().PushState((int)LogonStates.EnterUser);
                    PosEventStack.Instance.NextEvent();
					return;
				}

                if (posEventNext is SelectTable)
                {

                    PosContext.Instance.CurrentPosDisplay.UnloadTableSelect();
                    PosContext.Instance.HomeGUI();

                }

				PosContext.Instance.ClearInput();
                PosContext.Instance.HomeGUI();
				PosEventStack.Instance.ClearPending();
				PosEventStack.Instance.ClearProcessed();
				PosEventStack.Instance.NextEvent();
				return;

			}

            

			if (posEventCurrent is UnLock)
			{
				return;
			}

            if (posEventCurrent is FinishTransaction)
            {
                PosEventStack.Instance.NextEvent();
                return;
            }

            if (posEventCurrent is CloseCashDrawer)
            {
                PosEventStack.Instance.NextEvent();
                return;
            }

			if (posEventCurrent is PromptPrintReceipt)
			{
				// get rid of this event and continue
				PosContext.Instance.ClearInput();
                PosContext.Instance.HomeGUI();
				PosEventStack.Instance.PopEvent();
				PosEventStack.Instance.NextEvent();
				return;
			}

			// If this is a finish trans then the user wants to
			// cancel the current tender, clean up the operator
			// reciept, remove the tender ej and continue.

			if (posEventCurrent is FinishTransaction)
			{

				PosContext.Instance.Receipt.ClearLine();

				PosContext.Instance.ClearInput();
				//PosContext.Instance.CurrentEj.RemoveCurrLine();
                PosContext.Instance.HomeGUI();
				PosEventStack.Instance.ClearPending();
				PosEventStack.Instance.NextEvent();
            
				return;
			}

            if (posEventCurrent is EjItem)
            {

                EjItem ejItem = posEventCurrent as EjItem;
                if (ejItem.DialogStep != EjItem.ITEM_FINAL)
                {
                    ejItem.States().PopState();
                    ejItem.States().PushState(EjItem.ITEM_CLEAR);
                    PosEventStack.Instance.NextEvent();
                }
               

                return;
            }



			if (posEventCurrent is EjLine)
			{

				PosContext.Instance.ClearInput();
				//PosContext.Instance.CurrentEj.RemoveCurrLine ();
                PosContext.Instance.HomeGUI();
				PosEventStack.Instance.ClearPending();
                PosContext.Instance.EnableKeys();
				PosEventStack.Instance.NextEvent();
            
				return;
			}

			if (posEventCurrent is LogOn)
			{
				PosContext.Instance.ClearInput();
				LogOn logOn = posEventCurrent as LogOn;
				logOn.ResetState();
				PosEventStack.Instance.NextEvent();
				return;
			}


			if (posEventCurrent is RegisterOpen )
			{
               // if ( (PosContext.Instance.CurrentEj.TransHeader.State == (int) Transaction.Status.COMPLETE) ||
               //     (PosContext.Instance.CurrentEj.TransHeader.State == (int) Transaction.Status.VOIDED) )
               // {
               //     PosContext.Instance.Receipt.ClearLine();
               // }
                PosContext.Instance.HomeGUI();
                PosContext.Instance.EnableKeys();
				PosContext.Instance.Operprompt.Update(this);
				PosContext.Instance.Receipt.Update(this);
			}

            if (posEventCurrent is TerminalReport)
            {
                PosContext.Instance.HomeGUI();
                PosContext.Instance.EnableKeys();
                PosContext.Instance.Operprompt.Update(this);
                PosContext.Instance.Receipt.Update(this);
            }


            if (posEventCurrent is SelectTable )
            {
                PosContext.Instance.HomeGUI();
                PosContext.Instance.CurrentPosDisplay.UnloadTableSelect();
                PosContext.Instance.Operprompt.Update(this);
                PosContext.Instance.Receipt.Update(this);
            }


			if (posEventCurrent is PosNumberDialog)
			{
				PosNumberDialog dialog = posEventCurrent as PosNumberDialog;
                PosContext.Instance.EnableKeys();
				dialog.Clear();
				if (PosContext.Instance.Input() > 0)
				{
					PosContext.Instance.ClearInput();
					PosContext.Instance.Operprompt.Update(dialog);
				}
				else
				{
					PosContext.Instance.ClearInput();
					PosEventStack.Instance.ClearPending();
					PosEventStack.Instance.ClearProcessed();
					PosEventStack.Instance.NextEvent();
				}
			}
			else
			{
                PosContext.Instance.HomeGUI();
				PosContext.Instance.ClearInput();
				PosEventStack.Instance.ClearPending();
			//	PosEventStack.Instance.ClearPending();
				PosEventStack.Instance.NextEvent();
			}

			return;
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
