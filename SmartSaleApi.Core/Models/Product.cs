namespace SmartSaleApi.Core.Models;

public sealed record Product(
    int Id,
    string Name,
    int Count,
    int CountInPackage,
    double Price
);