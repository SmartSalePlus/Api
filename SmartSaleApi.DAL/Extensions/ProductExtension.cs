using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class ProductExtension {
    public static Core::Product ToModel(this DAL::Product src)
        => new(
            src.Id,
            src.Name,
            src.Count,
            src.CountInPackage,
            src.ProductPriceHistories.First(x => x.DateEnd == DateOnly.MaxValue).Price,
            src.ProductPriceHistories.ToModel()
        );

    public static IEnumerable<Core::Product> ToModel(this IEnumerable<DAL::Product> src)
        => src.Select(x => x.ToModel());
    public static Core::ProductPriceHistory CreateProductPriceHistory(this Core::Product src)
        => new(src.Price, DateOnly.FromDateTime(DateTime.Today), DateOnly.MaxValue);

    public static DAL::Product ToEntity(this Core::Product src)
        => new() {
            Id = src.Id,
            Name = src.Name,
            Count = src.Count,
            CountInPackage = src.CountInPackage,
        };
}