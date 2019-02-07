using System;
using System.Collections;
using System.Data;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosConfig.
	/// </summary>
	public class PosConfig:IRelatableSet				
	{
		private int config_id;
		private int config_no;
		private int config_no_from;
		private string name;
		private Hashtable hashTableTaxGroups;
		private Hashtable hashTableDialogs;
        private Hashtable hashTableMenuConfig;
        private Hashtable hashTableCardMedia;
        private Hashtable hashTableCardMediaByTotalType;
		private DataSet resultSet;
        private string organization_id;

        

        public PosConfig()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
			hashTableTaxGroups = new Hashtable();
			hashTableDialogs = new Hashtable();
            hashTableMenuConfig = new Hashtable();
            hashTableCardMedia = new Hashtable();
            hashTableCardMediaByTotalType = new Hashtable();
		}

		#region Properties
		public int ConfigId
		{
			set
			{
				config_id = value;
			}
			get
			{
				return config_id;
			}
		}

		public int ConfigNo
		{
			set
			{
				config_no = value;
			}
			get
			{
				return config_no;
			}
		}

		public string Name
		{
			set
			{
				name = value;
			}
			
			get
			{
				return name;
			}
		}

		public int ConfigNoFrom
		{
			set
			{
				config_no_from = value;
			}
			get
			{
				return config_no_from;
			}
		}


		public Hashtable TaxGroups
		{
			set
			{
				hashTableTaxGroups = value;
			}
			get
			{
				return hashTableTaxGroups;
			}
		}

		public Hashtable Dialogs
		{
			set
			{
				hashTableDialogs = value;
			}
			get
			{
				return hashTableDialogs;
			}
		}

        public Hashtable MenuConfigs
        {
            set
            {
                hashTableMenuConfig = value;
            }
            get
            {
                return hashTableMenuConfig;
            }
        }

        public Hashtable CardMedia
        {
            set
            {
                this.hashTableCardMedia = value;
            }
            get
            {
                return this.hashTableCardMedia;
            }
        }

        public Hashtable CardMediaByTotalType
        {
            set
            {
                this.hashTableCardMediaByTotalType = value;
            }
            get
            {
                return this.hashTableCardMediaByTotalType;
            }
        }



        public string Organization_id
        {
            get { return organization_id; }
            set { organization_id = value; }
        }

		#endregion

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}

		public void Remove()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Remove");
		}

        public void LoadByConfigNo()
        {

            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadPosConfigByConfigNo");

        }


		public void LoadByConfigName()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPosConfigByConfigName");
			
		}


		public void Save()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Save");
		}


		
		public DataSet LoadAll()
		{
		
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAll");
			return resultSet;
			
		}


		public void Relations()
		{
		//	if ( this.config_no == 0) return;

			//Load tax groups
			this.hashTableTaxGroups.Clear();
			TaxGroup taxG = new TaxGroup();
            taxG.Organization_no = this.organization_id;
			DataSet data = taxG.LoadTaxGroupByOrganizationId();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				TaxGroup taxGroupTemp = new TaxGroup();
				taxGroupTemp.TaxGroupId = dr["tax_group_id"].ToString();
                taxGroupTemp.Organization_no = dr["organization_no"].ToString();
				//Load taxes
				taxGroupTemp.Relations();
				this.hashTableTaxGroups.Add(taxGroupTemp.TaxGroupId, taxGroupTemp );
			}


			//Load Dialogs
			this.hashTableDialogs.Clear();
			Dialog dialog = new Dialog();
            //dialog.ConfigNo = this.config_no;
			DataSet data1 = dialog.LoadDialog();
			DataTable dt1 = data1.Tables[0];
			foreach (DataRow dr1 in dt1.Rows )
			{
				Dialog dialogTemp = new Dialog();
				dialogTemp.DialogID = int.Parse(dr1["dialog_id"].ToString());
				//dialogTemp.ConfigNo = int.Parse(dr1["config_no"].ToString());
				//dialogTemp.HelpID = int.Parse(dr1["help_id"].ToString());
				dialogTemp.DialogType = int.Parse(dr1["dialog_type"].ToString());
				dialogTemp.DialogName = dr1["dialog_name"].ToString();
				dialogTemp.Relations(this.config_no);
				this.hashTableDialogs.Add(dialogTemp.DialogName, dialogTemp );
			}


            //Load Menus
            this.hashTableMenuConfig.Clear();
            MenuConfig menus = new  MenuConfig();
            menus.Config_no = this.config_no;
            DataSet data3 = menus.Load();
            DataTable dt3 = data3.Tables[0];
            foreach (DataRow dr3 in dt3.Rows)
            {
                MenuConfig menusTemp = new  MenuConfig();
                menusTemp.Config_no = int.Parse(dr3["Config_no"].ToString());
                menusTemp.Menu_id = int.Parse(dr3["Menu_id"].ToString());
                menusTemp.Left_panel_id  = int.Parse(dr3["left_panel_id"].ToString());
                menusTemp.Right_panel_id  = int.Parse(dr3["right_panel_id"].ToString());
                menusTemp.Bottom_panel_id = int.Parse(dr3["bottom_panel_id"].ToString());
                this.hashTableMenuConfig.Add(menusTemp.Menu_id, menusTemp);
            }


            //Load Card Media
            CardMedia cards = new CardMedia();
            cards.Organization_no = this.Organization_id;
            DataSet data4 =  cards.LoadAllMedia();
            DataTable dt4 = data4.Tables[0];
            this.CardMedia.Clear();
            this.CardMediaByTotalType.Clear();

            foreach (DataRow dr4 in dt4.Rows)
            {
                CardMedia cardMediaTemp = new CardMedia();
                cardMediaTemp.Organization_no = dr4["organization_no"].ToString();
                cardMediaTemp.Media_id = int.Parse(dr4["media_id"].ToString());
                cardMediaTemp.Media_name = dr4["media_name"].ToString();
                cardMediaTemp.Media_desc = dr4["media_desc"].ToString();
                cardMediaTemp.Media_class = dr4["media_class"].ToString();
                cardMediaTemp.Total_type = int.Parse(dr4["total_type"].ToString());
                cardMediaTemp.Media_type = int.Parse(dr4["media_type"].ToString());
                this.CardMedia.Add(cardMediaTemp.Media_id, cardMediaTemp);
                this.CardMediaByTotalType.Add(cardMediaTemp.Total_type, cardMediaTemp);
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
