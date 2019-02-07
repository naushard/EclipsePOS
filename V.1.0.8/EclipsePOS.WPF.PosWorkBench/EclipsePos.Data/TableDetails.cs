using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class TableDetails : IRelatableSet	
    {
        private DataSet resultSet;

        private string organization_id;
        private string store_no;
        private int table_group_no;
        private int table_no;
        private string table_name;
        private int display_row_no;
        private int display_column_no;
        private int number_of_guests;
        private string picture_name;



        public TableDetails()
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
                table_group_no = value;
            }
            get
            {
                return table_group_no;
            }
        }

		public int Table_no
		{
			set
			{
				table_no= value;
			}
			get
			{
				return table_no;
			}
		}

		public String  Table_name
		{
			set
			{
				table_name = value;
			}
			get
			{
				return table_name;
			}
		}

        public int Display_row_no
        {
            set
            {
                display_row_no = value;
            }
            get
            {
                return display_row_no;
            }
        }

        public int Displays_column_no
        {
            set
            {
                display_column_no = value;
            }
            get
            {
                return display_column_no;
            }
        }

        public int Number_of_guests
        {
            set
            {
                number_of_guests = value;
            }
            get
            {
                return number_of_guests;
            }
        }

        public string Picture_name
        {
            set
            {
                picture_name = value;
            }
            get
            {
                return picture_name;
            }
        }

		

		#endregion


		
		
        public DataSet LoadTable()
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
