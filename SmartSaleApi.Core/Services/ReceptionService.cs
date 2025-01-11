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
            productService.Update(CreateProduct(receptionDetail.Product, receptionDetail.Count));
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

    private Product CreateProduct(Product product, int count)
        => new(
            0,
            product.Name,
            product.Count + count,
            product.CountInPackage,
            product.Price
        );
}