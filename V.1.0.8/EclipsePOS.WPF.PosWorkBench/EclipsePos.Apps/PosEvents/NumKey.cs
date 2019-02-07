using System.Windows;
using System.Text;
using System;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for NumKey.
	/// </summary>
	public class NumKey :PosEvent	
	{
		private static string eventname = "NumKey";
		private string numText = null;
		Encoding ascii;

		public NumKey()
		{
			ascii = Encoding.ASCII;

		}

		#region Properties
		public string NumText
		{
			get 
			{
				return numText;
			}
		}

		#endregion


	//	public NumKey(PosContext pContext)
	//	{
			//this.Context = pContext;
	//	}

	
		
		/*
		* If the input is >= 0, assume valid number is entered.
		* Else look at the current PosEvent and figure out what to do
		* Logon, get the prompt text from that event
		* EjCheckTender, get the prompt text from that event
		* etc.
		*/

		public override void  Engage (int keyValue)
		{
			//MessageBox.Show( keyValue.ToString() );
			if (keyValue >= 0 )
			{
				PosContext.Instance.AddToInput(keyValue);
			}

			PosEvent posEvent = PosEventStack.Instance.CurrentEvent;
			
			if (posEvent is PosError)
			{
				PosError  posError = posEvent as PosError;
				PosContext.Instance.Operprompt.Update(posError);
				return;
			}

			if(posEvent is PosNumberDialog)
			{
				PosNumberDialog numberDialog = posEvent as PosNumberDialog;
				this.PromptText = numberDialog.PromptText;
				numText = PosContext.Instance.InputLine;

				switch(numberDialog.Type)
				{
					case (PosNumberDialogTypes.Clear):
						break;

					case (PosNumberDialogTypes.Currency): 
						double currVal  = PosContext.Instance.InputDouble()/100.0;

						string argToConvert = currVal.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
						// Convert the specified argument using the specified format.
						try
						{  
							numText = string.Format(new PosTextFormatter( ), "{0:Money}", argToConvert );
						}
						catch( Exception ex )
						{
							MessageBox.Show(ex.ToString());
						}
						
						break;
						//

					case (PosNumberDialogTypes.Decimal):
						double val1  = PosContext.Instance.InputDouble()/100.0;
						numText = val1.ToString("#########.##");
						break;
					
					case (PosNumberDialogTypes.Mask):
						StringBuilder tmp = new StringBuilder();
						tmp.Append('*', numText.Length); 
						numText = tmp.ToString();
						break;
					
				}

			}
			else 
				if (posEvent is EjLine )
				{
					numText = PosContext.Instance.InputLine;
				}
				else
				{
					numText = PosContext.Instance.InputLine;

				}

			PosContext.Instance.Operprompt.Update(this);
		}



		/** Always return true. */

		public override bool ValidTransition (string pEvent)
		{
			return true;
		}

		/** Clear impementation for clear, do nothing. */
		public override void Clear ()
		{
		}
		
		
		/** Return staic name. */
		public string EventName 
		{
			get
			{
				return eventname;
			}
		}

		

	}
}
