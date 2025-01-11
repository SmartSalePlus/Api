using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IBuyerRepository {
    void Add(Buyer buyer);
    void Update(Buyer buyer);
    void Delete(int id);
    Buyer Get(int id);
    IEnumerable<Buyer> Get(string name);
    IEnumerable<Buyer> Get();
}