using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text;
using System.Data;
using Microsoft.PointOfService;

using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.Devices
{
     
    public class TerminalPrintJob : PrintWorker
    {
        private TerminalReport tReport;

        public TerminalPrintJob(TerminalReport report)
        {
            this.tReport = report;

        }

        public void Worker()
        {

            int nlines = 0;
           
            int start = 0;
            int end = 0;
            string header = null;

            switch (tReport.ReportType)
            {
                case XZReportType.X_DAILY:
                    header = PosContext.Instance.Parameters.getParam("DailyXHeader");
                    start = (int)TotalType.DAILY_BASE;
                    end = (int)TotalType.WEEKLY_BASE;
                    break;
                case XZReportType.Z_DAILY:
                    header = PosContext.Instance.Parameters.getParam("DailyZHeader");
                    start = (int)TotalType.DAILY_BASE;
                    end = (int)TotalType.WEEKLY_BASE;
                    break;
                case XZReportType.X_WEEKLY:
                    header = PosContext.Instance.Parameters.getParam("WeeklyXHeader");
                    start = (int)TotalType.WEEKLY_BASE;
                    end = (int)TotalType.MONTHLY_BASE;
                    break;
                case XZReportType.Z_WEEKLY:
                    header = PosContext.Instance.Parameters.getParam("WeeklyZHeader");
                    start = (int)TotalType.WEEKLY_BASE;
                    end = (int)TotalType.MONTHLY_BASE;
                    break;
                case XZReportType.X_MONTHLY:
                    header = PosContext.Instance.Parameters.getParam("MonthlyXHeader");
                    start = (int)TotalType.MONTHLY_BASE;
                    end = (int)TotalType.YEARLY_BASE;
                    break;
                case XZReportType.Z_MONTHLY:
                    header = PosContext.Instance.Parameters.getParam("MonthlyZHeader");
                    start = (int)TotalType.MONTHLY_BASE;
                    end = (int)TotalType.YEARLY_BASE;
                    break;
                default:
                    header = "";
                    break;
            }

            PosHardware.Instance.PosPrinter.Println("\x1B|cA" + header);
            PosHardware.Instance.PosPrinter.FeedLines(1);
           

            // Print sequence number and start date and time
            this.PrintReceipt( PosContext.Instance.Parameters.getParam("SequenceNo"), tReport.PosTotal.Sequence_no, PosContext.Instance.Training);
            this.PrintReceipt(PosContext.Instance.Parameters.getParam("StartDate") + tReport.PosTotal.Start_date.ToString(), 0, PosContext.Instance.Training);
            this.PrintReceipt(PosContext.Instance.Parameters.getParam("StartReceiptNo") + tReport.PosTotal.Start_receipt_no, 0, PosContext.Instance.Training);
            this.PrintReceipt(PosContext.Instance.Parameters.getParam("EndReceiptNo") + tReport.PosTotal.End_receipt_no, 0, PosContext.Instance.Training);


            PosHardware.Instance.PosPrinter.FeedLines(1);
            

            this.TerminalReportBySalesman(tReport);

            PosHardware.Instance.PosPrinter.FeedLines(1);

            this.TerminalReportByCollections(tReport, start, end);

            PosHardware.Instance.PosPrinter.FeedLines(1);

            
            this.TerminalReportForCashInDrawer(tReport, start, end);

            PosHardware.Instance.PosPrinter.FeedLines(1);


            this.PrintReportTrailer();
        }

        private void TerminalReportBySalesman(TerminalReport terminalReport)
        {
            this.PrintReceipt(PosContext.Instance.Parameters.getParam("SalesBySalesman"), 0, PosContext.Instance.Training);
            PosEmployeeTotal employeeTotal = new PosEmployeeTotal();
            employeeTotal.Organization_no = PosSettings.Default.Organization;
            employeeTotal.Store_no = PosSettings.Default.Store;
            employeeTotal.Pos_no = PosSettings.Default.Station;
            employeeTotal.Sequence_no = terminalReport.PosTotal.Sequence_no;
            double totalSales = 0;
            DataSet empData = employeeTotal.LoadEmployeeTotal();
            int seq = 0;
            try
            {
                DataTable empTable = empData.Tables[0];

                foreach (DataRow dr in empTable.Rows)
                {
                    string employee_no = dr["employee_no"].ToString();
                    Employee emp = new Employee();
                    emp.Organization_no = PosSettings.Default.Organization;
                    emp.Employee_no = employee_no;
                    emp.LoadByEmployeeNo();

                    seq++;
                    string strEmp = string.Format("{0:##\\.}", seq) + emp.FName;

                    double salesAmt = double.Parse(dr["total_amount"].ToString());
                    this.PrintReceipt(strEmp, salesAmt, PosContext.Instance.Training);
                    totalSales += salesAmt;
                }

                string strSalesTotal = PosContext.Instance.Parameters.getParam("SalesTotal");
                this.PrintReceipt(strSalesTotal, totalSales, PosContext.Instance.Training);
            }

            catch (Exception e)
            {
                Logger.Error(this.GetType().FullName, e.StackTrace, e);
            }



        }


        public void PrintReceipt(string desc, double amount, bool trainingMode) 
		{
			//this.operDisplay = pOperDisplay;
			double Qty = 0;
			string Plu = "";
			string Item = "";
			string Desc = desc;
			double Price = 0;
			double Amount = amount;
			bool TrainingMode = trainingMode;

            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
			StringBuilder tmpStr = new StringBuilder(rWidth);
			for (int i=0;i<rWidth;i++)
			{
				tmpStr.Append(" ");
			}

			if (Qty != 0 )
			{

				//string str1 = Item + "  " + Desc;
                string str1 = Desc;
				
                
				string strQty = string.Format("{0:#####.00}", Qty);
				string strPrice = string.Format("{0:#######.00}", Price);
				string strAmount = string.Format("{0:########.00}", Amount);
				try
				{
                    int amtStartPos = rWidth - strAmount.Length;
                    int priceStartPos = ((int)(rWidth * 3 / 4)) - strPrice.Length;
                    int qtyStartPos =  ((int)(rWidth * 2/4 )) - strQty.Length  ;
                    
                    tmpStr.Insert(0, Item);
					tmpStr.Insert(qtyStartPos, strQty);
					tmpStr.Insert(priceStartPos, strPrice);
					tmpStr.Insert(amtStartPos, strAmount);
					
				}
				catch (Exception e)
				{
					Logger.Error("PrintReceipt.cs", e.ToString());
				}

                PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
				PosHardware.Instance.PosPrinter.Println(str1);
               // PosHardware.Instance.PosPrinter.FeedLines(1);
			
			}
			else
			{
                if (Amount != 0)
                {
                    string strAmount = string.Format("{0:############.00}", Amount);
                    tmpStr.Insert(0, Desc);
                    tmpStr.Insert((rWidth - strAmount.Length), strAmount);

                    PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));

                }
                else
                {
                    tmpStr.Insert(0, Desc);
                    PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));
                }
				
			}

			
			
		}


        public void PrintReportTrailer()
        {
            PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            PosHardware.Instance.PosPrinter.FeedLines(PosHardware.Instance.PosPrinter.RecLinesToPaperCut);  //5);
            PosHardware.Instance.PosPrinter.Cut();
         
        }

        private void TerminalReportByCollections(TerminalReport report, int start, int end)
        {

            this.PrintReceipt(PosContext.Instance.Parameters.getParam("Collections"), 0, PosContext.Instance.Training);
            double totalCollection = 0;

            foreach (object obj in report.PosTotal.Totals)
            {
                EclipsePos.Data.Total total = obj as EclipsePos.Data.Total;


                String countLit = null;
                String amountLit = null;


                if ((total.Total_type > start) && (total.Total_type < end))
                {
                    int type = total.Total_type - start;
                    switch (type)
                    {

                        case (int)TotalType.CASH_SALES:

                            countLit = PosContext.Instance.Parameters.getParam("CashSalesCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashSalesAmount");
                            break;


                        case (int)TotalType.GIFT_CERTIFICATE:

                            countLit = PosContext.Instance.Parameters.getParam("GiftCertCount");
                            amountLit = PosContext.Instance.Parameters.getParam("GiftCertAmount");
                            break;

                        case (int)TotalType.CHECK:
                        case (int)TotalType.CHECK_IN_DRAWER:

                            countLit = PosContext.Instance.Parameters.getParam("CheckCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CheckAmount");
                            break;

                        default:
                            break;
                    }

                    if (type > 400 && type < 500)
                    {
                        object objCard = PosContext.Instance.Config.CardMediaByTotalType[type];
                        if (objCard is CardMedia)
                        {
                            CardMedia cMedia = objCard as CardMedia;
                            countLit = cMedia.Media_name;
                            amountLit = cMedia.Media_name;
                        }

                    }

                    if (countLit != null)
                    {
                        this.PrintReceipt(amountLit.Trim(), total.Total_amount, PosContext.Instance.Training);
                        totalCollection += total.Total_amount;
                    }


                }
            }

            string strCollectionTotal = PosContext.Instance.Parameters.getParam("CollectionTotal");
            this.PrintReceipt(strCollectionTotal, totalCollection, PosContext.Instance.Training);



        }


        private void TerminalReportForCashInDrawer(TerminalReport report, int start, int end)
        {


            this.PrintReceipt(PosContext.Instance.Parameters.getParam("CashInDrawer"), 0, PosContext.Instance.Training);
            double cashInDrawer = 0;

            foreach (object obj in report.PosTotal.Totals)
            {
                EclipsePos.Data.Total total = obj as EclipsePos.Data.Total;


                String countLit = null;
                String amountLit = null;


                if ((total.Total_type > start) && (total.Total_type < end))
                {
                    int type = total.Total_type - start;
                    switch (type)
                    {

                        case (int)TotalType.CASH_SALES:

                            countLit = PosContext.Instance.Parameters.getParam("CashSalesCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashSalesAmount");
                            break;

                        //	case (int) TotalType.CASH_IN_DRAWER:

                        //		countLit = PosContext.Instance.Parameters.getParam("CashInDrCount");
                        //		amountLit = PosContext.Instance.Parameters.getParam("CashInDrAmount");
                        //		break;



                        case (int)TotalType.CASH_BACK:

                            countLit = PosContext.Instance.Parameters.getParam("CashBackCount");
                            amountLit = PosContext.Instance.Parameters.getParam("CashBackAmount");
                            break;



                        case (int)TotalType.PAID_IN:

                            countLit = PosContext.Instance.Parameters.getParam("PaidInCount");
                            amountLit = PosContext.Instance.Parameters.getParam("PaidInAmount");
                            break;

                        case (int)TotalType.PAID_OUT:

                            countLit = PosContext.Instance.Parameters.getParam("PaidOutCount");
                            amountLit = PosContext.Instance.Parameters.getParam("PaidOutAmount");
                            break;

                        case (int)TotalType.LOAN:

                            countLit = PosContext.Instance.Parameters.getParam("LoanCount");
                            amountLit = PosContext.Instance.Parameters.getParam("LoanAmount");
                            break;

                        case (int)TotalType.PICK_UP:

                            countLit = PosContext.Instance.Parameters.getParam("PickupCount");
                            amountLit = PosContext.Instance.Parameters.getParam("PickupAmount");
                            break;


                        default:
                            break;
                    }


                    if (countLit != null)
                    {
                        this.PrintReceipt(amountLit.Trim(), total.Total_amount, PosContext.Instance.Training);
                        cashInDrawer += total.Total_amount;
                    }
                }
            }

            string strCashInDrawer = PosContext.Instance.Parameters.getParam("CashInDrAmount");
            this.PrintReceipt(strCashInDrawer, cashInDrawer, PosContext.Instance.Training);


        }





    }
}
