using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ProductRepository(SmartSaleDbContext context) : IProductRepository {
    public void Add(Product product) {
        context.Products
            .Add(product.ToEntity());
        context.SaveChanges();
    }

    public void Delete(int id) {
        context.Products
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Product Get(int id) {
        return context.Products
            .AsNoTracking()
            .Include(x => x.ProductPriceHistories)
            .FirstOrDefault(x => x.Id == id)?
            .ToModel() ?? throw new ArgumentException($"Не найден товар по данному Id = {id}");
    }

    public IEnumerable<Product> Get(string name) {
        return context.Products
            .AsNoTracking()
            .Include(x => x.ProductPriceHistories)
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .ToModel();
    }

    public IEnumerable<Product> Get() {
        return context.Products
            .AsNoTracking()
            .Include(x => x.ProductPriceHistories)
            .ToModel();
    }

    public void Update(Product product) {
        context.Products
            .Where(x => x.Id == product.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Name, product.Name)
                .SetProperty(p => p.Count, product.Count)
                .SetProperty(p => p.CountInPackage, product.CountInPackage)
            );
    }
}