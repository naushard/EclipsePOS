using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Operators;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for ItemMarkdown.
	/// </summary>
	public class ItemMarkdown :PosEvent	
	{
		public ItemMarkdown()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Item markdown ***" + keyValue.ToString() );
			//if there are no items in the invoice error out
			if ( PosContext.Instance.CurrentEj== null || PosContext.Instance.CurrentEj.SeqNo == 0 )
			{
				PosError posError = new PosError(PosErrorCode.ITEM_DISCOUNT_NOT_APPLICABLE);
				posError.Engage(0);
				return;
			}

			Promotion promo = new Promotion();
           // int keyValue = (int) PosContext.Instance.PosKeyValue;
			promo.PromotionNo = keyValue;
            promo.Organization_no = PosSettings.Default.Organization;
			promo.Load();
			if (promo.PromotionClass != null)
			{
				EjPromotion ejPromo = new EjPromotion(promo, PosContext.Instance.CurrentEjItem);
				ejPromo.Engage(0);
			}
//			PosEventStack.Instance.NextEvent();

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
