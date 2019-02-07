using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Diagnostics;
using System.Windows;




namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for ObjectRelator.
	/// </summary>
	public abstract class ObjectRelator
	{
		public ObjectRelator()
		{
		
		}

		public virtual void Relate( IRelatable relatee, RelationType relationType )
		{
		}

		public virtual void Relate( IRelatable relatee, string relationKey )
		{
		}

		protected ORMTypeMapping FetchTypeMap( IRelatable relatee )
		{
			//Logger.Write("Testing");
			//LogWriter.gger.Writer.SystemTrace.MethodStart( MethodBase.GetCurrentMethod() );
			Type t = relatee.GetType();
			Assembly sourceAssembly = t.Assembly;
			string resourceName = t.Namespace + ".ORM.xml";
			XmlDocument xDoc = new XmlDocument();
			StreamReader xmlRaw = new StreamReader(sourceAssembly.GetManifestResourceStream(resourceName) ); 
		 //	StreamReader xmlRaw = new StreamReader((esourceName);
			xDoc.Load( xmlRaw );

			string query = "//type[@fullname='" + t.FullName + "']";
			XmlNode typeMapNode = xDoc.DocumentElement.SelectSingleNode( query );
			if (typeMapNode != null )
			{
				ORMTypeMapping typeMap = new ORMTypeMapping( typeMapNode );
				return typeMap;
			}
			else
			{
			//	SystemTrace.TraceError("Failed to load type map for {0}", t.FullName);
			//	ExceptionPolicy.HandleException( new NullReferenceException("Unable to fetch type map for " + t.FullName), "Exception" );
                string debug = "Unable to fetch type map for " + t.FullName;
			}
			return null;
		}

	}
}
