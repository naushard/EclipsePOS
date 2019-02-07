using System;
//using System.Windows.Forms;
using EclipsePos.Apps.Context;



namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Lock.
	/// </summary>
	public class Lock :PosEvent
	{
		public Lock()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			//PosContext.GetInstance().Dispose();
			//Application.Exit();
			//throw new Exception("An unhandled exception occured");
			//AppService svc = new AppService();

			//svc.ProcessAndNotify();
			//svc.ProcessAndNotify();
			//PosContext.Instance.CurrentPosDisplay.LoadMenu(3);
			PosContext.Instance.DisableKeys();
			PosContext.Instance.Locked = true;
			PosEventStack.Instance.LoadDialog("UnLock");
			PosEventStack.Instance.NextEvent();
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
