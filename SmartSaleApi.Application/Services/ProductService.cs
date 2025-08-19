using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class ProductService : IProductService {
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository) {
        _repository = repository;
    }

    public void Add(Product product) {
        _repository.Add(product);
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public Product Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Product> Get(string name) {
        return _repository.Get(name);
    }

    public IEnumerable<Product> Get() {
        return _repository.Get();
    }

    public IEnumerable<Product> Get(params int[] ids) {
        return _repository.Get(ids);
    }

    public void Update(Product product) {
        _repository.Update(product);
    }
}