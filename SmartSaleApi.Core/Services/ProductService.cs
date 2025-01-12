using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ProductService(
    IProductRepository repository,
    IProductPriceHistoryService productPriceHistoryService
) : IProductService {
    public void Add(Product product) {
        repository.Add(product);
        productPriceHistoryService.Add(product);
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
            productPriceHistoryService.Add(product);
        }
    }

    public void IncreaseCount(Product product, int count) {
        Product newProduct = new(0, product.Name, product.Count + count, product.CountInPackage, product.Price);
        Update(newProduct);
    }

    public void DecreaseCount(Product product, int count) {
        Product newProduct = new(0, product.Name, product.Count - count, product.CountInPackage, product.Price);
        Update(newProduct);
    }

    private bool IsPriceChanged(Product product) {
        var oldPrice = repository.Get(product.Id).Price;
        return oldPrice != product.Price;
    }
}