using Microsoft.EntityFrameworkCore;
using SmartSaleApi.DAL.Contexts;

namespace SmartSaleApi.Extensions;

internal static class RepositoriesRegisterExtension {
    public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString(nameof(SmartSaleDbContext));
        services.AddDbContext<SmartSaleDbContext>(x => x.UseNpgsql(connectionString), ServiceLifetime.Transient);

        return services;
    }
}