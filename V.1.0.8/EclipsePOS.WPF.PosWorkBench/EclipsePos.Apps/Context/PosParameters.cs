using System;
using System.Data;
using System.Collections;
using System.Windows;

using EclipsePos.Data;

namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for PosParameters.
	/// </summary>
	public sealed class PosParameters
	{
		private Hashtable paramHashtable = new Hashtable();

		public PosParameters(int configNo)
		{
			PosParam param = new PosParam();
			param.Config_no = configNo;
			DataSet paramData = param.LoadByConfigNo();
			DataTable paramTable = paramData.Tables[0];
			foreach (DataRow dr in paramTable.Rows )
			{
				try
				{

					paramHashtable.Add(dr["param_name"].ToString(), dr["param_value"].ToString() );
					//paramHashtable[dr["param_name"].ToString()] =  dr["param_value"].ToString();
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			}
					
		}

		public string getParam(string key)
		{
			string valueParam = null;
			try
			{
				valueParam = paramHashtable[key].ToString();
			}
			catch (Exception e)
			{
				valueParam = key;
			}

			return valueParam;

		}

	}
}
