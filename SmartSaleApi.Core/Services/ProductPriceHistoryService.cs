using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ProductPriceHistoryService(IProductPriceHistoryRepository repository) : IProductPriceHistoryService {
    public void Add(Product product) {
        repository.Add(product);
    }

    public void Update(int productId) {
        repository.Update(productId);
    }
}