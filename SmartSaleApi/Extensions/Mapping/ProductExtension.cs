using SmartSaleApi.Core.Models;
using SmartSaleApi.Dtos.Products;

namespace SmartSaleApi.Extensions.Mapping;

public static class ProductExtension {
    public static Product ToModel(this ProductSaveDto src, int id = 0)
        => new() {
            Id = id,
            Name = src.Name,
            Count = src.Count,
            InPackage = src.InPackage,
            Price = src.Price
        };

    public static ProductDto ToDto(this Product src)
        => new(src.Id, src.Name, src.Count, src.InPackage, src.Price);
}
