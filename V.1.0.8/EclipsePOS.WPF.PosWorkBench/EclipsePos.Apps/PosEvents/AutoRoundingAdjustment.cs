using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.EJournal;


namespace EclipsePos.Apps.PosEvents
{
    public class AutoRoundingAdjustment : PosEvent
    {
        public AutoRoundingAdjustment()
        {
        }

        public override void Engage(int val)
        {
            if (!(PosContext.Instance.Parameters.getParam("ApplyRoundingToCashTender") == "TRUE"))
            {
                PosEventStack.Instance.NextEvent();
                return;
            }
            int keyValue = 0;
            try
            {
                 keyValue =int.Parse(PosContext.Instance.Parameters.getParam("AutoRoundDownPromotionNo")); //999; 
            }
            catch (Exception e)
            {
                PosEventStack.Instance.NextEvent();
                return;
            }
            Promotion pro = new Promotion();
            pro.PromotionNo = keyValue;
            pro.Organization_no = PosSettings.Default.Organization;
            pro.Load();
            EjPromotion ejPromo1 = new EjPromotion(pro, PosContext.Instance.CurrentEjItem);
            ejPromo1.SKU = PosContext.Instance.CurrentEjItem.SKU;
            ejPromo1.Engage(0);
            PosEventStack.Instance.NextEvent();

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
