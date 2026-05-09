using SmartSaleApi.Core.Enums;

namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceFilterDto(
    DateOnly DateBegin,
    DateOnly DateEnd,
    int BuyerId,
    PaymentStatus? PaymentStatus
);
