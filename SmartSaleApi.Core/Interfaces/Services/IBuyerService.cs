using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IBuyerService {
    void Add(Buyer buyer);
    void Update(Buyer buyer);
    void Delete(int id);
    Buyer Get(int id);
    IEnumerable<Buyer> Get(string name);
    IEnumerable<Buyer> Get();
}