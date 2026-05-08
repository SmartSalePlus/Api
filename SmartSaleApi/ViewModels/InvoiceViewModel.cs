using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModels;

public sealed record InvoiceViewModel(
    int Id,
    DateOnly Date,
    int Total,
    int Discount,
    int TotalWithDiscount,
    bool IsPaid,
    Buyer Buyer,
    IEnumerable<InvoiceDetailViewModel> InvoiceDetailViewModels
);