using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ReceptionDetailService(
    IReceptionDetailRepository repository,
    IProductService productService
) : IReceptionDetailService {
    public void AddRange(Reception reception) {
        repository.AddRange(reception);
        foreach (var receptionDetail in reception.ReceptionDetails) {
            productService.AddCount(receptionDetail.Product, receptionDetail.Count);
        }
    }
}