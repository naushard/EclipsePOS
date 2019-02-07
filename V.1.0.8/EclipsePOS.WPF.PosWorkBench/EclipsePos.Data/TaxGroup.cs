using System;
using System.Data;
using System.Diagnostics;
using System.Collections;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for TaxGroup.
	/// </summary>
	public class TaxGroup: IRelatableSet		
	{
		private DataSet resultSet; 
		private string tax_group_id;
		private string organization_id;
        private string tax_group_name;
       	private ArrayList arrayListTaxes;
        
		public TaxGroup()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
			arrayListTaxes = new ArrayList();
		}

		#region Properties

		//1
		public string TaxGroupId
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

		
		
		//2
		public string  Organization_no
		{
			set
			{
				
				organization_id = value;
			}
			get
			{
				return organization_id;
			}
		}

        //2
        public string Tax_group_name
        {
            set
            {

                tax_group_name = value;
            }
            get
            {
                return tax_group_name;
            }
        }

        //2
       


		public ArrayList Taxes
		{
			set
			{
				this.arrayListTaxes = value;
			}
			get
			{
				return this.arrayListTaxes;
			}
		}
		
		
		#endregion
		

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public DataSet LoadTaxGroupByOrganizationId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadTaxGroupByOrganizationId");
			return resultSet;
					
		}


		public void Relations()
		{
			this.arrayListTaxes.Clear();
			if ( string.IsNullOrEmpty (this.TaxGroupId) ) return;
			Tax tax = new Tax();
            tax.TaxGroupId = this.TaxGroupId;
            tax.Organization_no = this.Organization_no;
			DataSet data =  tax.LoadTaxByGroup();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				Tax taxTemp = new Tax();
				taxTemp.Tax_id = int.Parse(dr["tax_id"].ToString());
				taxTemp.TaxGroupId = dr["tax_group_id"].ToString();
				taxTemp.TaxType = int.Parse(dr["tax_type"].ToString());
				taxTemp.ShortDesc = dr["short_desc"].ToString();
				taxTemp.Rate = double.Parse(dr["rate"].ToString());
				taxTemp.AltRate = double.Parse(dr["alt_rate"].ToString());
				
				this.arrayListTaxes.Add(taxTemp);
			}

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
