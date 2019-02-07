using System;
using System.Data;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Pos.
	/// </summary>
	public class Pos : IRelatableSet		
	{
		#region Variables
		private int posID;
		private int posNumber;
		private int numberOfDrawers;
		private string description;
		private int retailStoreID;
        private int configurationNumber;
		private DateTime createDate;
		private DateTime modifyDate;
		private DataSet resultSet;
		#endregion

		#region Properties
		
		public int PosID
		{
			set 
			{	
				posID = value;
			}
			get 
			{
				return posID;	
			}
		}

		public int PosNumber
		{
			set 
			{	
				posNumber = value;
			}
			get 
			{
				return posNumber;	
			}
		}

		public int NumberOfDrawers
		{
			set 
			{	
				numberOfDrawers  = value;
			}
			get 
			{
				return numberOfDrawers;	
			}
		}

		public string  Desription
		{
			set 
			{	
				description = value;
			}
			get 
			{
				return description;	
			}
		}

		public int  RetailStoreID
		{
			set 
			{	
				retailStoreID = value;
			}
			get 
			{
				return retailStoreID;	
			}
		}

		public int  ConfigurationNumber
		{
			set 
			{	
				configurationNumber = value;
			}
			get 
			{
				return configurationNumber;	
			}
		}
		
		public DateTime CreateDate
		{
			set 
			{	
				createDate = value;
			}
			get 
			{
				return createDate;	
			}
		}

		public DateTime ModifyDate
		{
			set 
			{	
				modifyDate = value;
			}
			get 
			{
				return modifyDate;	
			}
		}

		#endregion
		
		
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
