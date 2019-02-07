using System;
using System.Collections;
using System.Data;
using System.Reflection;
//using System.Windows.Forms;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;

//using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for DialogEventProxy.
	/// </summary>
	public class DialogEventProxy
	{
		//private delegate void DialogEventHandler(object sender, EventArgs e);
		
		private static DialogEventProxy dialogEventProxy;
		public delegate void EventHandler(Object sender, EventArgs e);
		public event EventHandler NoDataEventHandler;


	
		public DialogEventProxy()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/*
		public static DialogEventProxy DialogEvent
		{
			get 
			{
				if (dialogEventProxy == null)
				{
					dialogEventProxy = new DialogEventProxy();
				}
				return dialogEventProxy;
			}

		}


		public void RunDialog()
		{
			Delegate [] DelegateList;
			DelegateList = NoDataEventHandler.GetInvocationList();
			MessageBox.Show(DelegateList.Length.ToString());
			foreach ( EventHandler e in NoDataEventHandler.GetInvocationList())
			{
				MessageBox.Show(e.Method.DeclaringType.FullName.ToString());
				PosEvent posEvent = (PosEvent) e.Target;
				if ( posEvent.isDialog)
				{
					PosDialogEvent posDialogEvent = (PosDialogEvent)posEvent;
					
					while ( posDialogEvent.States().PendingCount > 0)
					{
						e(null, new EventArgs());
						e.EndInvoke(null);
					}
				
				}
				else
				{
					e(null, new EventArgs());
				}
	
			}

			//foreach ( Delegate d1 in DelegateList)
			//{
			//	MessageBox.Show(DelegateList.Length.ToString());
			//}
			//
			//NoDataEventHandler(null, new EventArgs() );	
			//dialogEventHandler(null, new EventArgs());
			/*	Delegate[] delegateList = dialogEventHandler.GetInvocationList(); 
			foreach (Delegate d1 in delegateList)
			{
				DialogEventHandler dialog = (DialogEventHandler) d1;
				if (dialog is PosNumberDialog)
				{
					PosNumberDialog numberDialog = (PosNumberDialog)dialog;
					while (numberDialog.States().PendingCount > 0 )
					{
						numberDialog.PeekState();
						numberDialog.Engage( 
					}
				}
				else 
				{
					dialog(null, new EventArgs() );
				}
			}
		
		} 
	
		public void LoadDialog(string dialog_name)
		{
			
		//	CheckHardware ch = new CheckHardware();
		//	NoDataEventHandler = new EventHandler(ch.Engage);	
			
		//	PromptPrintReceipt pR = new PromptPrintReceipt();
		//	NoDataEventHandler += new EventHandler(pR.Engage);	
				
			Dialog dialog = new Dialog();
			dialog.DialogName = dialog_name;
			//Load table Dialog
			dialog.LoadDialogByDialogName();
			
			//if Dialog table was loaded successfully
			if ( dialog.DialogID != 0 )
			{
				
				Assembly assembly = Assembly.GetExecutingAssembly();
				
				//Load table DialogEvent
				DialogEvent dialogEvent = new DialogEvent();
				DataSet data = dialogEvent.LoadDialogEvents(dialog);
				DataTable dt = data.Tables[0];
				foreach (DataRow dr in dt.Rows )
				{
					
					string eventClass = dr["event_class"].ToString();
					int eventRequired = (int) dr["event_enabled"];
					try
					{
						if ( eventRequired == 1 )
						{
							PosEvent posEvent = assembly.CreateInstance(eventClass.Trim()) as PosEvent;
							// Push the event in current event stack
							//	this.PushEvent(posEvent);
						//	dialogEventHandler  += new System.EventHandler(posEvent.Engage);
							NoDataEventHandler += new EventHandler(posEvent.Engage);							
						}
					} 
					catch(System.NullReferenceException exNull) 
					{

						MessageBox.Show("Invalid class name "+eventClass);
						System.Diagnostics.Trace.WriteLine("_*_*_*_*_*_*_*_*_*_*_" +
							Environment.NewLine + "Project Load" +
							Environment.NewLine + exNull.ToString());

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}

				}
			}
			
		}*/
	}
}
