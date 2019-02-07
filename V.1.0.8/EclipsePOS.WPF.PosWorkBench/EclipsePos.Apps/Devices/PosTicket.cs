using System;
using EclipsePos.Apps.PosEvents;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// An interface for coupling application logic to psuedo
	/// and real display devices.
	/// </summary>
	public interface  PosTicket
	{ 
		int QtyWidth 
		{
			get;
			set;
		}

		int ItemWidth
		{
			get;
			set;
		}

		int AmountWidth 
		{
			get;
			set;
		}
		
		int TotalWidth
		{
			get;
			set;
		}

		string Qty
		{
			set;
			get;
		}
	
		string PLU
		{
			set;
			get;
		}

		string Item
		{
			set;
			get;
		}
	
		string Desc 
		{
			set;
			get;
		}
	
		string Price
		{
			set;
			get;
		}
	

		string Amount
		{
			set;
			get;
		}

        string Employee_no
        {
            set;
            get;
        }

        int LineNumber
        {
            set;
            get;
        }

		
	
	
		//public void addSelectableItem (EjLine value);
	

		void Println ();
		
		void Println (String value);
		
		void PrintBold (String value);
		
		void Clear ();
	
		void Clearln (int index);

        void ClearEmployeeLine(string employee);

        void PrintlnSurcharge();

        void PrintlnDiscount();

        void ChangeLineQuantity(string qty, string amt);

        void ChangeLinePrice(string price, string amt);

        int GetCurrentLineNo
        {
            get;
        }


	}
}
