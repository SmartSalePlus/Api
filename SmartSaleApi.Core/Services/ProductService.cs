using SmartSaleApi.Core.Extensions;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ProductService(
    IProductRepository repository,
    IProductPriceHistoryService productPriceHistoryService
) : IProductService {
    public void Add(Product product) {
        var id = repository.Add(product);
        productPriceHistoryService.Add(product.CloneWithNewId(id));
    }

    public void Delete(int id) {
        repository.Delete(id);
    }

    public Product Get(int id) {
        return repository.Get(id);
    }

    public IEnumerable<Product> Get(string name) {
        return repository.Get(name);
    }

    public IEnumerable<Product> Get() {
        return repository.Get();
    }

    public void Update(Product product) {
        repository.Update(product);
        if (IsPriceChanged(product)) {
            productPriceHistoryService.Update(product.Id);
            productPriceHistoryService.Add(product);
        }
    }

    public void AddCount(Product product, int count) {
        Update(product.CloneWithNewCount(product.Count + count));
    }

    public void ReduceCount(Product product, int count) {
        Update(product.CloneWithNewCount(product.Count - count));
    }

    private bool IsPriceChanged(Product product) {
        var oldPrice = repository.Get(product.Id).Price;
        return oldPrice != product.Price;
    }
}