using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
    class QuickSaleItem:PosEvent
    {

        public override void Engage(int keyValue)
        {

            try
            {
                int pluItem = int.Parse(PosContext.Instance.Parameters.getParam("QuickSalePLU"));
                Plu plu = new Plu();
               // PosContext.Instance.InputLine = pluItem.ToString();
                plu.Engage(pluItem);
            }
            catch
            {
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
