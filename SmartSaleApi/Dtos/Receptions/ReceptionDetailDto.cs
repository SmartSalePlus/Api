namespace SmartSaleApi.Dtos.Receptions;

public sealed record ReceptionDetailDto(
    int ProductId,
    string ProductName,
    int Count,
    double Price
);
