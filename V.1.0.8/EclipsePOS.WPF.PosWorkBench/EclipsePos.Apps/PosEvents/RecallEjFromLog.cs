using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.PosEvents
{
    public class RecallEjFromLog : PosDialogEvent
    {
        private int trxno;
        private int posno;

        private Transaction trans;
       
        private string promptText = null;
        public RecallEjFromLog()
		{
         	promptText = PosContext.Instance.Parameters.getParam("RegOpen");
		}


		public override void  Engage(int keyValue)
		{

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("Recall"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            try
            {
                if (PosContext.Instance.CurrentEj.SeqNo > 0)
                {
                    PosError posError = new PosError(PosErrorCode.RECALL_FAILLED);
                    posError.Engage(0);
                    return;
                }
            }
            catch(Exception ex)
            {
            }


			PosContext.Instance.ClearInput();
			trans  = new Transaction(this.trxno);
			trans.Pos_no = this.PosNo;
            trans.Organization_no = PosSettings.Default.Organization;
            trans.Store_no = PosContext.Instance.RetailStore.Retail_store_no;
			trans.Load();

			PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);

			if (PosContext.Instance.CurrentEj.EjArrayList.Count > 0)
		    {
                // finally make sure there are records
               	foreach(Object obj in PosContext.Instance.CurrentEj.EjArrayList)
				{
						EjLine line =(EjLine) obj;
						PosContext.Instance.Receipt.Update(line);
				}
								
				this.States().Clear();
			}
            
            PosContext.Instance.TrxNo = this.TrxNo; /* ES01-26/11/08 */
			this.PromptText = PosContext.Instance.Parameters.getParam("RegOpen");

                    
			//PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.Receipt.Update(this);

            if (trans.Customer_tax_id.Length > 0)
            {
                 EclipsePos.Data.Customer cus = new EclipsePos.Data.Customer();
                 cus.Organization_no = PosSettings.Default.Organization;
                 cus.Tax_id = trans.Customer_tax_id;
                 cus.LoadByTaxID();
                 EjCustomer ejCus = new EjCustomer(cus);
                 PosContext.Instance.Receipt.Update(ejCus);
                 PosContext.Instance.EjCustomer = ejCus;
                        
            }

            this.States().Clear();
            PosEventStack.Instance.ClearPending();

            //Clear transaction if complete
            if ( (trans.State == (int)Transaction.Status.COMPLETE) ||
               (trans.State == (int)Transaction.Status.VOIDED))
            {
                 PosEventStack.Instance.PushEvent(new FinishTransaction());
                       
            }
                   

		}



		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}
		

		public int TrxNo
		{
			get 
			{
				return this.trxno;
			}
			set
			{
				this.trxno = value;
			}

		}

		public int PosNo
		{
			get 
			{
				return this.posno;
			}
			set
			{
				this.posno = value;
			}

		}

    }
}
