using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;
using System.Diagnostics;
using EclipsePos.Apps.Hardware;

namespace EclipsePos.Apps.PosEvents
{
    public class ClearPreviousKeyStroke : PosEvent
    {
       
        public ClearPreviousKeyStroke()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{

            if (! String.IsNullOrEmpty(PosContext.Instance.InputLine) )
            {
                PosContext.Instance.EraseLast();  
                PosContext.Instance.Operprompt.Update(this);
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
