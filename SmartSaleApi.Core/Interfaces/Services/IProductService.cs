using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IProductService {
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    Product Get(int id);
    IEnumerable<Product> Get(string name);
    IEnumerable<Product> Get();
    IEnumerable<Product> Get(IEnumerable<int> ids);
    void Sell(IEnumerable<InvoiceDetail> details);
    void Return(IEnumerable<InvoiceDetail> details);
}
