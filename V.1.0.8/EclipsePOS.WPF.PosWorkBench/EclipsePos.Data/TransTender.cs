using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Trans_tender.
	/// </summary>
	public class TransTender : IRelatableSet	
	{
		private int trans_no;
		private int seq_no;
        private string store_no;
        private string organization_no;
		private int tendertype;
		private int pass_no;
		private double  amount;
		private double change_amt;
		private string tender_desc;
		private string change_desc;
		private string locale_language;
		private string locale_country;
		private string data_capture;
		private int state;
        private int pos_no;
		
		private DataSet resultSet; 

		public TransTender()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

        public TransTender(DataRow dr)
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());
			this.Seq_no = int.Parse(dr["seq_no"].ToString());
            this.Store_no = dr["store_no"].ToString();
            this.Organization_no = dr["organization_no"].ToString();
			this.Tendertype = int.Parse(dr["tendertype"].ToString());
			this.Amount = double.Parse(dr["amount"].ToString());
			this.Change_amount = double.Parse(dr["change_amt"].ToString());
			this.Tender_desc = dr["tender_desc"].ToString();
			this.Change_desc  = dr["change_desc"].ToString();
			this.Locale_language = dr["locale_language"].ToString();
			this.Locale_country = dr["locale_country"].ToString();
			this.Data_capture  = dr["data_capture"].ToString();
            this.State = int.Parse(dr["state"].ToString());
            this.Pos_no = int.Parse(dr["pos_no"].ToString());
		}

		#region Properties

		//1
		public int Trans_no
		{
			set
			{
				trans_no = value;
			}
			get
			{
				return trans_no;
			}
		}

		
		
		//2
		public int  Seq_no
		{
			set
			{
				
				seq_no = value;
			}
			get
			{
				return seq_no;
			}
		}


        public string Store_no
        {
            set
            {

                store_no = value;
            }
            get
            {
                return store_no;
            }
        }



        public string Organization_no
        {
            set
            {

                organization_no = value;
            }
            get
            {
                return organization_no;
            }
        }
		
		//3
		public int  Tendertype
		{
			set
			{
				
				tendertype = value;
			}
			get
			{
				return tendertype;
			}
		}

		//4
		public double Amount
		{
			set
			{
				
				amount = value;
			}
			get
			{
				return amount;
			}
		}
		
		//5
		public double Change_amount
		{
			set
			{
				
				change_amt = value;
			}
			get
			{
				return change_amt;
			}
		}

		public string Tender_desc
		{
			set
			{
				
				tender_desc = value;
			}
			get
			{
				return tender_desc;
			}
		}

		public string Change_desc
		{
			set
			{
				
				change_desc = value;
			}
			get
			{
				return change_desc;
			}
		}

		public string Locale_language
		{
			set
			{
				
				locale_language = value;
			}
			get
			{
				return locale_language;
			}
		}

		public string Locale_country
		{
			set
			{
				
				locale_country  = value;
			}
			get
			{
				return locale_country;
			}
		}

		public string Data_capture
		{
			set
			{
				
				data_capture = value;
			}
			get
			{
				return data_capture;
			}
		}

		public int State
		{
			set
			{
				
				state = value;
			}
			get
			{
				return state;
			}
		}

        //2
        public int Pos_no
        {
            set
            {

                pos_no = value;
            }
            get
            {
                return pos_no;
            }
        }

		#endregion
		

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public DataSet LoadByTransid()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTransTenderByTransno");
			return resultSet;
		}


        public void UpdateState()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransTenderState");

        }
		


		#region IRelatableSet Members

		public DataSet ResultSet
		{
			get
			{
				return resultSet;
			}
			set
			{
				resultSet = value;
			}
		}

		#endregion
	
		public enum TenderTypes
		{
			CASH = 0,
			CREDIT = 1,
			DEBIT = 2,
			GIFT = 3,
			ALT_CURRENCY = 4,
			CHECK = 5,
			GIFT_CERTIFICATE = 6,
			COUPON = 7,
			NETS =8,
            CREDIT_ON_ACC = 9
		}

       // public enum States
       // {
       //     INCOMPLETE = 0,
       //     IN_PROGRESS = 1,
       //     COMPLETE = 2,
       //     SUSPEND = 3,
       //     VOID_SALE = 4,
       // 
       //  }
	
	}

    

	
}
