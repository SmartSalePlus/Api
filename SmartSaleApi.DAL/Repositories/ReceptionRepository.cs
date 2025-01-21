using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ReceptionRepository(SmartSaleDbContext context) : IReceptionRepository {
    public int Add(Reception reception) {
        var entity = reception.ToEntity();
        context.Receptions.Add(entity);
        context.SaveChanges();

        return entity.Id;
    }

    public void Delete(int id) {
        context.Receptions
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Reception Get(int id) {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.ProductPriceHistories)
            .FirstOrDefault(x => x.Id == id)?
            .ToModel() ?? throw new ArgumentException($"Не найдена приемка по данному Id = {id}");
    }

    public IEnumerable<Reception> Get() {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.ProductPriceHistories)
            .ToModel();
    }

    public IEnumerable<Reception> GetByDate(DateOnly date) {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.ProductPriceHistories)
            .Where(x => x.Date == date)
            .ToModel();
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.ProductPriceHistories)
            .Where(x => x.ReceptionDetails.Any(r => r.ProductId == productId))
            .ToModel();
    }

    public void Update(Reception reception) {
        context.Receptions
            .Where(x => x.Id == reception.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Date, reception.Date)
            );
    }
}
