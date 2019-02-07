using System;
using System.Reflection;
//using System.Windows.Forms;
using System.Text;


using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Hardware;  
//using EclipsePos.Apps.Gui; 
using EclipsePos.Apps;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;



namespace EclipsePos.Apps.Devices
{
	
	/// <summary>
	/// C# Operator Prompt
	/// </summary>
	
	public class OperPrompt 
	{
		
		#region Variables
		private PosPrompt prompt;
		private PosDisplays posDisplay;
		private string promptClass;
		#endregion
		
		
		public OperPrompt()
		{
			prompt = PosContext.Instance.PosPrompt;
			posDisplay = PosContext.Instance.CurrentPosDisplay;
		}
		
		public void Clear()
		{
			prompt.InputText = "";
			prompt.PromptText = "";
            prompt.MessageText = "";

			posDisplay.MessageText = "";
		}

		

		/**
		 *
		 */
		public void Update (RegisterOpen pEvent)
		{
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
                prompt.MessageText = ""; 
				posDisplay.MessageText = ""; 
				prompt.InputText = "";
                prompt.EndErrorAnimation();
                prompt.EndInputAnimation();
			}
			if (PosHardware.Instance.LineDisplay != null)
			{
			//	PosHardware.Instance.LineDisplay.Clear();
			//	PosHardware.Instance.LineDisplay.SetText(PosContext.Instance.Parameters.getParam("CustWelcome")); // EclipsePosSettings.LineDisplayWelcomeText);
				
			}

		}



        public void Update(FinishTransaction pEvent)
        {
            
            if (PosHardware.Instance.LineDisplay != null)
            {
                PosHardware.Instance.LineDisplay.Clear();
                PosHardware.Instance.LineDisplay.SetText(PosContext.Instance.Parameters.getParam("CustWelcome")); // EclipsePosSettings.LineDisplayWelcomeText);

            }

        }



		public void Update(NumKey pEvent)
		{
			prompt = PosContext.Instance.PosPrompt;
			if (prompt != null)
			{

				prompt.InputText = pEvent.NumText; 
			}
		}



		public void Update(ClearKey pEvent)
		{
			prompt.InputText = "";
			posDisplay.MessageText = "";
            prompt.EndInputAnimation();
            prompt.EndErrorAnimation();
		}



		public void Update(EjItem ejItem)
		{
            int state = ejItem.States().PeekState();

            StringBuilder strDisplay = new StringBuilder(prompt.MessageWidth);
          //  for (int i = 0; i < prompt.MessageWidth; i++)
          //  {
          //      strDisplay.Append(" ");
          //  }
           
            
            switch (state)
            {
                
                case (int)EjItemStates.ENTER_QTY:
                  //  strDisplay.Append("Item : ");
                    strDisplay.Append(ejItem.Item.Short_Desc + "  ");
                    prompt.MessageText = strDisplay.ToString(); //ejItem.Item.Short_Desc +"   "+ " ? " + ejItem.Item.Shipping_uom + " ? $";
                    break;
                case (int)EjItemStates.ENTER_AMOUNT:
                    strDisplay.Append(ejItem.Item.Short_Desc + "    " );
                    strDisplay.Append(string.Format("{0:###########0.00}", ejItem.Quantity) + " " + ejItem.Item.Shipping_uom);
                    prompt.MessageText = strDisplay.ToString();  //ejItem.Item.Short_Desc + "   " + string.Format("{0:###########0.00}", ejItem.Quantity) +ejItem.Item.Shipping_uom + " X " + "    ?$";
                    break;
                case (int) EjItemStates.ITEM_FINAL:
                    prompt.MessageText = "";  //ejItem.Item.Short_Desc + "    " + ejItem.Quantity.ToString() + string.Format("{0:###########0.00}", ejItem.Amount);
                    prompt.EndInputAnimation();
                    break;
                defaut:
                    prompt.MessageText = "";
                    break;
            }

            
            if (state != (int)EjItemStates.ITEM_FINAL)
            {
                if (prompt != null)
                {
                    this.prompt.PromptText = ejItem.PromptText;
                   // this.posDisplay.MessageText = "";
                    prompt.InputText = "";
                    prompt.StartInputAnimation();
                }
                return;

            }



			prompt.PromptText = ejItem.PromptText;
			prompt.InputText = "";
		//	posDisplay.MessageText = ejItem.Quantity.ToString()+ " * " +
		//		ejItem.Desc +"    "+ string.Format( "{0:###########0.00}", ejItem.Amount);

			if (PosHardware.Instance.LineDisplay != null)
			{
               	PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(ejItem.Desc,0, 0);
				//Item price
				string itemPrice = string.Format("{0:#########0.00}", ejItem.Amount);
				int col = PosHardware.Instance.LineDisplay.PromptWidth() - itemPrice.Length-1;
				PosHardware.Instance.LineDisplay.SetText(itemPrice,1, col);
				//Total
				string total = string.Format("{0:<#########0.00>}", PosContext.Instance.CurrentEj.EjSubTotal());;
				PosHardware.Instance.LineDisplay.SetText(total,1, 0);
				
			}
			
				
		}

