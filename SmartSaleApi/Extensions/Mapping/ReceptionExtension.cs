using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Receptions;

namespace SmartSaleApi.Extensions.Mapping;

public static class ReceptionExtension {
    public static Reception ToModel(this ReceptionSaveDto src, int id = 0)
        => new() {
            Id = id,
            Date = src.Date,
            ReceptionDetails = src.ReceptionDetails.Select(x => x.ToModel()).ToList()
        };

    public static ReceptionDto ToDto(this Reception src)
        => new(
            src.Id,
            src.Date,
            src.ReceptionDetails.Select(x => x.ToDto()).ToList()
        );
}
