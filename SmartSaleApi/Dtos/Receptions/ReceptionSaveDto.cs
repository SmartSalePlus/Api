namespace SmartSaleApi.Dtos.Receptions;

public sealed record ReceptionSaveDto(
    DateOnly Date,
    IEnumerable<ReceptionDetailSaveDto> ReceptionDetails
);
