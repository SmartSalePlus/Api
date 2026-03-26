using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;

namespace SmartSaleApi.DAL.Repositories;

public sealed class UserRepository : IUserRepository {
    private readonly SmartSaleDbContext _context;

    public UserRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public Core::User Get(string login) {
        var user = _context.Set<DAL::User>()
            .AsNoTracking()
            .FirstOrDefault(x => x.Login == login);

        ArgumentNullException.ThrowIfNull(user);

        return user.ToModel();
    }
}