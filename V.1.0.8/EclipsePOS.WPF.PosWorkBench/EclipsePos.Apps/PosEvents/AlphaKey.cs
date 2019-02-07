using System;
using System.Windows;
using System.Windows.Input;
using System.Text;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for AlphaKey.
	/// </summary>
	public class AlphaKey: PosEvent
	{
		private string inputText = null;

		public AlphaKey()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
           /*
            MessageBox.Show(((int)Key.Up).ToString());
            MessageBox.Show(((int)Key.Down).ToString());
            MessageBox.Show(((int)Key.Right).ToString());
            MessageBox.Show(((int)Key.Left).ToString());
            MessageBox.Show(((int)Key.E).ToString());
            MessageBox.Show(((int)Key.F).ToString());
            MessageBox.Show(((int)Key.G).ToString());
            MessageBox.Show(((int)Key.H).ToString());
            MessageBox.Show(((int)Key.I).ToString());
            MessageBox.Show(((int)Key.J).ToString());
            MessageBox.Show(((int)Key.K).ToString());
            MessageBox.Show(((int)Key.L).ToString());
            MessageBox.Show(((int)Key.M).ToString());
            MessageBox.Show(((int)Key.N).ToString());
            MessageBox.Show(((int)Key.O).ToString());
            MessageBox.Show(((int)Key.P).ToString());
            MessageBox.Show(((int)Key.Q).ToString());
            MessageBox.Show(((int)Key.R).ToString());
            MessageBox.Show(((int)Key.S).ToString());
            MessageBox.Show(((int)Key.T).ToString());
            MessageBox.Show(((int)Key.U).ToString());
            MessageBox.Show(((int)Key.V).ToString());
            MessageBox.Show(((int)Key.X).ToString());
            MessageBox.Show(((int)Key.Y).ToString());
            MessageBox.Show(((int)Key.Z).ToString());
            MessageBox.Show(((int)Key.Space).ToString());
             * */

            PosEvent posEvent = PosEventStack.Instance.CurrentEvent;

            Char ch = (char)keyValue;
           // MessageBox.Show(ch.ToString());


			Key inputKey = (Key)keyValue;
			if (inputKey == Key.Space)
			{
				PosContext.Instance.AddToInput(" ");
			}
			else
			{
                PosContext.Instance.AddToInput(inputKey.ToString()); //ch.ToString()); //inputKey.ToString());
			}
         
			//	PosContext.Instance.InputLine = PosContext.Instance.InputLine + inputKey.ToString();
			inputText = PosContext.Instance.InputLine;
			PosContext.Instance.Operprompt.Update(this);
			
		}


        public  void Update(char keyValue)
        {
            PosEvent posEvent = PosEventStack.Instance.CurrentEvent;

            if ( keyValue == '\r')
            {
                new EnterKey().Engage(0);
                return;
            }

            if (keyValue == ' ')
            {
                PosContext.Instance.AddToInput(" ");
                return;
            }

            if (keyValue == '\b')
            {
               new ClearPreviousKeyStroke().Engage(0);
                return;
            }
            
            
            PosContext.Instance.AddToInput(keyValue.ToString()); //inputKey.ToString());
            
           
            //	PosContext.Instance.InputLine = PosContext.Instance.InputLine + inputKey.ToString();
            //inputText = PosContext.Instance.InputLine;

            if (posEvent is PosNumberDialog)
            {
                PosNumberDialog numberDialog = posEvent as PosNumberDialog;
                //this.inputText = numberDialog.PromptText;
                inputText = PosContext.Instance.InputLine;

                switch (numberDialog.Type)
                {
                    case (PosNumberDialogTypes.Clear):
                        break;

                    case (PosNumberDialogTypes.Currency):
                        double currVal = PosContext.Instance.InputDouble() / 100.0;

                        string argToConvert = currVal.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                        // Convert the specified argument using the specified format.
                        try
                        {
                            inputText = string.Format(new PosTextFormatter(), "{0:Money}", argToConvert);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        break;
                    //

                    case (PosNumberDialogTypes.Decimal):
                        double val1 = PosContext.Instance.InputDouble() / 100.0;
                        inputText = val1.ToString("#########.##");
                        break;

                    case (PosNumberDialogTypes.Mask):
                        StringBuilder tmp = new StringBuilder();
                        tmp.Append('*', inputText.Length);
                        inputText = tmp.ToString();
                        break;

                }

            }
            else
                if (posEvent is EjLine)
                {
                    inputText = PosContext.Instance.InputLine;
                }
                else
                {
                    inputText = PosContext.Instance.InputLine;

                }
        
            PosContext.Instance.Operprompt.Update(this);

        }


		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

		public string InputText ()
		{
			return inputText;
		}
	}
}
