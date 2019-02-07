using System;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for PosKeyEnable.
	/// </summary>
	public interface PosKeyEnable
	{
		void KeyEnable();
		void KeyDisable();
        void AddPosKeys(int panelId, string panelName);

		int PanelId
		{
			get;
		}
	}
}
