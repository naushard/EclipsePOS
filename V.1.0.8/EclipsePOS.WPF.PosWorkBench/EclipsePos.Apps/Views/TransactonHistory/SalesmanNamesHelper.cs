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
    public sealed class SalesmanNamesHelper
    {
        private static Dictionary<String, Employee> empCol = new Dictionary<String, Employee>();
        
        SalesmanNamesHelper()
        {
            try
            {
                Employee emp = new Employee();
                emp.Organization_no = PosSettings.Default.Organization;
                DataSet data = emp.LoadAllEmployees();

                DataTable dt = data.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp1 = new Employee();
                    emp1.Organization_no = dr["Organization_no"].ToString();
                    emp1.Employee_no = dr["employee_no"].ToString();
                    emp1.Logon_pass = dr["logon_pass"].ToString();
                    emp1.FName = dr["fname"].ToString();
                    emp1.LName = dr["lname"].ToString();
                    emp1.Employee_no = dr["employee_no"].ToString();
                    emp1.MI = dr["mi"].ToString();
                    emp1.SSN = dr["ssn"].ToString();
                    emp1.Sal_grade = 0; //int.Parse(dr["Organization_no"].ToString());
                    try
                    {
                        empCol.Add(emp1.Employee_no, emp1);
                    }
                    catch (System.ArgumentNullException e1)
                    {
                       // MessageBox.Show(e1.ToString());
                    }
                    catch (System.ArgumentException e2)
                    {
                       // MessageBox.Show(e2.ToString());
                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        static readonly SalesmanNamesHelper instance = new SalesmanNamesHelper();
        public static SalesmanNamesHelper Instance()
        {
            return instance;
        }

        public string SalesmanName(string logon)
        {
            Employee emp1 = empCol[logon];
            return emp1.FName + emp1.LName;
        }


    }
}
