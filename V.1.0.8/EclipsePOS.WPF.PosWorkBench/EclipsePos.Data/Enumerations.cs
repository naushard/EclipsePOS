using System;

namespace EclipsePos.Data
{
	/// <summary>
	/// Summary description for Enumerations.
	/// </summary>
	public enum EjLineStates
	{
		INCOMPLETE = 0,
        IN_PROGRESS = 1,
        PAID = 2,
        SUSPEND = 3,
        VOID_SALE = 4,
        VOID_ITEM = 5,
        PRICE_OVERRIDE = 6,
      //  QUANTITY_OVERRIDE = 7,
	}

	public enum EjPromotionTypes
	{
		SKU = 1,
		WHOLE_ORDER=2
	}

    public enum EjItemReasonCodes
    {
        NORMAL_ITEM =0,
        SURCHARGE = 1
    }

    public enum TransStockTypes
    {
        PURCHASES_IN = 1,
        REFUND_IN = 2,
        MOVEMENT_IN = 3,
        SALE_OUT = 11,
        REFUND_OUT = 12,
        BREAK_OUT = 13,
        MOVEMENT_OUT = 14
    }

    public enum CardTypes
    {
        DEBIT = 1,
        CREDIT= 2
    }

    
}
