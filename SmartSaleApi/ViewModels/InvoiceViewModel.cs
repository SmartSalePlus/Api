using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModels;

public sealed record InvoiceViewModel(
    int Id,
    DateOnly Date,
    int Total,
    int Discount,
    int TotalWithDiscount,
    int PaidAmount,
    int RemainingAmount,
    PaymentStatus PaymentStatus,
    Buyer Buyer,
    IEnumerable<InvoiceDetailViewModel> InvoiceDetailViewModels
);
