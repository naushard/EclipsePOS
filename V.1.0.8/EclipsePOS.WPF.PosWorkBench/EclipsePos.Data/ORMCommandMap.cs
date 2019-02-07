using System;
using System.Diagnostics;
using System.Collections;
using System.Xml;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for ORMCommandMap.
	/// </summary>
	public class ORMCommandMap
	{
		private string relationKey;
		private string storedProcedure;
		private bool returnsMultiple;
		private ArrayList propertyMaps;

		public ORMCommandMap()
		{
			propertyMaps = new ArrayList();
		}

		public ORMCommandMap( XmlNode cmdMap )
		{
			string multiple;
			propertyMaps = new ArrayList();

			relationKey = cmdMap.Attributes["type"].Value;
			storedProcedure = cmdMap.Attributes["storedproc"].Value;
			multiple = cmdMap.Attributes["multiple"].Value.ToUpper();
			returnsMultiple = ( (multiple == "TRUE") || (multiple == "YES") );
			
			foreach (XmlNode propertyMap in cmdMap.ChildNodes)
			{
				ORMPropertyMap propMap = new ORMPropertyMap( propertyMap );
				propertyMaps.Add( propMap );
			}
		}

		public bool ReturnsMultiple
		{
			get 
			{
				return returnsMultiple;
			}
			set 
			{
				returnsMultiple = value;
			}
		}
		
		public ArrayList PropertyMaps
		{
			get 
			{
				return propertyMaps;
			}
			set 
			{
				propertyMaps = value;
			}
		}

		public string StoredProcedure
		{
			get 
			{
				return storedProcedure;
			}
			set 
			{
				storedProcedure = value;
			}
		}

		public string RelationKey
		{
			get 
			{
				return relationKey;
			}
			set 
			{
				relationKey = value;
			}
		}

	}
}
