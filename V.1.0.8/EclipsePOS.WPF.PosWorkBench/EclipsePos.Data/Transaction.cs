 using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Trans.
	/// </summary>
	public class Transaction : IRelatableSet	
	{
        private int trans_no;
		private string store_no;
       // private int retail_store_group_no;
        private string organization_no;
		private int pos_no;
		private int drawer_no;
		private int config_no;
		private int trans_type;
		private int state;
		private int reason_code;
		private string customer_tax_id;
		private DateTime start_time;
		private DateTime complete_time;
		private string employee_login_no;
		private int carry_out;
		private int training_mode;
        private string table_name;
		private DateTime archive_date;
		private string  upload_session_no;
		private DateTime replication_date;


		private DataSet resultSet; 


		public Transaction(int transNo)
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();

			this.Trans_no = transNo;
			this.Store_no = "";
           // this.Retail_store_group_no = 0;
            this.Organization_no = "";
			this.Pos_no = 0;
			this.Drawer_no = 0;
			this.Config_no = 0;
			this.Trans_type = (int)Transaction.Types.SALES;
			this.State = (int)Transaction.Status.INCOMPLETE;
			this.Reason_code = 0;
			this.customer_tax_id = "";
			this.Start_time = System.DateTime.Now;//new DateTime(2006, 8, 3, 0, 0, 0);
			this.Complete_time = System.DateTime.Now; //new DateTime(2006, 8, 3, 0, 0, 0);
			this.employee_login_no = "";
			this.Carry_out =0;
			this.Training_mode = 0;
            this.table_name = "";
            this.Archive_date = System.DateTime.Now;  // new DateTime(2006, 8, 3, 0, 0, 0);
            this.Upload_session_no = "X";
            this.Replication_date = System.DateTime.Now;  //  new DateTime(2006, 8, 3, 0, 0, 0);
            this.Pos_no = 0;

			
		}
		#region Properties

		
		
		
		//2
		public int  Trans_no
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

		
		//3
		public string  Store_no
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

        
        //4
		public int  Pos_no
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
		
		//5
		public int Drawer_no
		{
			set
			{
				
				drawer_no = value;
			}
			get
			{
				return drawer_no;
			}
		}

		//5
		public int Config_no
		{
			set
			{
				
				config_no = value;
			}
			get
			{
				return config_no;
			}
		}

		//5
		public int Trans_type
		{
			set
			{
				
				trans_type = value;
			}
			get
			{
				return trans_type;
			}
		}

		//5
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

		//5
		public int Reason_code
		{
			set
			{
				
				reason_code = value;
			}
			get
			{
				return reason_code;
			}
		}

		//5
		public string Customer_tax_id
		{
			set
			{
				
				customer_tax_id = value;
			}
			get
			{
				return customer_tax_id;
			}
		}

		//5
		public DateTime Start_time
		{
			set
			{
				
				start_time = value;
			}
			get
			{
				return start_time;
			}
		}

		//5
		public DateTime Complete_time
		{
			set
			{
				
				complete_time = value;
			}
			get
			{
				return complete_time;
			}
		}

		//5
		public string Employee_login_no
		{
			set
			{
				
				employee_login_no = value;
			}
			get
			{
				return employee_login_no;
			}
		}

		//5
		public int Carry_out
		{
			set
			{
				
				carry_out = value;
			}
			get
			{
				return carry_out;
			}
		}

		//5
		public int Training_mode
		{
			set
			{
				
				training_mode = value;
			}
			get
			{
				return training_mode;
			}
		}

        //5
        public string Table_name
        {
            set
            {

                table_name = value;
            }
            get
            {
                return table_name;
            }
        }
		
		
		//5
		public DateTime Archive_date
		{
			set
			{
				
				archive_date = value;
			}
			get
			{
				return archive_date;
			}
		}

		public string Upload_session_no
		{
			set
			{
				
				upload_session_no = value;
			}
			get
			{
				return upload_session_no;
			}
		}

		
		public DateTime Replication_date
		{
			set
			{
				
				replication_date = value;
			}
			get
			{
				return replication_date;
			}
		}


		#endregion
		
 
	    public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public void UpdateState()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "UpdateTransState");
					
		}


		public void UpdateStateAndType()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "UpdateTransStateAndType");
 				
		}

		public void Load()
		{
			

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTransByTrans");
		}

        public DataSet LoadByStatus()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByState");
            return resultSet;

        }

        public DataSet LoadByTableAndState()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByTableAndState");
            return resultSet;

        }

        public DataSet LoadByStartDate()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByStartDate");
            return resultSet;

        }


        public void UpdateCustomer()
        {

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateCustomer");

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

		public enum Types
		{
			SALES = 1,
			LOGON = 2,
			LOGOFF = 3,
			RETURN = 4,
			BALANCE = 5,
			COUNT = 6,
			ADJUSTMENT = 7,
            DINE_IN = 8,
            CARRY_OUT = 9,
            PAID_IN = 10,
            PAID_OUT = 11,
            LOAN = 12,
            PETTY_CASH_IN = 13,
            PETTY_CASH_OUT = 14,
            BANK_IN = 15,
            PICKUP = 16
			
		}

		public enum Status 
		{
			INCOMPLETE = 0,
			IN_PROGRESS = 1,
			COMPLETE = 2,
			SUSPEND = 3,
			VOIDED = 4
		}


	}
}
