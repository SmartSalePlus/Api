using SmartSaleApi.Core.Enums;
using SmartSaleApi.Dtos.Buyers;

namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceDto(
    int Id,
    DateOnly Date,
    int Total,
    int Discount,
    int TotalWithDiscount,
    int PaidAmount,
    int RemainingAmount,
    PaymentStatus PaymentStatus,
    BuyerDto Buyer,
    IEnumerable<InvoiceDetailDto> InvoiceDetails,
    IEnumerable<InvoicePaymentDto> InvoicePayments
);
