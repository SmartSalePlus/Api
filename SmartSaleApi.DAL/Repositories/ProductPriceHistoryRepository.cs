using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ProductPriceHistoryRepository(SmartSaleDbContext context) : IProductPriceHistoryRepository {
    public void Add(ProductPriceHistory productPriceHistory) {
        context.ProductPriceHistories
            .Add(productPriceHistory.ToEntity());
        context.SaveChanges();
    }
}