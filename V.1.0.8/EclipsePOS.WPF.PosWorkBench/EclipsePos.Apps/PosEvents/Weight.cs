//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: March, 2007
//===============================================================================
// Changes/Fixes
//
//===============================================================================


using System;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for Weight.
	/// </summary>
	public class Weight:PosEvent	
	{
		private string promptText;
		private double weight;

		public Weight()
		{
			// 
			// TODO: Add constructor logic here
			//
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
		public override void  Engage(int keyValue)
		{
			
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
