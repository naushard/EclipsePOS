using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text;
using Microsoft.PointOfService;

using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.PosEvents;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps;
using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.Util;
using EclipsePos.Apps.Properties;

namespace EclipsePos.Apps.Devices
{
    public class ReceiptPrint 
    {
        private Ej ej;
        private bool totalPrinted = false;
        private bool salesInvoice = false;

        public ReceiptPrint(Ej ejToPrint)
        {
            this.ej = ejToPrint;
        }

        #region PrintWorker Members
        public void  PrintEj()
        {

            foreach (Object obj in this.ej.EjArrayList)
            {
                 if ( obj is EjLine )
                 {
                     EjLine ejLine = (EjLine) obj;

                     if  ((ejLine.LineType ==(int) EjLineType.ALT_CURRENCY_TENDER)
                          || (ejLine.LineType == (int) EjLineType.DEBIT_TENDER)  
                          || (ejLine.LineType == (int) EjLineType.CHECK_TENDER)
                          || (ejLine.LineType == (int)EjLineType.CC_TENDER)
                          || (ejLine.LineType == (int)EjLineType.TENDER ) )
                     {
                         if (!totalPrinted) this.PrintTotal();
                         totalPrinted = true;
                     }

                     if  ((ejLine.LineType ==(int) EjLineType.SALES_PERSON))
                     {
                       continue;   
                     }

                    
                     ejLine.PrintEj();
                     if (ejLine.LineType == (int)EjLineType.ITEM)
                     {
                         this.salesInvoice = true;
                     }
                 }
            }

            if (salesInvoice)
            {
                this.PrintDue();
                this.PrintInvoiceTrailler();
            }
            else
            {
                this.PrintReportTrailler();
            }
            

        }
        #endregion

        private void PrintTotal()
        {
           
            string totalText = PosContext.Instance.Parameters.getParam("Total");
            double totalAmount = this.ej.EjTotal();

            if (PosContext.Instance.Training)
                totalText = "<T>" + totalText;

            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
            StringBuilder tmpStrLine = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStrLine.Append("-");
            }


            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            string strAmount = string.Format("{0:############.00}", totalAmount);
            tmpStr.Insert(0, totalText);
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);

