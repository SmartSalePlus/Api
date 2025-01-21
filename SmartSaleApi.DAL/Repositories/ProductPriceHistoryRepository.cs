using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ProductPriceHistoryRepository(SmartSaleDbContext context) : IProductPriceHistoryRepository {
    public void Add(Product product) {
        var productEntity = product.ToEntity();
        var entity = product.CreateProductPriceHistory()
            .ToEntity(productEntity);
        context.Attach(productEntity);
        context.ProductPriceHistories.Add(entity);
        context.SaveChanges();
    }

    public void Update(int productId) {
        context.ProductPriceHistories
            .Where(x => x.ProductId == productId && x.DateEnd == DateOnly.MaxValue)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.DateEnd, DateOnly.FromDateTime(DateTime.Today))
            );
    }
}