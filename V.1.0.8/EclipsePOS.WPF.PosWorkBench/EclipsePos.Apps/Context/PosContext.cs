//===============================================================================
// EclipsePos Pos System
//===============================================================================
// Eclipse Software Pte ltd.
//===============================================================================
// Author	: M.S.Naushard
// Date		: August, 2006
//===============================================================================
// Changes/Fixes
//
//===============================================================================
using System;
using System.Collections;
using System.Windows;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

using EclipsePos.Data;
using EclipsePos.Apps.Devices;
using EclipsePos.Apps.EJournal;
using EclipsePos.Apps.PosEvents;
using EclipsePos.Apps.Operators;
using EclipsePos.Apps.Hardware;
using EclipsePos.Apps.Util;


using Microsoft.PointOfService;

namespace EclipsePos.Apps.Context
{
	/// <summary>
	/// Summary description for PosContext.
	/// </summary>
	/// 

	
	public sealed class PosContext : IDisposable
	{
		

		#region Variable
		
		private RetailStore retailStore;
	
		private PosConfig config;
		private StringBuilder inputLine;
		private double sign=1.0;
		private int quantity;
		private Ej ej; 
		private int transType;
		private int user;
		private int recallPosNo;
		private int recallTransNo;
		public  Currency localCurrency;
		private Employee employee;
		private EjItem ejItem;
        private EjCustomer ejCustomer;
    	private Promotion promotion;
		private Filters msrFilters;
		private Filters scannerFilters;
		private bool locked;
		private OperPrompt operPrompt;
		private Receipt receipt;
		private ArrayList guis;
		private int drawerNo;
		private Currency altCurrency;
        private CurrencyCode altCurrencyCode;
		private ArrayList components;
		private bool speedDrawer = true;
		private string receiptClass;
		private string promptClass;
		private string mathClass;
		private string fieldsClass;
		private string initialDialog;
		private static PosContext posContext;
		private PosDisplays posDisplay;
		private PosTicket posTicket;
		private PosTicketHeader posTicketHeader;
		private PosTicketTotal posTicketTotal;
		private PosPrompt posPrompt;
		private PosKeyEnable keyPanel;
		private double subTotal;
		private double taxTotal;
		private double paymentTotal;
		private PosParameters parameters;
		private bool trainningMode =false;
		private int trxNo;
		private Hashtable keysById;
		private Hashtable keysByControl;
		private ItemLookup itemLookupPanel;
        private ICustomerLookup customerLookupDevice; 
		private PosMath posMath;
		private SearchBy searchBy;
		private PosExplorer posExplorer;
        private string tableName=" ";
        private Int64 posKeyValue;
        private Organization organization;
        private bool useDefaultPrinter = true;
        private PosHardwareStatusDisplay posHardwareStatusDevice1;
        private PosHardwareStatusDisplay posHardwareStatusDevice2;
        private AlphaKeyEntry alphaKeyEntry;
        private int transactionType;
        
	
		#endregion
		
		
		static PosContext()
		{
			posContext = new PosContext();
		}
		
		public PosContext()
		{
			keysById = new Hashtable();
			keysByControl= new Hashtable();
			guis = new ArrayList();
			inputLine = new StringBuilder();
			string mathClass = "EclipsePos.Apps.Operators.SimpleMath";
			//Assembly assemble = ;
			try 
			{
				this.PosMath = Assembly.GetExecutingAssembly().CreateInstance(mathClass) as PosMath; 
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		
			
		}

		
		

		#region Properties

		public static PosContext Instance
		{
			get
			{
				return posContext;
			}
		}

        public Organization Organization
        {
            get
            {
                return organization;
            }
            set
            {
                this.organization = value;
            }
        }


		//Currently logged in Employee 
		public Employee CurrentEmployee
		{
			get
			{
				return employee;
			}
			set
			{
				employee = value;
			}
		}

		//Event Stack
		//[Obsolete("Please use EclipsePos.Apps.Context.PosEventStack.Instance")] 
		//public PosEventStack EventStack
		//{
		//	get
		//	{
		//		return eventStack;
		//	}
		//	
		//}

		//Operator Prompt class 
		public OperPrompt Operprompt
		{
			get
			{
				return operPrompt;
			}
			set 
			{
				operPrompt = value;
				
			}
		}

		//Receipt class 
		public Receipt Receipt
		{
			get
			{
				return receipt;
			}
			set 
			{
				receipt = value;
			}
		}
 
		//RetailStore

		public RetailStore RetailStore
		{
			get
			{
				return retailStore;
			}
			set 
			{ 
				retailStore = value;
			}
		}

		//Pos Key Value
		public Int64 PosKeyValue
		{
			get
			{
				return posKeyValue;
			}
			set
			{
				posKeyValue = value;
			}
		}

		public PosDisplays CurrentPosDisplay
		{
			get
			{
				return posDisplay;
			}
			set
			{
				posDisplay = value;
				
			}
		}

		public PosTicket ReceiptDetails
		{
			get
			{
				return posTicket;
			}
			set
			{
				posTicket = value;
			}
		}

		public PosTicketHeader ReceiptHeader
		{
			get
			{
				return posTicketHeader;
			}
			set
			{
				posTicketHeader = value;
			}
		}
	
		public PosTicketTotal  ReceiptTotal
		{
			get
			{
				return posTicketTotal;
			}
			set
			{
				posTicketTotal = value;
			}
		}

		public PosPrompt PosPrompt
		{
			get
			{
				return posPrompt;
			}
			set
			{
				posPrompt = value;
			}
		}

		public PosKeyEnable CurrentPosKeyPanel
		{
			get
			{
				return keyPanel;
			}
			set
			{
				keyPanel = value;
			}
		}

	
	

		public int Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				quantity = value;
			}
		}


