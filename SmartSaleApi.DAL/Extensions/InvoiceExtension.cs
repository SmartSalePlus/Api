using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class InvoiceExtension {
    public static Core::Invoice ToModel(this DAL::Invoice src) {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(src.Buyer);

        return new(
            src.Id,
            src.Date,
            src.Total,
            src.Discount,
            src.TotalWithDiscount,
            src.IsPaid,
            src.BuyerId,
            src.InvoiceDetails.ToModel()
        );
    }

    public static IEnumerable<Core::Invoice> ToModel(this IEnumerable<DAL::Invoice> src)
        => src.Select(x => x.ToModel()).ToList();

    public static DAL::Invoice ToEntity(this Core::Invoice src)
        => new() {
            Id = src.Id,
            Date = src.Date,
            Total = src.Total,
            Discount = src.Discount,
            TotalWithDiscount = src.TotalWithDiscount,
            IsPaid = src.IsPaid,
            BuyerId = src.BuyerId,
            InvoiceDetails = src.InvoiceDetails.ToEntity()
        };

    public static DAL::Invoice OrderInvoiceDetailsByProductName(this DAL::Invoice invoice) {
        invoice.InvoiceDetails = invoice.InvoiceDetails
            .Select(invoiceDetail => {
                var product = invoiceDetail.Product;
                ArgumentNullException.ThrowIfNull(product);
                return (InvoiceDetail: invoiceDetail, Product: product);
            })
            .OrderBy(x => x.Product.Name)
            .Select(x => x.InvoiceDetail)
            .ToList();

        return invoice;
    }
}