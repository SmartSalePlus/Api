namespace SmartSaleApi.Core.Filters;

using SmartSaleApi.Core.Enums;

public sealed record InvoiceFilter(
    DateOnly DateBegin,
    DateOnly DateEnd,
    int BuyerId,
    PaymentStatus? PaymentStatus
);
