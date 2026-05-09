namespace SmartSaleApi.Dtos.Products;

public sealed record ProductDto(
    int Id,
    string Name,
    int Count,
    int InPackage,
    double Price
);
