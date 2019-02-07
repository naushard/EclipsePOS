using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosKey.
	/// </summary>
	public class PosKey : IRelatableSet	
	{

		private int key_id;
		private int	config_no;
        private int panel_id;
		private string key_text;
		private int key_type;
		private int key_val;
		private int key_code;
		private int device_type;
		private int x_loc;
		private int y_loc;
		private int key_height;
		private int key_width;
		private int fg_color;
		private int bg_color;
		private int attr;
		private string flags;
		private int logout_disable;
		private string key_class;
		private string param;
		private string image;

		private DataSet resultSet; 

		public PosKey()
		{

			resultSet = new DataSet();
		}

		#region Properties

		//1
		public int Key_ID
		{
			set
			{
				key_id = value;
			}
			get
			{
				return key_id;
			}
		}

		
		//2
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

        //2
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


		//3
		public string Key_Text
		{
			set
			{
				
				key_text = value;
			}
			get
			{
				return key_text;
			}
		}

		//4
		public int Key_Type
		{
			set
			{
				
				key_type = value;
			}
			get
			{
				return key_type;
			}
		}

		public int Key_Val
		{
			set
			{
				
				key_val = value;
			}
			get
			{
				return key_val;
			}
		}

		public int Key_Code
		{
			set
			{
				
				key_code = value;
			}
			get
			{
				return key_code;
			}
		}

		public int Device_Type
		{
			set
			{
				
				device_type = value;
			}
			get
			{ 
				return device_type;
			}
		}
		
		//5
		public int X_Loc
		{
			set
			{
				
				x_loc = value;
			}
			get
			{
				return x_loc;
			}
		}

		//6
		public int  Y_Loc
		{
			set
			{
				
				y_loc = value;
			}
			get
			{
				return y_loc;
			}
		}

		//7
		public int  Key_Height
		{
			set
			{
				
				key_height = value;
			}
			get
			{
				return key_height;
			}
		}

		//8
		public int  Key_Width
		{
			set
			{
				
				key_width = value;
			}
			get
			{
				return key_width;
			}
		}

		//9
		public int Fg_Color
		{
			set
			{
				
				fg_color = value;
			}
			get
			{
				return fg_color;
			}
		}

		public int Bg_Color
		{
			set
			{
				
				bg_color = value;
			}
			get
			{
				return bg_color;
			}
		}
		
		public int Attr
		{
			set
			{
				
				attr = value;
			}
			get
			{
				return attr;
			}
		}

		public string Flags
		{
			set
			{
				
				flags = value;
			}
			get
			{
				return flags;
			}
		}

		public int Logout_Disable
		{
			set
			{
				
				logout_disable = value;
			}
			get
			{
				return logout_disable;
			}
		}

		public string Key_Class
		{
			set
			{
				
				key_class = value;
			}
			get
			{
				return key_class;
			}
		}

		public string Param
		{
			set
			{
				
				param = value;
			}
			get
			{
				return param;
			}
		}

		public string Image
		{
			set
			{
				
				image = value;
			}
			get
			{
				return image;
			}
		}



		#endregion
	
	
		



		public DataSet LoadBySubMenu()
		{			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPosKeyByPanelID");
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
