using SmartSaleApi.Core.Filters;
using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Invoices;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceExtension {
    public static Invoice ToModel(this InvoiceSaveDto src, int id = 0)
        => new() {
            Id = id,
            BuyerId = src.BuyerId,
            Date = src.Date,
            Discount = src.Discount,
            InvoiceDetails = src.InvoiceDetails.Select(x => x.ToModel()).ToList(),
            InvoicePayments = src.InvoicePayments.Select(x => x.ToModel()).ToList()
        };

    public static InvoiceDto ToDto(this Invoice src)
        => new(
            src.Id,
            src.Date,
            src.Total,
            src.Discount,
            src.TotalWithDiscount,
            src.PaidAmount,
            src.TotalWithDiscount - src.PaidAmount,
            src.PaymentStatus,
            src.Buyer!.ToDto(),
            src.InvoiceDetails.Select(x => x.ToDto()).ToList(),
            src.InvoicePayments.Select(x => x.ToDto()).ToList()
        );

    public static InvoiceFilter ToFilter(this InvoiceFilterDto src)
        => new(src.DateBegin, src.DateEnd, src.BuyerId, src.PaymentStatus);
}
