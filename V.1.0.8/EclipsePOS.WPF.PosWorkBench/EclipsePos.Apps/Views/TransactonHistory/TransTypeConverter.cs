using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Data;

namespace EclipsePos.Apps.Views.TransactonHistory
{
    [ValueConversion(typeof(int), typeof(String))]
    public class TransTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int transType = int.Parse(value.ToString());

                switch (transType)
                {
                    case 1:
                        return "Sales";
                    case 2:
                        return "Logon";
                    case 3:
                        return "Logoff";
                    case 4:
                        return "Return";
                    case 5:
                        return "Blance";
                    case 6:
                        return "Count";
                    case 7:
                        return "Adjustment";
                    case 8:
                        return "Dine In";
                    case 9:
                        return "Carry Out";
                    case 10:
                        return "Paid In";
                    case 11:
                        return "Paid Out";
                    case 12:
                        return "Loan";
                    case 13:
                        return "Petty Cash In";
                    case 14:
                        return "Petty Cash Out";
                    case 15:
                        return "Bank In";
                    case 16:
                        return "Pick Up";
                    default:
                        return " ";
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
