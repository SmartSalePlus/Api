namespace SmartSaleApi.Core.Models;

public sealed record Reception(
    int Id,
    DateOnly Date,
    IEnumerable<ReceptionDetail> ReceptionDetails
);