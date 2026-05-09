namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoicePaymentSaveDto(
    DateOnly Date,
    int Amount
);
