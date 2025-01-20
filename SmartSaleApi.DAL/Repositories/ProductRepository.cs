using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ProductRepository(SmartSaleDbContext context) : IProductRepository {
    public int Add(Product product) {
        var entity = product.ToEntity();
        context.Products.Add(entity);
        context.SaveChanges();

        return entity.Id;
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
            .OrderBy(x => x.Name)
            .ToModel();
    }

    public IEnumerable<Product> Get() {
        return context.Products
            .AsNoTracking()
            .Include(x => x.ProductPriceHistories)
            .OrderBy(x => x.Name)
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