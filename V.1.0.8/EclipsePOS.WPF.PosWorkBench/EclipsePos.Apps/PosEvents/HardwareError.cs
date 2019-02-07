using System;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for HardwareError.
	/// </summary>
	public class HardwareError	:PosError	
	{
		public HardwareError():base(PosErrorCode.HARDWARE_PROBLEM)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		

	}
}