		public Employee Employee
		{
			get
			{
				return employee;
			}
			set
			{
				employee = value;
			}
		
		}


		public double SubTotal
		{
			get
			{
				return subTotal;
			}
			set
			{
				subTotal = value;
			}
		
		}


		public double TaxTotal
		{
			get
			{
				return taxTotal;
			}
			set
			{
				taxTotal = value;
			}
		
		}


		public double PaymentTotal
		{
			get
			{
				return paymentTotal;
			}
			set
			{
				paymentTotal = value;
			}
		
		}

		public PosParameters Parameters 
		{
			get
			{
				return parameters;
			}
			set
			{
				parameters = value;
			}
		
		}

		public bool Training
		{
			get
			{
				return trainningMode;
			}
			set
			{
				trainningMode = value;
			}
		}

		public EjItem CurrentEjItem
		{
			get
			{
				return ejItem;
			}
			set
			{
				ejItem = value;
			}
		}

		public Ej CurrentEj
		{
			get
			{
				return ej;
			}
			set
			{
				ej = value;
			}
		}

		public int TrxNo
		{
			get
			{
				return trxNo;
			}
			set
			{
				trxNo = value;
				//this.ReceiptHeader.TrxNo= string.Format("{0:000000}", trxNo);
		
			}
		}


		public Hashtable KeysById
		{
			get
			{
				return keysById;
			}
		}

		public Hashtable KeysByControl
		{
			get
			{
				return keysByControl;
			}
		}


		public ArrayList Guis
		{
			get
			{
				return guis;
			}
		}

		public ItemLookup ItemLookupDevice
		{
			get
			{
				return itemLookupPanel;
			}
			set
			{
				itemLookupPanel = value;
		
			}
		}


        public ICustomerLookup CustomerLookupDevice
        {
            get
            {
                return customerLookupDevice;
            }
          
            set
            {
                customerLookupDevice = value;
            }

        }


	
		public PosConfig Config
		{
			get
			{
				return config;
			}
			set
			{
				config = value;
		
			}
		}

		public Promotion SaleMode
		{
			get
			{
				return promotion;
			}
			set
			{
				promotion = value;
		
			}
		}

		public PosMath PosMath
		{
			get 
			{
				return posMath;
			}
			set
			{
				posMath = value;
			}
		}


		public bool Locked
		{
			get 
			{
				return locked;
			}
			set
			{
				locked = value;
			}
		}

		public double Sign
		{
			get
			{
				return sign;
			}
			set
			{
				sign=value;
			}
		}


		public Currency AltCurrency
		{
			get
			{
				return altCurrency;
			}
			set
			{
				altCurrency = value;
			}
		}


        public CurrencyCode AltCurrencyCode
        {
            get
            {
                return altCurrencyCode;
            }
            set
            {
                altCurrencyCode = value;
            }
        }


		public Filters  MsrFilters
		{
			get
			{
				return msrFilters;
			}
			set
			{
				msrFilters = value;
			}
		}

		public SearchBy SearchMode
		{
			set
			{
				this.searchBy = value;
			}
			get
			{
				return this.searchBy;
			}
		}

		public int DrawerNo
		{
			set
			{
				this.drawerNo = value;
			}
			get
			{
				return this.drawerNo;
			}
		}

		public PosExplorer PosExplorer
		{
			set
			{
				this.posExplorer = value;
			}
			get
			{
				return this.posExplorer;
			}
		}

        public string TableName
        {
            set
            {
                this.tableName = value;
            }
            get
            {
                return this.tableName;
            }
        }

        public EjCustomer EjCustomer
        {
            get { return ejCustomer; }
            set { ejCustomer = value; }
        }

        public PosHardwareStatusDisplay PosHardwareStatusDevice1
        {
            get
            {
                return posHardwareStatusDevice1;
            }
            set
            {
                posHardwareStatusDevice1 = value;
            }
        }

