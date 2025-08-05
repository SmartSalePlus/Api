using SmartSaleApi.Core.Models;
using SmartSaleApi.ViewModels;

namespace SmartSaleApi.Extensions.Mapping;

public static class ReceptionDetailExtension {
    public static ReceptionDetailViewModel ToViewModel(this ReceptionDetail receptionDetail, Product product)
        => new(
            receptionDetail.Count,
            receptionDetail.Price,
            product
        );
}