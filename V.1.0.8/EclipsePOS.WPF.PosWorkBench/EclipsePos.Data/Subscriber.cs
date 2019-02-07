using System;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Subscriber.
	/// </summary>
	public class Subscriber : IRelatableSet	
	{

		#region Varialbles

		private int subscriber_id;
		private string subscriber_name;
		private string subscriber_pass;
		private int organization_id;

		private DataSet resultSet; 

		#endregion 

		public Subscriber()
		{
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
		
		public string Subscriber_name
		{
			set 
			{
				subscriber_name = value;
			}
			get 
			{
				return subscriber_name;
			}
		
		}

		public string Subscriber_pass
		{
			set 
			{
				subscriber_pass = value;
			}
			get 
			{
				return subscriber_pass;
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

		#endregion
		
		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}

		
		public DataSet LoadSubscriberByOrganizationId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadByOrganizationId");
			return resultSet;
		}



		public void Load()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadBySubscriberName");
						
		}

		public DataSet SubsriberMap()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadSySubscriber");
			return resultSet;
		}

		public DataSet LoadAll()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAll");
			return resultSet;

		}


		public void Save()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Save");
		}


		public void Remove()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Remove");
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
