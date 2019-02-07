 using System;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Hardware;
 using System.Runtime.InteropServices;


namespace EclipsePos.Apps.PosEvents
{
	/// <summary>
	/// Summary description for PosError.
	/// </summary>
	public class PosError :PosEvent	
	{

		#region Variable

		private static string eventname = "PosError";
		private PosErrorCode errorCode;
	//	private string promptText;
		
		#endregion



		public PosError()
		{
		}

		public PosError(PosErrorCode  code)
		{
			errorCode = code;
			PromptText = "";

			switch (code)
			{
				case PosErrorCode.INVALID_INPUT:
					PromptText = PosContext.Instance.Parameters.getParam("InvalidInput");
					break;
				case PosErrorCode.INSUFFICIENT_FUNDS: 
					PromptText = PosContext.Instance.Parameters.getParam("InsufficientFunds");
					break;
				case PosErrorCode.MGR_REQUIRED:
					PromptText = PosContext.Instance.Parameters.getParam("MgrIntervention");
					break;
				case PosErrorCode.LOGON_FAILED:
					PromptText = PosContext.Instance.Parameters.getParam("");
					break;
				case PosErrorCode.BAD_USER:
					PromptText = PosContext.Instance.Parameters.getParam("BadName");
					break;
				case PosErrorCode.BAD_PASSWORD:
					PromptText = PosContext.Instance.Parameters.getParam("BadPass");
					break;
				case PosErrorCode.FLOPPY_ERROR:
					PromptText = PosContext.Instance.Parameters.getParam("InsertFloppy");
					break;
                case PosErrorCode.INVALID_CUSTOMER_NO:
                    PromptText = PosContext.Instance.Parameters.getParam("InvalidCustomer");
                    break;
                case PosErrorCode.INSUFFICIENT_TENDER_AMOUNT:
                    PromptText = PosContext.Instance.Parameters.getParam("InsufficientTenderAmount");
                    break;
                case PosErrorCode.INVALID_DRAWER_NO:
				case PosErrorCode.INVALID_CHECK_NO:
				case PosErrorCode.RECALL_FAILLED:
					PromptText = PosContext.Instance.Parameters.getParam("");
					break;
				case PosErrorCode.CASH_EXCEEDED:
					PromptText = PosContext.Instance.Parameters.getParam("CashLimitExceeded");
					break;
				case PosErrorCode.INVALID_CC:
					PromptText = PosContext.Instance.Parameters.getParam("BadCCNo");
					break;
				case PosErrorCode.INVALID_EXPR:
					PromptText = PosContext.Instance.Parameters.getParam("BadCCNo");
					break;
				case PosErrorCode.HARDWARE_PROBLEM:
					PromptText = PosContext.Instance.Parameters.getParam(PosHardware.Instance.ErrorText);
					break;
				case PosErrorCode.ITEM_DISCOUNT_NOT_APPLICABLE:
					PromptText = PosContext.Instance.Parameters.getParam("ItemDiscountNotApplicable");
					break;
				case PosErrorCode.PROMOTION_NOT_APPLICABLE:
					PromptText = PosContext.Instance.Parameters.getParam("SelectPromotionBeforeItemEntry");
					break;
				case PosErrorCode.SHUTDOWN_NOT_ALLOWED:
					PromptText = PosContext.Instance.Parameters.getParam("ShutdownKeyNotAllowed");
					break;
                case PosErrorCode.INSUFFICIENT_USER_AUTHORITY:
                    PromptText = PosContext.Instance.Parameters.getParam("InsufficientUserAuthority");
                    break;

                case PosErrorCode.PRICE_CHANGE_NOT_ALLOWED:
                    PromptText = PosContext.Instance.Parameters.getParam("PriceChangeNotAllowed");
                    break;

                case PosErrorCode.INVALID_FUNCTION_KEY:
                    PromptText = PosContext.Instance.Parameters.getParam("InvalidFunction");
                    break;

                case PosErrorCode.INVALID_EMPLOYEE_NO:
                    PromptText = PosContext.Instance.Parameters.getParam("InvalidEmployeeNumber");
                    break;

               	case PosErrorCode.OVER_MEDIA_LIMIT:
				case PosErrorCode.UNDER_MEDIA_LIMIT:
				case PosErrorCode.LOCKED: 
				default:
					PromptText = " -- unknown error --";
					break;
			}
		}


		/**
		* Do nothing.
		*/
		public override void  Engage (int keyValue)
		{

			Beep(500,250);
			PosContext.Instance.PosPrompt.DisableInput();
			PosContext.Instance.Operprompt.Update(this);
		//	PosEventStack.Instance.NextEvent();
		}

		/** Always return true. */
		public override bool ValidTransition (string pEvent)
		{
			return true;
		}

		/** Clear impementation for clear, do nothing. */
		public override void Clear ()
		{
		}
		
		
		#region Properties
		/** Return staic name. */
		public string EventName 
		{
			get
			{
				return eventname;
			}
		}

		

		public PosErrorCode ErrorCode
		{
			get
			{
				return errorCode;
			}
		}

		
		#endregion

		[DllImport("kernel32.dll")]
		public static extern bool Beep(int freq,int duration);


	}

	

	public enum PosErrorCode
	{
		ERROR_EVENT = 1000,
		INVALID_INPUT = 1001,
		INSUFFICIENT_FUNDS = 1004,
		MGR_REQUIRED = 1005,
		LOGON_FAILED = 1006,
		BAD_USER = 1007,
		BAD_PASSWORD = 1008,
		INVALID_DRAWER_NO = 1009,
		INVALID_CUSTOMER_NO = 1010,
		INVALID_CHECK_NO = 1011,
		RECALL_FAILLED = 1012,
		OVER_MEDIA_LIMIT = 1013,
		UNDER_MEDIA_LIMIT = 1014,
		INVALID_CC = 1015,
		LOCKED = 1016,
		CASH_EXCEEDED = 1017,
		INVALID_EXPR = 1018,
		HARDWARE_PROBLEM = 1019,
		FLOPPY_ERROR = 1020,
		ITEM_DISCOUNT_NOT_APPLICABLE = 1021,
		PROMOTION_NOT_APPLICABLE = 1022,
		TERMINAL_REPORT = 1023,
		SHUTDOWN_NOT_ALLOWED = 1024,
		INVALID_FUNCTION_KEY = 1025,
        INSUFFICIENT_TENDER_AMOUNT = 1026,
        INSUFFICIENT_USER_AUTHORITY = 1030,
        PRICE_CHANGE_NOT_ALLOWED = 1032,
        SELECT_CUSTOMER = 1033,
        INSUFFICIENT_CREDIT_LIMIT = 1034,
        INVALID_EMPLOYEE_NO = 1035


	}
}
