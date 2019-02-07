 //===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: September, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================

using System;
using System.Collections;
using System.Windows; 
using System.Data;
using System.Collections.Generic;

using EclipsePos.Apps.Context;
using EclipsePos.Apps.EJournal;
using EclipsePos.Data;

using Microsoft.PointOfService;

namespace EclipsePos.Apps.EJournal
{
  	/// <summary>
	/// Summary description for Ej.
	/// </summary>
    public class Ej : IComparer, IComparable
	{
		private ArrayList ejArrayList;
        private int seq_no = 0;
        private int line_no = 0;
        private List<EjSalesPerson> ejSalesPerson;
        private EjHeader ejHeader;

        

		public Ej()
		{
			ejArrayList = new ArrayList();
            //ejSalesPerson = new EjSalesPerson();
            ejSalesPerson = new List<EjSalesPerson>();
		}


		public void EjAdd(object obj)
		{
            if (obj is EjLine)
            {
                EjLine ejLine = obj as EjLine;
                if (ejLine.LineType == (int)EjLineType.ITEM || ejLine.LineType == (int)EjLineType.SURCHARGE )
                {
                    this.line_no++;
                  
                }
               
            }
            
            this.seq_no++;
			ejArrayList.Add(obj);

            if (obj is EjHeader)
            {
                this.ejHeader = (EjHeader)obj;
            }

            if (obj is EjSalesPerson)
            {
                EjSalesPerson ejPerson = obj as EjSalesPerson;
                this.SalesPerson.Add(ejPerson); 
            }

		}

