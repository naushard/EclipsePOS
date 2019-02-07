using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for SubMenu.
	/// </summary>
	public class SubMenu : IRelatableSet	
	{
		private int sub_menu_id;
		private int menu_id;
		private string sub_menu_name;
		private DataSet resultSet; 
 
		public SubMenu()
		{
			resultSet = new DataSet();
		}

		#region Properties
	
		public int Sub_Menu_ID
		{
			set 
			{
				sub_menu_id = value;
			}
			get 
			{
				return sub_menu_id;
			}
		}
		
		public int Menu_ID
		{
			set 
			{
				menu_id = value;
			}
			get 
			{
				return menu_id;
			}
		
		}

		public string Sub_Menu_Name
		{
			set 
			{
				sub_menu_name = value;
			}
			get 
			{
				return sub_menu_name;
			}
		
		}

		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}



		public DataSet GetSubMenus()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadSubMenus");
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
