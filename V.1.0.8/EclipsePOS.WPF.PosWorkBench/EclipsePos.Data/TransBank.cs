using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for TransBank.
	/// </summary>
	public class TransBank :IRelatableSet		
	{
		private int trans_no;
		private int seq_no;
        private string store_no;
        private string organization_no;
		private int pay_type;
		private int deposit_no;
		private int state;
		private int drawer_no;
		private string bank_desc;
		private string locale_language;
		private string locale_country;
		private double amount;
        private int pos_no;
		private DataSet resultSet;

		public TransBank()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

        public TransBank(DataRow dr):this()
		{
            this.Trans_no = int.Parse(dr["trans_no"].ToString());
            this.Seq_no = int.Parse(dr["seq_no"].ToString());
            this.Store_no = dr["store_no"].ToString();
            this.Organization_no = dr["organization_no"].ToString();
            this.Pos_no = int.Parse( dr["pos_no"].ToString());
            this.Pay_type = int.Parse(dr["pay_type"].ToString());
            this.Deposit_no = int.Parse(dr["deposit_no"].ToString());
            this.State = int.Parse(dr["state"].ToString() );
            this.Drawer_no = int.Parse(dr["drawer_no"].ToString());
            this.Bank_desc = dr["bank_desc"].ToString();
            this.Locale_language = dr["locale_language"].ToString();
            this.Locale_country = dr["locale_country"].ToString();
            this.Amount = double.Parse(dr["Amount"].ToString());
			
        }

		#region Properties
	
		public int Trans_no
		{
			set 
			{
				trans_no= value;
			}
			get
			{
				return trans_no;
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


		public int Seq_no
		{
			set 
			{
				seq_no= value;
			}
			get
			{
				return seq_no;
			}
		}

		public int Pay_type
		{
			set 
			{
				pay_type =  value;
			}
			get
			{
				return pay_type;
			}
		}

		public int Deposit_no
		{
			set 
			{
				deposit_no= value;
			}
			get
			{
				return deposit_no;
			}
		}

		public int State
		{
			set 
			{
				state= value;
			}
			get
			{
				return state;
			}
		}

		public int Drawer_no
		{
			set 
			{
				drawer_no= value;
			}
			get
			{
				return drawer_no;
			}
		}

		public string Bank_desc
		{
			set 
			{
				bank_desc= value;
			}
			get
			{
				return bank_desc;
			}
		}

		public string Locale_language
		{
			set 
			{
				locale_language= value;
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
				locale_country= value;
			}
			get
			{
				return locale_country;
			}
		}

		public double Amount
		{
			set 
			{
				amount= value;
			}
			get
			{
				return amount;
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

		public DataSet LoadByTransid()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTransBankByTransno");
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

        public enum States
        {
            INCOMPLETE = 0,
            IN_PROGRESS = 1,
            COMPLETE = 2,
            SUSPEND = 3,
            VOID_SALE = 4,

        }


	}

   
}