        public void EjAddReload(object obj)
        {
            ejArrayList.Add(obj);

            if (obj is EjHeader)
            {
                this.ejHeader = (EjHeader)obj;
            }

            if (obj is EjSalesPerson)
            {
                EjSalesPerson ejPerson = obj as EjSalesPerson;
                this.SalesPerson.Add(ejPerson);
            }
        }


 

		
	/**
	 * Sub-totals the current ej.
	*/
		public double EjSubTotal()
		{

			double total = 0;
			
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;

			
				switch (ejLine.LineType )
				{

					case (int)EjLineType.ITEM:

						TransItem transItem =  ejLine.DataRecord() as TransItem;
						if (transItem.State != (int)EjLineStates.VOID_ITEM)
						{
							total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
						}
						break;

                    case (int)EjLineType.SURCHARGE:

                        TransItem transItem1 = ejLine.DataRecord() as TransItem;
                        if (transItem1.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
                        break;

					case (int)EjLineType.ITEM_LINK:
					//	transItem = (TransItem) (context.currItem ().dataRecord ());
					//	if (transItem.state () != TransItem.VOID)
					//	{
					//		total = context.posMath ().add (total, line.extAmount ());
					//	}
						break;

					case (int)EjLineType.PROMOTION:
						EjPromotion ejPromotion = ejLine as EjPromotion;
						//if (ejPromotion.Applied )
						//{
                        if (ejPromotion.State != (int)EjLineStates.VOID_ITEM)
                        {

                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
						//}
						break;
                    
                    case (int)EjLineType.ACCOUNT:
                        EjReceiveOnAccount onAcc = ejLine as EjReceiveOnAccount;
                        total = PosContext.Instance.PosMath.Add(total, onAcc.TenderAmount);
                        break;


					default:
						break;
				}
			}
			return Math.Round(total, 2);
		}

	 /**
	 * Totals the current ej, exclueds surcharges.
	 */
		public double EjSaleTotal()
        {

            double total = 0;

            foreach (Object obj in ejArrayList)
            {
                EjLine ejLine = (EjLine)obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;


                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        TransItem transItem = ejLine.DataRecord() as TransItem;
                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
                        break;

                   

                    case (int)EjLineType.ITEM_LINK:
                        //	transItem = (TransItem) (context.currItem ().dataRecord ());
                        //	if (transItem.state () != TransItem.VOID)
                        //	{
                        //		total = context.posMath ().add (total, line.extAmount ());
                        //	}
                        break;

                    case (int)EjLineType.PROMOTION:
                        EjPromotion ejPromotion = ejLine as EjPromotion;
                        //if (ejPromotion.Applied )
                        //{
                        if (ejPromotion.State != (int)EjLineStates.VOID_ITEM)
                        {

                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
                        //}
                        break;

                  
                    default:
                        break;
                }
            }
           
            return Math.Round(total, 2);

           
		}

        /**
    * Totals the current ej, exclueds surcharges, order discounts.
    */
        public double EjGrossTotal()
        {

            double total = 0;

            foreach (Object obj in ejArrayList)
            {
                EjLine ejLine = (EjLine)obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;


                switch (ejLine.LineType)
                {

                    case (int)EjLineType.ITEM:

                        TransItem transItem = ejLine.DataRecord() as TransItem;
                        if (transItem.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
                        break;



                    case (int)EjLineType.ITEM_LINK:
                        //	transItem = (TransItem) (context.currItem ().dataRecord ());
                        //	if (transItem.state () != TransItem.VOID)
                        //	{
                        //		total = context.posMath ().add (total, line.extAmount ());
                        //	}
                        break;

                    case (int)EjLineType.PROMOTION:
                        EjPromotion ejPromotion = ejLine as EjPromotion;
                        //if (ejPromotion.Applied )
                        //{

                        if (ejPromotion.Promotion.PromotionType == (int)EjPromotionTypes.WHOLE_ORDER) break;
                        if (ejPromotion.State == (int)EjLineStates.VOID_ITEM) break;

                        total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        break;


                    default:
                        break;
                }
            }

            return Math.Round(total, 2);


        }


	 /**
	 * Totals tax records
	 */
		public double EjTaxTotal ()
		{
			double total = 0;
		
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;


                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;


				switch (ejLine.LineType)
				{

					case (int)EjLineType.TAX:
						EjTax ejTax = ejLine as EjTax;
						total = PosContext.Instance.PosMath.Add (total, ejTax.ExtAmount);
						break;

					default:
						break;
				}
			}
			return Math.Round(total, 2);

		}

	 /**
	 * Balance of items - tender.
	 */
		public double EjBalance ()
		{
			double total = 0;
			bool applyTax = true;
			
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;
		
				switch (ejLine.LineType)
				{  

					case (int) EjLineType.ITEM:

						EjItem ejItem = (EjItem) ejLine;

						// set apply tax flag
						if (ejItem.TaxInclusive == 0 )
						{
							applyTax = true;
						}
						else 
						{
							applyTax = false;
						}
						
					
						TransItem transItem = (TransItem) ejLine.DataRecord();
						if (transItem.State != (int) EjLineStates.VOID_ITEM)
						{
							total = PosContext.Instance.PosMath.Add(total,  ejLine.ExtAmount); 
							
						}
						break;
                    case (int)EjLineType.SURCHARGE:

                        EjSurcharge ejSurcharge = (EjSurcharge)ejLine;

                        // set apply tax flag
                        if (ejSurcharge.TaxInclusive == 0)
                        {
                            applyTax = true;
                        }
                        else
                        {
                            applyTax = false;
                        }


                        TransItem transItem1  = (TransItem)ejLine.DataRecord();
                        if (transItem1.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);

                        }
                        break;

					case (int)EjLineType.ITEM_LINK:
						//	transItem = (TransItem) (context.currItem ().dataRecord ());
						//	if (transItem.state () != TransItem.VOID)
						//	{
						//		total = context.posMath ().add (total, line.extAmount ());
						//	}
						break;

					case (int) EjLineType.TAX:
						EjTax tax = (EjTax) ejLine;

						if (applyTax)
						{
							//	if (tax.taxRecord ().taxable () > 0.0)
							//	{
							total = PosContext.Instance.PosMath.Add(total,  ejLine.ExtAmount);
							//	}
						}
						break;

					case (int)EjLineType.PROMOTION:
						EjPromotion ejPromotion = ejLine as EjPromotion;
						//if (ejPromotion.Applied )
						//{
                        if (ejPromotion.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
						//}
						break;

                    case (int)EjLineType.ACCOUNT:
                        EjReceiveOnAccount onAcc = ejLine as EjReceiveOnAccount;
                        total = PosContext.Instance.PosMath.Add(total, onAcc.TenderAmount);
                        break;
					
					
					case (int)EjLineType.CC_TENDER:
					case (int)EjLineType.CHECK_TENDER:
					case (int)EjLineType.ALT_CURRENCY_TENDER:
					case (int)EjLineType.COUPON:
					case (int)EjLineType.DEBIT_TENDER:
					case (int)EjLineType.GIFT_CERT_TENDER:
					case (int)EjLineType.TENDER:
			
						total = PosContext.Instance.PosMath.Sub(total, ejLine.ExtAmount);

						break;

					
					default:
						break;
				}
			}

			return Math.Round(total, 2);
		}	

