using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IProductPriceHistoryRepository {
    void Add(ProductPriceHistory productPriceHistory);
}