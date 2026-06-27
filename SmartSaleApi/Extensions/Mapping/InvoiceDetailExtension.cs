using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Invoices;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceDetailExtension {
    public static InvoiceDetail ToModel(this InvoiceDetailSaveDto src, int id = 0)
        => new() {
            Id = id,
            ProductId = src.ProductId,
            Count = src.Count,
            InPackage = src.InPackage,
            Price = src.Price
        };

    public static InvoiceDetailDto ToDto(this InvoiceDetail src)
        => new(
            src.Id,
            src.ProductId,
            src.Product.Name,
            src.Count,
            src.InPackage,
            src.Price,
            src.ReturnedCount,
            src.AvailableCount,
            src.Total,
            src.ReturnStatus,
            src.InvoiceDetailReturns.Select(x => x.ToDto()).ToList()
        );
}