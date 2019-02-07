//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: June, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================

using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for RetailStore.
	/// </summary>
	public class RetailStore: IRelatable 
	{
        private string retail_store_no;
        private string	organization_no;
		private string retailStoreName;
		private string address1;
		private string address2; 	
		private string address3;
		private string address4;
		private string city;
		private string state;
		private string zip; 
		private string country;
		private string phone;
        private string fax;
        private string contact;
        private string email;
        private string customer_tax_id;
		
		private int last_trans_no;

	
		 
		public RetailStore()
		{
		}


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}

		public void Load()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Select");
			
		}

		public void SaveByRetailStoreId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Save");
		}

		public int GetNextTransNo()
		{
			this.Load();

			Last_trans_no++;
			this.SaveByRetailStoreId();
			return this.Last_trans_no;
			
		}


		#region Properties

        public string Retail_store_no
        {
            get { return retail_store_no; }
            set { retail_store_no = value; }
        }
		

		//1
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


		//2
		public string RetailStoreName
		{
			set
			{
				retailStoreName = value;
			}
			get
			{
				return retailStoreName;
			}
		}


		
		//9
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

		//10	
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

		//11
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

		//12
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
	
		//13
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

		//14
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

		//15
		public string Zip
		{
			set
			{
				zip = value;
			}
			get
			{
				return zip;
			}
		}

		//16
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


        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }

        public string Customer_tax_id
        {
            set
            {
                customer_tax_id = value;
            }
            get
            {
                return customer_tax_id;
            }
        }

		
		//17
		public int Last_trans_no
		{
			set
			{
				last_trans_no = value;
			}
			get
			{
				return last_trans_no;
			}
		}
	
		
		#endregion 

	


	}
}
