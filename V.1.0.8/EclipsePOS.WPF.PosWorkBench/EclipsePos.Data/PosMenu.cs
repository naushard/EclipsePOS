using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for MenuRoot.
	/// </summary>
	public class PosMenu : IRelatableSet	
	{
		private int menu_id;
		private int config_no;
		private int xpos;
		private int ypos;
		private int height;
		private int width;
		private int pix_width;
		private int pix_height;
		private string name;

		private DataSet resultSet; 

		public PosMenu()
		{
			resultSet = new DataSet();
		}
		
		#region Properties
	
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

		public int XPos
		{
			set 
			{
				xpos = value;
			}
			get 
			{
				return xpos;
			}
		
		}

		public int YPos
		{
			set 
			{
				ypos = value;
			}
			get 
			{
				return ypos;
			}
		
		}


		public int Height
		{
			set 
			{
				height = value;
			}
			get 
			{
				return height;
			}
		
		}

		public int Width
		{
			set 
			{
				width = value;
			}
			get 
			{
				return width;
			}
		
		}


		public int Pix_height
		{
			set 
			{
				pix_height = value;
			}
			get 
			{
				return pix_height;
			}
		
		}

		public int Pix_width
		{
			set 
			{
				pix_width = value;
			}
			get 
			{
				return pix_width;
			}
		
		}


		public string Name
		{
			set 
			{
				name = value;
			}
			get 
			{
				return name;
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



		public DataSet GetMenus()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadMenusByConfigNo");
			return resultSet;
			
		}
	}
}
