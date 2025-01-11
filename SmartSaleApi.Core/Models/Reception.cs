namespace SmartSaleApi.Core.Models;

public sealed record Reception(
    int Id,
    DateTime Date,
    IEnumerable<ReceptionDetail> ReceptionDetails
);