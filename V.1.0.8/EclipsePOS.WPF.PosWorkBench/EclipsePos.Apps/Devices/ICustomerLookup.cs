using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Devices
{
    public interface ICustomerLookup
    {

        void LookupFunction(CustomerLookupDeviceFunctions key);
        string SelectedCustomer();
    }

    public enum CustomerLookupDeviceFunctions
    {
        Find = 0,
        MoveCurrentToLast = 1,
        MoveCurrentToFirst = 2,
        MoveCurrentToNext = 3,
        MoveCurrentToPrevious = 4,
        Select = 5,
        Cancel = 6,
        Clear = 7,
        CustomerDetails = 8,
        CancelFromCustomerDetails = 9
    }
}
