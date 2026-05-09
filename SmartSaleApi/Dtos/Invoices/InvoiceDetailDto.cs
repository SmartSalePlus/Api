namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceDetailDto(
    int ProductId,
    string ProductName,
    int Count,
    int InPackage,
    double Price,
    int Total
);
