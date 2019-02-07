using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for TransPromotion.
	/// </summary>
	public class TransPromotion : IRelatableSet	
	{
		private int trans_no;
		private int seq_no;
        private string store_no;
        private string organization_no;
        private int line_no;
		private int promotion_no;
		private int promotion_type;
		private double promotion_amount;
		private double promotion_quantity;
		private int reason_code;
		private string promotion_data;
		private string promotion_desc;
		private int state;
        private int pos_no;
		private DataSet resultSet; 

		public TransPromotion()
		{
			resultSet = new DataSet();
		}

		public TransPromotion(DataRow dr)
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());

            this.Seq_no = int.Parse(dr["seq_no"].ToString());
            this.Line_no = int.Parse(dr["line_no"].ToString());
            this.Organization_no = dr["organization_no"].ToString();
            this.Store_no = dr["store_no"].ToString();
			this.PromotionNo = int.Parse(dr["promotion_no"].ToString());
			this.PromotionType = int.Parse(dr["promotion_type"].ToString());
			this.PromotionAmount = double.Parse(dr["promotion_amount"].ToString());
			this.PromotionQuantity = double.Parse(dr["promotion_quantity"].ToString());
			this.ReasonCode = int.Parse(dr["reason_code"].ToString());
			this.PromotionData = dr["promotion_data"].ToString();
			this.PromotionDesc = dr["promotion_desc"].ToString();
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
		public int  PromotionNo
		{
			set
			{
				
				promotion_no = value;
			}
			get
			{
				return promotion_no;
			}
		}

		//4
		public int PromotionType
		{
			set
			{
				
				promotion_type = value;
			}
			get
			{
				return promotion_type;
			}
		}
		
		//5
		public double  PromotionAmount
		{
			set
			{
				
				promotion_amount = value;
			}
			get
			{
				return promotion_amount;
			}
		}
		
		//6
		public double PromotionQuantity
		{
			set
			{
				
				promotion_quantity = value;
			}
			get
			{
				return promotion_quantity;
			}
		}


		public int ReasonCode
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

		public string PromotionData
		{
			set
			{
				
				promotion_data = value;
			}
			get
			{
				return promotion_data;
			}
		}

		public string PromotionDesc
		{
			set
			{
				
				promotion_desc = value;
			}
			get
			{
				return promotion_desc;
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

		public DataSet LoadAllByTransId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAllByTransno");
			return resultSet;

		}

        public void UpdateState()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransPromotionState");

        }



        public void UpdatePromotionAmount()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "UpdateTransPromotionAmount");
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
