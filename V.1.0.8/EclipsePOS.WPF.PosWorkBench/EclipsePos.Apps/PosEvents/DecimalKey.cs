using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.Context;
using EclipsePos.Data;


namespace EclipsePos.Apps.PosEvents
{
    public class DecimalKey : NumKey
    {

        public DecimalKey()
            : base()
        {
        }


        public override void Engage(int keyValue)
        {
            //MessageBox.Show("*** MultKey ***");.
            //PosContext.Instance.MultByInput(keyValue);

            Organization org  = PosContext.Instance.Organization;
            CurrencyCode currCode = new CurrencyCode();
            currCode.Currency_code = org.Home_currency;
            currCode.LoadByCurrencyCode();
            PosContext.Instance.AddToInput(currCode.Decimal_seperator);

           
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
