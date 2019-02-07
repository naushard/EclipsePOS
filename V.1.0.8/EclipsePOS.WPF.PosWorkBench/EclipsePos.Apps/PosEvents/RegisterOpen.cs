using System;
//using System.Windows.Forms;

//using EclipsePos.Apps.Gui;
using EclipsePos.Apps.Context;
using EclipsePos.Data;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for RegisterOpen.
	/// </summary>
	public class RegisterOpen : PosEvent			
	{
		 
		#region Variables
		
		private string promptText="";
		private bool hardwareTested;
	
		#endregion
		
		public RegisterOpen()
		{
			//
			// TODO: Add constructor logic here
			//
			promptText = PosContext.Instance.Parameters.getParam("RegOpen");
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
				promptText = value;
			
			}

		}

		public bool HardwareTested
		{
			get
			{
				return hardwareTested;
			}
			set
			{
				hardwareTested = value;
			}

		}

	
		#endregion


		public override void  Engage(int keyValue)
		{
			//MessageBox.Show("***** Register open *****");
			//PosContext.Instance.CurrentPosDisplay.LoadMenu(90);//PosSettings.Default.DefaultLeftPanelid);
            //PosContext.Instance.HomeGUI();
            PosContext.Instance.Operprompt.Update(this);
			PosContext.Instance.Receipt.Update(this);
          
          
      

		}

		public override void Clear()
		{
		}

		public override bool ValidTransition(string pEventName)
		{
			return true;
		}
	}
}
