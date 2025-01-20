using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IReceptionRepository {
    int Add(Reception reception);
    void Update(Reception reception);
    void Delete(int id);
    Reception Get(int id);
    IEnumerable<Reception> GetByDate(DateTime date);
    IEnumerable<Reception> GetByProduct(int productId);
    IEnumerable<Reception> Get();
}