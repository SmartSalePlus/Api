namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoicePaymentDto(
    int Id,
    DateOnly Date,
    int Amount
);
