using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Windows;
using EclipsePos.Data.Util;


namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for SqlRelator.
	/// </summary>
	public class SqlRelator : ObjectRelator 
	{
		private SqlConnection conn;

		public SqlRelator()
		{

			
		//string  dataSource = "server=W2003\\MSSQL;" +
		//						 "uid=sa;pwd=naushard;" +
		//			"Trusted_Connection=True;" +
	    //							  "database=possite"; 	
			
		//	 string  dataSource = "server=eclipse-npc\\SQLEXPRESS;" +
		//				"Trusted_Connections=True;" +
        //        "database=possite;"; 	
		
		//	string dataSource = ConfigurationSettings.AppSettings["DataSource"];
		//	MessageBox.Show(dataSource);

           //tring dataSource = "Server=.\\SQLExpress;AttachDbFilename=C:\\DOCUMENTS AND SETTINGS\\NAUSHARD\\MY DOCUMENTS\\POSSITE.MDF;Database=dbname;Trusted_Connection=Yes";
           // string dataSource = "server=.\\SQLEXPRESS;AttachDbFilename=C:\\Documents and Settings\\naushard\\My Documents\\possite.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
          //  string dataSource = "server=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\possite.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";


            string dataSource = PosSettings.Default.DataSource; //"server=.\\SQLEXPRESS;Database=posste9;Integrated Security=True;";
        //    string dataSource = "server=.\\SQLEXPRESS;AttachDbFilename=C:\\C#Projects\\EclipsePOS.WPF.PosWorkBen" +
        //  "ch\\Data\\possite.mdf;Integrated Security=True;Connect Timeout=30;User Instance=Tr" +
        //  "ue";   

            try
            {
                conn = new SqlConnection(dataSource);
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString() );
            }
      

		}

		#region Public ObjectRelator methods
		public override void Relate( IRelatable relatee, RelationType relationType )
		{
			//SystemTrace.MethodStart( MethodBase.GetCurrentMethod() );
			//Logger.Write(MethodBase.GetCurrentMethod());
			Relate( relatee, relationType.ToString() );
		}

		

		public override void Relate( IRelatable relatee, string relationKey )
		{
			//Logger.Write( MethodBase.GetCurrentMethod() );
			ORMTypeMapping typeMap = FetchTypeMap( relatee );			
		 	ORMCommandMap cmdMap = typeMap.GetMapByName( relationKey );
			SqlCommand cmd = BuildCommandFromTypeMap( relatee, typeMap , relationKey );
			//Logger.Write(cmd.ToString());
			try 
			{
				conn.Open();
				if (cmdMap.ReturnsMultiple)
				{	
					SqlDataAdapter da = new SqlDataAdapter( cmd );
					IRelatableSet relateSet = (IRelatableSet)relatee;
					da.Fill( relateSet.ResultSet );
				}
				else 
				{
					//	Logger.Write(cmd.CommandText);
					//	Logger.Write(cmd.Parameters.ToString());
					cmd.ExecuteNonQuery();
				}			
				AssignOutputValuesToObject( cmd, relatee, typeMap, relationKey );
				//conn.Close();
			}
			catch(Exception e)
			{
                string b = e.ToString();
                MessageBox.Show( relationKey+ "\\n" +e.ToString() );
			}
			finally
			{
				conn.Close();
			}
		}

		private void AssignOutputValuesToObject( SqlCommand cmd, IRelatable relatee, ORMTypeMapping typeMap, string relationKey )
		{
		//	Logger.Write( MethodBase.GetCurrentMethod() );
			ORMCommandMap ocm = typeMap.GetMapByName( relationKey );
			foreach (object ob in ocm.PropertyMaps)
			{
				ORMPropertyMap propMap = (ORMPropertyMap)ob;
				if (( propMap.DataDirection == ParameterDirection.Output) ||
					( propMap.DataDirection == ParameterDirection.InputOutput ) )
				{
					PropertyInfo prop;
					Type t = relatee.GetType();
					prop = t.GetProperty( propMap.MemberName );
					if (prop != null)
					{
						if ( cmd.Parameters[ propMap.Parameter ].Value != DBNull.Value)
						{
								prop.SetValue( relatee, cmd.Parameters[ propMap.Parameter ].Value, null );
						}
					}
					else
					{
					//	ExceptionPolicy.HandleException( new NullReferenceException(("Missing member " + t.FullName + "." + propMap.MemberName)), "Exception"  );
					}
				}				
			}

		}

		private SqlCommand BuildCommandFromTypeMap( IRelatable relatee, ORMTypeMapping typeMap, string relationKey )
		{
		//	Logger.Write( MethodBase.GetCurrentMethod() );
			ORMCommandMap ocm = typeMap.GetMapByName( relationKey );
			if (ocm != null)
			{
				SqlCommand cmd = new SqlCommand( ocm.StoredProcedure, conn );
				cmd.CommandType = CommandType.StoredProcedure;
				foreach (object ob in ocm.PropertyMaps)
				{
					ORMPropertyMap propMap = (ORMPropertyMap)ob;
					SqlParameter newParam = CreateParameterFromPropertyMap( propMap );
					if ((newParam.Direction == ParameterDirection.Input) ||
						(newParam.Direction == ParameterDirection.InputOutput) )
					{
						SetParameterValue( newParam, relatee, propMap.MemberName );
					}
					cmd.Parameters.Add( newParam );
				}
				return cmd;
			}
			else
			{
				//ExceptionPolicy.HandleException( new NullReferenceException("No such command mapping: " + typeMap.FullName + ":" + relationKey), "Exception" );
			}
			return null;
		}

		private SqlParameter CreateParameterFromPropertyMap( ORMPropertyMap propMap )
		{
			//Logger.Write( MethodBase.GetCurrentMethod() );
			SqlParameter param = new SqlParameter();
			param.ParameterName = propMap.Parameter;
			param.SqlDbType = propMap.SqlDataType;
			param.Direction = propMap.DataDirection;
			if (propMap.Size != -1)
				param.Size = propMap.Size;
			return param;
		}

		private void SetParameterValue( SqlParameter param, IRelatable relatee, string member )
		{
			//Logger.Write( MethodBase.GetCurrentMethod() );
			PropertyInfo propInfo;
			Type t = relatee.GetType();
			propInfo = t.GetProperty( member );
			if (propInfo != null )
			{
				param.Value = propInfo.GetValue( relatee, null );
			}
			else
			{
				//Logger.Write("Read failed on member {0} on type {1}", "pos exception");
			}
		}
		#endregion

	


	}	
}
