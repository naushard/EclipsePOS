using System;

namespace EclipsePos.Apps.Devices
{
	/// <summary>
	/// Summary description for ItemLookup.
	/// </summary>
	public interface ItemLookup
	{
		void LookupFunction(ItemLookupDeviceFunctions key);
		string SelectedItem();
	}

	public enum ItemLookupDeviceFunctions
	{
		Find=0,
		MoveCurrentToLast=1,
		MoveCurrentToFirst=2,
		MoveCurrentToNext=3,
		MoveCurrentToPrevious=4,
		Select=5,
		Cancel=6,
		Clear=7,
        ItemDetails=8,
        CancelFromItemDetails=9
    }

	public enum SearchBy
	{
		Description=1,
		Sku=2,
		Department=3,
        ItemGroup=4
	}
}
