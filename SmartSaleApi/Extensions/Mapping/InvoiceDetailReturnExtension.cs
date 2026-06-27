using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Invoices;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceDetailReturnExtension {
    public static InvoiceDetailReturn ToModel(this InvoiceDetailReturnDto src)
        => new() {
            Id = src.Id,
            InvoiceDetailId = src.InvoiceDetailId,
            Count = src.Count,
            Date = src.Date
        };

    public static InvoiceDetailReturnDto ToDto(this InvoiceDetailReturn src)
        => new(
            src.Id,
            src.InvoiceDetailId,
            src.Count,
            src.Date
        );
}