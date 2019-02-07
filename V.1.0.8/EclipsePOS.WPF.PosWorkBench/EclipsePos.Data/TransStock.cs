using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EclipsePos.Data
{
    public class TransStock : IRelatableSet	
    {


        private string organization_no;
		private string store_no;
		private string sku;
        private double quantity;
        private int transaction_type;
        private string reference_number;
        private DateTime transaction_time;


		private DataSet resultSet; 
 
		public TransStock()
		{
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

        public string Sku
        {
            set
            {
                sku = value;
            }
            get
            {
                return sku;
            }

        }

        public double Quantity
        {
            set
            {
                quantity = value;
            }
            get
            {
                return quantity;
            }

        }

        public int Transaction_type
        {
            set
            {
                transaction_type = value;
            }
            get
            {
                return transaction_type;
            }

        }

        public string Reference_number
        {
            set
            {
                reference_number = value;
            }
            get
            {
                return reference_number;
            }

        }

        public DateTime Transaction_time
        {
            set
            {
                transaction_time = value;
            }
            get
            {
                return transaction_time;
            }

        }

        #endregion


        public void Add()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "Add");
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
