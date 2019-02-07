using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;


namespace EclipsePos.Apps.PosEvents
{
    public class ToggleDineInOut : PosEvent
    {

        public override void Engage(int keyValue)
        {
           
            switch ((int)PosContext.Instance.TransactionType)
            {
                case ((int)Transaction.Types.CARRY_OUT):
                    PosContext.Instance.TransactionType = (int)Transaction.Types.DINE_IN;
                    this.UpdateTransactionType(PosContext.Instance.TransactionType);
                    break;

                case ((int)(int)Transaction.Types.DINE_IN):
                    PosContext.Instance.TransactionType = (int)Transaction.Types.CARRY_OUT;
                    this.UpdateTransactionType(PosContext.Instance.TransactionType);
                    break;
            }

            
        }

        /** Class specific clear (key) implementation */
        public override void Clear()
        {
        }


        /*  ** Sublcasses implement event validation. */
        public override bool ValidTransition(string pEventName)
        {
            return true;
        }


        private void UpdateTransactionType(int type)
        {
            if (PosContext.Instance.CurrentEj == null) return;

            foreach (object obj in PosContext.Instance.CurrentEj.EjArrayList)
            {
                if (obj is EjHeader)
                {
                    EjHeader ejHeader = obj as EjHeader;
                    Transaction tran = (Transaction) ejHeader.DataRecord();
                    tran.Trans_type = type;
                    tran.UpdateStateAndType();
                    break;
                }
            }

        }




    }
}
