using System;

namespace Etmam
{
    /// <summary>Movement header date pickers (ReceivedDate/IssuedDate/TransferDate/ReturnDate/BalanceDate) are
    /// plain date-only <c>DateEdit</c> controls, so their <c>EditValue</c> always carries midnight as the time
    /// part. Reports that order several movement tables together (e.g. <see cref="InventoryReportsHelper.GetItemStockCard"/>)
    /// need real chronological order for same-day entries, whose Id sequences aren't comparable across tables —
    /// so every AddEdit form stamps the actual save moment's time-of-day onto the user-picked date instead of
    /// persisting midnight.</summary>
    public static class DateTimeHelper
    {
        public static DateTime? WithCurrentTime(DateTime? datePart) =>
            datePart?.Date + DateTime.Now.TimeOfDay;
    }
}
