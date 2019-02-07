using System;

using EclipsePos.Data;
using EclipsePos.Apps.EJournal;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for PosItemModifier.
	/// </summary>
	public interface PosItemModifier
	{
		
		/** How to initialize */
		void Init (EjItem item, Promotion promotion);
		/** Modifier apply logic. */
		void Apply ();
			
		/** Amount of this modifier */
		double Amount
		{
			set;
			get;
		}
		/** Quantity of this modifier */
		int Quantity
		{
			set;
			get;
		}
		/** Applied flag, true if this modifier can be applied to this item */
		bool Applied
		{
			set;
			get;
		}
		/** Description of the modifier. */
		string Desc
		{
			set;
			get;
		}

        /** Line number of this modifier */
        int LineNo
        {
            set;
            get;
        }

       
	

	}
}