        public void Update(EjSurcharge ejSurcharge)
        {
            

            prompt.PromptText = ejSurcharge.PromptText;
            prompt.InputText = "";
            //posDisplay.MessageText = ejItem.Quantity.ToString() + " * " +
            //    ejItem.Desc + "    " + string.Format("{0:###########0.00}", ejItem.Amount);

            if (PosHardware.Instance.LineDisplay != null)
            {
                PosHardware.Instance.LineDisplay.Clear();
                PosHardware.Instance.LineDisplay.SetText(ejSurcharge.Desc, 0, 0);
                //Item price
                string itemPrice = string.Format("{0:#########0.00}", ejSurcharge.Amount);
                int col = PosHardware.Instance.LineDisplay.PromptWidth() - itemPrice.Length - 1;
                PosHardware.Instance.LineDisplay.SetText(itemPrice, 1, col);
                //Total
                string total = string.Format("{0:<#########0.00>}", PosContext.Instance.CurrentEj.EjSubTotal()); ;
                PosHardware.Instance.LineDisplay.SetText(total, 1, 0);

            }


        }


		public void Update (LogOn pEvent)
		{
			if (prompt != null)
			{
				this.prompt.PromptText = pEvent.PromptText;
				this.posDisplay.MessageText = "";
				prompt.InputText = "";
                prompt.StartInputAnimation();
			}
			
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText( PosContext.Instance.Parameters.getParam("CustWelcome"));
			}

		}


        public void Update(DiscountInput pEvent)
        {
            if (prompt != null)
            {
                this.prompt.PromptText = pEvent.PromptText;
                this.posDisplay.MessageText = "";
                prompt.InputText = "";
            }

                        

        }
        


		public void Update(EjTender pEvent)
		{
			string promptText;
			double amount;
			if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
			{
				promptText = pEvent.PromptText;
				amount = PosContext.Instance.CurrentEj.EjBalance();
			}
			else
			{
				promptText = pEvent.Desc;
				amount = pEvent.ExtAmount;
			}

			prompt.PromptText = promptText + string.Format( "{0:##########.00}", amount);
				

			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(promptText, 0, 0);
				PosHardware.Instance.LineDisplay.SetText(string.Format( "{0:#########.00}", amount),1,0);
					
			}
            prompt.StartInputAnimation();

            prompt.MessageText = "";
            prompt.InputText = "";
			PosContext.Instance.ClearInput();
			PosContext.Instance.InputLine = "";
           


		}



		public void Update(PosError pEvent)
		{
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
                prompt.EndInputAnimation();
                prompt.StartErrorAnimation();
			}

			if (PosHardware.Instance.LineDisplay  != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
			}
			

		}

		public void Update(CloseCashDrawer pEvent)
		{
			prompt.PromptText  = pEvent.PromptText;
            prompt.InputText = "";
            prompt.MessageText = "   *** Tender Complete ***  ";
            prompt.EndInputAnimation();
           
;		}


        public void Update(SelectTable pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
            }
        }


        public void Update(EjCustomer pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
            }

        }


        public void Update(EjReceiveOnAccount pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
            }

        }



		public void Update(AlphaKey pEvent)
		{
			prompt = PosContext.Instance.PosPrompt;
			if (prompt != null)
			{

				prompt.InputText = pEvent.InputText(); 
			}
			
		}

        public void Update(ClearPreviousKeyStroke pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.InputText = PosContext.Instance.InputLine;
            }

        }


        public void Update(MediaValue pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.InputText = pEvent.PromptText;
            }

        }

        public void Update(MediaText pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.InputText = pEvent.PromptText;
            }

        }

        public void Update(MergeOrder pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
            }

        }

        public void Update(OpenOrdersList pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
            }

        }


		public void Update(Quantity pEvent)
		{
			this.Clear();
			if (this.prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}
		
			posDisplay.MessageText = PosContext.Instance.Quantity.ToString()+  "*";
			
		}



		public void Update(Subtotal pEvent)
		{
			this.Clear();
			if (this.prompt != null)
			{
				prompt.PromptText = pEvent.PromptText +"\n"+ string.Format(new PosTextFormatter(), "{0:Money}", string.Format("{0:#########.00}", pEvent.Amount) );
    		}
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText, 0, 0);
				PosHardware.Instance.LineDisplay.SetText(string.Format( "{0:#########.00}", pEvent.Amount),1,0);
			}
			
			
		}



		public void Update(Total pEvent)
		{
			this.Clear();
			if (this.prompt != null)
			{
				prompt.PromptText = pEvent.PromptText +"\n" + string.Format(new PosTextFormatter(), "{0:Money}", string.Format("{0:#########.00}", pEvent.Amount));  
			}
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText, 0, 0);
				PosHardware.Instance.LineDisplay.SetText(string.Format( "{0:#########.00}", pEvent.Amount),1,0);
			}
			
		}


		public void Update(EjCCTender pEvent)
		{

			switch (pEvent.PeekState())
			{

				
              //  case EjCCTender.ENTER_CARD_NAME:

			  //		prompt.PromptText = pEvent.PromptText;
			  //		prompt.InputText = "";
              //      prompt.StartInputAnimation();
	
			  //		break;

				case EjCCTender.TENDER_FINAL:
					
					prompt.PromptText =pEvent.Desc + pEvent.ExtAmount ;
					if (PosHardware.Instance.LineDisplay != null)
					
																					{
						PosHardware.Instance.LineDisplay.SetText(pEvent.Desc, 0, 0);
					}
              //      prompt.EndInputAnimation();
					break;
				default:
					break;
			}

		}

		public void Update (EjChequeTender pEvent)
		{

			switch (pEvent.PeekState())
			{

				case EjChequeTender.ENTER_CASH_BACK_AMOUNT:
				case EjChequeTender.ENTER_CHECK_NO:

					prompt.PromptText = pEvent.PromptText;
					break;

				case EjChequeTender.TENDER_FINAL:

					string text=null;
					double amount=0.0;

					if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
					{
						text = pEvent.PromptText;
						amount = PosContext.Instance.CurrentEj.EjBalance();
					}
					else
					{
						text = pEvent.Desc;
						amount = pEvent.Amount;
					}

					prompt.PromptText = text + amount.ToString();
					
					if (PosHardware.Instance.LineDisplay != null)
					{
						PosHardware.Instance.LineDisplay.Clear();
						PosHardware.Instance.LineDisplay.SetText (text, 0, 0);
						PosHardware.Instance.LineDisplay.SetText(amount.ToString(), 1 ,0);
					}
					break;
				default:
					break;
			}

		}



        public void Update(EjDebitCardTender pEvent)
        {

            switch (pEvent.PeekState())
            {

                case EjDebitCardTender.ENTER_CASH_BACK_AMOUNT:
                case EjDebitCardTender.ENTER_APPROVAL_NO:

                    prompt.PromptText = pEvent.PromptText;
                    break;

                case EjDebitCardTender.TENDER_FINAL:

                    string text = null;
                    double amount = 0.0;

                    if (PosContext.Instance.CurrentEj.EjBalance() > 0.0)
                    {
                        text = pEvent.PromptText;
                        amount = PosContext.Instance.CurrentEj.EjBalance();
                    }
                    else
                    {
                        text = pEvent.Desc;
                        amount = pEvent.Amount;
                    }

                    prompt.PromptText = text + amount.ToString();

                    if (PosHardware.Instance.LineDisplay != null)
                    {
                        PosHardware.Instance.LineDisplay.Clear();
                        PosHardware.Instance.LineDisplay.SetText(text, 0, 0);
                        PosHardware.Instance.LineDisplay.SetText(amount.ToString(), 1, 0);
                    }
                    break;
                default:
                    break;
            }

        }



		public void Update (UnLock pEvent)
		{
			this.Clear();
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText, 0, 0);
			}
		}



		public void Update (RecallEj pEvent)
		{
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.Clear();

			}
			//PosContext.Instance.ReceiptHeader.TrxNo = string.Format("{0:0000000}",pEvent.TrxNo );
		}


		

		
		public void Update(PosNumberDialog pEvent)
		{
			this.Clear();
			if (this.prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}
			
			if (PosHardware.Instance.LineDisplay != null)
			{
				PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText);
			}
		}



		public void Update(EjBank pEvent)
		{
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}
		
			
			if (PosHardware.Instance.LineDisplay  != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
			}
		}

		
		
		public void Update(ReturnSale pEvent)
		{
			//PosContext.Instance.ReceiptHeader.TransactionType = PosContext.Instance.Parameters.getParam("ReturnSalePrompt");

			//if (prompt != null)
			//{
			//	prompt.PromptText = pEvent.PromptText;
			//}
					
			if (PosHardware.Instance.LineDisplay  != null)
			{
				PosHardware.Instance.LineDisplay.Clear();
				PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText);
			}

		}

        public void Update(ToggleDineInOut  pEvent)
        {
            
            //if (prompt != null)
            //{
            //    prompt.PromptText = pEvent.PromptText;
            //}

            if (PosHardware.Instance.LineDisplay != null)
            {
                PosHardware.Instance.LineDisplay.Clear();
                PosHardware.Instance.LineDisplay.SetText(pEvent.PromptText);
            }

        }

		public void Update(PromptPrintReceipt pEvent)
		{
			if (prompt != null)
			{
				prompt.PromptText = pEvent.PromptText;
			}

		}

        public void Update(EjFreeText pEvent)
        {

            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;

                if (pEvent.State == EjFreeText.GET_TEXT)
                {
                    this.prompt.InputText = "";
                }
            }

            

        }


        public void Update(EjSalesPerson pEvent)
        {

            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                prompt.StartInputAnimation();
            }

        }

        public void Update(RemoveSalesPerson pEvent)
        {

            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                prompt.StartInputAnimation();
            }

        }




        public void Update(ItemVoid pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                if (pEvent.States().PeekState() == ItemVoid.GET_LINE_NUMBER)
                {
                    prompt.InputText = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString();// PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    PosContext.Instance.InputLine = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString(); //PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    prompt.StartInputAnimation();
                }
            }

        }


        public void Update(EjPriceOverride pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                if (pEvent.States().PeekState() == EjPriceOverride.GET_LINE_NUMBER )
                {
                  //  prompt.InputText = PosContext.Instance.CurrentEjItem.LineNo.ToString();
                  //  PosContext.Instance.InputLine = PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    prompt.InputText = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString();// PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    PosContext.Instance.InputLine = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString(); //PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    
                    prompt.StartInputAnimation();
                }
            }

        }



        public void Update(ChangeQuantity pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                if (pEvent.States().PeekState() == ChangeQuantity.GET_LINE_NUMBER)
                {
                 //   prompt.InputText = PosContext.Instance.CurrentEjItem.LineNo.ToString();
                 //   PosContext.Instance.InputLine = PosContext.Instance.CurrentEjItem.LineNo.ToString();

                   //  prompt.InputText = PosContext.Instance.po.Receipt..CurrentPosDisplay..CurrentEjItem.LineNo.ToString();
                   //  PosContext.Instance.InputLine = PosContext.Instance.CurrentEjItem.LineNo.ToString();

                    prompt.InputText = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString();// PosContext.Instance.CurrentEjItem.LineNo.ToString();
                    PosContext.Instance.InputLine = PosContext.Instance.Receipt.OperDisplay.GetCurrentLineNo.ToString(); //PosContext.Instance.CurrentEjItem.LineNo.ToString();
                  
                    prompt.StartInputAnimation();
                }
            }

        }


        public void Update(EjPromotion pEvent)
        {
            prompt = PosContext.Instance.PosPrompt;
            if (prompt != null)
            {

                prompt.PromptText = pEvent.PromptText;
                posDisplay.MessageText = "";
                prompt.InputText = "";
                
            }

        }


        



		#region Update Menus
        /*
		public void Update(MenuAltCurrency pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuCommonTasks pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuDiscounts pEvent)
		{
			this.prompt.InputText = "";	
		}
		public void Update(MenuExit pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuItemLookupSelection pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuManager pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuPromotions pEvent)
		{
			this.prompt.InputText = "";
		}
		public void Update(MenuTender pEvent)
		{
			this.prompt.InputText = "";
		}
        */
		#endregion
	
	}
}





	
