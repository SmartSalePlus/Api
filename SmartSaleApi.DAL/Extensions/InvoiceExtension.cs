using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class InvoiceExtension {
    public static Core::Invoice ToModel(this DAL::Invoice src)
        => new(
            src.Id,
            src.Date,
            src.Total,
            src.Discount,
            src.TotalWithDiscount,
            src.IsPaid,
            src.Buyer.ToModel(),
            src.InvoiceDetails.ToModel()
        );

    public static IEnumerable<Core::Invoice> ToModel(this IEnumerable<DAL::Invoice> src)
        => src.Select(x => x.ToModel());

    public static DAL::Invoice ToEntity(this Core::Invoice src)
        => new() {
            //BuyerId = src.Buyer.Id,
            Date = src.Date,
            Total = src.Total,
            Discount = src.Discount,
            TotalWithDiscount = src.TotalWithDiscount,
            IsPaid = src.IsPaid,
            Buyer = src.Buyer.ToEntity(),
            InvoiceDetails = src.InvoiceDetails.ToEntity(src)
        };
}