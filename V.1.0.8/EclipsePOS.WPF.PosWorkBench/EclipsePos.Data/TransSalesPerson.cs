using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class TransSalesPerson : IRelatableSet	
    {

        #region Variables
        private DataSet resultSet;

        private int trans_no;
        private string organization_no;
        private string store_no;
        private int pos_no;
        private string employee_no;
        private int state;
     
        #endregion


        public TransSalesPerson()
		{
			resultSet = new DataSet();
		}

        public TransSalesPerson(DataRow dr)
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());
            this.Employee_no = dr["employee_no"].ToString();
			this.Organization_no = dr["organization_no"].ToString();
            this.Store_no = dr["store_no"].ToString();
            this.Pos_no = int.Parse(dr["pos_no"].ToString());

		}

		#region Properties

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

		public string Store_no
		{
			set
			{
				store_no= value;
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

        public string Employee_no
        {
            set
            {
                employee_no = value;
            }
            get
            {
                return employee_no;
            }
        }

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
        
       
        

		#endregion

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

        public void Delete()
        {

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "Delete");


        }

		public DataSet LoadByTransNo()
		{
			SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByTransNo");
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

    }

       

}
