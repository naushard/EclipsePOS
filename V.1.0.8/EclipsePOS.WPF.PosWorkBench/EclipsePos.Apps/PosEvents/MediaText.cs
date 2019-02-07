using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class MediaText : PosEvent
    {

        public override void Engage(int keyValue)
        {
            
            PosContext.Instance.InputLine = this.PromptText;
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
