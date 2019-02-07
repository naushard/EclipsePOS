using System;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for UnLock.
	/// </summary>
	public class UnLock:PosNumberDialog
	{
		/** Prompt for PIN. */
		public const int ENTER_PASS = 0;
		/** Get the PIN from context input. */
		public const int GET_PASS = 1;
		/** Unlock the context */
		public const int UNLOCK = 2;

		private int trys = 0;
		private string pass;
		private int passno;
		private string promptText;
		private string messageText;
		private bool mask;
		private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;

		public UnLock()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{

			mask = false;
			switch (this.PeekState())
			{

				case ENTER_PASS:

					mask = true;
					PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("EnterPass");
					//type = PosNumberDialog.MASK;
					PosContext.Instance.Operprompt.Update(this);
					this.States().PushState(GET_PASS);
					break;

				case GET_PASS:

					this.PopState();
					pass = PosContext.Instance.InputLine;
					try
					{
						passno = int.Parse(pass);
					}
					catch (Exception e)
					{
						PosContext.Instance.Operprompt.Update (this);
						return;
					}

					if (this.CheckLogon())
					{
						this.PopState();
						PosEventStack.Instance.NextEvent();
					}
					else
					{
                        PosContext.Instance.DisableKeys();
						PosEventStack.Instance.ClearPending();
						PosEventStack.Instance.LoadDialog("UnLock");
						PosEventStack.Instance.NextEvent();
					}
					break;

				case UNLOCK:

					this.PopState();
					PosContext.Instance.EnableKeys();
					PosEventStack.Instance.NextEvent();
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

		private bool CheckLogon()
		{
			if (trys++ > 2)
			{
				trys = 0;
				return false;
			}
			Employee employee = new Employee();
			employee.Logon_no = PosContext.Instance.CurrentEmployee.Logon_no;
            employee.Organization_no = PosSettings.Default.Organization;
			employee.LoadByLogon();

            if (MD5HashHelper.verifyMd5Hash(passno.ToString(), employee.Logon_pass))
            {
                employee.Relations();
                PosContext.Instance.Employee = employee;
                return true;
            }
            else
            {
                
                return false;
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
}
