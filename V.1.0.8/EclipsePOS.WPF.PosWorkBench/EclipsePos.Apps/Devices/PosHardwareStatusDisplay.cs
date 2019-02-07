using System;
//using System.Drawing;
using Microsoft.PointOfService;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for PosHardwareStatusDisplay.
	/// </summary>
	public interface PosHardwareStatusDisplay
	{

        void Status(object sender, int deviceStatus);	
		
		
	}
  
}
 