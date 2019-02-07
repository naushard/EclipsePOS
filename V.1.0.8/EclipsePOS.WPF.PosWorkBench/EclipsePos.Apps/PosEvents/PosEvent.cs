 using System;

//using EclipsePos.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PosEvent.
	/// </summary>
	public abstract class PosEvent
	{

		private bool blocked = false;
		private bool dialog = false;
		private string promptText;

		public PosEvent()
		{
		}
			

		/** Event logic is implemented here */
		public abstract void Engage(int keyValue);

		 /** Class specific clear (key) implementation */
		public abstract void Clear();

		/*  ** Sublcasses implement event validation. */
		public abstract bool ValidTransition (string pEventName);

		/**
		* Sublcasses may override employee profile check.
		* This is used for common use events that don't need
		* to be checked, example, number keys. Override this
		* in profile sensitive classes.
		*/
		public bool CheckProfile ()
		{
			return false;
		}

		/**
		 * Validate that this is a valid event transition. Implemented as
		 * validTransition in subclass.
		 */
		public bool ValidEvent ()
		{
			return true; //(validTransition (context ().eventStack ().event ().toString ()));
		}

		/**
		* Validate that this user has the correct permission.
		*/
		public bool EmployeeHasProfile ()
		{
			

			/**
			* If no employee is logged on for this context return true.
			*/
		// 	if (PosContext.Concontext ().employee () == null)
			return true;

			/**
			* See if this profile needs to be checked
			*/
		//	if (!checkProfile ())
		//	return true;

			/**
			* Get the list of profile events from the employee profile
			* and see if this employee is allowed to do this function.
			*/
		//	Vector profiles = context ().employee ().posProfile ().events ();

		//	if (profiles.size () == 0)
		//	return true;  // super user

		//	for (int i=0;i<profiles.size ();i++)
		//	{
		//	PosProfileEvent prof = (PosProfileEvent) profiles.elementAt (i);
		//	if ( prof.posEvent ().equals (this.toString ()))
		//	return true;
		//	}

		//	context ().eventStack ().pushEvent (new PopEmployee (context));  // to remove the temp manager logon
		//	context ().eventStack ().pushEvent (this);                       // to execute the original event

		//	LogOn logonDialog = new LogOn (context);
		//	logonDialog.pushState (logonDialog.TEMPORARY_LOGON);              // creats a temp logon
		//	logonDialog.pushState (logonDialog.ENTER_PASS);                   // gets the pass
		//	logonDialog.pushState (logonDialog.ENTER_USER);                   // gets the user
		//	context ().eventStack ().pushEvent (logonDialog);                 // adds the logon dialog to the event stack

			// ouput error prompt to display

		//	context ().eventStack ().pushEvent (new PosError (context (),  PosError.MGR_REQUIRED));
		//	context ().operPrompt ().update ((PosError) context ().eventStack ().event ());

		//	return false;
		}

	/**
	 * Blocking mechanism, used to disable all key input
	 */

	
		public bool Blocked 
		{
			set 
			{
				blocked = value;
			}
			get
			{
				return blocked;
			}

		}


		public virtual bool isDialog
		{
			get 
			{
				return false;
			}
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
		
		
	
		public enum PosEventType
		{
			NumberKey=1,
			Item=2,
			ItemModifier=3,
			Navigate=4,
			Function=5,
			Previous=6,
			Next=7,
			Home=8,
			Hidden=9

		}
	
	}


}
