using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Trans_total.
	/// </summary>
	public class TransTotal : IRelatableSet	
	{
		private int trans_id;
		private int seq_no;
        private int pos_no;
		private int total_type;
		private decimal amount;
		private string total_desc;

		private DataSet resultSet; 

		public TransTotal()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}
		
		
		#region Properties

		//1
		public int Trans_id
		{
			set
			{
				trans_id = value;
			}
			get
			{
				return trans_id;
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

		
		//3
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

		//4
		public decimal Amount
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
		public string Total_desc
		{
			set
			{
				
				total_desc = value;
			}
			get
			{
				return total_desc;
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


		public DataSet LoadDialogByConfigNo()
		{
			

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialogByConfigNo");
			return resultSet;
					
		}


		public void LoadDialogByDialogName()
		{
			

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialogByDialogName");
			// return resultSet;
				
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
	}
}
