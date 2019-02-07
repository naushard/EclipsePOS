using System;
using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PosDialogEvent.
	/// </summary>
	public abstract class PosDialogEvent : PosEvent
	{
		private PosStateStack posStateStack;
        private int startState=0;
 
		public PosDialogEvent()
		{
			posStateStack = new PosStateStack();
		}

		public int PeekState()
		{
			return posStateStack.PeekState();
		}
		public PosStateStack States()
		{
			return this.posStateStack;
		}

		
		public int PopState()
		{
			return posStateStack.PopState();
		}
		
		public void PushState(int state)
		{
			posStateStack.PushState(state);
		}

		public override bool isDialog
		{
			get
			{
				return true;
			}

		}

        public int StartState
        {
            get
            {
                return startState;
            }
            set
            {
                startState = value;
            }
        }

		

	}
}
