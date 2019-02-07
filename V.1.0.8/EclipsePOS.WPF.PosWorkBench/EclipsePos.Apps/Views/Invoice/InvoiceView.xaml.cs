using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data;



using EclipsePos.Apps.Devices;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.EJournal;



namespace EclipsePos.Apps.Views.Invoice
{
    /// <summary>
    /// Interaction logic for InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : UserControl, PosTicket
    {
        private string itemQty;
        private string item;
        private string itemDescription;
        private string itemPrice;
        private string itemAmount;
        private string plu;
        private string employee_no;
        private int lineNumber;
        private ObservableCollection<InvoiceLineInfo> invoiceLines;
        private CollectionView _colView;

        private InvoiceLineInfo surchargeLine = null;
        private InvoiceLineInfo discountLine = null;
        private InvoiceLineInfo lineInfo;

        public InvoiceView() 
        {
           InitializeComponent();

           invoiceLines = new ObservableCollection<InvoiceLineInfo>();
          
           this.invoiceListView.ItemsSource = invoiceLines;
           _colView = CollectionViewSource.GetDefaultView(invoiceLines) as CollectionView;  //invoiceDataSet.Tables[0]) as CollectionView;

            
        //   this.invoiceDocPanel.SizeChanged += new SizeChangedEventHandler(invoiceDocPanel_SizeChanged);

        //   this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

           this.Loaded += new RoutedEventHandler(InvoiceView_Loaded);

           this.invoiceListView.SelectionChanged += new SelectionChangedEventHandler(invoiceListView_SelectionChanged);
        }

        void invoiceListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PosEventStack.Instance.CurrentEvent is ItemVoid)
            {
                ItemVoid itemVoid = PosEventStack.Instance.CurrentEvent as ItemVoid;
                if (itemVoid.States().PeekState() == ItemVoid.GET_LINE_NUMBER)
                {
                    try
                    {
                        InvoiceLineInfo lineInfo = _colView.CurrentItem as InvoiceLineInfo;
                        PosContext.Instance.ClearInput();
                        NumKey numKey = new NumKey();
                        numKey.Engage(lineInfo.LineNumber);
                    }
                    catch
                    {
                    }
                }
            }
           
            if (PosEventStack.Instance.CurrentEvent is EjPriceOverride)
            {
                EjPriceOverride ejPO = PosEventStack.Instance.CurrentEvent as EjPriceOverride;
                if (ejPO.States().PeekState() == EjPriceOverride.GET_LINE_NUMBER)
                {
                    try
                    {
                        InvoiceLineInfo lineInfo = _colView.CurrentItem as InvoiceLineInfo;
                        PosContext.Instance.ClearInput();
                        NumKey numKey = new NumKey();
                        numKey.Engage(lineInfo.LineNumber);
                    }
                    catch
                    {
                    }
                }
            }

            if (PosEventStack.Instance.CurrentEvent is ChangeQuantity)
            {
                ChangeQuantity chQty = PosEventStack.Instance.CurrentEvent as ChangeQuantity;
                if (chQty.States().PeekState() == ChangeQuantity.GET_LINE_NUMBER)
                {
                    try
                    {
                        InvoiceLineInfo lineInfo = _colView.CurrentItem as InvoiceLineInfo;
                        PosContext.Instance.ClearInput();
                        NumKey numKey = new NumKey();
                        numKey.Engage(lineInfo.LineNumber);
                    }
                    catch
                    {
                    }
                }
            }

