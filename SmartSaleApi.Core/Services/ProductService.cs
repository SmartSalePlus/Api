using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ProductService(
    IProductRepository repository, 
    IProductPriceHistoryRepository productPriceHistoryRepository
) : IProductService {
    public void Add(Product product) {
        repository.Add(product);
        productPriceHistoryRepository.Add(CreateProductPriceHistory(product));
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
            productPriceHistoryRepository.Add(CreateProductPriceHistory(product));
        }
    }

    private ProductPriceHistory CreateProductPriceHistory(Product product)
        => new(0, product.Price, DateTime.UtcNow, DateTime.MaxValue, product);

    private bool IsPriceChanged(Product product) {
        var oldPrice = repository.Get(product.Id).Price;
        return oldPrice != product.Price;
    }
}