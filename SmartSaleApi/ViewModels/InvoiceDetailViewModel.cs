using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModel;

public sealed record InvoiceDetailViewModel(
    int Count,
    double Price,
    double Total,
    Product Product
);