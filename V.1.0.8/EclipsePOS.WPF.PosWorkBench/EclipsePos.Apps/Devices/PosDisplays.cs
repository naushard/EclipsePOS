using System;
using System.Collections;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for PosDisplays.
	/// </summary>
	public interface PosDisplays
	{
		void LoadMenu(int i);

        void LoadItemSearch(int i);

        void LoadTableSelect();

        void UnloadTableSelect();

        void LoadTable(int tableGroupNo);

        
        void LoadCustomerSearch();

        void LoadOpenOrdersList();

        void LoadItemGroupDetailPanel(object panel);

        void LoadTransactionLog();

        void LoadEmployeeView();
               
        void PageUp();

        void PageDown();

        void KeyboardUtility(int utilityCode);

		void DisplayHardwareStatus(HardwareStatusPanelId panelID, string deviceInfo);

        

        string MessageText 
		{
			set;
			get;
		}
		
        Hashtable PanelHashtable
		{
			set;
			get;
		}
	}
	
    
    public enum HardwareStatusPanelId
	{
		Printer=1,
		LineDisplay=2,
		CashDrawer=3,
		Msr=4,
		Scanner=5,
		PosKeyboard=6,
		Database=7,
		Time=8

	}
	
}
