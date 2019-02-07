using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
//using System.Windows.Forms;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;

namespace EclipsePos.Apps.PosEvents
{
    class InputStartUpParameters : PosNumberDialog 
    {

        private int trys = 0;
        private Employee emp;
        private string user = null;
        private string pass = null;
        private int userno = 0;
        private int passno = 0;
        private int openamount = 0;
        private int drawerno = 0;
        private string promptText = null;
        private string messageText = null;
        private bool mask = false;
        private PosErrorCode errorCode;
        private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;

        public override void Engage(int keyValue)
        {
            //MessageBox.Show("*** Y ** Logon ***"+ this.PeekState().ToString() );
            StartUpParameters states = (StartUpParameters)this.PeekState();
            switch (states)
            {
                case StartUpParameters.EnterOrganization:

                    PosContext.Instance.ClearInput();
                    this.PromptText = "Organization no";
                    PosContext.Instance.Operprompt.Update(this);
                    this.States().PushState((int)StartUpParameters.GetOrganization);

                    break;

                case StartUpParameters.EnterStore:

                    PosContext.Instance.ClearInput();
                    this.PromptText = "Store no";
                    PosContext.Instance.Operprompt.Update(this);
                    this.States().PushState((int)StartUpParameters.GetStore);
                    break;

                case StartUpParameters.EnterStation:
                    PosContext.Instance.ClearInput();
                    this.PromptText = "Station no";
                    PosContext.Instance.Operprompt.Update(this);
                    this.States().PushState((int)StartUpParameters.GetStation);
                    break;

                case StartUpParameters.EnterConfigNo:
                    PosContext.Instance.ClearInput();
                    this.PromptText = "Config no";
                    PosContext.Instance.Operprompt.Update(this);
                    this.States().PushState((int)StartUpParameters.GetConfigNumber);
                    break;

                case StartUpParameters.GetOrganization:

                    /*this.States().PopState();
                    pass = PosContext.Instance.InputLine;
                    try
                    {
                        passno = int.Parse(pass);
                    }
                    catch
                    {
                        PosContext.Instance.Operprompt.Update(this);
                        return;
                    }

                    if (this.CheckLogon())
                    {

                        this.States().Clear();
                        PosContext.Instance.Receipt.Update(this);
                        PosContext.Instance.ClearInput();
                    }
                    else
                    {
                        //this.PromptText = PosContext.Instance.Parameters.getParam("BadName");
                        //PosContext.Instance.Operprompt.Update(this);
                        PosError posError = new PosError(errorCode);
                        PosEventStack.Instance.PushEvent(posError);
                    }

                    PosEventStack.Instance.NextEvent();
                     */
                    break;

                case StartUpParameters.GetStore:
                    break;
                case StartUpParameters.GetStation:
                    break;
                case StartUpParameters.GetPosNumber:
                    break;
                
                //default:

            }
        }


        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
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

        public override string MessageText
        {
            get
            {
                return messageText;
            }
            set
            {
                messageText = value;
            }

        }

        public override PosNumberDialogTypes Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }

    }

    public enum StartUpParameters
    {
        EnterOrganization = 0,
        EnterStore = 1,
        EnterStation = 2,
        EnterConfigNo = 3,
        GetOrganization = 4,
        GetStore = 5,
        GetStation = 6,
        GetPosNumber = 7,
        GetConfigNumber = 8
    }
}
