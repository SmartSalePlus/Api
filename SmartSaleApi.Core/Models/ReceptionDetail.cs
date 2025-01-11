namespace SmartSaleApi.Core.Models;

public sealed record ReceptionDetail(
    int Count,
    double Price,
    Product Product
);