namespace SmartSaleApi.Dtos.Products;

public sealed record ProductSaveDto(
    string Name,
    int Count,
    int InPackage,
    double Price
);
