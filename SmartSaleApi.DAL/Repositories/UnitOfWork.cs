using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.DAL.Contexts;

namespace SmartSaleApi.DAL.Repositories;

public sealed class UnitOfWork : IUnitOfWork {
    private readonly SmartSaleDbContext _context;

    public UnitOfWork(SmartSaleDbContext context) {
        _context = context;
    }

    public void SaveChanges() {
        _context.SaveChanges();
    }
}