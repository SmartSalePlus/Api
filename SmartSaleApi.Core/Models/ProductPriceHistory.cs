namespace SmartSaleApi.Core.Models;

public sealed record ProductPriceHistory(
    int Id,
    double Price,
    DateTime DateBegin,
    DateTime DateEnd,
    Product Product
);