using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for DialogEvent.
	/// </summary>
	public class DialogEvent : IRelatableSet		
	{
		private int dialog_event_id;
		private int dialog_id;
		private int dialog_seq;
	//	private int help_id;
		private string dialog_desc;
		private int state;
		private int event_enabled;
		private int event_required;
		private string event_class;
		private DataSet resultSet;

		
		
		public DialogEvent()
		{
			resultSet = new DataSet();
		}

		#region Properties
	
		public int DialogEventID
		{
			set 
			{
				dialog_event_id = value;
			}
			get 
			{
				return dialog_event_id;
			}
		}
		
		public int DialogID
		{
			set 
			{
				dialog_id  = value;
			}
			get 
			{
				return dialog_id;
			}
		
		}

		public int DialogSeq
		{
			set 
			{
				dialog_seq = value;
			}
			get 
			{
				return dialog_seq;
			}
		
		}
/*
		public int HelpID
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
		public string DialogDesc
		{
			set 
			{
				dialog_desc = value;
			}
			get 
			{
				return dialog_desc;
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
  
		public int EventEnabled
		{
			set 
			{
				event_enabled = value;
			}
			get 
			{
				return event_enabled;
			}
		
		}

		public int EventRequired
		{
			set 
			{
				event_required = value;
			}
			get 
			{
				return event_required;
			}
		
		}

		public string EventClass
		{
			set 
			{
				event_class = value;
			}
			get 
			{
				return event_class;
			}
		
		}




		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}



		 public DataSet LoadDialogEvents()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialogEventByDialogID");
			return resultSet;
		}

		public DataSet LoadDialogEvents(Dialog dialog)
		{
			this.DialogID = dialog.DialogID;
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadDialogEventByDialogID");
			return resultSet;
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
