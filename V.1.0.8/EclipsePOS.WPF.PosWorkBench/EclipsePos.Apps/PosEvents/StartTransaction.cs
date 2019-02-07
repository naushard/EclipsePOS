using System;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;

using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for StartTransaction.
	/// </summary>
	public class StartTransaction :PosEvent 
	{
		private Transaction trans;

		public StartTransaction()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
		
            PosContext.Instance.CurrentEjItem = null;
            PosContext.Instance.EjCustomer = null;

            //PrintJobQueue.Instance.Clear();

            PosContext.Instance.CurrentEj = new Ej();
            PosContext.Instance.Receipt.Update(this);
            EjHeader ejHeader = new EjHeader();
            ejHeader.Engage(0);
            PosContext.Instance.CurrentEj.EjAdd(ejHeader);
            PosEventStack.Instance.NextEvent();
		
		
		}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}

		#region Properties
		public int TrxNo
		{
			set
			{
				trans.Trans_no = value;
			}
			get
			{
				return trans.Trans_no;
			}
		}
		#endregion
	}
}
