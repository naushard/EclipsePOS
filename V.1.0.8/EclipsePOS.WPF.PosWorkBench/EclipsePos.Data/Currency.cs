using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Currency.
	/// </summary>
	public class Currency:IRelatableSet		
	{

		private DataSet resultSet;

        private string home_currency;
		private string source_currency;
		private double conversion_rate;
		private DateTime rate_date;
        private DateTime date_match;
        private int rate_operator;
        private double spread;
		

		public Currency()
		{
			resultSet = new DataSet();
		}

		#region Properties

        public string Home_currency
        {
            set
            {
                home_currency = value;
            }
            get
            {
                return home_currency;
            }
        }

		public string Source_currency
		{
			set
			{
				source_currency= value;
			}
			get
			{
				return source_currency;
			}
		}

		public double Spread
		{
			set
			{
				spread= value;
			}
			get
			{
				return spread;
			}
		}

		public double Conversion_rate
		{
			set
			{
				conversion_rate = value;
			}
			get
			{
				return conversion_rate;
			}
		}

		
					

		public DateTime Rate_date
		{
			set
			{
				rate_date = value;
			}
			get
			{
				return rate_date;
			}
		}

        public DateTime Date_match
        {
            set
            {
                date_match = value;
            }
            get
            {
                return date_match;
            }
        }

        public int Rate_operator
        {
            set
            {
                rate_operator = value;
            }
            get
            {
                return rate_operator;
            }
        }



		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public void LoadByCurrencyCodeId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadCurrencyByCurrencyCodeId");

		}


		/*public DataSet LoadTotalByTotalid()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTotalByTotalId");
			return resultSet;
					
		}
		*/ 

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
