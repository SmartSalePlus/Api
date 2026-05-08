namespace SmartSaleApi.Core.InputParameters;

using SmartSaleApi.Core.Enums;

public sealed record InvoiceInputParameter(
    DateOnly DateBegin,
    DateOnly DateEnd,
    int BuyerId,
    PaymentStatus? PaymentStatus
);
