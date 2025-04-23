using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class InvoiceDetailExtension {
    public static Core::InvoiceDetail ToModel(this DAL::InvoiceDetail src) {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(src.Product);

        return new(
            src.Count,
            src.Price,
            src.Total,
            src.Product.ToModel()
        );
    }
    public static IEnumerable<Core::InvoiceDetail> ToModel(this IEnumerable<DAL::InvoiceDetail> src)
        => src.Select(x => x.ToModel());

    public static DAL::InvoiceDetail ToEntity(this Core::InvoiceDetail src)
        => new() {
            ProductId = src.Product.Id,
            Count = src.Count,
            Price = src.Price,
            Total = src.Total,
        };

    public static ICollection<DAL::InvoiceDetail> ToEntity(this IEnumerable<Core::InvoiceDetail> src)
        => src.Select(x => x.ToEntity()).ToList();
}