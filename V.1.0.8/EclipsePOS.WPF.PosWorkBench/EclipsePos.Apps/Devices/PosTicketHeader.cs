using System;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for PosTicketHeader.
	/// </summary>
	public interface  PosTicketHeader
	{
		string TrxNo 
		{
			set;
			get;
		}
	
		string PosNo
		{
			set;
			get;
		}
	
		string Operator
		{
			set;
			get;
		}
	
		string PosDate
		{
			set;
			get;
		}

		string TransactionType
		{
			set;
			get;
		}

        string CustomerInfo
        {
            set;
            get;
        }
			
		
	}
}
