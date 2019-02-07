using System;
using System.Collections;
using System.Data;
using System.Diagnostics;

using EclipsePos.Data;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for Filters.
	/// </summary>
	public class Filters:ArrayList 
	{
		public Filters(int filterType):base()
		{
			InputFilter filter = new InputFilter();
			filter.Filter_type = filterType;
			DataSet data  = filter.LoadAllByFilterType();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				InputFilter inputFilter2 = new InputFilter();
				inputFilter2.Filter_id = int.Parse(dr["filter_id"].ToString());
				inputFilter2.Filter_type = int.Parse(dr["filter_type"].ToString());
				inputFilter2.Filter_sub_type = int.Parse(dr["filter_sub_type"].ToString());
				inputFilter2.Filter_name = dr["filter_name"].ToString();
				inputFilter2.Display_name = dr["display_name"].ToString();
				inputFilter2.Regex = dr["regex"].ToString();
				inputFilter2.Check_digit_class = dr["check_digit_class"].ToString();
				inputFilter2.Filter_class = dr["filter_class"].ToString();
				Filter filter2 = new Filter(inputFilter2);
				this.Add(filter2);
			}
		}

		/*public Filter GetFilter(int index)
		{
			return this[index] as Filters;
		}*/
	}
}
