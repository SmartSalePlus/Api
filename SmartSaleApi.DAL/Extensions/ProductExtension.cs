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
            src.Price
        );

    public static IEnumerable<Core::Product> ToModel(this IEnumerable<DAL::Product> src)
        => src.Select(x => x.ToModel()).ToList();

    public static DAL::Product ToEntity(this Core::Product src)
        => new() {
            Id = src.Id,
            Name = src.Name,
            Count = src.Count,
            CountInPackage = src.CountInPackage,
            Price = src.Price
        };
}