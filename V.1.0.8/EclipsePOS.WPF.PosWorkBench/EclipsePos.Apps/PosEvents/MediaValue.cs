using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class MediaValue : PosEvent
    {

        public override void Engage(int keyValue)
        {
            double inputAmt = keyValue / 100;
            double amt = PosContext.Instance.InputDouble()+ inputAmt;
            PosContext.Instance.InputLine = amt.ToString();
            this.PromptText = PosContext.Instance.InputLine;

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
