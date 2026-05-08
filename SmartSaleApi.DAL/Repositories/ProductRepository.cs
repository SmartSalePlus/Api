using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ProductRepository : IProductRepository {
    private readonly SmartSaleDbContext _context;

    public ProductRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(Product product) {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Products
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Product Get(int id) {
        var product = _context.Products
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(product);

        return product;
    }

    public IEnumerable<Product> Get(string name) {
        return _context.Products
            .AsNoTracking()
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .OrderBy(x => x.Name);
    }

    public IEnumerable<Product> Get() {
        return _context.Products
            .AsNoTracking()
            .OrderBy(x => x.Name);
    }

    public IEnumerable<Product> Get(params int[] ids) {
        return _context.Products
            .AsNoTracking()
            .Where(x => ids.Contains(x.Id))
            .OrderBy(x => x.Name);
    }

    public void Update(Product product) {
        var entity = _context.Products.FirstOrDefault(x => x.Id == product.Id);
        ArgumentNullException.ThrowIfNull(entity);

        entity.Name = product.Name;
        entity.Count = product.Count;
        entity.InPackage = product.InPackage;
        entity.Price = product.Price;
    }
}