 using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class Employee:IRelatableSet
	{
        private string employee_no;
        private string organization_id;
        //private int employee_id;
		private string	logon_no;
		private string logon_pass;
		private string role_id;
		private string fname;
		private string lname;
		private string mi;
		private string ssn;
		private int sal_grade;
        private ArrayList roleEventNames;
        private DataSet resultSet;
		
		public Employee()
		{
			//
			// TODO: Add constructor logic here
			//
            roleEventNames = new ArrayList();
            resultSet = new DataSet();
		}

		#region Properties


        public string Employee_no
        {
            get { return employee_no; }
            set { employee_no = value; }
        }
        

        public string Organization_no
        {
            get { return organization_id; }
            set { organization_id = value; }
        }

		//1
	/*	public int Employee_id
		{
			set
			{
				employee_id = value;
			}
			get
			{
				return employee_id;
			}
		}
    */
		
		//2
		public string Logon_no
		{
			set
			{
				logon_no = value;
			}
			get
			{
				return logon_no;
			}
		}

		//3
		public string Logon_pass
		{
			set
			{
				
				logon_pass = value;
			}
			get
			{
				return logon_pass;
			}
		}

		//4
		public string Role_id
		{
			set
			{
				
				role_id = value;
			}
			get
			{
				return role_id;
			}
		}
		
		//5
		public string FName
		{
			set
			{
				
				fname = value;
			}
			get
			{
				return fname;
			}
		}

		//6
		public string  LName
		{
			set
			{
				
				lname = value;
			}
			get
			{
				return lname;
			}
		}

		//7
		public string  MI
		{
			set
			{
				
				mi = value;
			}
			get
			{
				return mi;
			}
		}

		//8
		public string  SSN
		{
			set
			{
				
				ssn = value;
			}
			get
			{
				return ssn;
			}
		}

		//9
		public int Sal_grade
		{
			set
			{
				
				sal_grade = value;
			}
			get
			{
				return sal_grade;
			}
		}

        public ArrayList RolesEventNames
        {
            get
            {
                return roleEventNames;
            }
        }


		#endregion
		
		/*public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}
        */

		public void LoadByLogon()
		{
			if ( logon_no.Length == 0 )
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "SelectByLogon");
			
		}


        public void LoadByEmployeeNo()
        {
           
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "SelectByEmployeeNo");

        }

        public DataSet LoadAllEmployees()
        {

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadAllEmployees");
            return this.resultSet;

        }


        public void Relations()
        {
            EmployeeRoleEvent role = new EmployeeRoleEvent();
            role.Role_id = this.Role_id;
            role.Organization_no = this.Organization_no;

            DataSet data  = role.Load();

            DataTable dt = data.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string eventName = dr["role_event_name"].ToString().Trim();
                roleEventNames.Add(eventName);
            }
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
