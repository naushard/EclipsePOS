using System;
//using System.Windows.Forms;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Logon.
	/// </summary>
	public class LogOn :PosNumberDialog 
	{
		private int trys = 0;
		private Employee emp;
		private string user=null;
		private string pass=null;
		private int userno=0;
		private int passno=0;
		private int openamount=0;
		private int drawerno=0;
		private string promptText=null;
		private string messageText=null;
		private bool mask=false;
		private PosErrorCode errorCode;
		private PosNumberDialogTypes type = PosNumberDialogTypes.Mask;

		public LogOn()
		{
			//this.PushState(0);
		} 

		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Y ** Logon ***"+ this.PeekState().ToString() );
			LogonStates states = (LogonStates) this.PeekState();
			switch (states)
			{
				case LogonStates.EnterUser:
					
					PosContext.Instance.ClearInput();

                    PosContext.Instance.ClearInput();
                    PosContext.Instance.HomeGUI();
                   
					this.PromptText = PosContext.Instance.Parameters.getParam("EnterUser");
					//this.tytype = PosNumberDialog.CLEAR;
					PosContext.Instance.Operprompt.Update(this);
					this.States().PushState((int)LogonStates.GetUser);

					break;

				case LogonStates.EnterPassword:
					
					mask = true;
					PosContext.Instance.ClearInput();
					this.PromptText = PosContext.Instance.Parameters.getParam("EnterPass");
					//type = PosNumberDialog.MASK;
					PosContext.Instance.Operprompt.Update(this);
					this.States().PushState((int)LogonStates.GetPassword);
					break;
					
				case LogonStates.EnterOpenAmount:
					break;
				case LogonStates.EnterDrawerNumber:
					break;
				case LogonStates.GetUser:

					this.States().PopState();
					user = PosContext.Instance.InputLine;
					try
					{
						userno = int.Parse(user);
					}
					catch 
					{
						this.PromptText = PosContext.Instance.Parameters.getParam("BadName");
						PosContext.Instance.Operprompt.Update(this);
						return;
					}

					this.States().PushState((int)LogonStates.EnterPassword);
					PosContext.Instance.ClearInput();
					PosEventStack.Instance.NextEvent();
					break;


				case LogonStates.GetPassword:

					this.States().PopState();
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
                        try
                        {
                            PosContext.Instance.TransactionType = int.Parse(PosContext.Instance.Parameters.getParam("DefaultTransactionType"));
                        }
                        catch
                        {
                        }
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
					break;

				case LogonStates.GetAmount:
					break;
				case LogonStates.GetDrawerNumber:
					break;
				case LogonStates.CompleteLogon:
					break;
				case LogonStates.TemproryLogon:
					break;
				case LogonStates.Unlock:
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

		private bool CheckLogon()
		{
			if (trys++ > 2)
			{
				trys = 0;
				return false;
			}
			Employee employee = new Employee();
            employee.Organization_no = PosSettings.Default.Organization;
            employee.Logon_no = userno.ToString();
			employee.LoadByLogon();
			//if( employee.Logon_pass.Length == 0 )
			//{
			//	errorCode = PosErrorCode.BAD_USER;
			//	return false;
			//}

            if ( MD5HashHelper.verifyMd5Hash(passno.ToString(), employee.Logon_pass) )
			{
                employee.Relations();
				PosContext.Instance.Employee = employee;
				return true;
			}
			else
			{	
				errorCode = PosErrorCode.BAD_PASSWORD;
				return false;
			}
         
            
			
		
		}

		//Helper method used in Clear key imlementation
		public void ResetState()
		{	LogonStates states = (LogonStates) this.PeekState();
			switch (states)
			{
				case LogonStates.GetUser:
					this.States().PopState();
					this.States().PushState((int)LogonStates.EnterUser);
					break;

				case LogonStates.GetPassword:
					this.States().PopState();
					this.States().PushState((int)LogonStates.EnterPassword);
					break;

				case LogonStates.GetAmount:
					this.States().PopState();
					this.States().PushState((int)LogonStates.EnterOpenAmount);
					break;
				
				case LogonStates.GetDrawerNumber:
					this.States().PopState();
					this.States().PushState((int)LogonStates.EnterDrawerNumber);
					break;
			}
		}

		
	}

	public enum LogonStates
	{
		EnterUser=0,
		EnterPassword=1,
		EnterDrawerNumber=2,
		EnterOpenAmount=3,
		GetUser=4, 
		GetPassword=5,
		GetAmount=6,
		GetDrawerNumber=7,
		CompleteLogon=8,
		TemproryLogon=9,
		Unlock=10
	}

}
