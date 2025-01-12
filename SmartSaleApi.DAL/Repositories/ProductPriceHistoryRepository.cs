using Microsoft.EntityFrameworkCore;
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

    public void Update(int productId) {
        context.ProductPriceHistories
            .Where(x => x.ProductId == productId && x.DateEnd == DateTime.MaxValue)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.DateEnd, DateTime.UtcNow)
            );
    }
}