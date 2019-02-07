using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for SubscriberMap.
	/// </summary>
	public class SubscriberMap : IRelatableSet		
	{

		#region Varialbles

		private int subscriber_id;
		private int organization_id;
		private int subscriber_priv;

		private DataSet resultSet; 

		#endregion

		public SubscriberMap()
		{
			//
			// TODO: Add constructor logic here
			//
			resultSet = new DataSet();
		}

		#region Properties
	
		public int Subscriber_id
		{
			set 
			{
				subscriber_id = value;
			}
			get 
			{
				return subscriber_id;
			}
		}
		
		public int Organization_id
		{
			set 
			{
				organization_id = value;
			}
			get 
			{
				return organization_id;
			}
		
		}

		
		public int Subscriber_priv
		{
			set 
			{
				subscriber_priv = value;
			}
			get 
			{
				return subscriber_priv;
			}
		
		}


		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}



		public DataSet LoadSubMap()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadSubMapBySubscriberId");
			return resultSet;
			
		}

		public DataSet LoadSubMapByIdAndType()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadSubMapBySubscriberIdAndType");
			return resultSet;
			
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
