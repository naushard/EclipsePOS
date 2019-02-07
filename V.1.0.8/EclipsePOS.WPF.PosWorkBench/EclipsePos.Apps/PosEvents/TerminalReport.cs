using System;
//using System.Windows.Forms;

using EclipsePos.Data;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for TerminalReport.
	/// </summary>
	public class TerminalReport : PosDialogEvent	
	{
		private XZReportType reportType;
		private PosTotal posTotal;


		public TerminalReport()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Properties
		public XZReportType ReportType
		{
			set
			{
				reportType = value;
			}
			get
			{
				return reportType;
			}
		}


		public PosTotal PosTotal
		{
			get
			{
				return posTotal;
			}
		}


		#endregion
	
		/**
		* Switch on the report type and update displays.
		*/
		public override void  Engage(int keyValue)
		{
            keyValue = (int) PosContext.Instance.PosKeyValue;
			//MessageBox.Show("*** TerminalReport ***"+keyValue.ToString());

            //Check if employee role is authorized to this event
            if (!PosContext.Instance.Employee.RolesEventNames.Contains("TerminalReports"))
            {
                PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
                posError.Engage(0);
                return;
            }

            //Check if employee role is authorized to this event
            if ( (PosContext.Instance.CurrentEj != null)  && (PosContext.Instance.CurrentEj.SeqNo > 0) )
            {
                PosError posError = new PosError(PosErrorCode.ERROR_EVENT);
                posError.Engage(0);
                return;
            }


			if (keyValue == 0)
			{
				reportType = (XZReportType) this.States().PeekState();
			}
			else
			{
				reportType = (XZReportType) keyValue;
			}

			posTotal = new PosTotal();
            posTotal.Organization_no = PosSettings.Default.Organization;
            posTotal.Store_no = PosContext.Instance.RetailStore.Retail_store_no;
			posTotal.Pos_no = PosSettings.Default.Station;
            switch (reportType) 
			{
                case XZReportType.Z_DAILY:
                case XZReportType.X_DAILY:
                    posTotal.Total_name = (int) TotalName.DAILY_BASE;
                    break;	

				case XZReportType.Z_WEEKLY:
                case XZReportType.X_WEEKLY:
                    posTotal.Total_name = (int)TotalName.WEEKLY_BASE;
                    break;						
												
				case XZReportType.Z_MONTHLY:
                case XZReportType.X_MONTHLY:
                   posTotal.Total_name = (int)TotalName.MONTHLY_BASE;
                    break;
                
                case XZReportType.Z_YEARLY:
                case XZReportType.X_YEARLY:
                    posTotal.Total_name = (int)TotalName.MONTHLY_BASE;
                    break;
			}
            posTotal.Load();
			posTotal.Relations();



			
			if ( (reportType == XZReportType.Z_WEEKLY || (reportType == XZReportType.Z_MONTHLY) ))
			{
				// roll-up totals that migth be left over.
				switch (reportType) 
				{
                    case XZReportType.Z_DAILY:
                        UpdateTotals(posTotal, TotalType.DAILY_BASE, TotalName.DAILY_BASE);
                        break;	

					case XZReportType.Z_WEEKLY:
                        UpdateTotals(posTotal, TotalType.WEEKLY_BASE, TotalName.WEEKLY_BASE);
						break;						
												
					case XZReportType.Z_MONTHLY:
                        UpdateTotals(posTotal, TotalType.MONTHLY_BASE, TotalName.MONTHLY_BASE);
						break;

				}

				// re-read the totals
				posTotal = new PosTotal();
                posTotal.Organization_no = PosSettings.Default.Organization;
                posTotal.Store_no = PosContext.Instance.RetailStore.Retail_store_no;
				posTotal.Pos_no = PosSettings.Default.Station;
				posTotal.Load();
				posTotal.Relations();
			}

			// see if there is any total information.

			if (posTotal.Totals.Count > 0)
			{
				PosContext.Instance.Receipt.Update(this);
			//	PosError posError = new PosError(PosErrorCode.TERMINAL_REPORT);
			//	posError.Engage(0);
			}
			else
			{
				return;
			}
			 

			switch (reportType) 
			{

				case XZReportType.Z_DAILY:
					UpdateTotals(posTotal, TotalType.WEEKLY_BASE, TotalName.DAILY_BASE);
					break;						
												
				case XZReportType.Z_WEEKLY:					
					UpdateTotals(posTotal, TotalType.MONTHLY_BASE, TotalName.WEEKLY_BASE);
					break;						
												
				case XZReportType.Z_MONTHLY:					
					UpdateTotals(posTotal, TotalType.YEARLY_BASE, TotalName.MONTHLY_BASE);
					break;

			}

			// pause...

			//PosContext ().eventStack ().pushEvent (new Pause (context ()));
			//PosContext.Instance.Operprompt.Update((Pause) context ().eventStack ().event ());
            PosContext.Instance.InputLine = "";
            PosContext.Instance.PosKeyValue = 0;
           
		}

		private void UpdateTotals (PosTotal posTotal, TotalType end, TotalName totalName)
		{
			foreach ( object obj in posTotal.Totals )
			{
				EclipsePos.Data.Total total = obj as EclipsePos.Data.Total;
				if ((int)total.Total_type < (int)end )
				{
					
					total.AddToTotalAndCount(
                         PosSettings.Default.Organization,
                        PosContext.Instance.RetailStore.Retail_store_no,
						PosSettings.Default.Station,
                        (TotalName)((int)posTotal.Total_name+1),
						(TotalType)total.Total_type,
						total.Total_amount,
						total.Total_count);

					//total.Delete();

				} 
			}




            posTotal.UpdateEndDate(PosSettings.Default.Organization,
                                    PosSettings.Default.Store,
                                    PosSettings.Default.Station,
                                    (int)totalName);
		}



		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}
	}

	public enum XZReportType
	{
		X_DAILY = 1,
		Z_DAILY = 2,
		X_WEEKLY = 3,
		Z_WEEKLY = 4,
		X_MONTHLY = 5,
		Z_MONTHLY = 6,
        X_YEARLY = 7,
        Z_YEARLY = 8
	}
}
