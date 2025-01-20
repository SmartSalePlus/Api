using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class BuyerRepository(SmartSaleDbContext context) : IBuyerRepository {
    public void Add(Buyer buyer) {
        var entity = buyer.ToEntity();
        context.Buyers.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id) {
        context.Buyers
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Buyer Get(int id) {
        return context.Buyers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id)?
            .ToModel() ?? throw new ArgumentException($"Не найден покупатель по данному Id = {id}");
    }

    public IEnumerable<Buyer> Get(string name) {
        return context.Buyers
            .AsNoTracking()
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .OrderBy(x => x.Name)
            .ToModel();
    }

    public IEnumerable<Buyer> Get() {
        return context.Buyers
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToModel();
    }

    public void Update(Buyer buyer) {
        context.Buyers
            .Where(x => x.Id == buyer.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Name, buyer.Name)
            );
    }
}