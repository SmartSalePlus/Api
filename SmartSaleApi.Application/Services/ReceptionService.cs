using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class ReceptionService : IReceptionService {
    private readonly IReceptionRepository _repository;
    private readonly IProductService _productService;

    public ReceptionService(IReceptionRepository repository, IProductService productService) {
        _repository = repository;
        _productService = productService;
    }

    public void Add(Reception reception) {
        if (reception.ReceptionDetails.Any(x => x.Count <= 0)) {
            throw new ArgumentException($"Некорректное количество, значение <= 0");
        }

        _repository.Add(reception);

        var products = _productService.Get(reception.ReceptionDetails.Select(x => x.ProductId).ToArray());
        foreach (var receptionDetail in reception.ReceptionDetails) {
            var product = products.First(x=>x.Id == receptionDetail.ProductId);
            var updatedProduct = product with { Count = product.Count + receptionDetail.Count };

            _productService.Update(updatedProduct);
        }
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public Reception Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Reception> Get() {
        return _repository.Get();
    }

    public IEnumerable<Reception> Get(DateOnly date) {
        return _repository.Get(date);
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return _repository.GetByProduct(productId);
    }

    public void Update(Reception reception) {
        _repository.Update(reception);
    }
}