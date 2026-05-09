namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceSaveDto(
    int BuyerId,
    DateOnly Date,
    int Discount,
    IEnumerable<InvoiceDetailSaveDto> InvoiceDetails,
    IEnumerable<InvoicePaymentSaveDto> InvoicePayments
);
