using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EclipsePos.Data
{
    public class StockBalance : IRelatableSet	
    {
        private string organization_no;
		private string store_no;
		private string sku;
        private double quantity_on_hand;
        private double cost;
        private double maximum_quantity;
        private double minimum_quantity;


		private DataSet resultSet; 
 
		public StockBalance()
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

        public double Quantity_on_hand
        {
            set
            {
                quantity_on_hand = value;
            }
            get
            {
                return quantity_on_hand;
            }

        }

        public double Maximum_quantity
        {
            set
            {
                maximum_quantity = value;
            }
            get
            {
                return maximum_quantity;
            }

        }

        public double Minimum_quantity
        {
            set
            {
                minimum_quantity = value;
            }
            get
            {
                return minimum_quantity;
            }

        }

        public double Cost
        {
            set
            {
                cost = value;
            }
            get
            {
                return cost;
            }

        }

        #endregion


        public void AddBalance()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "AddBalance");
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
