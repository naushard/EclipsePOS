using System;
//using System.Windows.Forms;

using EclipsePos.Apps.Context;
//using EclipsePos.Apps.Gui;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for LookupItemMenu.
	/// </summary>
	public class LookupItemMenu :PosEvent	
	{
		private string promptText;

		public LookupItemMenu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("*** Item Lookup Menu ***");
			//ItemLookupForm itemLookupForm = new ItemLookupForm();
			//itemLookupForm.Show();
			PosContext.Instance.CurrentPosDisplay.LoadMenu(9);
			
		}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}


		#region Properties

		public string PromptText
		{
			get 
			{
				return promptText;
			}
			set 
			{
				promptText= value;
			}
		}

		#endregion
	}
}
