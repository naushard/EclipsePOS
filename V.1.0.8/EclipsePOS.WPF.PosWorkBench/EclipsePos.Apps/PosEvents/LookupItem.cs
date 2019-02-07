using System;
using System.Windows;
using System.Data;

using EclipsePos.Apps.Context;
using EclipsePos.Data;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.Util;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for LookupItem.
	/// </summary>
	public class LookupItem : PosEvent		
	{
		private int maxPluLength=15;

		public LookupItem() 
		{
			int maxLenth= int.Parse(PosContext.Instance.Parameters.getParam("MaximumPluLength"));	
			if (maxLenth != 0)
			{
				maxPluLength = maxLenth;
			}
		}

		/** Event logic is implemented here */
		public override void Engage(int keyValue)
		{

			
			Item item = new Item();
            item.Organization_no = PosSettings.Default.Organization;

           // if (keyValue > 0)
           // {
           //     item.Plu = keyValue;
           //     item.LoadByPLU();
           //     
           // }
           //  else
           // {
                if (PosContext.Instance.InputLine.Length == 0 &&
                    PosContext.Instance.ItemLookupDevice.SelectedItem().Length > 0)
                {
                    item.Sku = PosContext.Instance.ItemLookupDevice.SelectedItem();
                    item.LoadBySKU();
                }
                else
                {
                    if (PosContext.Instance.InputLine.Length <= maxPluLength)
                    {
                        try
                        {
                            item.Plu = PosContext.Instance.InputLine.Trim();
                            item.LoadByPLU();

                        }
                        catch (System.FormatException e)
                        {
                            //Could be SKU
                            item.Sku = PosContext.Instance.InputLine;
                            item.LoadBySKU();

                        }

                   }


                    if (item.Short_Desc == null )
                    {
                        try
                        {
                            item.Sku = PosContext.Instance.InputLine;
                            item.LoadBySKU();
                        }
                        catch
                        {
                        }

                    }
                }
          //  }
            
			if (item.Short_Desc != null)
			{
                try
                {
                    EjItem ejItem = new EjItem(item);
                    //ejItem.Engage(0);
                    ejItem.States().PushState((int)EjItemStates.ENTER_QTY);
                    PosEventStack.Instance.PushEvent(ejItem);
                   // PosEventStack.Instance.Dump();
                    PosEventStack.Instance.NextEvent();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace.ToString());
                }
			}
			else
			{
				PosError posError = new PosError(PosErrorCode.INVALID_INPUT);
				posError.Engage(0);
			}
			
			PosContext.Instance.InputLine = "";
			PosContext.Instance.ClearInput();
			

		}

		/** Class specific clear (key) implementation */
		public override void Clear()
		{
		}


		/*  ** Sublcasses implement event validation. */
		public override bool ValidTransition (string pEventName)
		{
			return true;
		}

	}
}
