using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Tax.
	/// </summary>
	public class Tax: IRelatableSet		
	{
		private DataSet resultSet; 
		private int tax_id;
		private string tax_group_id;
        private string organization_no;
		private int tax_type;
		private string short_desc;
		private double rate;
		private double alt_rate;
		
		public Tax()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties

		//1
		public int Tax_id
		{
			set
			{
				tax_id = value;
			}
			get
			{
				return tax_id;
			}
		}

		
		
		//2
		public string  TaxGroupId
		{
			set
			{
				
				tax_group_id = value;
			}
			get
			{
				return tax_group_id;
			}
		}

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

		
		//3
		public int  TaxType
		{
			set
			{
				
				tax_type = value;
			}
			get
			{
				return tax_type;
			}
		}

		//4
		public string ShortDesc
		{
			set
			{
				
				short_desc = value;
			}
			get
			{
				return short_desc;
			}
		}
		
		//5
		public double  Rate
		{
			set
			{
				
				rate = value;
			}
			get
			{
				return rate;
			}
		}
		
		//6
		public double AltRate
		{
			set
			{
				
				alt_rate = value;
			}
			get
			{
				return alt_rate;
			}
		}

		#endregion
		

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public DataSet LoadTaxByGroup()
		{
			if ( string.IsNullOrEmpty(tax_group_id) )
			{
				return null;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTaxByTaxGroupId");
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
