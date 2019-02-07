using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EclipsePos.Apps.Hardware;

namespace EclipsePos.Apps.Views.Controls
{
    public class PosButton:Button
    {
        private int keyValue;
        private int keyCode;
        private string keyClass;
        private int accessKeyValue;
        private string keyText;
        private int logoutDisable;

        public int LogoutDisable
        {
            get { return logoutDisable; }
            set { logoutDisable = value; }
        }
       

        public int KeyValue
        {
            set
            {
                keyValue = value;
            }
            get
            {
                return keyValue;
            }
        }

        public int KeyCode
        {
            set
            {
                keyCode = value;
            }
            get
            {
                return keyCode;
            }
        }

        public string KeyClass
        {
            set
            {
                keyClass = value;
            }
            get
            {
                return keyClass;
            }
        }

        public int AccessKeyValue
        {
            set
            {
                accessKeyValue = value; 
            }
            get
            {
                return accessKeyValue;
            }
        }

        public string KeyText
        {
            set
            {
                keyText = value;
            }
            get
            {
                return keyText;
            }
        }

        public string Sku
        {
            set;get;
        }

        public string ItemGroup
        {
            set;get;
        }

        

    }
}
