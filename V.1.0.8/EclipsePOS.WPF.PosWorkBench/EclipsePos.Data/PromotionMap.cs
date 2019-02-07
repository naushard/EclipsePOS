using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PromotionMap.
	/// </summary>
	public class PromotionMap : IRelatableSet	
	{
        private string organization_no;
		private int promotion_no;
		private string promotion_map;
		private int map_type;
		private DataSet resultSet;

		public PromotionMap()
		{
			resultSet = new DataSet();
		}

		#region Properties

        //1
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

		//1
		public int Promotion_no
		{
			set
			{
				promotion_no = value;
			}
			get
			{
				return promotion_no;
			}
		}

		
		
		//2
		public string  Promotion_map
		{
			set
			{
				
				promotion_map = value;
			}
			get
			{
				return promotion_map;
			}
		}

		
		//3
		public int  Map_type
		{
			set
			{
				
				map_type = value;
			}
			get
			{
				return map_type;
			}
		}

	
		#endregion
		

		//public void Add()
		//{
		//	SqlRelator sr = new SqlRelator();
		//	sr.Relate(this, "AddRun");
        //
		//}

		public DataSet LoadByMap()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPromotionMapByMap");
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