        public PosHardwareStatusDisplay PosHardwareStatusDevice2
        {
            get
            {
                return posHardwareStatusDevice2;
            }
            set
            {
                posHardwareStatusDevice2 = value;
            }
        }


        public AlphaKeyEntry AlphaKeyEntryDisplay
        {
            get
            {
                return alphaKeyEntry;
            }
            set
            {
                alphaKeyEntry = value;
            }
        }

        public int TransactionType
        {
            get
            {
                return this.transactionType;
            }
            set
            {
                this.transactionType = value;
                this.DisplayTransactionType();
            }
        }
        #endregion
	
		


		public void LoadConfig()
		{
			//posEventHandler += new PosEventHandler(numkey.Engage);
		}

		public bool InitConfig()
		{
			this.msrFilters = new Filters(InputFilter.MSR);
			return true;
		}

		public void PosInit(string startupDialog) 
		{
			operPrompt = new OperPrompt();
			receipt = new Receipt();

			PosEventStack.Instance.LoadDialog(startupDialog);
			PosEventStack.Instance.NextEvent();
			
		} 
 
		public void HomeGUI()
		{
            this.posDisplay.LoadMenu(int.Parse(this.parameters.getParam("HomeMenuID")));
		}

		public void Raise( string panel)
		{
		}


		public int Input ()
		{

			int val = 0;

			if (inputLine.Length == 0) return 0;
			
			try
			{
				val = int.Parse(inputLine.ToString());
			}
			catch (Exception e)
			{
				val = -1;
			}

			return val;

		}

		/**
		* Converts the input buffer to a double.
		*/
		public double InputDouble ()
		{
			if (inputLine.Length  == 0) return 0;

            try
            {

                return double.Parse(inputLine.ToString());
            }
            catch
            {
                this.ClearInput();
                return 0;
            }
		
		}
		
		/**
		* Returns the input buffer as a String.
		*/
		public string InputLine 
		{
			get 
			{
				return inputLine.ToString();
			}
			set
			{
				if (inputLine.Length >0 ) inputLine.Remove(0, inputLine.Length);
				inputLine.Append(value);
			}
		}

		/**
		* Erase the last character in the input buffer (clear ()).
		 */
		public void EraseLast()
		{
			inputLine.Remove(inputLine.Length-1, 1);
		}

    /**
     * Clears the input buffer.
     */
		public void ClearInput ()
		{
			if (inputLine == null) return;

			if (inputLine.Length > 0)
			inputLine.Remove(0, inputLine.Length);

            
		}

		/**
		* Multiplies the input buffer by the value.
		*/
		public void MultByInput (int i)
		{
			double tmp;

			if (inputLine.Length  == 0)
			{
				tmp = 0;
			}
			else
			{
				tmp = Input ();
			}

			tmp *= i;
			
			if (inputLine.Length > 0)
			inputLine.Remove (0, inputLine.Length);
			inputLine.Append(tmp.ToString());
		}

		/**
		* Add the value to the end of the input buffer as a 
		* string.
		*/
		public void AddToInput (int i)
		{
			inputLine.Append(i.ToString());
		}

		public void AddToInput(string c)
		{
			inputLine.Append(c);
		}

		
		public void EnableKeys()
		{
			foreach(Object obj in guis)
			{
				if (obj is PosKeyEnable)
				{
					((PosKeyEnable)obj).KeyEnable();
				}
			}
			
		}

		public void DisableKeys()
		{
			foreach(Object obj in guis)
			{
				if (obj is PosKeyEnable)
				{
					((PosKeyEnable)obj).KeyDisable();
				}
			}

		}

		public void ToggleSign()
		{
			this.sign = this.sign * (-1);
		}

        private void DisplayTransactionType()
        {
            if (this.posTicketHeader == null) return;
            
            switch (this.TransactionType)
            {
                case (int)Transaction.Types.SALES:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("SalePrompt");
                    break;
                case (int)Transaction.Types.RETURN:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("ReturnSalePrompt");
                    break;
                case (int)Transaction.Types.DINE_IN:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("DineInPrompt");
                    break;
                case (int)Transaction.Types.CARRY_OUT:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("CarryOutPrompt");
                    break;
                case (int)Transaction.Types.PAID_IN:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("PaidInPrompt");
                    break;
                case (int)Transaction.Types.PAID_OUT:
                    this.posTicketHeader.TransactionType = this.Parameters.getParam("PaidOutPrompt");
                    break;
                default:
                    this.posTicketHeader.TransactionType = "";
                
                    break;

            }
            
        }
		
		#region IDisposable Members

		public void Dispose()
		{
			// TODO:  Add PosContext.Dispose implementation
            try
            {
                this.Receipt.Dispose();
                PosHardware.Instance.Dispose();
                PrintJobQueue.Instance.Dispose();
            }
            catch
            {
            }
			
		}

		#endregion

		//Beep sound
		[DllImport("kernel32.dll")]
		public static extern bool Beep(int freq,int duration);


	}
}
