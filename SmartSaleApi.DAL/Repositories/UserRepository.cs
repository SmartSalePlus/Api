using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;

namespace SmartSaleApi.DAL.Repositories;

public sealed class UserRepository : IUserRepository {
    private readonly SmartSaleDbContext _context;

    public UserRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public User Get(string login) {
        var user = _context.Set<User>()
            .AsNoTracking()
            .FirstOrDefault(x => x.Login == login);

        ArgumentNullException.ThrowIfNull(user);

        return user;
    }
}