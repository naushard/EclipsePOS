using System;
using System.Collections;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Item.
	/// </summary>
	public class Item : IRelatableSet
	{
		//private double item_id;
		private string organization_no;
		private string sku;
		private string short_desc;
		private double amount;
		private string dept;
		private string item_group;
		private string tax_group_id;
		private int pricing_opt;
		private DateTime act_date;
		private DateTime deact_date;
		private int tax_inclusive;
		private int tax_exempt;
		private DataSet resultSet; 
		private ArrayList promoArrayList;
		private string plu;
        private string catogory;
        private string shipping_uom;
        private double def_quantity;




		public Item()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties

		//1
		public double Def_quantity
		{
			set
			{
				def_quantity = value;
			}
			get
			{
				return def_quantity;
			}
		}

		
		//2
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
		public string Short_Desc
		{
			set
			{
				
				short_desc = value;
			}
			get
			{
				return short_desc;
			}
		}
		
		//5
		public double  Amount
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

		//6
		public string Dept
		{
			set
			{
				
				dept = value;
			}
			get
			{
				return dept;
			}
		}
        //7
		public string Item_group
		{
			set
			{
				
				item_group = value;
			}
			get
			{
				return item_group;
			}
		}



		//8
		public string Tax_group_id
		{
			set
			{
				
				tax_group_id = value;
			}
			get
			{
				return tax_group_id;
			}
		}

		//9
		public int Pricing_Opt
		{
			set
			{
				
				pricing_opt = value;
			}
			get
			{
				return pricing_opt;
			}
		}

		//10
		public DateTime Active_Date
		{
			set
			{
				
				act_date = value;
			}
			get
			{
				return act_date;
			}
		}

		//11
		public DateTime Deactive_Date
		{
			set
			{
				
				deact_date = value;
			}
			get
			{
				return deact_date;
			}
		}
		
		//12
		public int Tax_Inclusive
		{
			set
			{
				
				tax_inclusive = value;
			}
			get
			{
				return tax_inclusive;
			}
		}

		//13
		public int Tax_Exempt
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
		
		//14
		public string Plu
		{
			set
			{
				
				plu = value;
			}
			get
			{
				return plu;
			}
		}


        //
        public string Catogory
        {
            set
            {

                catogory = value;
            }
            get
            {
                return catogory;
            }
        }

        //
        public string Shipping_uom
        {
            set
            {

                 shipping_uom = value;
            }
            get
            {
                return shipping_uom;
            }
        }

		#endregion
		
		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}


		public void LoadBySKU()
		{
			if ( string.IsNullOrEmpty(sku ))
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadItemBySKU");
			
		}

		public void LoadByPLU()
		{
			if ( string.IsNullOrEmpty(plu) )
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadItemByPlu");
			
		}

		public DataSet LoadByDesc()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadItemByDesc");
			return resultSet;
			
		}

		public DataSet LoadAllSKUs()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAllItems");
			return resultSet;
			
		}

		public DataSet LoadByItemGroup(string itemGroupId)
		{
            this.Item_group = itemGroupId;
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadItemsByItemGroup");
			return resultSet;
			
		}

		
		public ArrayList Promotions()
		{
			promoArrayList = new ArrayList();

			PromotionMap map = new PromotionMap();
            map.Organization_no = this.Organization_no;
			map.Promotion_map = this.Sku;
			DataSet data = map.LoadByMap();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				int promoNo = int.Parse(dr["promotion_no"].ToString());
				Promotion promo  = new Promotion();
                promo.Organization_no = this.Organization_no;
				promo.PromotionNo = promoNo;
				promo.Load();
                if (promo.Valid_date_from <= DateTime.Now && promo.Valid_date_to >= DateTime.Now)
                {
                    promoArrayList.Add(promo);
                }
			}

			return this.promoArrayList;
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

    public enum PricingOptions
    {
        Price_override_allowed = 1,
        Price_override_not_allowed = 2,
        Counter_pricing = 3
    }

}
