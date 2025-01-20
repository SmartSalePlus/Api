using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class InvoiceDetailRepository(SmartSaleDbContext context) : IInvoiceDetailRepository {
    public void AddRange(Invoice invoice) {
        var buyerEntity = invoice.Buyer.ToEntity();
        var invoiceEntity = invoice.ToEntity(buyerEntity);
        context.Attach(buyerEntity);
        context.Attach(invoiceEntity);

        foreach (var invoiceDetail in invoice.InvoiceDetails) {
            var productEntity = invoiceDetail.Product.ToEntity();
            context.Attach(productEntity);
            context.InvoiceDetails.Add(invoiceDetail.ToEntity(invoiceEntity, productEntity));
        }

        context.SaveChanges();
    }
}