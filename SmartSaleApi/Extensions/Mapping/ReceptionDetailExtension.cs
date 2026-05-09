using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Receptions;

namespace SmartSaleApi.Extensions.Mapping;

public static class ReceptionDetailExtension {
    public static ReceptionDetail ToModel(this ReceptionDetailSaveDto src)
        => new() {
            ProductId = src.ProductId,
            Count = src.Count,
            Price = src.Price
        };

    public static ReceptionDetailDto ToDto(this ReceptionDetail src)
        => new(
            src.ProductId,
            src.Product!.Name,
            src.Count,
            src.Price
        );
}
