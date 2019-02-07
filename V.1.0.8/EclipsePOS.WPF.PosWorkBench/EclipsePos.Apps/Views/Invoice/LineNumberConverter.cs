using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace EclipsePos.Apps.Views.Invoice
{
    [ValueConversion(typeof(int), typeof(String))]
    public class LineNumberConverter : IValueConverter
    {
        public static LineNumberConverter Instance = new LineNumberConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int linNumber = (int)value;
            if (linNumber == 0)
            {
                return " ";
            }
            else
            {
                return linNumber.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();


            if (string.IsNullOrEmpty(strValue))
            {
                return 0;
            }
            else
            {
                return strValue;
            }

            
        }


    }
}
