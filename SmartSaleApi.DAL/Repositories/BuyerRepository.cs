using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class BuyerRepository : IBuyerRepository {
    private readonly SmartSaleDbContext _context;

    public BuyerRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(Buyer buyer) {
        _context.Buyers.Add(buyer.ToEntity());
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Buyers
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Buyer Get(int id) {
        var buyer = _context.Buyers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(buyer);

        return buyer.ToModel();
    }

    public IEnumerable<Buyer> Get(string name) {
        return _context.Buyers
            .AsNoTracking()
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .OrderBy(x => x.Name)
            .ToModel();
    }

    public IEnumerable<Buyer> Get() {
        return _context.Buyers
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToModel();
    }

    public void Update(Buyer buyer) {
        _context.Buyers
            .Where(x => x.Id == buyer.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Name, buyer.Name)
            );
    }
}