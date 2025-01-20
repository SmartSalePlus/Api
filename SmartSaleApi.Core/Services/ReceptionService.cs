using SmartSaleApi.Core.Extensions;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class ReceptionService(
    IReceptionRepository repository,
    IReceptionDetailService receptionDetailService
) : IReceptionService {
    public void Add(Reception reception) {
        var id = repository.Add(reception);
        receptionDetailService.AddRange(reception.CloneWithNewId(id));
    }

    public void Delete(int id) {
        repository.Delete(id);
    }

    public Reception Get(int id) {
        return repository.Get(id);
    }

    public IEnumerable<Reception> Get() {
        return repository.Get();
    }

    public IEnumerable<Reception> GetByDate(DateTime date) {
        return repository.GetByDate(date);
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return repository.GetByProduct(productId);
    }

    public void Update(Reception reception) {
        repository.Update(reception);
    }
}