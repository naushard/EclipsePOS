using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Trans_tax.
	/// </summary>
	public class TransTax : IRelatableSet	
	{
		private int trans_no;
		private int seq_no;
        private string store_no;
        private string organization_no;
        private int line_no;
		private int tax_id;
		private string tax_desc;
		private double rate;
		private double taxable_amount;
		private double tax_amount;
		private int state;
        private int pos_no;
		

		private DataSet resultSet; 

		public TransTax()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		public TransTax(DataRow dr)
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());
			this.SeqNo = int.Parse(dr["seq_no"].ToString());
            this.Line_no = int.Parse(dr["line_no"].ToString());
            this.Organization_no = dr["organization_no"].ToString();
            this.Store_no = dr["store_no"].ToString();
            this.TaxId = int.Parse(dr["tax_id"].ToString());
			this.TaxDesc = dr["tax_desc"].ToString();
			this.Rate = double.Parse(dr["rate"].ToString());
			this.TaxableAmount = double.Parse(dr["taxable_amount"].ToString());
			this.TaxAmount = double.Parse(dr["tax_amount"].ToString());
			this.State = int.Parse(dr["state"].ToString());
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
		public int  SeqNo
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
		public int  TaxId
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

		//4
		public string TaxDesc
		{
			set
			{
				
				tax_desc = value;
			}
			get
			{
				return tax_desc;
			}
		}
		
		//5
		public double Rate
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

		public double TaxableAmount
		{
			set
			{
				taxable_amount = value;
			}
			get
			{
				return taxable_amount;
			}
		}

		public double TaxAmount
		{
			set
			{
				
				tax_amount = value;
			}
			get
			{
				return tax_amount;
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
		public DataSet LoadByTransid()
		{
			SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadTransTaxByTransno");
			return resultSet;
		}

        public void Save()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "Save");
        }


        public void UpdateState()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransTaxState");
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
