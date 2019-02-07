using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Trans_item.
	/// </summary>
	public class TransItem : IRelatableSet	
	{
		private int trans_no;
        private string store_no;
        private string organization_no;
		private int seq_no;
        private int line_no;
		private string sku;
		private string sku_link;
		private double quantity;
		private double amount;
		private double  ext_amount;
		private double  weight;
		private string item_desc;
		private int state;
		private int reason_code;
		private int tax_exempt;
		private int tax_incl;
		private double var_amount;
        private int pos_no;

		private DataSet resultSet; 

		public TransItem()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		public TransItem(DataRow dr):this()
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());
			this.Seq_no = int.Parse(dr["seq_no"].ToString());
            this.Line_no = int.Parse(dr["line_no"].ToString());
            this.Organization_no =  dr["organization_no"].ToString() ;
            this.Store_no = dr["store_no"].ToString();
			this.Sku = dr["sku"].ToString();
			this.Sku_link = dr["sku_link"].ToString();
			this.Quantity =(int) decimal.Parse(dr["quantity"].ToString());
			this.Amount = (double)decimal.Parse(dr["amount"].ToString());
			this.Ext_amount =(double) decimal.Parse(dr["ext_amount"].ToString());
			this.Weight = double.Parse(dr["weight"].ToString());
			this.Item_desc = dr["item_desc"].ToString();
			this.State = int.Parse(dr["state"].ToString());
			this.Reason_code = int.Parse(dr["reason_code"].ToString());
			this.Tax_exempt = int.Parse(dr["tax_exempt"].ToString());
			this.Tax_incl = int.Parse(dr["tax_incl"].ToString());
			this.Var_amount = (double) decimal.Parse(dr["var_amount"].ToString());
            this.Pos_no = int.Parse(dr["pos_no"].ToString());
		}


		#region Properties

		//1
		public int Trans_no
		{
			set
			{
				trans_no = value;
			}
			get
			{
				return trans_no;
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
		public int  Seq_no
		{
			set
			{
				
				seq_no = value;
			}
			get
			{
				return seq_no;
			}
		}

        //2
        public int Line_no
        {
            set
            {
                line_no = value;
            }
            get
            {
                return line_no;
            }
        }

		//3
		public string  Sku
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

		//4
		public string Sku_link
		{
			set
			{
				
				sku_link = value;
			}
			get
			{
				return sku_link;
			}
		}
		
		//5
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

		public double Amount
		{
			set
			{
				
				amount = value;
			}
			get
			{
				return amount;
			}
		}

		public double Ext_amount
		{
			set
			{
				
				ext_amount = value;
			}
			get
			{
				return ext_amount;
			}
		}

		public double Weight
		{
			set
			{
				
				weight = value;
			}
			get
			{
				return weight;
			}
		}

		public string Item_desc
		{
			set
			{
				
				item_desc = value;
			}
			get
			{
				return item_desc;
			}
		}

		public int State
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

		public int Reason_code
		{
			set
			{
				
				reason_code = value;
			}
			get
			{
				return reason_code;
			}
		}

		public int Tax_exempt
		{
			set
			{
				
				tax_exempt = value;
			}
			get
			{
				return tax_exempt;
			}
		}
		
		public int Tax_incl
		{
			set
			{
				
				tax_incl = value;
			}
			get
			{
				return tax_incl;
			}
		}

		public double  Var_amount
		{
			set
			{
				
				var_amount = value;
			}
			get
			{
				return var_amount;
			}
		}

        public int Pos_no
        {
            set
            {

                pos_no = value;
            }
            get
            {
                return pos_no;
            }
        }


		#endregion
		

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

        public void UpdateState()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransItemState");

        }

		public DataSet LoadByTransno()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTransItemByTransno");
			return resultSet;

		}


        public void UpdateAmounts()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransItemAmounts");

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
