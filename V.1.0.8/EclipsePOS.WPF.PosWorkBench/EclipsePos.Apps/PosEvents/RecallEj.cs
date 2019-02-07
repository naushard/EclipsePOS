using System;
//using System.Windows.Forms;
using System.Data;

using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;



namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for RecallEj.
	/// </summary>
	public class RecallEj:PosDialogEvent
	{
		/** Start recall event */
		public const int RECALL = 0;
		/** Prompt for transaction number. */
		public const int ENTER_TRANS_NO = 1;
		/** Prompt for POS number. */
		public const int ENTER_POS_NO = 2;
		/** Get transaction number. */
		public const int GET_TRANS_NO = 3;
		/** Get POS number. */
		public const int GET_POS_NO = 4;
		/** Complete recall. */
		public const int COMPLETE_RECALL = 5;

		private int trxno;
		private Transaction trans;
		private int posno;
		private string promptText=null;
		//private string messageText=null;
		//private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;
	
		public RecallEj()
		{
            this.StartState = RECALL;
			//
			// TODO: Add constructor logic here
			//
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


			switch (this.States().PeekState())
			{

				case RECALL:

                    // Tried to recall in a middle of a dialog
                    if ( PosContext.Instance.CurrentEj != null && PosContext.Instance.CurrentEj.SeqNo > 0  )
                       
                    {

                        PosEventStack.Instance.PushEvent(new PosError(PosErrorCode.ERROR_EVENT));
                        PosEventStack.Instance.NextEvent();
                        return;
                    }


					PosEventStack.Instance.LoadDialog("RecallEj");
					this.PopState();
					this.PushState(RecallEj.ENTER_TRANS_NO);
					PosEventStack.Instance.NextEvent();
					break;

				case ENTER_TRANS_NO:

					PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("PromptTransNo");
					PosContext.Instance.Operprompt.Update(this);
					this.PopState();
					this.PushState(GET_TRANS_NO);

					break;

				case ENTER_POS_NO:

					PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("PromptPosNo");
					PosContext.Instance.Operprompt.Update(this);
					this.PopState();
					this.PushState(GET_POS_NO);

					break;

				case GET_TRANS_NO:

					this.trxno = PosContext.Instance.Input();
					PosContext.Instance.ClearInput();
					PosContext.Instance.Operprompt.Clear();
					this.PopState();
					PosEventStack.Instance.NextEvent();

					break;

				case GET_POS_NO:

					this.PosNo = PosContext.Instance.Input();
					PosContext.Instance.ClearInput();
					this.PopState();
					PosContext.Instance.Operprompt.Clear();
					PosEventStack.Instance.NextEvent();

					break;

				case COMPLETE_RECALL:

					PosContext.Instance.ClearInput();
					trans  = new Transaction(this.trxno);
					trans.Pos_no = this.PosNo;
                    trans.Organization_no = PosSettings.Default.Organization;
                    trans.Store_no = PosContext.Instance.RetailStore.Retail_store_no;
					trans.Load();
				//	if (trans.State == (int)Transaction.Status.SUSPEND)
				//	{  // was this a suspended transaction?

							PosContext.Instance.CurrentEj = Ej.GetSuspendedEj(trans);

							if (PosContext.Instance.CurrentEj.EjArrayList.Count > 0)
							{  // finally make sure there are records
                                if (trans.State == (int)Transaction.Status.SUSPEND)
                                {
                                    trans.State = (int)Transaction.Status.IN_PROGRESS;
                                }
								foreach(Object obj in PosContext.Instance.CurrentEj.EjArrayList)
								{
									EjLine line =(EjLine) obj;
									PosContext.Instance.Receipt.Update(line);
								}
								
								this.States().Clear();
							}
				    // }
                    PosContext.Instance.TrxNo = this.TrxNo; /* ES01-26/11/08 */
					this.PromptText = PosContext.Instance.Parameters.getParam("RegOpen");

                    
					PosContext.Instance.Operprompt.Update(this);
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
                    if (trans.State == (int)Transaction.Status.COMPLETE)
                    {
                       PosEventStack.Instance.PushEvent(new FinishTransaction());
                       
                    }
                   

					break;
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
				return trans.Trans_no;
			}
			set
			{
				this.trans.Trans_no = value;
			}

		}

		public int PosNo
		{
			get 
			{
				return posno;
			}
			set
			{
				posno = value;
			}

		}

		

	}
}
