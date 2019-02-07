using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for InputFilter.
	/// </summary>
	public class InputFilter:IRelatableSet	
	{
		public const int MSR = 1;
		public const int EAN_UPC = 2;

		public const int MASTER_CARD = 1;
		public const int VISA = 2;
		public const int DISCOVER = 3;
		public const int AMEX = 4;

		public const int EAN = 1;
		public const int UPC = 2;

		private DataSet resultSet;

		private int filter_id;
		private int filter_type;
		private int filter_sub_type;
		private string filter_name;
		private string display_name;
		private string regex;
		private string check_digit_class;
		private string filter_class;
		private ArrayList fields;
	
		public InputFilter()
		{
			resultSet = new DataSet();
		}

		#region Properties

		public int Filter_id
		{
			set
			{
				filter_id = value;
			}
			get
			{
				return filter_id;
			}
		}

		public int Filter_type
		{
			set
			{
				filter_type = value;
			}
			get
			{
				return filter_type;
			}
		}

		public int Filter_sub_type
		{
			set
			{
				filter_sub_type = value;
			}
			get
			{
				return filter_sub_type;
			}
		}

		public string Filter_name
		{
			set
			{
				filter_name =  value;
			}
			get
			{
				return filter_name;
			}
		}

		public string Display_name
		{
			set
			{
				display_name =  value;
			}
			get
			{
				return display_name;
			}
		}


		public string Regex
		{
			set
			{
				regex = value;
			}
			get
			{
				return regex;
			}
		}


		public string Check_digit_class
		{
			set
			{
				check_digit_class = value;
			}
			get
			{
				return check_digit_class ;
			}
		}
		
		public string Filter_class
		{
			set
			{
				filter_class = value;
			}
			get
			{
				return filter_class;
			}
		}

		public ArrayList Fields
		{
			set
			{
				fields = value;
			}
			get
			{
				return fields;
			}
		}

		
		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public DataSet LoadAllByFilterType()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAllByFilterType");
			return resultSet;
		}
		
		public void Relations()
		{
			if (this.Filter_id == 0) return;
			
			ArrayList arrayList = new ArrayList(); 

			InputFilterField field1 = new InputFilterField();
			field1.Filter_id = this.Filter_id; 
			DataSet data = field1.LoadAllByFilterId();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				InputFilterField field2 = new InputFilterField();
				field2.Filter_id = this.Filter_id;
				field2.Sequence_no = int.Parse(dr["sequence_no"].ToString());
				field2.Name = dr["name"].ToString();
				
				arrayList.Add(field2);
			}

			this.Fields = arrayList;

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
