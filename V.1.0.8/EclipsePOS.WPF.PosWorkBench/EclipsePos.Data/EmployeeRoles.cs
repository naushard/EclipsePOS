using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosProfile.
	/// </summary>
	public class EmployeeRoles: IRelatableSet				
	{
		
		#region Variables
		
        private string role_id;
		private string organization_no;
		private string role_name;
	
        private DataSet resultSet;
		#endregion


		public EmployeeRoles()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties
	
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

		
		public string Role_name
		{
			set 
			{
				role_name = value;
			}
			get 
			{
				return role_name;
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
			sr.Relate(this, "LoadByRoleId");
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
