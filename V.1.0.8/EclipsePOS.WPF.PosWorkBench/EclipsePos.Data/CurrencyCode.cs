using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class CurrencyCode : IRelatableSet	
    {
        private DataSet resultSet;

        private string currency_code;
		private string currency_name;
		private string symbol;
		private int decimals;
        private int symbol_position;
        private string thousand_seperator;
        private string decimal_seperator;
		private int  negative_display;
        private int pos_key_number;

		public CurrencyCode()
		{
			resultSet = new DataSet();
		}

		#region Properties

        public string Currency_code
        {
            set
            {
                currency_code = value;
            }
            get
            {
                return currency_code;
            }
        }

		public string Currency_name
		{
			set
			{
				currency_name= value;
			}
			get
			{
				return currency_name;
			}
		}

		public string Symbol
		{
			set
			{
				symbol= value;
			}
			get
			{
				return symbol;
			}
		}

		public int Decimals
		{
			set
			{
				decimals = value;
			}
			get
			{
				return decimals;
			}
		}

		
					

		public int Symbol_position
		{
			set
			{
				symbol_position = value;
			}
			get
			{
				return symbol_position;
			}
		}

        public string Thousand_seperator
        {
            set
            {
                thousand_seperator = value;
            }
            get
            {
                return thousand_seperator;
            }
        }

        public string Decimal_seperator
        {
            set
            {
                decimal_seperator = value;
            }
            get
            {
                return decimal_seperator;
            }
        }

        public int Negative_display
		{
			set
			{
				negative_display = value;
			}
			get
			{
				return negative_display;
			}
		}


        public int Pos_key_number
		{
			set
			{
				pos_key_number = value;
			}
			get
			{
				return pos_key_number;
			}
		}


		#endregion


		
		public void LoadCurrencyCodeByPosKey()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadCurrencyCodeByPosKey");

		}


        public void LoadByCurrencyCode()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByCurrencyCode");

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
