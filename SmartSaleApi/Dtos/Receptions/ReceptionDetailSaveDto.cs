namespace SmartSaleApi.Dtos.Receptions;

public sealed record ReceptionDetailSaveDto(
    int ProductId,
    int Count,
    double Price
);
