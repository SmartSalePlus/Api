namespace SmartSaleApi.Dtos.Receptions;

public sealed record ReceptionDto(
    int Id,
    DateOnly Date,
    IEnumerable<ReceptionDetailDto> ReceptionDetails
);
