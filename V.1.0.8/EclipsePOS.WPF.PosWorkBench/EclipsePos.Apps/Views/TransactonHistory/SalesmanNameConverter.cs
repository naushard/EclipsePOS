using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Data;
//using System.Collections.ObjectModel;
using System.Windows;

using EclipsePos.Data;
using EclipsePos.Apps.Util;



namespace EclipsePos.Apps.Views.TransactonHistory
{
    [ValueConversion(typeof(String), typeof(String))]
    public class SalesmanNameConverter : IValueConverter
    {
        private Dictionary<String, Employee> empCol = new Dictionary<String, Employee>();
        public SalesmanNameConverter()
        {
           
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return " ";
            }

            try
            {
               // Employee emp1 = empCol[value.ToString()];
               // return emp1.FName + emp1.LName;
                return SalesmanNamesHelper.Instance().SalesmanName(value.ToString());
            }
            catch
            {
            }



            return " ";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "Unspecified";
            }

            return "Testing";
        }


    }
}
