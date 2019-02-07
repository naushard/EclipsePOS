using System;
using System.Data;

namespace EclipsePos.Data 	
{
	/// <summary>
	/// Summary description for Site.
	/// </summary>
	public class Site : IRelatableSet	
	{
		#region Variables
		private int site_id;
		private int site_no;
		private string name;
		private string lat;
		private string lon;
		private string addr1;
		private string addr2;
		private string addr3;
		private string addr4;
		private string addr5;
		private string ip;
		private int port;
		private int merchant_id;
		private DataSet resultSet;
		#endregion

		public Site()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IRelatableSet Members

		public DataSet ResultSet
		{
			get
			{
				return resultSet;
			}
			set
			{
				resultSet = value;
			}
		}

		#endregion
	}
}
