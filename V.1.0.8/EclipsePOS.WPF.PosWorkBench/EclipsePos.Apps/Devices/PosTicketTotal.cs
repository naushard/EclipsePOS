using System;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for PosTicketTotal.
	/// </summary>
	public interface PosTicketTotal
	{
		//SubTotal
		string SubTotal
		{
			set;
			get;
		}
		int SubTotalWidth
		{
			set;
			get;
		}
		
		//TAX
		string Tax
		{
			set;
			get;
		}
		int TaxWidth
		{
			set;
			get;
		}
		// Total
		string Total
		{
			set;
			get;
		}
		int TotalWidth
		{
			set;
			get;
		}
		// Terndared
		string Tendared
		{
			set;
			get;
		}
		int TendaredWidth
		{
			set;
			get;
		}
		// Balance due
		string BalanceDue
		{
			set;
			get;
		}
		int BalanceDueWidth 
		{
			set;
			get;
		}

		string BalanceDueText
		{
			set;
			get;
		}


         
		void Clear();
		
	}
}
