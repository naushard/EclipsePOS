using System;
using Microsoft.PointOfService.BaseServiceObjects;


namespace EclipsePos.Apps.Hardware
{
	public sealed class MsrDataParser
	{
		private MsrDataParser () {}

		private static byte[] StringToByteArray(string source)
		{
			char[] chars = source.ToCharArray();
			byte[] data = new byte[chars.Length];
			int i = 0;
			foreach (char c in chars)
			{
				data[i] = Convert.ToByte(c);
				i++;
			}
			return data;
		}

		public static MsrFieldData ParseIsoData(string track1Data, string track2Data)
		{
			MsrFieldData data = new MsrFieldData();

			string [] Track1DataElements = track1Data.Trim().Split("^".ToCharArray());
			if (Track1DataElements.Length == 3 && Track1DataElements[0].Length > 0 && Track1DataElements[0][0] == 'B')
			{
				if (Track1DataElements[0].Length > 1)
					data.AccountNumber	= Track1DataElements[0].Substring(1);

				if (Track1DataElements[2].Length > 3)
					data.ExpirationDate	= Track1DataElements[2].Substring(0, 4);
				if (Track1DataElements[2].Length > 6)
					data.ServiceCode	= Track1DataElements[2].Substring(4, 3);
				
				// Track1DiscretionaryData
				if (Track1DataElements[2].Length > 7)
					data.Track1DiscretionaryData = StringToByteArray(Track1DataElements[2].Substring(7));
			
				// if the PAN contains a '/' then it's standard Visa format
				string [] PAN = Track1DataElements[1].Trim().Split("/".ToCharArray());
				if (PAN.Length == 2)
				{
					// Visa Format: "Surname/FirstName MiddleInitial.Title"
					
					// Surname is everything before '/' unless the PAN begins with "59" in which case
					// there will be a 3-digit country code before Surname
					if (data.AccountNumber.StartsWith("59"))
					{
						if (PAN[0].Length > 2)
							data.Surname = PAN[0].Substring(3).Trim();  // skip 3-digit country code
					}
					else
					{
						data.Surname = PAN[0].Trim();
					}

					// Split the text to the right of the '/'
					string [] SplitPAN = PAN[1].Trim().Split(" ".ToCharArray());
					if (SplitPAN != null)
					{
						// FirstName is the first text to the right of '/'
						if (SplitPAN.Length > 0)
							data.FirstName = SplitPAN[0].Trim();

						if (SplitPAN.Length > 1)
						{
							// After FirstName is MiddleInitial.Title
							string [] splitInitial = SplitPAN[1].Trim().Split(".".ToCharArray());
							if (splitInitial.Length < 2)
							{
								data.MiddleInitial = SplitPAN[1].Trim();
							}
							else
							{
								data.MiddleInitial = splitInitial[0].Trim();
								data.Title = splitInitial[1].Trim();
							}
						}
					}
				}
				else
				{
					// Format: "FirstName MiddleInitial Surname Suffix"

					// Split PAN at spaces
					string [] SplitPAN = Track1DataElements[1].Trim().Split(" ".ToCharArray());

					if (SplitPAN.Length > 0)
						data.FirstName = SplitPAN[0].Trim();

					if (SplitPAN.Length == 2)
					{
						data.Surname = SplitPAN[1].Trim();
					}
					else if (SplitPAN.Length > 2)
					{
						data.MiddleInitial = SplitPAN[1].Trim();
						data.Surname = SplitPAN[2].Trim();

						if (SplitPAN.Length > 3)
							data.Suffix = SplitPAN[3].Trim();
					}
				}
			}
			
			string [] Track2DataElements = track2Data.Trim().Split("=".ToCharArray());
			if (Track2DataElements.Length == 2)
			{
				// Track2DiscretionaryData
				if (Track2DataElements[1].Length > 7)
					data.Track2DiscretionaryData = StringToByteArray(Track2DataElements[1].Substring(7));

				// If we didn't get these fields from track1 try to get them from track2
				if (data.AccountNumber.Length == 0)
					data.AccountNumber	= Track2DataElements[0].Trim();	
				if (data.ExpirationDate.Length == 0 && Track2DataElements[1].Length > 3)
					data.ExpirationDate	= Track2DataElements[1].Substring(0, 4);
				if (data.ServiceCode.Length == 0 && Track2DataElements[1].Length > 6)
					data.ServiceCode	= Track2DataElements[1].Substring(4, 3);
			}
		
			return data;
			
		}

	}
	
}
