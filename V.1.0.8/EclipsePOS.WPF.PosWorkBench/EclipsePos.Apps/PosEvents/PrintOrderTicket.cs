using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
    public class PrintOrderTicket : PosEvent	
    {
       

        public PrintOrderTicket()
        {
        }


        public override void  Engage(int keyValue)
		{
            if (PosContext.Instance.CurrentEj == null || PosContext.Instance.CurrentEj.LineNo == 0)
            {
                PosError posError = new PosError(PosErrorCode.INVALID_FUNCTION_KEY);
                posError.Engage(0);
                return;
            }


           // PrintJobQueue.Instance.Backup();
           // PrintJobQueue.Instance.PrintReceiptStart();
           // PrintJobQueue.Instance.Restore();
            PosContext.Instance.Receipt.Update(this);  


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
