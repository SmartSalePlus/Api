using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class BuyerService : IBuyerService {
    private readonly IBuyerRepository _repository;

    public BuyerService(IBuyerRepository repository) {
        _repository = repository;
    }

    public void Add(Buyer buyer) {
        _repository.Add(buyer);
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public Buyer Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Buyer> Get(string name) {
        return _repository.Get(name);
    }

    public IEnumerable<Buyer> Get() {
        return _repository.Get();
    }

    public void Update(Buyer buyer) {
        _repository.Update(buyer);
    }
}