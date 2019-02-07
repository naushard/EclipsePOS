using System;
//using System.Windows.Forms;

using EclipsePos.Data;
using EclipsePos.Apps.Context;

using Microsoft.PointOfService;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for AltCurrTender.
	/// </summary>
	public class AltCurrTender : PosEvent
	{
		public AltCurrTender()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** AltCurrTender ***" + keyValue);
			//Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("AltCurrencyTender"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            Logger.Info(
                       this.GetType().FullName,
                       this.GetType().FullName + "Key value:"+PosContext.Instance.InputLine.ToString(),
                           PosSettings.Default.Debug
                       ); 

            // The type of alternate currency is passed as the value to engage ()
            CurrencyCode inputCurrencyCode = new CurrencyCode();
            inputCurrencyCode.Pos_key_number = keyValue;
            inputCurrencyCode.LoadCurrencyCodeByPosKey();

			Currency curr = new Currency();
            //curr.Organization_no = PosContext.Instance.Config.Organization_id;
			//curr.Currency_code = PosContext.Instance.InputLine.Substring(0,3);
			curr.Home_currency = PosContext.Instance.Organization.Home_currency;
            curr.Source_currency = inputCurrencyCode.Currency_code;
            curr.Rate_date = DateTime.Now;
            curr.LoadByCurrencyCodeId();
			
			PosContext.Instance.AltCurrency = curr;
            PosContext.Instance.AltCurrencyCode = inputCurrencyCode;
		
			// Set up and push the current dialog on the stack
			
			PosEventStack.Instance.LoadDialog("AltCurrTender");
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
