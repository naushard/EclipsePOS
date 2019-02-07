using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for ORMTypeMapping.
	/// </summary>
	/// 
	[Serializable()]
	public class ORMTypeMapping
	{
		private string fullName;
		private ArrayList commandMappings;

		public ORMTypeMapping()
		{
			commandMappings = new ArrayList();
		}

		public ORMTypeMapping( XmlNode typeMap )
		{
			commandMappings = new ArrayList();
			fullName = typeMap.Attributes["fullname"].Value;

			// build command mappings
			XmlNodeList commandList = typeMap.SelectNodes("commandmap");
			foreach (XmlNode commandMap in commandList)
			{
				ORMCommandMap cmdMap = new ORMCommandMap( commandMap );
				commandMappings.Add( cmdMap );
			}
		}
		
		public ORMCommandMap GetMapByName( string relationKey )
		{
			foreach (object ob in commandMappings)
			{
				ORMCommandMap ocm = (ORMCommandMap)ob;
				if (ocm.RelationKey.ToUpper() == relationKey.ToUpper())
					return ocm;
			}
			return null;
		}

		public ArrayList CommandMappings
		{
			get 
			{
				return commandMappings;
			}
			set 
			{
				commandMappings = value;
			}
		}

		public string FullName
		{
			get 
			{
				return fullName;
			}
			set 
			{
				fullName = value;
			}
		}
	
	}

}
