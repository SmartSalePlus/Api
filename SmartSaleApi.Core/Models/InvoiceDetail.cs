namespace SmartSaleApi.Core.Models;

public sealed record InvoiceDetail(
    int Count,
    double Price,
    double Total,
    int ProductId
);