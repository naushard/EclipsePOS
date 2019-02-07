using System;
using System.Data;
using System.Xml;
//using System.Windows.Forms;



namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for ORMPropertyMap.
	/// </summary>
	public class ORMPropertyMap
	{
		private string memberName;
		private string dbType;
		private string direction;
		private int size;
		private string parameter;

		public ORMPropertyMap()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ORMPropertyMap( XmlNode propMap )
		{
			memberName = propMap.Attributes["member"].Value;
		//	Logger.Write(memberName);
			dbType = propMap.Attributes["dbtype"].Value;
			direction = propMap.Attributes["direction"].Value;
			size = System.Convert.ToInt32(propMap.Attributes["dbsize"].Value);
			parameter = propMap.Attributes["parameter"].Value;
		}

		public int Size
		{
			get 
			{
				return size;
			}
			set 
			{
				size = value;
			}
		}

		public string MemberName
		{
			get 
			{
				return memberName;
			}
			set 
			{
				memberName = value;
			}
		}

		public string DbType
		{
			get 
			{
				return dbType;
			}
			set 
			{
				dbType = value;
			}
		}

		public string Direction
		{
			get 
			{
				return direction;
			}
			set 
			{
				direction = value;
			}
		}

		public ParameterDirection DataDirection
		{
			get 
			{
				switch (direction.ToUpper())
				{
					case "INPUT" : return ParameterDirection.Input;
					case "OUTPUT" : return ParameterDirection.Output;
					case "INPUTOUTPUT" : return ParameterDirection.InputOutput;
					case "RETURNVALUE" : return ParameterDirection.ReturnValue;
				}
				return ParameterDirection.Input;
			}
		}

		public string Parameter
		{
			get 
			{
				return parameter;
			}
			set 
			{
				parameter = value;
			}
		}

		public SqlDbType SqlDataType
		{
			get 
			{
				//MessageBox.Show(dbType.ToUpper().ToString());
				switch (dbType.ToUpper())
				{
					case "INT" : return SqlDbType.Int;
					case "VARCHAR" : return SqlDbType.VarChar;
					case "DATETIME" : return SqlDbType.DateTime;
					case "TEXT" : return SqlDbType.Text;
					case "BINARY" : return SqlDbType.Binary;
					case "BOOLEAN" : return SqlDbType.Bit;
					case "DECIMAL" : return SqlDbType.Decimal;
					case "DOUBLE" : return SqlDbType.Float;
					case "FLOAT":return SqlDbType.Float;
                    case "BIGINT": return SqlDbType.BigInt;

				}
				return SqlDbType.Int;
			}
		}
	}
}
