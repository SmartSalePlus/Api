using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class BuyerExtension {
    public static Core::Buyer ToModel(this DAL::Buyer src)
        => new(
            src.Id,
            src.Name
        );

    public static IEnumerable<Core::Buyer> ToModel(this IEnumerable<DAL::Buyer> src)
        => src.Select(x => x.ToModel());

    public static DAL::Buyer ToEntity(this Core::Buyer src)
        => new() { 
            Id = src.Id,
            Name = src.Name 
        };
}