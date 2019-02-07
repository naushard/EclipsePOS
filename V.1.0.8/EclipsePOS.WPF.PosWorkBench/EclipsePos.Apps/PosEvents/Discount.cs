using System;
//using System.Windows.Forms;
using System.Collections;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;

using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Discount.
	/// </summary>
	public class Discount : PosEvent
	{
		public Discount()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public override void Engage(int val)
        {

            //MessageBox.Show("*** Discount ***" + keyValue.ToString());
            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Discount"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }



            // if ( PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.Seq_no > 0 )
            //{
            //	PosError posError = new PosError(PosErrorCode.PROMOTION_NOT_APPLICABLE);
            //	posError.Engage(0);
            //	return;
            //}


            int keyValue = val; //(int) PosContext.Instance.PosKeyValue;

            Promotion pro = new Promotion();
            pro.PromotionNo = keyValue;
            pro.Organization_no = PosSettings.Default.Organization;
            pro.Load();
            if (pro.PromotionType == (int)EjPromotionTypes.WHOLE_ORDER)
            {
                PosContext.Instance.SaleMode = pro;

                //Apply promotion for current Ej
                object[] currentEj = new Object[PosContext.Instance.CurrentEj.EjArrayList.Count];
                PosContext.Instance.CurrentEj.EjArrayList.CopyTo(currentEj);
                foreach (object obj in currentEj)
                {
                    if (obj is EjItem)
                    {
                        EjItem ejItem = obj as EjItem;
                        if ((ejItem.TransItem.State == (int)EjLineStates.VOID_ITEM) || ejItem.TransItem.State == (int)EjLineStates.PRICE_OVERRIDE) continue; 
                        EjPromotion ejPromo1 = new EjPromotion(PosContext.Instance.SaleMode, ejItem);
                        ejPromo1.SKU = ejItem.SKU;
                        ejPromo1.Engage(0);
                    }
                }

            }
            else
            {
                EjPromotion ejPromo1 = new EjPromotion(pro, PosContext.Instance.CurrentEjItem);
                ejPromo1.SKU = PosContext.Instance.CurrentEjItem.SKU;
                ejPromo1.Engage(0);
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
