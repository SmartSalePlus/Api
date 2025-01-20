using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Extensions;

internal static class InvoiceExtension {
    public static Invoice CloneWithNewId(this Invoice src, int id)
        => new(
            id,
            src.Date,
            src.Total,
            src.Discount,
            src.TotalWithDiscount,
            src.IsPaid,
            src.Buyer,
            src.InvoiceDetails
        );
}