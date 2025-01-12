using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ReceptionService(
    IReceptionRepository repository,
    IProductService productService
) : IReceptionService {
    public void Add(Reception reception) {
        repository.Add(reception);
        foreach (var receptionDetail in reception.ReceptionDetails) {
            productService.IncreaseCount(receptionDetail.Product, receptionDetail.Count);
        }
    }

    public void Delete(int id) {
        repository.Delete(id);
    }

    public Reception Get(int id) {
        return repository.Get(id);
    }

    public IEnumerable<Reception> Get() {
        return repository.Get();
    }

    public IEnumerable<Reception> GetByDate(DateTime date) {
        return repository.GetByDate(date);
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return repository.GetByProduct(productId);
    }

    public void Update(Reception reception) {
        repository.Update(reception);
    }
}