            if (PosEventStack.Instance.CurrentEvent is RemoveSalesPerson)
            {
                RemoveSalesPerson rSalesPerson = PosEventStack.Instance.CurrentEvent as RemoveSalesPerson;
                if (rSalesPerson.States().PeekState() == RemoveSalesPerson.GET_SALES_PERSON)
                {
                    try
                    {

                        InvoiceLineInfo lineInfo = _colView.CurrentItem as InvoiceLineInfo;
                        PosContext.Instance.ClearInput();
                        PosContext.Instance.InputLine = lineInfo.Employee_no;
                        PosEventStack.Instance.NextEvent();
                    }
                    catch
                    {
                    }
                }
            }
            
        }

        void InvoiceView_Loaded(object sender, RoutedEventArgs e)
        {
            this.columnHeaderItem.Header = PosContext.Instance.Parameters.getParam("ItemHeader");
            this.columnHeaderDescription.Header = PosContext.Instance.Parameters.getParam("DescHeader");
            this.columnHeaderQty.Header = PosContext.Instance.Parameters.getParam("QtyHeader");
            this.columnHeaderAmount.Header = PosContext.Instance.Parameters.getParam("PriceHeader");
            this.columnHeaderValue.Header = PosContext.Instance.Parameters.getParam("ValueHeader");
            this.columnHeaderLineNumber.Header = PosContext.Instance.Parameters.getParam("LineNumberHeader");


            double invWidth = this.invoiceDocPanel.ActualWidth-5;
            
            int lineNumberWidth = 10;
            int itemWidth = 20;
            int descriptionWidth = 30;
            int quantityWidth = 10;
            int priceWidth = 15;
            int amountWidth = 15;
            
           

            try
            {
                lineNumberWidth = int.Parse(PosContext.Instance.Parameters.getParam("LineNumberWidth%"));
                itemWidth = int.Parse(PosContext.Instance.Parameters.getParam("ItemWidth%"));
                descriptionWidth = int.Parse(PosContext.Instance.Parameters.getParam("DescriptionWidth%"));
                quantityWidth = int.Parse(PosContext.Instance.Parameters.getParam("QuantityWidth%"));
                priceWidth = int.Parse(PosContext.Instance.Parameters.getParam("PriceWidth%"));
                amountWidth = int.Parse(PosContext.Instance.Parameters.getParam("AmountWidth%"));
            }
            catch
            {
                lineNumberWidth = 10;
                itemWidth = 20;
                descriptionWidth = 30;
                quantityWidth = 10;
                priceWidth = 15;
                amountWidth = 15;

            }

            double totalWidth = lineNumberWidth + itemWidth + descriptionWidth + quantityWidth + priceWidth + amountWidth;

            this.columnHeaderLineNumber.Width = Math.Ceiling((invWidth * lineNumberWidth / totalWidth));
            this.columnHeaderItem.Width = Math.Ceiling((invWidth * itemWidth / totalWidth));
            this.columnHeaderDescription.Width = Math.Ceiling((invWidth * descriptionWidth / totalWidth));
            this.columnHeaderQty.Width = Math.Ceiling((invWidth * quantityWidth / totalWidth));
            this.columnHeaderAmount.Width = Math.Ceiling((invWidth * priceWidth / totalWidth));
            this.columnHeaderValue.Width = Math.Ceiling((invWidth * amountWidth / totalWidth));
 

            
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          //  MessageBox.Show(Application.Current.MainWindow.ActualHeight.ToString());
        }

        void invoiceDocPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double invWidth  = this.invoiceDocPanel.ActualWidth - 25;
            
            int lineNumberWidth = 10;
            int itemWidth = 20;
            int descriptionWidth = 30; 
            int quantityWidth = 10;
            int priceWidth = 15;
            int amountWidth = 15;
            
            try
            {
                lineNumberWidth = int.Parse(PosContext.Instance.Parameters.getParam("LineNumberWidth%"));
                itemWidth = int.Parse(PosContext.Instance.Parameters.getParam("ItemWidth%"));
                descriptionWidth = int.Parse(PosContext.Instance.Parameters.getParam("DescriptionWidth%"));
                quantityWidth = int.Parse(PosContext.Instance.Parameters.getParam("QuantityWidth%"));
                priceWidth = int.Parse(PosContext.Instance.Parameters.getParam("PriceWidth%"));
                amountWidth = int.Parse(PosContext.Instance.Parameters.getParam("AmountWidth%"));
            }
            catch
            {
                lineNumberWidth = 10;
                 itemWidth = 20;
                 descriptionWidth = 30;
                 quantityWidth = 10;
                 priceWidth = 15;
                 amountWidth = 15;
            
            }

             double totalWidth = lineNumberWidth + itemWidth + descriptionWidth + quantityWidth + priceWidth + amountWidth; 

             this.columnHeaderLineNumber.Width = Math.Ceiling((invWidth * lineNumberWidth / totalWidth));
             this.columnHeaderItem.Width = Math.Ceiling( (invWidth * itemWidth/totalWidth));
             this.columnHeaderDescription.Width = Math.Ceiling((invWidth * descriptionWidth / totalWidth));
             this.columnHeaderQty.Width = Math.Ceiling((invWidth * quantityWidth / totalWidth));
             this.columnHeaderAmount.Width = Math.Ceiling((invWidth * priceWidth / totalWidth));
             this.columnHeaderValue.Width = Math.Ceiling((invWidth * amountWidth / totalWidth));
 
            
             this.invoiceDocPanel.MaxHeight = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.43);
           
        
        }

        
        #region PosTicket Members

        public int QtyWidth
        {
            get
            {  
                return (int) this.columnHeaderQty.Width;
            }
            set
            {
                this.columnHeaderQty.Width = value;
            }
        }

        public int ItemWidth
        {
            get
            {
                return (int) this.columnHeaderItem.Width;
            }
            set
            {
                this.columnHeaderItem.Width = value;
            }
        }

        public int AmountWidth
        {
            get
            {
                return (int)columnHeaderAmount.Width;
            }
            set
            {
                columnHeaderAmount.Width = value;
            }
        }

        public int TotalWidth
        {
            get
            {
                // TODO:  Add OperDisplay.TotalWidth getter implementation
                return 0;
            }
            set
            {
                // TODO:  Add OperDisplay.TotalWidth setter implementation
            }
        }

        public string Qty
        {
            set
            {
                itemQty = value;
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
                plu = value; // TODO:  Add OperDisplay.Item setter implementation
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
            }
            get
            {
                return employee_no;
            }
        }

        public int GetCurrentLineNo
        {
            get
            {
                try
                {
                    InvoiceLineInfo lineInfo = _colView.CurrentItem as InvoiceLineInfo;
                    return lineInfo.LineNumber;
                }
                catch
                {
                    return 0; 
                }
 
            }
        }





        public void Println()
        {


            lineInfo = new InvoiceLineInfo();
            lineInfo.Amount = this.Amount;
            lineInfo.Desc = this.Desc;
            lineInfo.Item = this.Item;
            lineInfo.Price = this.Price;
            lineInfo.Qty = this.Qty;
            lineInfo.PLU = this.PLU;
            lineInfo.LineNumber = this.LineNumber;
            lineInfo.Employee_no = this.Employee_no;

            invoiceLines.Add(lineInfo);

            
            _colView.MoveCurrentToLast();
            this.SetSelectedItemCursor();

        }

        


        public void ChangeLineQuantity(string qty, string amt)
        {
            lineInfo = _colView.CurrentItem as InvoiceLineInfo;
            lineInfo.Amount = amt;
            lineInfo.Qty = qty;
        }

        public void ChangeLinePrice(string price, string amt)
        {
            lineInfo = _colView.CurrentItem as InvoiceLineInfo;
            lineInfo.Amount = amt;
            lineInfo.Price = price;
        }
        

        void EclipsePos.Apps.Devices.PosTicket.Println(String value)
        {
            // TODO:  Add OperDisplay.EclipsePos.Apps.Devices.PosTicket.Println implementation
        }

        public void PrintBold(String value)
        {
            // TODO:  Add OperDisplay.PrintBold implementation
        }

        public void Clearln(int index)
        {
           try
            {
                InvoiceLineInfo lineInfoWork = null;
                foreach (InvoiceLineInfo lineInfo in invoiceLines)
                {
                    if (lineInfo.LineNumber == index )
                    {
                        lineInfoWork = lineInfo;
                    }
                }
                if (lineInfoWork != null)
                {
                    invoiceLines.Remove(lineInfoWork);
                }
            }
            catch (Exception ex)
            {
            }
            
        }

        public void ClearEmployeeLine(string employee)
        {
            try
            {
                InvoiceLineInfo lineInfoWork = null;
                foreach (InvoiceLineInfo lineInfo in invoiceLines)
                {
                    if (lineInfo.Employee_no == employee)
                    {
                        lineInfoWork = lineInfo;
                    }
                }
                if (lineInfoWork != null)
                {
                    invoiceLines.Remove(lineInfoWork);
                }
            }
            catch (Exception ex)
            {
            }

        }


        public void Clear()
        {
             invoiceLines.Clear();
             this.surchargeLine = null;
             this.discountLine = null;
          
        }

        public void PrintlnSurcharge()
        {
            if (this.surchargeLine == null)
            {
                this.Println();
                this.surchargeLine = this.lineInfo;
            }
            else
            {
                this.surchargeLine.Amount = this.Amount;
            }


        }

        public void PrintlnDiscount()
        {

         
            if (this.discountLine == null)
            {
                this.Println();
                this.discountLine = this.lineInfo;
            }
            else
            {
                this.discountLine.Amount = this.Amount;

            }
            
        }



        #endregion

        #region PageUp
        public void PageUp()
        {
         
            _colView.MoveCurrentToPrevious();
            this.SetSelectedItemCursor();
            

        }
        #endregion

        #region PageDown
        public void PageDown()
        {
            
            _colView.MoveCurrentToNext();
            this.SetSelectedItemCursor();

        }
        #endregion

        public void SetSelectedItemCursor()
        {
            this.invoiceListView.ScrollIntoView(this.invoiceListView.Items.CurrentItem);
            this.invoiceListView.SelectedItem = this.invoiceListView.Items.CurrentItem;
        }

        
    }

    
}
