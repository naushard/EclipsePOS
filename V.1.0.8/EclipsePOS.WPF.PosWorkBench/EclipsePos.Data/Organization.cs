using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Organization.
	/// </summary>
	public class Organization:IRelatableSet
	{

		#region Variables
		private DataSet resultSet;
		private string organization_no;
		private string organization_name;
		private string address1;
		private string address2;
		private string address3;
		private string address4;
        private string city;
        private string state;
        private string postal_code;
        private string country;
        private string phone;
        private string fax;
        private string contact;
        private string home_currency;
        private string tax_number;

        private int pos_shipment_code_length;
        private string pos_shipment_prefix;
        private double pos_shipment_next_number;
	
	
	
		
		#endregion


		public Organization()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties

		public string Organization_no
		{
			set
			{
				organization_no= value;
			}
			get
			{
				return organization_no;
			}
		}

		public string Organization_name
		{
			set
			{
				organization_name= value;
			}
			get
			{
				return organization_name;
			}
		}

		public string Address1
		{
			set
			{
				address1 = value;
			}
			get
			{
				return address1;
			}
		}

		public string Address2
		{
			set
			{
				address2 = value;
			}
			get
			{
				return address2;
			}
		}


		public string Address3
		{
			set
			{
				address3 = value;
			}
			get
			{
				return address3;
			}
		}

		public string Address4
		{
			set
			{
				address4 = value;
			}
			get
			{
				return address4;
			}
		}

        public string City
        {
            set
            {
                city = value;
            }
            get
            {
                return city;
            }
        }

        public string State
        {
            set
            {
                state = value;
            }
            get
            {
                return state;
            }
        }

        public string Postal_code
        {
            set
            {
                postal_code = value;
            }
            get
            {
                return postal_code;
            }
        }

        public string Country
        {
            set
            {
                country = value;
            }
            get
            {
                return country;
            }
        }

        public string Phone
        {
            set
            {
                phone = value;
            }
            get
            {
                return phone;
            }
        }

        public string Fax
        {
            set
            {
                fax = value;
            }
            get
            {
                return fax;
            }
        }


        public string Contact
        {
            set
            {
                contact = value;
            }
            get
            {
                return contact;
            }
        }

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

        public string Tax_number
        {
            set
            {
                tax_number = value;
            }
            get
            {
                return tax_number;
            }
        }


       

        public int Pos_shipment_code_length
        {
            set
            {
                pos_shipment_code_length = value;
            }
            get
            {
                return pos_shipment_code_length;
            }
        }


        public string Pos_shipment_prefix
        {
            set
            {
                pos_shipment_prefix  = value;
            }
            get
            {
                return pos_shipment_prefix;
            }
        }

        public double Pos_shipment_next_number
        {
            set
            {
                pos_shipment_next_number = value;
            }
            get
            {
                return  pos_shipment_next_number;
            }
        }

		#endregion

		

		public DataSet LoadByOrganizationNo()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Load");
			return resultSet;
		}


		
		
		public void Save()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "SaveOrganizationByOrganizationId");
					
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
