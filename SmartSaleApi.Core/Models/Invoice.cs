namespace SmartSaleApi.Core.Models;

public sealed record Invoice(
    int Id,
    DateOnly Date,
    double Total,
    double Discount,
    double TotalWithDiscount,
    bool IsPaid,
    Buyer Buyer,
    IEnumerable<InvoiceDetail> InvoiceDetails
);