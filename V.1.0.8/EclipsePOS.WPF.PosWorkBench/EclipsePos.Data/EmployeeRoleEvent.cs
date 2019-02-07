using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosProfileEvent.
	/// </summary>
	public class EmployeeRoleEvent: IRelatableSet	
	{
		#region Variables
		
        private int role_event_id;
		private string role_id;
		private string role_event_name;
        private string organization_no;

		private DataSet resultSet;

		#endregion

		public EmployeeRoleEvent()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties
	
	/*	public int Role_event_id
		{
			set 
			{
				role_event_id = value;
			}
			get 
			{
				return role_event_id;
			}
		}
     * */
		
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

		
		public string Role_event_name
		{
			set 
			{
				role_event_name = value;
			}
			get 
			{
				return role_event_name;
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

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}



		public DataSet Load()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Load");
			return resultSet;
			
		}

		public void Remove()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Remove");
		}

		public void Save()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Save");
		}


	}
}
