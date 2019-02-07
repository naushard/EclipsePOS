using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.PosEvents
{
    public class PrintKitchenTicket : PosEvent	
    {

        public PrintKitchenTicket()
        {

        }

        public override void Engage(int keyValue)
        {

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
