using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class ReceptionExtension {
    public static Core::Reception ToModel(this DAL::Reception src)
        => new(
            src.Id,
            src.Date,
            src.ReceptionDetails.ToModel()
        );

    public static IEnumerable<Core::Reception> ToModel(this IEnumerable<DAL::Reception> src)
        => src.Select(x => x.ToModel());

    public static DAL::Reception ToEntity(this Core::Reception src)
        => new() {
            Id = src.Id,
            Date = src.Date,
            ReceptionDetails = src.ReceptionDetails.ToEntity()
        };
}