using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PromptPrintReceipt.
	/// </summary>
	public class PromptPrintReceipt : PosDialogEvent	
	{
		private string promptText = null;
		private bool print = false;
        private string param = "FALSE";

        public const int CHECK_PROMPT_PRINT = 0;
        public const int WAIT_FOR_PRINT =1;
        public const int PRINT_FINAL = 2;
       
       


		public PromptPrintReceipt()
		{

            this.PromptText = PosContext.Instance.Parameters.getParam("PressPrintKey");
             this.PrintReceipt = true;
		}

        public override void Engage(int keyValue)
        {

            if (PosContext.Instance.CurrentEj.EjBalance() > 0.00)
            {

                PosContext.Instance.ClearInput();
                PosEventStack.Instance.ClearPending();
                PosError error = new PosError(PosErrorCode.INSUFFICIENT_TENDER_AMOUNT);
               // this.PromptText = PosContext.Instance.Parameters.getParam("InsufficientTenderAmount");
                PosEventStack.Instance.PushEvent(error);
                PosContext.Instance.Operprompt.Update(this);
                PosEventStack.Instance.NextEvent();
                return;
            }


            switch (this.PeekState())
            {
                
                case CHECK_PROMPT_PRINT:

                    try
                    {
                        this.param = PosContext.Instance.Parameters.getParam("PromptForReceiptPrint");

                    }
                    catch
                    {
                    }


                   
                    //Wait for the Enter key after after input amount 
                    this.PopState();
                    if (this.param == "TRUE")
                    {
                        this.PushState(WAIT_FOR_PRINT);
                        PosContext.Instance.ClearInput();
                        this.PromptText = PosContext.Instance.Parameters.getParam("PressPrintKey");
                        PosContext.Instance.Operprompt.Update(this);
                    }
                    else
                    {
                        this.PushState(PRINT_FINAL);
                        PosEventStack.Instance.NextEvent();
                        return;
                    }

                    

                     break;

                case WAIT_FOR_PRINT:

                    // Wait for Print Key to be presseed 
                    this.PopState();
                    PosContext.Instance.ClearInput();
				    PosEventStack.Instance.NextEvent();
                    // 
                    break;


                case PRINT_FINAL:

                    this.PopState();
                    //Print Receipt;
                    
                    PosContext.Instance.Receipt.PrintBuffer();
          		    PosContext.Instance.ClearInput();
				    PosEventStack.Instance.NextEvent();

                    break;

            }

        }
		


	//	public override void  Engage(int keyValue)
	//	{
		//	MessageBox.Show("*** Prompt Print Receipt ***");
			
		/*	if (PosContext.Instance.CurrentEj.EjBalance() > 0.00 )
			{
				//MessageBox.Show("*** Clear pending ***");
				PosContext.Instance.ClearInput();
				PosEventStack.Instance.ClearPending();
				PosEventStack.Instance.NextEvent();
				return;
			}
         */

		//	if (!PosSettings.Default.PrintReceiptImmediate)
		//	{
		//		print = true;
		//	}

		//	if (print)
		//	{
		//		PosContext.Instance.Receipt.PrintBuffer();
        //  		PosContext.Instance.ClearInput();
		//		PosEventStack.Instance.NextEvent();
		//		return;
		//	}

		//	print = true;
		//	promptText = PosContext.Instance.Parameters.getParam("PromptPrintReceipt");
		//	PosEventStack.Instance.PushEvent(this);  // push back on stack as prompt
		//	PosContext.Instance.Operprompt.Update(this);
	
			//CashDrawer cashDrawer = PosHardware.cashDrawer () [context ().drawerNo () - 1];
			//cashDrawer.openDrawer ();

		    //PosEventStack.Instance.NextEvent();
			
	//	}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

		public string PromptText
		{
			get
			{
				return promptText;
			}
			set
			{
				promptText = value;
			}
		}

        public bool PrintReceipt
        {
            get; set;
        }
	}
}
