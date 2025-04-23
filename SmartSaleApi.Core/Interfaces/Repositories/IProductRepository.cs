using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IProductRepository {
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    Product Get(int id);
    IEnumerable<Product> Get(string name);
    IEnumerable<Product> Get();
};