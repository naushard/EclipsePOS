using System;

namespace EclipsePos.Apps.Hardware
{
	/// <summary>
	/// Summary description for HardwareSupport.
	/// </summary>
	public interface HardwareSupport
	{
		bool CheckHealth();
		bool Reset();
		string DeviceText();
		string StatusText();
		void Close();
		
	}
}
