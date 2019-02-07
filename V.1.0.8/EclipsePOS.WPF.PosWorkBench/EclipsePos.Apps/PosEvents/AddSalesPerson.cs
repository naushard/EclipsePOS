using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    public class AddSalesPerson:PosEvent
    {
        public AddSalesPerson()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{

            if (PosContext.Instance.Parameters.getParam("PromptForEmployee") == "TRUE")
            {
                PosEventStack.Instance.LoadDialog("AddSalesPerson");
                PosEventStack.Instance.NextEvent();
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
