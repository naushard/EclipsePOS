using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Operators;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;
using System.Data;
using System.Windows;



namespace EclipsePos.Apps.PosEvents
{
    public class AddSurcharge : PosEvent	
    {
        public AddSurcharge()
        {
        }


        public override void Engage(int keyValue)
        {
            //MessageBox.Show("*** Item markdown ***" + keyValue.ToString() );
            //if there are no items in the invoice error out

            Surcharge surcharge = new Surcharge();
         
            surcharge.Surcharge_key_id  = keyValue;
            surcharge.Organization_no  = PosSettings.Default.Organization;
            surcharge.LoadByKeyId();
            if (!string.IsNullOrEmpty (surcharge.Surcharge_desc ))
            {
                EjSurcharge ejSurcharge = new EjSurcharge(surcharge);
                ejSurcharge.Engage(0);
            }
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
