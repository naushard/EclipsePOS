using System;

namespace EclipsePos.Apps.Util
{
	/// <summary>
	/// Summary description for AnyRadix.
	/// </summary>
	public class PosTextFormatter : ICustomFormatter, IFormatProvider
	{
		
		public PosTextFormatter()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public object GetFormat( Type argType )
		{
			// Here, the same object (this) is returned, but it would 
			// be possible to return an object of a different type.
			if ( argType == typeof( ICustomFormatter ) )
				return this;
			else
				return null;
		}
		public string Format( string formatString, 
			object argToBeFormatted, IFormatProvider provider )
		{
			// If no format string is provided or the format string cannot 
			// be handled, use IFormattable or standard string processing.
			/*		if( formatString == null || 
						! formatString.Trim( ).StartsWith( radixCode ) )
					{
						if( argToBeFormatted is IFormattable )
							return ( (IFormattable)argToBeFormatted ).
								ToString( formatString, provider );
						else
							return argToBeFormatted.ToString( );
					}

					// The formatting is handled here.
					int     digitIndex = 0;
					long    radix;
					long    longToBeFormatted;
					long    longPositive;
					char[ ] outDigits = new char[ 63 ];
            
					// Extract the radix from the format string.
					formatString = formatString.Replace( radixCode, "" );
					try
					{
						radix = Convert.ToInt64( formatString );
					}
					catch( Exception ex )
					{
						throw new ArgumentException( String.Format( 
							"The radix \"{0}\" is invalid.", 
							formatString ), ex );
					}

					// Verify that the radix is in the proper range.
					if( radix <2 || radix > 36 )
						throw new ArgumentException( String.Format( 
							"The radix \"{0}\" is not in the range 2..36.", 
							formatString ) );
            
					// Verify that the argument can be converted to a long integer.
					try
					{
						longToBeFormatted = (long)argToBeFormatted;
					}
					catch( Exception ex )
					{
						throw new ArgumentException( String.Format(
							"The argument \"{0}\" cannot be " +
							"converted to an integer value.", 
							argToBeFormatted ), ex );
					}
            
					// Extract the magnitude for conversion.
					longPositive = Math.Abs( longToBeFormatted );

					// Convert the magnitude to a digit string.
					for( digitIndex = 0; digitIndex <= 64; digitIndex++ )
					{
						if( longPositive == 0 ) break;

						outDigits[ outDigits.Length - digitIndex - 1 ] = 
							rDigits[ longPositive % radix ];
						longPositive /= radix;
					}
            
					// Add a minus sign if the argument is negative.
					if( longToBeFormatted < 0 )
						outDigits[ outDigits.Length - digitIndex++ - 1 ] = 
							'-';

					return new string( outDigits, 
						outDigits.Length - digitIndex, digitIndex );
						*/
			string newstring = "";
			switch (formatString)
			{
				case ("Money"):
						newstring = System.Globalization.RegionInfo.CurrentRegion.CurrencySymbol+argToBeFormatted.ToString();
						break;

				default:
					newstring = argToBeFormatted.ToString();
					break;

			}


			return newstring;
		}
	}
}
