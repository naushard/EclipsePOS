using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for CloseCashDrawer.
	/// </summary>
	public class CloseCashDrawer :PosDialogEvent	
	{
        public const int PROMPT_CLOSE_DRAWER = 0;
        public const int  CLOSE_DRAWER_FINAL = 1 ;

		public CloseCashDrawer()
		{
			//
			// TODO: Add constructor logic here
			//
            this.States().PushState(PROMPT_CLOSE_DRAWER);
		}


		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Prompt Close Drawer ***");
			//if (PosContext.Instance.CurrentEj.EjBalance() > 0) 
			//{
			//}
			//else
			//{
			//	this.PromptText = PosContext.Instance.Parameters.getParam("CloseDrawer");
			//	PosContext.Instance.Operprompt.Update(this);
			//}

            switch (this.PeekState() )
            {
                case PROMPT_CLOSE_DRAWER:
                    this.PopState();
                    this.States().PushState(CLOSE_DRAWER_FINAL);
                    this.PromptText = PosContext.Instance.Parameters.getParam("CloseDrawer");
                    PosContext.Instance.Operprompt.Update(this);
                    break;
                
                case CLOSE_DRAWER_FINAL:
                    this.States().Clear();
                    PosEventStack.Instance.NextEvent();
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
	}
}
