using System;
using System.Reflection;
using System.Windows;

using EclipsePos.Data;

namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for KeyEvent.
	/// </summary>
	public class KeyEvent
	{
		private PosEvent function;
		private Assembly assembly;
		
		public KeyEvent()
		{
			assembly = Assembly.GetExecutingAssembly();
		}


		#region Properties
		public PosEvent Function
		{
			get
			{
				return function;
			}
		}
		#endregion


		public KeyEvent(PosKey key)
		{
			if (key.Key_Class != null)
			{
				try 
				{
					function = assembly.CreateInstance(key.Key_Class) as PosEvent;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString() );
				}

			}
		}
	}
}
