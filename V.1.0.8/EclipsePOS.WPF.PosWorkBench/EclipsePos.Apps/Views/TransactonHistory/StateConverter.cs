using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Data;
//using System.Collections.ObjectModel;

using EclipsePos.Data;
using EclipsePos.Apps.Util;

namespace EclipsePos.Apps.Views.TransactonHistory
{
    [ValueConversion(typeof(int), typeof(String))]
    public class StateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int state = int.Parse(value.ToString());

                switch (state)
                {
                    case 0:
                        return "Incomplete" ;
                    case 1:
                    	return "In progress";
                    case 2:
                        return  "Complete";
                    case 3:
			            return "Suspended";
                    case 4:
                        return "Voided";
                    default:
                        return "Unspecified";
                }
            }
            catch
            {
                return "System error";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
