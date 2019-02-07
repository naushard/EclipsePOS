//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: June, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================

using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Windows;

using EclipsePos.Apps.PosEvents;
using EclipsePos.Data;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for PosEventStack.
	/// </summary>
	public sealed class PosEventStack : PosStack	
	{
		#region Variables
		private static PosEventStack eventStack;
		#endregion


		static PosEventStack()
		{
			eventStack = new PosEventStack(); 
		}
		
		private PosEventStack()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Properties
		
		//Singleton implementation
		public static PosEventStack Instance
		{
			get
			{
				return eventStack;
			}
		}
		
		// Returns the current event object
		public PosEvent CurrentEvent
		{
			get
			{
				return (PosEvent) this.Peek();
			}
		}

		#endregion


		public void PosInit(string initialDialog)
		{
			
		}



		//----------------------------------------
		public PosEvent CurrentPosEvent ()
		{
			PosEvent event1 = (PosEvent) this.Peek();
			return event1;
		}

	/**
	 * Pop the pending, push it on the processed and return it.
	 */
	/**
	 * Remove the top of the pending stack and return it. Invoke
	 * the push operation to move it to the pending stack. If there
	 * is only one event on the stack leave it and just peek.
	 */
	public PosEvent PopEvent()
	{

		object o=null;

		if (this.PendingCount > 1)
		{
			o =  this.PopPending();
		}
		else
		{
			o = this.Peek();
		}
		return (PosEvent) o;
	}

	
	/**
	 * Add an object to the pending stack.
	 */
	public void PushEvent (PosEvent posEvent1)
	{
		this.PushPending(posEvent1);
	}

	/**
	 * Add an object to the processed stack.
	 */
	public void PushProcessed (Object o)
	{
		//this.PushProcessed(o);
	}

	/**
	 * Set the fist event in the pending stack
	 * to the object.
	 */
	public void SetEvent (PosEvent posEvent1)
	{

		this.Clear();
		this.PushPending(posEvent1);
	}

	/**
	 * Set the fist event in the pending stack
	 * to the object.
	 */
	//public void insertElementAt (PosEvent event, int pos)
	//{
	//pendingInsertElementAt (event, pos);
	//}


	
	
	

	/**
	 * Pops and executes the next event on the stack.
	 */
/*	public void NextEvent() 
	{
		//this.PopEvent();
		PosEvent posEvent = this.PopEvent();
		posEvent.Engage(this, new EventArgs());
	
	}
*/

	public void PopAllEvents()
	{
		while( this.PendingCount>=1 )
		{
			
			NextEvent();
		}
		
	}



		
	public void NextEvent ()
	{

		//this.Dump();

		PosEvent posEvent = null;
        PosEvent posEventCheck = this.CurrentEvent;

        		
		//Engage the pos error until Clear Key is pressed
		 if (this.CurrentEvent is PosError)
		{
			this.CurrentEvent.Engage(0);
			return;
		}

		try
		{
					
			// if this is a dialog pop it's state stack and invoke
			// the current event

			if (this.CurrentPosEvent().isDialog )
			{

				PosDialogEvent dialog = this.CurrentPosEvent() as PosDialogEvent;

				// if there are state events pop

				if (dialog.States().PendingCount > 0)
				{
					posEvent = this.CurrentPosEvent();
				}
				else
				{
					// if there are no state events in the dialog
					// pop the entire event, and engage the next one
					this.PopEvent();
					//posEvent = PopEvent ();
                    posEvent = this.CurrentPosEvent(); //this.Peek();
				}
			}
			else
			{
				posEvent = this.PopEvent();
			}

			posEvent.Engage(0);
		}
		catch (Exception e)
		{
			MessageBox.Show(e.ToString());
            Logger.Error(this.GetType().FullName, this.GetType().FullName +":"+e.ToString(), e);
		
		}
	}
		
	/**
	 * Finds a dialog set in PosConfig and loads it.
	 */

		
		public void LoadDialog (string dialog_name)
		{
			PosEvent posEvent = null;
			Dialog dialog = (Dialog)PosContext.Instance.Config.Dialogs[dialog_name];
			
			if ( dialog != null )
			{
				
				foreach(object obj in dialog.DialogEvents) 
				{
				
					DialogEvent dialogEvent = obj as DialogEvent;
					if ( dialogEvent.EventClass.Trim().Length != 0)
					{
						try 
						{
							posEvent = Assembly.GetExecutingAssembly().CreateInstance(dialogEvent.EventClass)as PosEvent; //eventClass.Trim()) as PosEvent;
							// Push the event in current event stack
							//this.PushEvent(posEvent);
							
							if (posEvent.isDialog)
							{
								int state =  dialogEvent.State; 
								((PosDialogEvent)posEvent).PushState(state);
							}

						}
						catch(System.NullReferenceException exNull)
						{
                            MessageBox.Show(exNull.ToString() + dialogEvent.EventClass);
							Logger.Error( "PosEventStack.cs", "PosEventStack.cs :" + "Invalid class name "+ dialogEvent.EventClass ); 
							return;
						}
						catch (Exception ex)
						{
                            MessageBox.Show(ex.ToString() + dialogEvent.EventClass);
							Logger.Error("PosEventStack.cs", "PosEventStack.cs :" + ex.ToString());
							return;
						}

						if (dialogEvent.EventRequired ==1 || dialogEvent.EventEnabled == 1 )
						{ 
							this.PushEvent(posEvent);
						}
					}
					else
					{
						//Use the event on top of stack
						posEvent = this.CurrentPosEvent();
						if (posEvent.isDialog && ( dialogEvent.EventRequired ==1 || dialogEvent.EventEnabled == 1) )
						{
							int state =  dialogEvent.State; 
							((PosDialogEvent)posEvent).PushState(state);
						}
					}
				}
			}
		}
	
	}
}
