using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using System.Windows;

namespace EclipsePos.Apps.PosEvents
{
    public class Plu : PosEvent
    {

        public override void Engage(int keyValue)
        {
            if (PosContext.Instance.InputLine.Length > 0) return;

           
            if (PosEventStack.Instance.CurrentEvent is PosError)
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

            PosContext.Instance.InputLine = keyValue.ToString();  //PosContext.Instance.PosKeyValue.ToString(); // keyValue.ToString();

          //  if (PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.RegisterOpen || 
          //      PosEventStack.Instance.CurrentPosEvent() is EclipsePos.Apps.PosEvents.Plu )
          //  {
                if (PosContext.Instance.InputLine.Length > 0)
                {
                    /*
                    if (PosContext.Instance.Parameters.getParam("PromptForTableNo").ToUpper() == "TRUE")
                    {
                        PosEventStack.Instance.LoadDialog("FindItem");
                        PosEventStack.Instance.NextEvent();
                    }
                    else
                    {
                        new LookupItem().Engage(0);
                    }
                     * */

                    if (PosContext.Instance.Parameters.getParam("PromptForTableNo").ToUpper() == "TRUE" &&
                          PosContext.Instance.TransactionType == (int)Transaction.Types.DINE_IN )
                    {
                        // PosEventStack.Instance.LoadDialog("FindItem");

                        PosContext.Instance.PosKeyValue = keyValue;

                        PosEventStack.Instance.PushEvent(new LookupItem());

                        // Request to select or enter table number
                        SelectTable posEvent = new SelectTable();
                        posEvent.PushState(posEvent.StartState);

                        PosEventStack.Instance.PushEvent(posEvent);

                        PosEventStack.Instance.NextEvent();
                    }
                    else
                    {
                         new LookupItem().Engage(0);
                       // PosEventStack.Instance.PushEvent(new LookupItem());
                       // PosEventStack.Instance.NextEvent();
                    }

            //    }

            }
            else
            {
                // Get the next event
                PosEventStack.Instance.NextEvent();
                PosContext.Instance.InputLine = "";

            }
            /*
            Item item = new Item();
            item.Organization_no = PosSettings.Default.Organization;

            if (keyValue > 0)
            {
                item.Plu = keyValue;
                item.LoadByPLU();

            }
           
            if (item.Short_Desc != null)
            {
                EjItem ejItem = new EjItem(item);
                ejItem.Engage(0);
            }
            else
            {
                PosError posError = new PosError(PosErrorCode.INVALID_INPUT);
                posError.Engage(0);
            }

            PosContext.Instance.InputLine = "";
            PosContext.Instance.ClearInput();
            
            keyValue = 0;
            */

        }

        /** Class specific clear (key) implementation */
        public override void Clear()
        {
        }


        /*  ** Sublcasses implement event validation. */
        public override bool ValidTransition(string pEventName)
        {
            return true;
        }

    }
}
