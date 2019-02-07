//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: August, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================


using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for PosPaarm.
	/// </summary>
	public class PosParam : IRelatableSet	
	{
		#region Varialbles

		//private int param_id;
		private int config_no;
		private int param_type;
		private int param_catogory;
		private int help_id;
		private string param_name;
		private string param_value;
        private string remarks;

		private DataSet resultSet; 

		#endregion 


		public PosParam()
		{
			resultSet = new DataSet();
		}

		#region Properties
	
		public string Remarks
		{
			set 
			{
				remarks = value;
			}
			get 
			{
				return remarks;
			}
		}
		
		public int Config_no
		{
			set 
			{
				config_no = value;
			}
			get 
			{
				return config_no;
			}
		
		}

		public int Param_type
		{
			set 
			{
				param_type = value;
			}
			get 
			{
				return param_type;
			}
		
		}

		public int Param_catogory
		{
			set 
			{
				param_catogory = value;
			}
			get 
			{
				return param_catogory;
			}
		
		}


		public int Help_id
		{
			set 
			{
				help_id = value;
			}
			get 
			{
				return help_id;
			}
		
		}

		public string Param_name
		{ 
			set 
			{
				param_name = value;
			}
			get 
			{
				return param_name;
			}
		
		}


		public string Param_value
		{
			set 
			{
				param_value = value;
			}
			get 
			{
				return param_value;
			}
		
		}

		#endregion
		
		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");
		}



		public void Load()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "Select");
						
		}

		public DataSet LoadByConfigNo()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPosParamByConfigNo");
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