		/**
	 * Totals the tender amounts.
	 */
		public double EjTotalTender ()
		{
			double total = 0;
		
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;

               // if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;
		
				switch (ejLine.LineType)
				{

					case (int)EjLineType.CC_TENDER:
					case (int)EjLineType.CHECK_TENDER:
					case (int)EjLineType.ALT_CURRENCY_TENDER:
					case (int)EjLineType.COUPON:
					case (int)EjLineType.DEBIT_TENDER:
					case (int)EjLineType.GIFT_CERT_TENDER:
					case (int)EjLineType.TENDER:
			
						EjTax ejTax = ejLine as EjTax;
						total = PosContext.Instance.PosMath.Add (total, ejLine.ExtAmount);

						break;

					default:
						break;
				}
			}
			
			return Math.Round(total, 2);

			
		}

	
		public double EjTotal()
		{

			double total = 0;
			bool applyTax = true;
			
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;


                //if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;


				switch (ejLine.LineType)
				{  

					case (int) EjLineType.ITEM:

						EjItem ejItem = (EjItem) ejLine;

						// set apply tax flag
						if (ejItem.TaxInclusive == 0 )
						{
							applyTax = true;
						}
						else 
						{
							applyTax = false;
						}
											
						TransItem transItem = (TransItem) ejLine.DataRecord();
                        if ((transItem.State != (int)EjLineStates.VOID_ITEM) && (transItem.State != (int)EjLineStates.PRICE_OVERRIDE))
						{
							total = PosContext.Instance.PosMath.Add(total,  ejLine.ExtAmount); 
							
						}
						break;

                    case (int)EjLineType.SURCHARGE:

                        EjSurcharge ejSurcharge = (EjSurcharge)ejLine;

                        // set apply tax flag
                        if (ejSurcharge.TaxInclusive == 0)
                        {
                            applyTax = true;
                        }
                        else
                        {
                            applyTax = false;
                        }

                        TransItem transItem1 = (TransItem)ejLine.DataRecord();
                        if (transItem1.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);

                        }
                        break;


					case (int)EjLineType.ITEM_LINK:
					//	transItem = (TransItem) (context.currItem ().dataRecord ());
					//	if (transItem.state () != TransItem.VOID)
					//	{
					//		total = context.posMath ().add (total, line.extAmount ());
					//	}
						break;

					case (int) EjLineType.TAX:
						EjTax tax = (EjTax) ejLine;

						if (applyTax)
						{
						//	if (tax.taxRecord ().taxable () > 0.0)
						//	{
								total = PosContext.Instance.PosMath.Add(total,  ejLine.ExtAmount);
						//	}
						}
						break;

					case (int)EjLineType.PROMOTION:
						EjPromotion ejPromotion = ejLine as EjPromotion;
						//if (ejPromotion.Applied )
						//{
                        if (ejPromotion.State != (int)EjLineStates.VOID_ITEM)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejLine.ExtAmount);
                        }
						//}
						break;

                    case (int)EjLineType.ACCOUNT:
                        EjReceiveOnAccount onAcc = ejLine as EjReceiveOnAccount;
                        total = PosContext.Instance.PosMath.Add(total, onAcc.TenderAmount);
                        break;

					default:
						break;
				}
			}

			return Math.Round(total, 2);
		}


        /**
	 * Total order discount
	 */
        public double EjWholeOrderDiscountTotal()
        {
            double total = 0;

            foreach (Object obj in ejArrayList)
            {
                EjLine ejLine = (EjLine)obj;


                if (ejLine.State == (int)EjLineStates.VOID_SALE || ejLine.State == (int)EjLineStates.VOID_ITEM || ejLine.State == (int)EjLineStates.PRICE_OVERRIDE  ) continue;


                switch (ejLine.LineType)
                {

                    case (int)EjLineType.PROMOTION:
                        EjPromotion ejPromo = ejLine as EjPromotion;
                        if (ejPromo.Promotion.PromotionType == (int)EjPromotionTypes.WHOLE_ORDER)
                        {
                            total = PosContext.Instance.PosMath.Add(total, ejPromo.Amount );
                        }
                        break;

                    default:
                        break;
                }
            }
            return Math.Round(total, 2);

        }


		public void Complete(int state)
		{
            if (PosContext.Instance.Training)
            {
                this.Clear();
                return;
            }

			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;

                if (ejLine.State != (int)EjLineStates.IN_PROGRESS) continue;

               // ejLine.State = state;
				switch (ejLine.LineType)
				{

					case (int)EjLineType.TRANS_HEADER:
                        EjHeader ejHeader = (EjHeader)ejLine;
                        if (!ejHeader.UpdateState(state))
                        {
                        	MessageBox.Show("Error :- Unable to complete UpdateState-Ej");
                        }
						break;

					case (int)EjLineType.ITEM:
                       
                        ejLine.UpdateTotals();
                        EjItem ejItem = ejLine as EjItem;
                        ejItem.SaveState( (EjLineStates)state );
                        if (state == (int)Transaction.Status.COMPLETE)
                        {
                            ejItem.UpdateStock();
                        }
                        break;

					case (int)EjLineType.PROMOTION:
					case (int)EjLineType.BANK:
					case (int)EjLineType.TENDER:
					case (int)EjLineType.CHECK_TENDER:
					case (int)EjLineType.CC_TENDER:
					case (int)EjLineType.GIFT_CERT_TENDER:
					case (int)EjLineType.DEBIT_TENDER:
					case (int)EjLineType.ALT_CURRENCY_TENDER:
					case (int)EjLineType.COUPON:    
                    case (int)EjLineType.ACCOUNT:
                    case (int)EjLineType.TAX:
                    case (int)EjLineType.SURCHARGE:

						ejLine.UpdateTotals();


						break;
					
					case (int)EjLineType.TOTAL:
						break;
					default:
						break;
				}
           // es01-26/11/08     if (!ejLine.Save())
           // es01-26/11/08     {
           // es01-26/11/08        MessageBox.Show("Error :- Unable to save Ej");
           // es01-26/11/08     }
            
            }
			
            //EjHeader ejHeader = (EjHeader)ejArrayList[0];
			//if (!ejHeader.UpdateState(state))
			//{
			//	MessageBox.Show("Error :- Unable to complete UpdateState-Ej");
			//}

			this.Clear();

		}

		public void Clear()
		{
			ejArrayList.Clear();
            seq_no = 0;
            line_no = 0;
	
		}

		public static Ej GetSuspendedEj(Transaction trans)
		{
            
			Ej transRecords = new Ej();
            transRecords.LineNo = 0;
            transRecords.SeqNo = 0;


            //Do not load if not suspended
            if (trans.State == (int)Transaction.Status.SUSPEND)
            {
                trans.State = (int)(Transaction.Status.IN_PROGRESS);
                trans.UpdateState();
            }

			//Create a header
			EjHeader ejHeader = new EjHeader(trans);
			transRecords.EjAddReload(ejHeader);
			//Get items
			TransItem item = new TransItem();
            item.Trans_no = trans.Trans_no;
            item.Organization_no = trans.Organization_no;
            item.Store_no = trans.Store_no;
            item.Pos_no = trans.Pos_no;
			
			DataSet data = item.LoadByTransno();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				TransItem transItem = new TransItem(dr);

                if (transItem.State == (int)EjLineStates.PRICE_OVERRIDE) continue;
                if (transItem.State == (int)EjLineStates.VOID_ITEM) continue;
                if (transItem.State == (int)EjLineStates.VOID_SALE) continue;

                if (transItem.Line_no > transRecords.LineNo)
                {
                    transRecords.LineNo = transItem.Line_no;
                }
                if (transItem.Seq_no > transRecords.SeqNo)
                {
                    transRecords.SeqNo = transItem.Seq_no;
                }


                if (transItem.State == (int)EjLineStates.SUSPEND)
                {
                    transItem.State = (int)EjLineStates.IN_PROGRESS;
                    transItem.UpdateState();
                }

                if (transItem.Reason_code == (int)EjItemReasonCodes.NORMAL_ITEM)
                {
                     EjItem ejItem = new EjItem(transItem);

                     transRecords.EjAddReload(ejItem);
                 }
                 if (transItem.Reason_code == (int)EjItemReasonCodes.SURCHARGE)
                 {
                     EjSurcharge ejSurcharge = new EjSurcharge(transItem);
                     transRecords.EjAddReload(ejSurcharge);
                 }

           		
			}


			//Get promotions
			try
			{
				TransPromotion promo = new  TransPromotion();
				promo.Trans_no = trans.Trans_no;
                promo.Organization_no = trans.Organization_no;
                promo.Store_no = trans.Store_no;
                promo.Pos_no = trans.Pos_no;
			
				DataSet data1 = promo.LoadAllByTransId();
				DataTable dt1 = data1.Tables[0];
				foreach (DataRow dr1 in dt1.Rows )
				{
					TransPromotion transPromotion = new  TransPromotion(dr1);
                    if (transPromotion.Line_no > transRecords.LineNo)
                    {
                        transRecords.LineNo = transPromotion.Line_no;
                    }
                    if (transPromotion.Seq_no > transRecords.SeqNo)
                    {
                        transRecords.SeqNo = transPromotion.Seq_no;
                    }

                    if (transPromotion.State != (int)EjLineStates.VOID_ITEM )
                    {
                        transPromotion.State = (int)EjLineStates.IN_PROGRESS;
                        transPromotion.UpdateState();
                    }
					EjPromotion ejPromotion = new EjPromotion(transPromotion);
                    transRecords.EjAddReload(ejPromotion);
				}
			}
			catch
			{
			}

			//Get Tax
			try
			{
				TransTax ttax = new  TransTax();
				ttax.Trans_no = trans.Trans_no;
                ttax.Organization_no = trans.Organization_no;
                ttax.Store_no = trans.Store_no;
                ttax.Pos_no = trans.Pos_no;
			
				DataSet data2 = ttax.LoadByTransid();
				DataTable dt2 = data2.Tables[0];
				foreach (DataRow dr2 in dt2.Rows )
				{
                    

					TransTax transTax = new TransTax(dr2);
					EjTax  ejTax = new EjTax(transTax);
					transRecords.EjAddReload(ejTax);

                    if (transTax.Line_no > transRecords.LineNo)
                    {
                        transRecords.LineNo = transTax.Line_no;
                    }
                   
				}
			}
			catch
			{
			}


            //Get Free Text
            try
            {
                TransText ttext = new TransText();
                ttext.Trans_no = trans.Trans_no;
                ttext.Organization_no = trans.Organization_no;
                ttext.Store_no = trans.Store_no;
                ttext.Pos_no = trans.Pos_no;

                DataSet data3 = ttext.LoadByTransNo();
                DataTable dt3 = data3.Tables[0];
                foreach (DataRow dr3 in dt3.Rows)
                {
                    if (ttext.Line_no > transRecords.LineNo)
                    {
                        transRecords.LineNo = ttext.Line_no;
                    }
                    if (ttext.Seq_no > transRecords.SeqNo)
                    {
                        transRecords.SeqNo = ttext.Seq_no;
                    }
                    TransText transText = new TransText(dr3);
                    EjFreeText ejText = new EjFreeText(transText);
                    transRecords.EjAddReload(ejText);
                }
            }
            catch
            {
            }

            try
            {
                //Get Sales person
                TransSalesPerson salesPerson = new TransSalesPerson();
                salesPerson.Organization_no = trans.Organization_no;
                salesPerson.Trans_no = trans.Trans_no;
                salesPerson.Store_no = trans.Store_no;
                salesPerson.Pos_no = trans.Pos_no;
                DataSet dataSalP = salesPerson.LoadByTransNo();
                DataTable dtSalP = dataSalP.Tables[0];
                foreach (DataRow drSalP in dtSalP.Rows)
                {
                    TransSalesPerson transSp = new TransSalesPerson(drSalP);
                    EjSalesPerson ejSalP = new EjSalesPerson(transSp);
                    transRecords.EjAddReload(ejSalP);

                }
            }
            catch
            {
            }


            //Get Bank EJ
            try
            {
                //Get Sales person
                TransBank transBank = new  TransBank();
                transBank.Organization_no = trans.Organization_no;
                transBank.Pos_no = trans.Pos_no;
                transBank.Store_no = trans.Store_no;
                transBank.Trans_no = trans.Trans_no;
                DataSet dataTBank = transBank.LoadByTransid();
                DataTable dtTBank = dataTBank.Tables[0];
                foreach (DataRow drTBank in dtTBank.Rows)
                {
                    TransBank tb = new TransBank(drTBank);
                    EjBank ejBank = new EjBank(tb);
                    transRecords.EjAddReload(ejBank);

                }
            }
            catch
            {
            }
            

            

 


            //Get Payments made
            try
            {
                TransTender tender = new TransTender(); 
                tender.Trans_no  = trans.Trans_no;
                tender.Organization_no = trans.Organization_no;
                tender.Store_no = trans.Store_no;
                tender.Pos_no = trans.Pos_no;


                DataSet data1 = tender.LoadByTransid();
                DataTable dt1 = data1.Tables[0];
                foreach (DataRow dr1 in dt1.Rows)
                {

                    TransTender transTender = new TransTender(dr1);
                    EjTender ejTender = new  EjTender(transTender);
                    transRecords.EjAddReload(ejTender);

                    
                }
            }
            catch
            {
            }



			transRecords.EjArrayList.Sort(new Ej());
			return transRecords;

		}



		

