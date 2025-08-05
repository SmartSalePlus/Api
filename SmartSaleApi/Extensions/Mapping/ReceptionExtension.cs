using SmartSaleApi.Core.Models;
using SmartSaleApi.ViewModels;

namespace SmartSaleApi.Extensions.Mapping;

public static class ReceptionExtension {
    public static ReceptionViewModel ToViewModel(this Reception reception, IEnumerable<ReceptionDetailViewModel> receptionDetailViewModels)
        => new(
            reception.Id,
            reception.Date,
            receptionDetailViewModels
        );
}