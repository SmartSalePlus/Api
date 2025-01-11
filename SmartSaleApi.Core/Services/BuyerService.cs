using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class BuyerService(IBuyerRepository repository) : IBuyerService {
    public void Add(Buyer buyer) {
        repository.Add(buyer);
    }

    public void Delete(int id) {
        repository.Delete(id);
    }

    public Buyer Get(int id) {
        return repository.Get(id);
    }

    public IEnumerable<Buyer> Get(string name) {
        return repository.Get(name);
    }

    public IEnumerable<Buyer> Get() {
        return repository.Get();
    }

    public void Update(Buyer buyer) {
        repository.Update(buyer);
    }
}