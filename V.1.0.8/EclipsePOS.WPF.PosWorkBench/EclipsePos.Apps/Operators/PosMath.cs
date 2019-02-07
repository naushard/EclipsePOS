using System;

namespace EclipsePos.Apps.Operators
{
	/// <summary>
	/// Summary description for PosMath.
	/// </summary>
	public interface PosMath
	{
		/** Addition */
		double Add (double a, double b);
		/** Subtraction */
		double Sub (double a, double b);
		/** Multiplication */
		double Mult (double a, double b);
		/** Division */
		double Div (double a, double b);
		/** Round double up */
		double RoundUp (double a);
		/** Round double down */
		double RoundDown (double a);
		/** Negate, ex: n*-1 */
		double Negate (double a);
		/** Integer add */
		int Add (int a, int b);
		/** Integer subtract */
		int Sub (int a, int b);
		/** Integer multiply */
		int Mult (int a, int b);
		/** Integer divide */
		int Div (int a, int b);
		/** int Negative **/
		int Negate(int a);
		/** Tax application */
		double ApplyTax (double a, double b);

        /** Get Amount from input with proper decimals **/ 
        double GetAmount(double a);
        /** Get Quantity from input with proper decimals **/
        double GetQantity(double a);

	}
}
