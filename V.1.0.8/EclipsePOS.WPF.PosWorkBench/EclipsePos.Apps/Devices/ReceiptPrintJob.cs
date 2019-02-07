using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text;
using Microsoft.PointOfService;

using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.Devices
{
    public class ReceiptPrintJob : PrintWorker
    {
        private string organization;
        private string storeno;
        private int trxno;
        private int posno;

        public ReceiptPrintJob( string org, string store, int posno, int trxno)
        {
            this.organization = org;
            this.storeno = store;
            this.trxno = trxno;
            this.posno = posno;
        }

        #region PrintWorker Members

        public void Worker()
        {
            Transaction trans = new Transaction(this.trxno);
            trans.Pos_no = this.posno;
            trans.Organization_no = this.organization;
            trans.Store_no = this.storeno;
            trans.Load();

            Ej ej = Ej.GetSuspendedEj(trans);

            ReceiptPrint rp = new ReceiptPrint(ej);
            rp.PrintEj();
            
        }
        #endregion 
    }
}
