namespace SmartSaleApi.Core.InputParameters;
public sealed record InvoiceInputParameter(
    DateOnly DateBegin,
    DateOnly DateEnd,
    int? BuyerId,
    bool IsPaid
);