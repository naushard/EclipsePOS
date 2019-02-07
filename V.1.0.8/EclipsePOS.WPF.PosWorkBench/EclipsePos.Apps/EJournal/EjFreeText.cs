using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Hardware;


namespace EclipsePos.Apps.EJournal
{
    public class EjFreeText : EjLine	
    {
        /** Enter text */
        public const int PROMPT_ENTER_TEXT = 1;
        /** Get text */
        public const int GET_TEXT = 2;

        private int state;
      

        private TransText transText;
        private int transType;  
        
        private string promptText;
        private double sign;


        public EjFreeText()
        {
            this.LineType = (int)EjLineType.FREE_TEXT;
            this.States().PushState(1);
        }

        public EjFreeText(TransText pTransText)
        {
            this.transText = pTransText;
            this.LineType = (int)EjLineType.FREE_TEXT;
        }


        #region Properties

        public override bool TenderComplete
        {
            get
            {
                return true;
            }

        }

        public override string Desc
        {
            get
            {
                return transText.Extended_text;
            }
            set
            {
                transText.Extended_text = value;
            }
        }

        public override double Amount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double ExtAmount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override int LineNo
        {
            get
            {
                return this.transText.Line_no;
            }
            set
            {
            }
        }


        public override string PromptText
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

        public override string SKU
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public override double Quantity
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override double TaxAmount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }


        public override double Change
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public override int State
        {
            set
            {

                
            }
            get
            {
                return this.States().PeekState();
            }
        }


        public override int SeqNo
        {
            set
            {
                this.transText.Seq_no = value;  
            }
            get
            {
                return this.transText.Seq_no;
            }
        }

        #endregion


        public override void UpdateTotals()
        {
            
        }


        public override bool Save()
        {
            if (!PosContext.Instance.Training)
            {
                try
                {
                    transText.Add();
                }
                catch (Exception e)
                {
                    
                }
            }
            return true;
        }


        public override void SaveState(EjLineStates state)
        {
        }


        public override void Engage(int keyValue)
        {

            switch (this.States().PeekState())
            {

                case PROMPT_ENTER_TEXT:

                    this.PromptText = PosContext.Instance.Parameters.getParam("PromptExtendedText");
                    
                    PosContext.Instance.Operprompt.Update(this);
                    
                    //this.transType = (int)TotalType..PAID_IN;
                    PosContext.Instance.ClearInput();
                    this.States().PopState();

                    this.States().PushState(GET_TEXT);
                    
                   
                    break;

               

                case GET_TEXT: 

                    this.PopState();

                    string inputText  = PosContext.Instance.InputLine;
                    if (string.IsNullOrEmpty(inputText.Trim() ))
                    {
                        this.States().Clear();
                        PosContext.Instance.ClearInput();
                        PosEventStack.Instance.NextEvent();
                        return;

                    }
                   

                    transText = new TransText();

                    transText.Organization_no = PosSettings.Default.Organization;
                    transText.Pos_no = PosSettings.Default.Station;
                    transText.Store_no = PosSettings.Default.Store;
                    transText.Extended_text = inputText;
                    transText.Text_line_no = PosContext.Instance.CurrentEj.LineNo; //PosContext.Instance.CurrentEjItem.Text_line_no;
                    transText.Trans_no = PosContext.Instance.TrxNo;
                    transText.Line_no = PosContext.Instance.CurrentEj.LineNo;

                    PosContext.Instance.CurrentEj.EjAdd(this);

                    transText.Seq_no = PosContext.Instance.CurrentEj.SeqNo;

                    transText.Add();


                     
                    PosContext.Instance.Receipt.Update(this);

                    PosContext.Instance.ClearInput();
                    this.States().PushState(GET_TEXT);
                    PosContext.Instance.Operprompt.Update(this);
                    //PosContext.Instance.HomeGUI();
                   
                   // PosEventStack.Instance.NextEvent();

                    break;

                default:
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

        public override IRelatable DataRecord()
        {
            return transText;
        }


        public override void PrintEj()
        {
            PosHardware.Instance.PosPrinter.Println(this.transText.Extended_text);
        }

               
    }
}