//		public void  RemoveCurrLine()
//		{
//			if (this.EjArrayList.Count > 0 )
//			{
//				this.EjArrayList.RemoveAt(this.ejArrayList.Count-1);
//		
//			}
//		}


      /*  public EjLine GetCurrentLine()
        {
            if (this.EjArrayList.Count > 0)
            {
                return this.EjArrayList[this.ejArrayList.Count - 1] as EjLine;

            }

            return null;

        }
       * */

	
		public double EjQtyTotal()
		{

			double total = 0;
			
			foreach( Object obj in ejArrayList)
			{
				EjLine ejLine = (EjLine) obj;
			
				if ( ejLine.LineType == (int)EjLineType.ITEM )
				{
					TransItem transItem =  ejLine.DataRecord() as TransItem;
					if (transItem.State != (int)EjLineStates.VOID_ITEM)
					{
						//total = PosContext.Instance.PosMath.Add(total, ejLine.Quantity);
                        total++;
					}
                    
				}
			}
			return total;
		}


       
 		#region Properties

		/*
		public int LastItemIndex
		{
			get
			{
				return total-tax;
			}
		}
		
		public int Size
		{
			get
			{
				return total;
            }
		}
	
		
		public double EjTax
		{
			get
			{
				return tax;
			}
		}
		*/
		/*public double EjBalance
		{
			get
			{
				return total - tendered;
			}
		}
		
		public double EjTotalTender
		{
			get
			{
				return tendered;
			}
		}
		*/

		public int SeqNo
		{
			get
			{
				//return ejArrayList.Count;
                return seq_no;
			}
            set
            {
                this.seq_no = value;
            }
		}

        public int LineNo
        {
            get
            {
              return line_no;
            }
            set
            {
                this.line_no = value;
            }
        }


		public ArrayList EjArrayList
		{
			get
			{
				return ejArrayList;
			}
		}

        public EjHeader TransHeader
        {
            get
            {
                return this.ejHeader;
            }
        }

       
        public List<EjSalesPerson> SalesPerson
        {
            get
            {
                return this.ejSalesPerson;
            }
        }




        
       
		#endregion

        int IComparer.Compare(Object x, Object y)
        {
            if (x == null || y == null) return 0;
            
            try
            {
                EjLine lineX = x as EjLine;
                EjLine lineY = y as EjLine;
                if (lineX.SeqNo > lineY.SeqNo)
                {
                    return 1;
                }

                if (lineX.SeqNo < lineY.SeqNo)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }


        // Implement IComparable CompareTo method - provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            EjLine x = (EjLine)obj;
            if (x == null ) return 0;

            try
            {
                if (x.SeqNo > this.SeqNo)
                {
                    return 1;
                }
                
                if (x.SeqNo < this.SeqNo)
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
	

	}
}
