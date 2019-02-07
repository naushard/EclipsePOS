using System;
using System.Data;
using System.Diagnostics;
using System.Collections;



namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosTotal.
	/// </summary>
	public class PosTotal :IRelatableSet		
	{
		private DataSet resultSet;
        private int total_name;
		private int sequence_no;
		private string store_no;
        private string organization_no;
		private int pos_no;
		private int emp_id;
		private int drawer_no;
        private DateTime start_date;
        private DateTime end_date;
		private ArrayList arrayList;
        private int start_receipt_no;
        private int end_receipt_no;
		

		public PosTotal()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
			arrayList = new ArrayList();
		}

		#region Properties

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
		
		public int Emp_id
		{
			set
			{
				emp_id = value;
			}
			get
			{
				return emp_id;
			}
		}

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

        public int Start_receipt_no
        {
            set
            {
                start_receipt_no = value;
            }
            get
            {
                return start_receipt_no;
            }
        }

        public int End_receipt_no
        {
            set
            {
                end_receipt_no = value;
            }
            get
            {
                return end_receipt_no;
            }
        }


        public DateTime Start_date
        {
            set
            {
                start_date = value;
            }
            get
            {
                return start_date;
            }
        }

        public DateTime End_date
        {
            set
            {
                end_date = value;
            }
            get
            {
                return end_date;
            }
        }

		public ArrayList Totals
		{
			set
			{
				arrayList = value;
			}
			get
			{
				return arrayList;  
			}
		}
		
		#endregion

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

		public void Load()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPosTotal");
        }


        /* Update the end_date with current date and time */

        public void UpdateEndDate(string org_no, string sto_no, int p_no, int tot_name)
        {
            this.Organization_no = org_no;
            this.Store_no = sto_no;
            this.Pos_no = p_no;
            this.Total_name = tot_name;

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdatePosTotalEndDate");
        
        }


		public void Relations()
		{
            arrayList.Clear();
			
            this.Load();

			Total total = new Total();
            total.Organization_no = this.Organization_no;
            total.Store_no = this.Store_no;
            total.Pos_no = this.Pos_no; 
            total.Sequence_no = this.Sequence_no;
            total.Total_name = this.Total_name;

			DataSet data = total.LoadTotalByTotalid();
			
            
            DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				Total total2 = new Total();
				total2.Total_name = int.Parse(dr["total_name"].ToString());
				total2.Sequence_no = int.Parse(dr["sequence_no"].ToString());
                total2.Organization_no = dr["organization_no"].ToString();
                total2.Store_no = dr["store_no"].ToString();
                total2.Pos_no = int.Parse(dr["pos_no"].ToString());
				total2.Total_type =	int.Parse(dr["total_type"].ToString());
				total2.Total_count = int.Parse(dr["total_count"].ToString());
				total2.Total_amount = double.Parse(dr["total_amount"].ToString());
				arrayList.Add(total2);
			}


		}

	}
}
