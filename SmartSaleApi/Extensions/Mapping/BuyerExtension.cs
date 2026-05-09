using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Buyers;

namespace SmartSaleApi.Extensions.Mapping;

public static class BuyerExtension {
    public static Buyer ToModel(this BuyerSaveDto src, int id = 0)
        => new() {
            Id = id,
            Name = src.Name
        };

    public static BuyerDto ToDto(this Buyer src)
        => new(src.Id, src.Name);
}
