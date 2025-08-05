using SmartSaleApi.Core.Models;

namespace SmartSaleApi.ViewModels;

public sealed record ReceptionDetailViewModel(
    int Count,
    double Price,
    Product Product
);