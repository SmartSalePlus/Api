using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Invoices;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoicePaymentExtension {
    public static InvoicePayment ToModel(this InvoicePaymentSaveDto src)
        => new() {
            Date = src.Date,
            Amount = src.Amount
        };

    public static InvoicePaymentDto ToDto(this InvoicePayment src)
        => new(src.Id, src.Date, src.Amount);
}
