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

    public IEnumerable<Product> Get(IEnumerable<int> ids) {
        return _repository.Get(ids);
    }

    public void Update(Product product) {
        _repository.Update(product);
    }

    public void SellProducts(IEnumerable<InvoiceDetail> details) {
        var grouped = details
            .GroupBy(d => d.ProductId)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Count));

        var products = _repository.Get(grouped.Keys)
            .ToDictionary(x => x.Id);

        foreach (var item in grouped) {
            if (!products.TryGetValue(item.Key, out var product)) {
                throw new InvalidOperationException($"Товар {item.Key} не найден");
            }

            if (product.Count < item.Value) {
                throw new InvalidOperationException($"Недостаточно остатка по товару {product.Name}: нужно {item.Value}, доступно {product.Count}");
            }

            product.Count -= item.Value;
            _repository.Update(product);
        }
    }

    public void ReconcileInvoiceDetails(IEnumerable<InvoiceDetail> oldDetails, IEnumerable<InvoiceDetail> newDetails) {
        var oldGrouped = GroupByProduct(oldDetails);
        var newGrouped = GroupByProduct(newDetails);

        var ids = oldGrouped.Keys.Concat(newGrouped.Keys).Distinct();
        var products = LoadProducts(ids);

        var additionalRequired = newGrouped.ToDictionary(
            x => x.Key,
            x => x.Value - oldGrouped.GetValueOrDefault(x.Key, 0));

        EnsureStockAvailable(additionalRequired, products, newGrouped);

        var delta = ids.ToDictionary(
            id => id,
            id => oldGrouped.GetValueOrDefault(id, 0) - newGrouped.GetValueOrDefault(id, 0));

        ApplyDelta(products, delta);
    }

    public void ReturnForInvoice(IEnumerable<InvoiceDetail> details) {
        var grouped = details
            .GroupBy(d => d.ProductId)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Count));

        var products = _repository.Get(grouped.Keys)
            .ToDictionary(x => x.Id);

        foreach (var item in grouped) {
            if (!products.TryGetValue(item.Key, out var product)) {
                throw new InvalidOperationException($"Товар {item.Key} не найден");
            }

            product.Count += item.Value;
            _repository.Update(product);
        }
    }
}
