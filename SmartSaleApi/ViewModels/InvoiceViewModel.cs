using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModel;

public sealed record InvoiceViewModel(
    int Id,
    DateOnly Date,
    double Total,
    double Discount,
    double TotalWithDiscount,
    bool IsPaid,
    Buyer Buyer,
    IEnumerable<InvoiceDetailViewModel> InvoiceDetailViewModels
);