using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for ItemGroup.
	/// </summary>
	public class ItemGroup:IRelatableSet						
	{
		#region Variables
		private DataSet resultSet;
		private string organization_no;
		private string group_id;
		private string group_name;
		#endregion

		public ItemGroup()
		{
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

		public string Group_id
		{
			set
			{
				group_id= value;
			}
			get
			{
				return group_id;
			}
		}

		public string Group_name
		{
			set
			{
				group_name = value;
			}
			get
			{
				return group_name;
			}
		}

		#endregion


		

		public DataSet LoadByOrganization()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Load");
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
