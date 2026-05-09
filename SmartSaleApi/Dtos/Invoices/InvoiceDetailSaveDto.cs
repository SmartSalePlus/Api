namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceDetailSaveDto(
    int ProductId,
    int Count,
    int InPackage,
    double Price
);
