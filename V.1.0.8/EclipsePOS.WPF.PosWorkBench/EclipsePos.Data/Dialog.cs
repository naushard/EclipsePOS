using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Dialog.
	/// </summary>
	public class Dialog	: IRelatableSet	
	{
		private int dialog_id;
		//private int config_no;
		//private int help_id;
		private int dialog_type;
		private string dialog_name;
		private DataSet resultSet; 
		private ArrayList arrayListDialogEvent; 
		
		
		
		public Dialog()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
			arrayListDialogEvent = new ArrayList();
		}


		#region Properties

		//1
		public int DialogID
		{
			set
			{
				dialog_id = value;
			}
			get
			{
				return dialog_id;
			}
		}

		
		
		//2
	/*	public int  ConfigNo
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
    */
		
		//3
	/*	public int  HelpID
		{
			set
			{
				
				help_id = value;
			}
			get
			{
				return help_id;
			}
		}
    */
		//4
		public int  DialogType
		{
			set
			{
				
				dialog_type = value;
			}
			get
			{
				return dialog_type;
			}
		}
		
		//5
		public string DialogName
		{
			set
			{
				
				dialog_name = value;
			}
			get
			{
				return dialog_name;
			}
		}

		//6
		public ArrayList DialogEvents
		{
			get
			{
				return arrayListDialogEvent;
			}
		}

		#endregion
		

		public void Add()
		{ 
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public DataSet LoadDialog()
		{
			
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialog");
			return resultSet;
					
		}


		public void LoadDialogByDialogName()
		{
			if ( dialog_name == null )
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialogByDialogName");
			// return resultSet;
				
		}

		public void Relations(int config)
		{
			this.arrayListDialogEvent.Clear();
			DialogEvent dialogEvent = new DialogEvent();
			dialogEvent.DialogID = this.DialogID;
            dialogEvent.DialogEventID = config;
			DataSet data = dialogEvent.LoadDialogEvents();
			DataTable dt = data.Tables[0];
			foreach (DataRow dr in dt.Rows )
			{
				DialogEvent dialogEventTemp = new DialogEvent(); 
				dialogEventTemp.DialogEventID = int.Parse(dr["dialog_event_id"].ToString());
				dialogEventTemp.DialogID = int.Parse(dr["dialog_id"].ToString());
				dialogEventTemp.DialogSeq = int.Parse(dr["dialog_seq"].ToString());
			//	dialogEventTemp.HelpID = int.Parse(dr["help_id"].ToString());
				dialogEventTemp.DialogDesc = dr["dialog_desc"].ToString();
				dialogEventTemp.State = int.Parse(dr["state"].ToString());
				dialogEventTemp.EventEnabled = int.Parse(dr["event_enabled"].ToString());
				dialogEventTemp.EventRequired = int.Parse(dr["event_required"].ToString());
				dialogEventTemp.EventClass = dr["event_class"].ToString();
				
				this.arrayListDialogEvent.Add(dialogEventTemp);
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
