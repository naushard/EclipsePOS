using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for MenuConfig.
	/// </summary>
	public class MenuConfig :IRelatableSet	
	{
        private int config_no;
		private int menu_id ;
        private string menu_name;
		private int left_panel_id;
        private int right_panel_id;
		private int bottom_panel_id;
		 
		
		private DataSet resultSet; 

		public MenuConfig()
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
		
		public int Menu_id
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

		public int Left_panel_id
		{
			set 
			{
				left_panel_id = value;
			}
			get 
			{
				return left_panel_id;
			}

		
		}



        public int Right_panel_id
        {
            set
            {
                right_panel_id = value;
            }
            get
            {
                return right_panel_id;
            }


        }

        public int Bottom_panel_id
        {
            set
            {
                bottom_panel_id = value;
            }
            get
            {
                return bottom_panel_id;
            }


        }

		#endregion
        /*
		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}
        */


		public DataSet Load()
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
