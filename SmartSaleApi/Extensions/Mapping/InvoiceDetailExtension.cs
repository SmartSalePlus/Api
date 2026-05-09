using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Invoices;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceDetailExtension {
    public static InvoiceDetail ToModel(this InvoiceDetailSaveDto src)
        => new() {
            ProductId = src.ProductId,
            Count = src.Count,
            InPackage = src.InPackage,
            Price = src.Price
        };

    public static InvoiceDetailDto ToDto(this InvoiceDetail src)
        => new(
            src.ProductId,
            src.Product!.Name,
            src.Count,
            src.InPackage,
            src.Price,
            src.Total
        );
}
