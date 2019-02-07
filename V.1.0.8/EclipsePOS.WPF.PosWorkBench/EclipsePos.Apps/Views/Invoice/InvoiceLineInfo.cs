using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows;
using System.Collections;
using System.ComponentModel;



namespace EclipsePos.Apps.Views.Invoice
{
    public class InvoiceLineInfo : INotifyPropertyChanged

    {
        private string itemQty;
        private string item;
        private string itemDescription;
        private string itemPrice;
        private string itemAmount;
        private string plu;
        private int lineNumber;
        private string employee_no;
        public event PropertyChangedEventHandler PropertyChanged;


        public string Qty
        {
            set
            {
                itemQty = value;
                OnPropertyChanged("Qty");
            }
            get
            {
                return itemQty;
            }
        }

        public string Item
        {
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
            get
            {
                return item;
            }
        }

        public string PLU
        {
            set
            {
                plu = value;
                OnPropertyChanged("PLU");
            }
            get
            {
                return plu;
            }
        }

        public string Desc
        {
            set
            {
                itemDescription = value;
                OnPropertyChanged("Desc");
            }
            get
            {
                return itemDescription;
            }
        }

        public string Price
        {
            set
            {
                itemPrice = value;
                OnPropertyChanged("Price");
            }
            get
            {
                return itemPrice;
            }
        }

        public string Amount
        {
            set
            {
                itemAmount = value;
                OnPropertyChanged("Amount");
            }
            get
            {
                return itemAmount;
            }
        }

        public int LineNumber
        {
            set
            {
                lineNumber = value;
                OnPropertyChanged("LineNumber");
            }
            get
            {
                return lineNumber;
            }
        }

        public string Employee_no
        {
            set
            {
                employee_no = value;
                OnPropertyChanged("Employee_no");
            }
            get
            {
                return employee_no;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
