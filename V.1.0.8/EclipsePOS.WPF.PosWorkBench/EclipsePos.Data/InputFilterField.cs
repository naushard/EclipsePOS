using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for InputFilterField.
	/// </summary>
	public class InputFilterField:IRelatableSet		
	{
		private DataSet resultSet;

		private int filter_id;
		private int sequence_no;
		private string name;


		public InputFilterField()
		{
			resultSet = new DataSet();
		}

		#region Properties

		public int Filter_id
		{
			set
			{
				filter_id = value;
			}
			get
			{
				return filter_id;
			}
		}

		public int Sequence_no
		{
			set
			{
				sequence_no= value;
			}
			get
			{
				return sequence_no;
			}
		}

		public string Name
		{
			set
			{
				name = value;
			}
			get
			{
				return name;
			}
		}

		
		#endregion


		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public DataSet LoadAllByFilterId()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadAllByFilterId");
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
