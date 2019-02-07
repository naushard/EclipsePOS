using System;
using System.Collections;
using System.Data;
using System.Reflection;
//using System.Windows.Forms;

using EclipsePos.Apps.PosEvents;

 
using EclipsePos.Data;

namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for PosStateStack.
	/// </summary>
	public class PosStateStack : PosStack	 
	{
		public PosStateStack()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/**
		* Return the current event type.
		*/
		public int PeekState ()
		{

			int state = 0;

			if (this.PendingCount > 0)
			{
				state = (int) this.Peek();
			}

			return state;
		}

		// Pop State
		public int PopState ()
		{
			int state = 0;
			if (this.PendingCount > 0)
			{
				 state = (int) this.PopPending();
				
			}
			return state;
		} 

		/**
		 * Add an object to the pending stack.
		 */
		public void PushState (int state)
		{
			this.PushPending(state);
		}

		/**
		 * Add an object to the processed stack.
		 */
		public void PushProcessed (Object state)
		{
			this.PushProcessed(state);
		}
	
		/**
		 * Set the fist event in the pending stack
		 * to the object.
		 */
		public void SetState (int state)
		{

			this.Clear();
			this.PushPending(state);
		}
	
		/**
		* Removes all events from the proccesed and puts them back
		* on the pending stack.
		*/
		/*
		public void restore ()
		{
			super.restore ();
		}
		*/
		/**
		* Removes all events from the pending stack.
		*/
		/*
		public void clearPending ()
		{
		while (super.pendingSize () > 0) super.popPending ();
		}
		*/
		/**
		* Removes all events from the processed stack.
		*/
		/*	public void clearProcessed ()
		{
			super.clearProcessed ();
		} */

	} 
}
