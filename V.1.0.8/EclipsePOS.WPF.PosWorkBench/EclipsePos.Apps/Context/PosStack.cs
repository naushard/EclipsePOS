using System;
using System.Collections;
using System.Windows;

using EclipsePos.Apps.PosEvents;

namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for PosStack.
	/// </summary>
	public class PosStack
	{
		private Stack pending;
		private Stack processed;

		public PosStack()
		{
			pending = new Stack();
			processed = new Stack();
		}

		#region Properties
		// peindig event size
		public int PendingCount
		{
			get 
			{
				return pending.Count;
			}
		}

		//processed event size
		public int ProcessedCount
		{
			get 
			{
				return processed.Count;
			}
		}
		#endregion


		//Clear the pending and push and event
		public void Set(object o)
		{
			pending.Clear();
			pending.Push(o);
		}

		//Get the top event without removing it
		public object Peek()
		{
			return pending.Peek();
		}

		
		//Clear both stacks
		public void Clear()
		{
            try
            {
                pending.Clear();
                processed.Clear();
            }
            catch
            {
            }
		}

		// Pop the pending, puch it on the proceseed
		public object PopPending()
		{
			 
			if (pending.Count == 0)
			{
				return null;
			}
			else
			{
				object o = pending.Pop();
				return o;
			}
 
		}

		//
		public void PushPending(object o)
		{
			pending.Push(o);		
		}

		/**
		 * Restore all of the processed to the pending.
		 */
		protected void Restore ()
		{

			while (processed.Count > 0)
			{
				object o = processed.Pop();
				pending.Push (o);
			}
		}

		/**
		 * Clear the pending stack.
		 */
		public void ClearPending ()
		{
			while (pending.Count > 1)
			{
				object o = pending.Pop();
			}
			//pending.Clear();
		}

		/**
		 * Clear the processed stack.
		 */
		public void ClearProcessed ()
		{
			while (processed.Count > 1)
			{
				object o = processed.Pop ();
			}
		}

		public void Dump()
		{
			foreach(Object obj in pending)
			{
				PosEvent posEvent = (PosEvent)obj;
				MessageBox.Show("pending " +posEvent.ToString() );
			}

            foreach (Object obj1 in processed)
            {
                PosEvent posEvent1 = (PosEvent)obj1;
                MessageBox.Show("processed: " + posEvent1.ToString());
            }

		}



	}
}
