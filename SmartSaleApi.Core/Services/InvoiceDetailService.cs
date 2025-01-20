using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class InvoiceDetailService(
    IInvoiceDetailRepository repository,
    IProductService productService
) : IInvoiceDetailService {
    public void AddRange(Invoice invoice) {
        repository.AddRange(invoice);
        foreach(var invoiceDetail in invoice.InvoiceDetails) {
            productService.ReduceCount(invoiceDetail.Product, invoiceDetail.Count);
        }
    }
}