using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

using EclipsePos.Apps.Context;

namespace EclipsePos.Apps.Views.OrderList
{
    [ValueConversion(typeof(int), typeof(string))]
    public class OrderTypeConverter:IValueConverter
    {

        public static OrderTypeConverter Instance = new OrderTypeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tranType = int.Parse (value.ToString());
            switch (tranType)
            {
                case 0:
                    return PosContext.Instance.Parameters.getParam("SalePrompt");
                   
                case 4:
                    return PosContext.Instance.Parameters.getParam("ReturnSalePrompt");
                    
                case 8:
                    return PosContext.Instance.Parameters.getParam("DineInPrompt");
                   
                case 9:
                    return PosContext.Instance.Parameters.getParam("CarryOutPrompt");
                  
            }
            return "";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
