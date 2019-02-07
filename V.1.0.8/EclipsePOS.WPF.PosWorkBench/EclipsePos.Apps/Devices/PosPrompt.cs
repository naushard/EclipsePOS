using System;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// An interface for coupling application logic to psuedo
	/// and real display devices.
	/// </summary>
	public interface PosPrompt
	{
		
		int PromptWidth
		{
			get;
		}
		
		int InputWidth
		{
			get;
		}

        int MessageWidth
        {
            get;
        }

	


		string PromptText 
		{
			set;
		}
		
		
		string InputText
		{	
			set;
		}


        string MessageText
        {
            set;
        }

		void Clear();

		void EnableInput();
		void DisableInput();

        void StartErrorAnimation();
        void EndErrorAnimation();

        void StartInputAnimation();
        void EndInputAnimation();

	}
}
