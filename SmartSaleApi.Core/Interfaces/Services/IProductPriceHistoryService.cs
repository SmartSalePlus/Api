using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IProductPriceHistoryService {
    void Add(Product product);
}