using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModels;

public sealed record InvoiceDetailViewModel(
    int Count,
    int InPackage,
    double Price,
    int Total,
    Product Product
);