namespace SmartSaleApi.ViewModels;

public sealed record ReceptionViewModel(
    int Id,
    DateOnly Date,
    IEnumerable<ReceptionDetailViewModel> ReceptionDetailViewModels
);