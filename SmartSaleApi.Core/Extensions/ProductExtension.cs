using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Extensions;

internal static class ProductExtension {
    public static Product CloneWithNewId(this Product src, int id)
        => new(
            id,
            src.Name,
            src.Count,
            src.CountInPackage,
            src.Price,
            src.ProductPriceHistories
    );

    public static Product CloneWithNewCount(this Product src, int count)
        => new(
            src.Id,
            src.Name,
            count,
            src.CountInPackage,
            src.Price,
            src.ProductPriceHistories
        );
}