            //PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(tmpStrLine.ToString());
            PosHardware.Instance.PosPrinter.Println("\x1B|3C" + tmpStr.ToString().Substring(0, rWidth));
        }


        private void PrintDue()
        {
            string desc = null;
            double amt = 0;

            int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;

            StringBuilder tmpStr = new StringBuilder(rWidth);
            for (int i = 0; i < rWidth; i++)
            {
                tmpStr.Append(" ");
            }

            amt = this.ej.EjBalance();
            if (amt > 0 )
            {
                desc = PosContext.Instance.Parameters.getParam("BalanceDue");
            }
            else
            {
                amt = PosContext.Instance.PosMath.Negate(amt);
                desc = PosContext.Instance.Parameters.getParam("Change");
            }


            string strAmount = string.Format("{0:############.00}", amt);
            tmpStr.Insert(0, desc);
            tmpStr.Insert((rWidth - strAmount.Length), strAmount);
            PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0, rWidth));

        }



        private void PrintInvoiceTrailler()
		{

			//PosHardware.Instance.PosPrinter.FeedLines(1);


			int rWidth = PosHardware.Instance.PosPrinter.ReceiptLineChars;
			StringBuilder tmpStr = new StringBuilder(rWidth);
			for (int i=0;i<rWidth;i++)
			{
				tmpStr.Append(" ");
			}
			//string strAmount = string.Format("{0:############.00}", PosContext.Instance.CurrentEj.EjTaxTotal());
            string strAmount = string.Format("{0:############.00}", this.ej.EjTaxTotal());
			tmpStr.Insert(0, PosContext.Instance.Parameters.getParam("TaxIncludedText") );
			tmpStr.Insert((rWidth-strAmount.Length), strAmount);

			PosHardware.Instance.PosPrinter.Println(tmpStr.ToString().Substring(0,rWidth));
			
            StringBuilder tmpLnStr = new StringBuilder(rWidth);
			for (int i5=0;i5<rWidth;i5++)
			{
				tmpLnStr.Append("-");
			}
			PosHardware.Instance.PosPrinter.Println(tmpLnStr.ToString());

			StringBuilder tmpStr1 = new StringBuilder(rWidth);
			for (int i1=0;i1<rWidth;i1++)
			{
				tmpStr1.Append(" ");
			}
			//string strQty = string.Format("{0:###############}", PosContext.Instance.CurrentEj.EjQtyTotal());
            string strQty = string.Format("{0:###############}", this.ej.EjQtyTotal());
			tmpStr1.Insert(0, PosContext.Instance.Parameters.getParam("TotalItemCountText") );
			tmpStr1.Insert((rWidth-strQty.Length), strQty);

			PosHardware.Instance.PosPrinter.Println(tmpStr1.ToString().Substring(0,rWidth));

            this.ej.SalesPerson.ForEach(delegate(EjSalesPerson ejSalesPerson)
            {
                string salesPerson = ejSalesPerson.Desc;
                if (!String.IsNullOrEmpty(salesPerson))
                {
                    // Print sales person
                    StringBuilder sbSalesPerson = new StringBuilder();
                    sbSalesPerson.Append(PosContext.Instance.Parameters.getParam("SalesStaff"));
                    sbSalesPerson.Append(" ");
                    sbSalesPerson.Append(salesPerson);
                    PosHardware.Instance.PosPrinter.Println(sbSalesPerson.ToString());
                }
 
            });
                
           
            
           
			
			
			
			StringBuilder tmp = new StringBuilder();
			StringBuilder trxInfo = new StringBuilder();

			trxInfo.Append(PosContext.Instance.Parameters.getParam("TrxNo"));
			//trxInfo.Append(PosContext.Instance.TrxNo);
            trxInfo.Append( ej.TransHeader.TransNo.ToString());
			trxInfo.Append(" ");
			trxInfo.Append(PosContext.Instance.Parameters.getParam("PosNo"));
			//trxInfo.Append(PosSettings.Default.Station);
            trxInfo.Append(this.ej.TransHeader.PosNo.ToString());
			trxInfo.Append("\n");
			trxInfo.Append(PosContext.Instance.Parameters.getParam("ReceiptBottomMOD"));
				
			//PosHardware.Instance.PosPrinter.Open();
			PosHardware.Instance.PosPrinter.FeedLines(1);
			PosHardware.Instance.PosPrinter.Println(trxInfo.ToString());
			PosHardware.Instance.PosPrinter.Println(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));	
			PosHardware.Instance.PosPrinter.FeedLines(PosHardware.Instance.PosPrinter.RecLinesToPaperCut);  //5);
			PosHardware.Instance.PosPrinter.Cut();
		//	PosHardware.Instance.Close();
				
		}


        public void PrintReportTrailler()
        {
            StringBuilder tmp = new StringBuilder();
            StringBuilder trxInfo = new StringBuilder();

            trxInfo.Append(PosContext.Instance.Parameters.getParam("TrxNo"));
            //trxInfo.Append(PosContext.Instance.TrxNo);
            trxInfo.Append(ej.TransHeader.TransNo.ToString());
            trxInfo.Append(" ");
            trxInfo.Append(PosContext.Instance.Parameters.getParam("PosNo"));
            //trxInfo.Append(PosSettings.Default.Station);
            trxInfo.Append(this.ej.TransHeader.PosNo.ToString());
           

            //PosHardware.Instance.PosPrinter.Open();
            PosHardware.Instance.PosPrinter.FeedLines(1);
            PosHardware.Instance.PosPrinter.Println(trxInfo.ToString());
            PosHardware.Instance.PosPrinter.Println(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            PosHardware.Instance.PosPrinter.FeedLines(PosHardware.Instance.PosPrinter.RecLinesToPaperCut);  //5);
            PosHardware.Instance.PosPrinter.Cut();
        }

		


    }
}
