namespace SmartSaleApi.Core.Models;

public sealed record ProductPriceHistory(
    double Price,
    DateTime DateBegin,
    DateTime DateEnd
);