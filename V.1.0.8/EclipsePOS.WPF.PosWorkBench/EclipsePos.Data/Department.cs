using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Department.
	/// </summary>
	public class Department:IRelatableSet	
	{

		#region Variables
		private DataSet resultSet;
		private string organization_no;
		private string department_id;
		private string department_name;
		#endregion


		public Department()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
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

		public string Department_id
		{
			set
			{
				department_id= value;
			}
			get
			{
				return department_id;
			}
		}

		public string Department_name
		{
			set
			{
				department_name = value;
			}
			get
			{
				return department_name;
			}
		}

		#endregion

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public DataSet LoadByConfigNo()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAllByConfigNo");
			return resultSet;
		}


		public void LoadByDepartmentId()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDepartmentByDepartmentId");
					
		}

		public void DeleteByDepartmentId()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "DeleteDepartmentByDepartmentId");
					
		}
		
		public void Save()
		{
			if (this.department_id.Length == 0) return;

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "SaveDepartmentByDepartmentId");
					
		}
		 

		public void Remove()
		{
			if (this.department_id.Length == 0) return;

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "DeleteDepartmentByDepartmentId");
					
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
