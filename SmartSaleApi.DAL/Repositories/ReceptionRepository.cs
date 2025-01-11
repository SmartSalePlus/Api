using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ReceptionRepository(SmartSaleDbContext context) : IReceptionRepository {
    public void Add(Reception reception) {
        context.Receptions
            .Add(reception.ToEntity());
        context.SaveChanges();
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
            .FirstOrDefault(x => x.Id == id)?
            .ToModel() ?? throw new ArgumentException($"Не найдена приемка по данному Id = {id}");
    }

    public IEnumerable<Reception> Get() {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ToModel();
    }

    public IEnumerable<Reception> GetByDate(DateTime date) {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .Where(x => x.Date == date)
            .ToModel();
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails.Where(x => x.ProductId == productId))
            //.ThenInclude(x => x.Product)
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
