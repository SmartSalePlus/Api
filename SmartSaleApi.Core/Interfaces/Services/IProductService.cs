using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IProductService {
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    Product Get(int id);
    IEnumerable<Product> Get(string name);
    IEnumerable<Product> Get();
    void AddCount(Product product, int count);
    void ReduceCount(Product product, int count);
}