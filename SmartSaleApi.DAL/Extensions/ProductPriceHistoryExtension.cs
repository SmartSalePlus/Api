using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class ProductPriceHistoryExtension {
    public static Core::ProductPriceHistory ToModel(this DAL::ProductPriceHistory src)
        => new(
            src.Price,
            src.DateBegin,
            src.DateEnd
        );

    public static IEnumerable<Core::ProductPriceHistory> ToModel(this IEnumerable<DAL::ProductPriceHistory> src)
        => src.Select(x => x.ToModel());

    public static DAL::ProductPriceHistory ToEntity(this Core::ProductPriceHistory src, DAL::Product product)
        => new() {
            ProductId = product.Id,
            Price = src.Price,
            DateBegin = src.DateBegin,
            DateEnd = src.DateEnd,
            Product = product
        };
}