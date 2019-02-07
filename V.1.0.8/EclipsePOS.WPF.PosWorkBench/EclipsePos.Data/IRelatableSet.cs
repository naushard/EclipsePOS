
using System;
using System.Data;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for IRelatableSet.
	/// </summary>
	public interface IRelatableSet : IRelatable
	{		
		DataSet ResultSet { get; set; }
	}
}
