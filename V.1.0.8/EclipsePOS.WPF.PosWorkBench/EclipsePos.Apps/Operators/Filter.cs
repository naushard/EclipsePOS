using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
//using System.Windows.Forms;

using EclipsePos.Data;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for Filter.
	/// </summary>
	public class Filter
	{

		#region Constants

		// MSR/Credit Card keys

		/** Display name for filter, example: Visa */
		public const string DISPLAY_NAME = "DisplayName";
		/** Application filter name */
		public const string FILTER_NAME = "FilterName";
		/** Account number key */
		public const string ACCT_NO = "AccountNum";
		/** Expiration year key */
		public const string EXPR_YEAR = "ExprYear";
		/** Expiration month key */
		public const string EXPR_MONTH = "ExprMonth";
		/** Card holder Surname key */
		public const string SURNAME = "SurName";
		/** Card holder first name key */
		public const string FIRSTNAME = "FirstName";

		// UPC/EAN keys

		/** Upc filter key */
		public const string UPC_TYPE = "UpcType";
		/** Upc Manufacturer key */
		public const string UPC_MANUFACTURER = "UpcManufacturer";
		/** Upc Product Code key */
		public const string UPC_PRODUCT_CODE = "UpcProductCode";
		/** Upc Check Digit key */
		public const string UPC_CHECK_DIGIT = "UpcCheckDigit";

		/** Parse succeeded. */
		public const int PARSE_OK = 0;
		/** Check digit application failed. */
		public const int CHECKDIGIT_FAILED = 1;

		#endregion 



		#region Variables

		private int filterType;
		private int filterSubType;
		private InputFilter inputFilter;
		private string regex;
		private string filterName;
		private CheckDigit checkDigit;
		
		#endregion 
		
		
		#region Constructor
		public Filter(InputFilter f)
		{
			this.inputFilter = f;
			regex = inputFilter.Regex;
			filterName = inputFilter.Filter_name;
			filterType = inputFilter.Filter_type;
			filterSubType = inputFilter.Filter_sub_type;
			if ( inputFilter.Check_digit_class.Trim().Length > 0 )
			{
				try
				{
					checkDigit = Assembly.GetExecutingAssembly().CreateInstance(inputFilter.Check_digit_class) as CheckDigit;
				}
				catch
				{
				}
			}

		}
		#endregion

		public int Apply(string s, Hashtable result)
		{
		
			Regex r = new Regex(regex);
			Match match = r.Match(s);
			if (match.Success)
			{

				if (result != null)
				{
					result.Add(Filter.FILTER_NAME, inputFilter.Filter_name);
					result.Add(Filter.DISPLAY_NAME, inputFilter.Display_name);
				}
				
				inputFilter.Relations();
				ArrayList inputfilterFilds = inputFilter.Fields;

				GroupCollection gc = match.Groups;
				int i =1;
				foreach(Group g in gc)
		 		{
					if (g.Index>0)
					{
						InputFilterField  fields = inputFilter.Fields[i++] as InputFilterField;
						result.Add(fields.Name.Trim(), g.Value);
					}

				}

			}
	
			return Filter.PARSE_OK; 
		}




		#region Properties

		public int FilterType
		{
			get
			{
				return filterType;
			}
			set
			{
				filterType=value;
			}
		}

		public int FilterSubType
		{
			get
			{
				return filterSubType;
			}
			set
			{
				filterSubType=value;
			}
		}
		
		#endregion

	}

}
