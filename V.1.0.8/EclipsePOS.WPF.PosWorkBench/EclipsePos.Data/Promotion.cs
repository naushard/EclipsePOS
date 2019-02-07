using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Promotion.
	/// </summary>
	public class Promotion : IRelatable
	{

		#region Variable
		private string organization_no;
       	private int promotion_no;
		private int promotion_type;
		private int promotion_val1;
		private int promotion_val2;
		private int promotion_val3;
		private int promotion_val4;
		private int promotion_val5;
		private double promotion_dval1;
		private double promotion_dval2;
		private double promotion_dval3;
		private double promotion_dval4;
		private double promotion_dval5;
		private int print_before_item;
		private DateTime valid_date_from;
		private DateTime valid_date_to;
		private string promotion_string;
		private string promotion_class;
		#endregion

		public Promotion()
		{
			//
			// TODO: Add constructor logic here
			//
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
		
		
		//2
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

		
		//3
		public int  PromotionType
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

		//4
		public int PromotionVal1
		{
			set
			{
				
				promotion_val1 = value;
			}
			get
			{
				return promotion_val1;
			}
		}
		

		public int PromotionVal2
		{
			set
			{
				
				promotion_val2 = value;
			}
			get
			{
				return promotion_val2;
			}
		}
		

		public int PromotionVal3
		{
			set
			{
				
				promotion_val3 = value;
			}
			get
			{
				return promotion_val3;
			}
		}
		

		public int PromotionVal4
		{
			set
			{
				
				promotion_val4 = value;
			}
			get
			{
				return promotion_val4;
			}
		}
		

		public int PromotionVal5
		{
			set
			{
				
				promotion_val5 = value;
			}
			get
			{
				return promotion_val5;
			}
		}
		

		public double PromotionDval1
		{
			set
			{
		 		
				promotion_dval1 = value;
			}
			get
			{
				return promotion_dval1;
			}
		}
		

		public double PromotionDval2
		{
			set
			{
				
				promotion_dval2 = value;
			}
			get
			{
				return promotion_dval2;
			}
		}
		

		public double PromotionDval3
		{
			set
			{
				
				promotion_dval3 = value;
			}
			get
			{
				return promotion_dval3;
			}
		}
		

		public double PromotionDval4
		{
			set
			{
				
				promotion_dval4 = value;
			}
			get
			{
				return promotion_dval4;
			}
		}
		

		public double PromotionDval5
		{
			set
			{
				
				promotion_dval5 = value;
			}
			get
			{
				return promotion_dval5;
			}
		}
		



		public int PrintBeforeItem
		{
			set
			{
				
				print_before_item = value;
			}
			get
			{
				return print_before_item;
			}
		}
		
		public DateTime Valid_date_from
		{
			set
			{
				
				valid_date_from = value;
			}
			get
			{
				return valid_date_from;
			}
		}
		

		//5
		public DateTime  Valid_date_to
		{
			set
			{
				
				valid_date_to = value;
			}
			get
			{
				return valid_date_to;
			}
		}


		
		//6
		public string PromotionString
		{
			set
			{
				
				promotion_string = value;
			}
			get
			{
				return promotion_string;
			}
		}


		public string PromotionClass
		{
			set
			{
				
				promotion_class = value;
			}
			get
			{
				return promotion_class;
			}
		}

		#endregion
		

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public void Load()
		{
			if (this.PromotionNo == 0 ) return;
			SqlRelator sr = new SqlRelator(); 
			sr.Relate(this, "LoadPromotionByPromotionNo");
		}

	}
}
