using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Services;

namespace SmartSaleApi.Extensions.DI;

internal static class ServicesRegisterExtension {
    public static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReceptionService, ReceptionService>();

        return services;
    }
}