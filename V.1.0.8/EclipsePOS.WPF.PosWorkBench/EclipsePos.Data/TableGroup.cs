using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class TableGroup : IRelatableSet	
    {
        private DataSet resultSet;

        private string organization_id;
        private string store_no;
        private int table_group_no;
        private string table_group_name;

        public TableGroup()
		{
			resultSet = new DataSet();
		}

		#region Properties

        public string Store_no
        {
            set
            {
                store_no = value;
            }
            get
            {
                return store_no;
            }
        }

		public string Organization_no
		{
			set
			{
				organization_id= value;
			}
			get
			{
				return organization_id;
			}
		}

		public int Table_group_no
		{
			set
			{
				table_group_no= value;
			}
			get
			{
				return table_group_no;
			}
		}

		public String  Table_group_name
		{
			set
			{
				table_group_name = value;
			}
			get
			{
				return table_group_name;
			}
		}

		

		#endregion


		
		public DataSet LoadTableGroup()
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
