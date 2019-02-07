using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class Customer : IRelatableSet
    {

        #region Variables
		private DataSet resultSet;
		
        
        private string organization_no;
	    private string tax_id;
	    private string customer_search_key;
        private string customer_first_name;
        private string customer_last_name;
        private string addr1;
        private string addr2;
        private string postel_code;
        private string city;
        private string region;
        private string country;
        private string phone;
        private string alt_phone;
        private string fax;
        private string email;
        private string card;
        private string notes;
        private double max_debt;
        private double current_debt;
        private DateTime creation_date;
        private int status;
        private string customer_account_set;
        private string price_list_code;
        private string terms_code;
        private string rate_type;
        private string tax_group_code;

       
        
        #endregion


		public Customer()
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
                organization_no = value;
			}
			get
			{
                return organization_no;
			}
		}

        public string Tax_id
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

        public string Customer_search_key
		{
			set
			{
                customer_search_key = value;
			}
			get
			{
                return customer_search_key;
			}
		}

        public string Customer_first_name
        {
            get { return customer_first_name; }
            set { customer_first_name = value; }
        }

       

        public string Customer_last_name
        {
            get { return customer_last_name; }
            set { customer_last_name = value; }
        }
       

        public string Addr1
        {
            get { return addr1; }
            set { addr1 = value; }
        }
      

        public string Addr2
        {
            get { return addr2; }
            set { addr2 = value; }
        }
      

        public string Postel_code
        {
            get { return postel_code; }
            set { postel_code = value; }
        }
      

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        

        public string Region
        {
            get { return region; }
            set { region = value; }
        }
       

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
       

        public string Alt_phone
        {
            get { return alt_phone; }
            set { alt_phone = value; }
        }
      

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
      

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
       

        public string Card
        {
            get { return card; }
            set { card = value; }
        }
       

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    
        public double Max_debt
        {
            get { return max_debt; }
            set { max_debt = value; }
        }

      
        public double Current_debt
        {
            get { return current_debt; }
            set { current_debt = value; }
        }
        

        public DateTime Creation_date
        {
            get { return creation_date; }
            set { creation_date = value; }
        }
      

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Customer_account_set
        {
            get { return customer_account_set; }
            set {  customer_account_set = value; }
        }
        
        public string Price_list_code
        {
            get { return price_list_code; }
            set { price_list_code = value; }
        }

        public string Terms_code
        {
            get { return  terms_code; }
            set { terms_code= value; }
        }

        public string Rate_type
        {
            get { return rate_type; }
            set { rate_type = value; }
        }

        public string Tax_group_code
        {
            get { return tax_group_code; }
            set { tax_group_code = value; }
        }

		#endregion


		public void LoadByTaxID()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadCustomerByTaxId");
		}


		public DataSet LoadBySearchKey()
		{
            
			SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadCustomerBySearchKey");
            return resultSet;
					
		}


        public DataSet UpdateCurrentDebt()
        {

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateCurrentDebt");
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
