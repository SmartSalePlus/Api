using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IReceptionService {
    void Add(Reception reception);
    void Update(Reception reception);
    void Delete(int id);
    Reception Get(int id);
    IEnumerable<Reception> GetByDate(DateOnly date);
    IEnumerable<Reception> GetByProduct(int productId);
    IEnumerable<Reception> Get();
}