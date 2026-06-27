namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceDetailReturnDto(
    int Id,
    int InvoiceDetailId,
    int Count,
    DateTime Date
);