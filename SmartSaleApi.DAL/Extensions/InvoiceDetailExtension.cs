using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class InvoiceDetailExtension {
    public static Core::InvoiceDetail ToModel(this DAL::InvoiceDetail src)
        => new(
            src.Count,
            src.Price,
            src.Total,
            src.Product.ToModel()
        );

    public static IEnumerable<Core::InvoiceDetail> ToModel(this IEnumerable<DAL::InvoiceDetail> src)
        => src.Select(x => x.ToModel());

    public static DAL::InvoiceDetail ToEntity(this Core::InvoiceDetail src, DAL::Invoice invoice, DAL::Product product)
        => new() {
            InvoiceId = invoice.Id,
            ProductId = product.Id,
            Count = src.Count,
            Price = src.Price,
            Total = src.Total,
            Invoice = invoice,
            Product = product
        };
}