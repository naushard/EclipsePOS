using System;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for SimpleMath.
	/// </summary>
	public class SimpleMath:PosMath
	{
		public SimpleMath()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region PosMath Members

		public double Add(double a, double b)
		{
			return a+b;
		}

		public double Sub(double a, double b)
		{
			return a-b;
		}

		public double Mult(double a, double b)
		{
			return a*b;
		}

		public double Div(double a, double b)
		{
			return a/b;
		}

		public double RoundUp(double a)
		{
			return Math.Ceiling(a);
		}

		public double RoundDown(double a)
		{
			return Math.Floor(a);
		}

		public double Negate(double a)
		{
			return a*(-1);
		}

		int EclipsePos.Apps.Operators.PosMath.Add(int a, int b)
		{
			return a+b;
		}

		int EclipsePos.Apps.Operators.PosMath.Sub(int a, int b)
		{
			return a-b;
		}

		int EclipsePos.Apps.Operators.PosMath.Mult(int a, int b)
		{
			return a*b;
		}

		int EclipsePos.Apps.Operators.PosMath.Div(int a, int b)
		{
			return a/b;
		}

		int EclipsePos.Apps.Operators.PosMath.Negate(int a)
		{
			return a*(-1);
		}
		
		public double ApplyTax(double itemAmount, double rate)
		{
			return itemAmount * rate;
		}

        /** Get Amount from input with two decimals **/
        public double GetAmount(double a)
        {
            return a / 100;
        }
        /** Get Quantity with zero decimals **/
        public double GetQantity(double a)
        {
            return a;
        }

		#endregion
	}
}
