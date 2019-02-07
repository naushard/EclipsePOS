using System;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Plu.
	/// </summary>
	public class Plu : IRelatable	
	{

		private double plu;
		private string sku;

		public Plu()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Properties

		//1
		public double PLU
		{
			set
			{
				plu = value;
			}
			get
			{
				return plu;
			}
		}

		
		
		//2
		public string  Sku
		{
			set
			{
				
				sku = value;
			}
			get
			{
				return sku;
			}
		}

		

		#endregion
		
		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}


		public void LoadByPLU()
		{
			if ( plu==0 )
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPluByPLU");
			
		}
		
		public void LoadBySku()
		{
			if ( sku == null )
			{
				return;
			}

			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "LoadPluBySku");
			
		}

	}
}
