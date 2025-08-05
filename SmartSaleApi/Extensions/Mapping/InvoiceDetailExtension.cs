using SmartSaleApi.Core.Models;
using SmartSaleApi.ViewModel;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceDetailExtension {
    public static InvoiceDetailViewModel ToViewModel(this InvoiceDetail invoiceDetail, Product product)
        => new(
            invoiceDetail.Count,
            invoiceDetail.Price,
            invoiceDetail.Total,
            product
        );
}