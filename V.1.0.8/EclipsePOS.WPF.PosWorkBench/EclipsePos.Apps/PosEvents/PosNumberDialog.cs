using System;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PosNumberDialog.
	/// </summary>
	public abstract class PosNumberDialog: PosDialogEvent 
	{
		public PosNumberDialog()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public abstract string PromptText
		{
			get;
			set;
		}
		
		public abstract string MessageText
		{
			get;
			set;
		}


		public abstract PosNumberDialogTypes Type
		{
			get;
			set;
		}
	}
}
