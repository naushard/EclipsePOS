using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for MenuPanels.
	/// </summary>
	public class MenuPanels :IRelatableSet	
	{
		private int config_no;
		private int panel_id;
        private string panel_name;
		private string panel_class_name;
		
		private DataSet resultSet; 

		public MenuPanels()
		{
			resultSet = new DataSet();
		}

		#region Properties
	
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

		public int Panel_id
		{
			set 
			{
				panel_id = value;
			}
			get 
			{
				return panel_id;
			}
		
		}

        public string Panel_name
        {
            set
            {
                panel_name = value;
            }
            get
            {
                return panel_name;
            }

        }
		
		public string Panel_class_name
		{
			set 
			{
				panel_class_name = value;
			}
			get 
			{
				return panel_class_name;
			}
		
		}

		#endregion


		/*public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}
        */


		public DataSet GetMenuPanels()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadMenuPanels");
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
