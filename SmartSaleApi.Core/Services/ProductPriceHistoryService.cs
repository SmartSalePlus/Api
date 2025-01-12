using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ProductPriceHistoryService(IProductPriceHistoryRepository repository) : IProductPriceHistoryService {
    public void Add(Product product) {
        repository.Update(product.Id);
        ProductPriceHistory productPriceHistory = new(0, product.Price, DateTime.UtcNow, DateTime.MaxValue, product);
        repository.Add(productPriceHistory);
    }
}