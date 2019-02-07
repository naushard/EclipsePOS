//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: April, 2007
//===============================================================================
// Changes/Fixes
// 
//===============================================================================


using System;
using System.Collections;

using System.Windows;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Devices;

using Microsoft.PointOfService;



namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for MenuItem.
	/// </summary>
	public class MenuItemLookup :PosEvent	
	{
		private string promptText;

		public MenuItemLookup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void  Engage(int keyValue)
		{
			PosContext.Instance.SearchMode = (SearchBy)keyValue;
			/*try
			{
				Hashtable panels =  PosContext.Instance.CurrentPosDisplay.PanelHashtable;
				PnlItemLookup pnlItemLookup  = panels["11"] as PnlItemLookup;
				pnlItemLookup.ArrangeColumns(PosContext.Instance.SearchMode);
			}
			catch (Exception e)
			{
				Logger.Error("MenuItemLookup.cs", e.ToString() );
			}
			*/
            MessageBox.Show("Deleted code");
			PosContext.Instance.CurrentPosDisplay.LoadMenu(3);
				
		}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}


		#region Properties

		public string PromptText
		{
			get 
			{
				return promptText;
			}
			set 
			{
				promptText= value;
			}
		}

		#endregion
	}
}
