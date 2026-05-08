using SmartSaleApi.Core.Models;
using SmartSaleApi.ViewModels;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceDetailExtension {
    public static InvoiceDetailViewModel ToViewModel(this InvoiceDetail invoiceDetail, Product product)
        => new(
            invoiceDetail.Count,
            invoiceDetail.InPackage,
            invoiceDetail.Price,
            invoiceDetail.Total,
            product
        );
}