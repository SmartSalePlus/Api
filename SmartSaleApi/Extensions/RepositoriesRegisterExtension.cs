using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Repositories;

namespace SmartSaleApi.Extensions;

internal static class RepositoriesRegisterExtension {
    public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString(nameof(SmartSaleDbContext));
        services.AddDbContext<SmartSaleDbContext>(x => x.UseNpgsql(connectionString), ServiceLifetime.Transient);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductPriceHistoryRepository, ProductPriceHistoryRepository>();
        services.AddScoped<IReceptionRepository, ReceptionRepository>();

        return services;
    }
}