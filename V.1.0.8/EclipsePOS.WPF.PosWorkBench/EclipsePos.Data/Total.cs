using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Total.
	/// </summary>
	public class Total:IRelatableSet	
	{

		private DataSet resultSet;

		private string organization_no;
        private string store_no;
        private int pos_no;
        private int sequence_no;
        private int total_name;
		private int total_type;
		private int total_count;
		private double total_amount;
	

		public Total()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties

		public int Sequence_no
		{
			set
			{
				sequence_no = value;
			}
			get
			{
				return sequence_no;
			}
		}

        public int Total_name
        {
            set
            {
                total_name = value;
            }
            get
            {
                return total_name;
            }
        }

		public string Organization_no
		{
			set
			{
				organization_no= value;
			}
			get
			{
				return organization_no;
			}
		}

        


		public int Total_type
		{
			set
			{
				total_type = value;
			}
			get
			{
				return total_type;
			}
		}

		public int Total_count
		{
			set
			{
				total_count =  value;
			}
			get
			{
				return total_count;
			}
		}
		public double Total_amount
		{
			set
			{
				total_amount= value;
			}
			get
			{
				return total_amount;
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

		public DataSet LoadTotalByTotalid()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTotalByTotalId");
			return resultSet;
					
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
	
		public  void AddToTotal(string organization_no, string storeno, int posno, EclipsePos.Data.TotalName totalName,  EclipsePos.Data.TotalType totaltype, double amount)
		{
            this.Organization_no = organization_no;
			this.Store_no = storeno;
			this.Pos_no = posno;
			this.Total_type = (int)totaltype;
            this.Total_name = (int)totalName;
			this.Total_amount = amount;

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddToTotal");
		
		}

        public void AddToCardTotal(string organization_no, string storeno, int posno, EclipsePos.Data.TotalName totalName, int totaltype, double amount)
        {
            this.Organization_no = organization_no;
            this.Store_no = storeno;
            this.Pos_no = posno;
            this.Total_type = totaltype;
            this.Total_name = (int)totalName;
            this.Total_amount = amount;

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "AddToTotal");

        }


        public void AddToTotalAndCount(string organization_no, string storeid, int posno, EclipsePos.Data.TotalName totalName,  EclipsePos.Data.TotalType totaltype, double amount, int count)
		{
            this.Organization_no = organization_no;
			this.Store_no = storeid;
			this.Pos_no = posno;
			this.Total_type = (int)totaltype;
            this.Total_name = (int)totalName;
			this.Total_amount = amount;
			this.Total_count = count;

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddToTotalAndCount");

		}
      

		public void Delete()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "DeleteRun");
		}

	}


    public enum TotalType
    {
        CASH_SALES = 1,
        TAXABLE = 3,
        NON_TAXABLE = 4,
        VOID = 5,
        RETURN = 6,
        RCVD_ON_ACCT = 8,
        PAID_IN = 9,
        PAID_OUT = 10,
        PICK_UP = 12,
        CASH_BACK = 7,

        CASH_IN_DRAWER = 20,

        LOAN = 21,
        DEBIT = 22,
        GIFT_CERTIFICATE = 23,
        CHECK = 24,
        CHECK_IN_DRAWER = 25,
        COUPON = 26,
        DEBT = 27,


        CREDIT_CARD_BASE = 100,
        DEPARTMENT_BASE = 200,
        ALT_CURRENCY_BASE = 300,

        DAILY_BASE = 0,
        WEEKLY_BASE = 1000,
		MONTHLY_BASE = 2000,
		YEARLY_BASE = 3000
    }
        

    public enum TotalName
    {
        DAILY_BASE = 1,
        WEEKLY_BASE = 2,
		MONTHLY_BASE = 3,
		YEARLY_BASE = 4
	}

    
}
