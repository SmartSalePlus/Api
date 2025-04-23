using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class ReceptionRepository : IReceptionRepository {
    private readonly SmartSaleDbContext _context;

    public ReceptionRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(Reception reception) {
        _context.Receptions.Add(reception.ToEntity());
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Receptions
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Reception Get(int id) {
        var reception = _context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(reception);

        return reception.ToModel();
    }

    public IEnumerable<Reception> Get() {
        return _context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .ToModel();
    }

    public IEnumerable<Reception> Get(DateOnly date) {
        return _context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .Where(x => x.Date == date)
            .ToModel();
    }

    public IEnumerable<Reception> GetByProduct(int productId) {
        return _context.Receptions
            .AsNoTracking()
            .Include(x => x.ReceptionDetails)
            .ThenInclude(x => x.Product)
            .Where(x => x.ReceptionDetails.Any(r => r.ProductId == productId))
            .ToModel();
    }

    public void Update(Reception reception) {
        _context.Receptions
            .Where(x => x.Id == reception.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Date, reception.Date)
            );
    }
}
