using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Services;

namespace SmartSaleApi.Extensions;

internal static class ServicesRegisterExtension {
    public static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
        services.AddScoped<IProductPriceHistoryService, ProductPriceHistoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReceptionService, ReceptionService>();
        services.AddScoped<IReceptionDetailService, ReceptionDetailService>();

        return services;
    }
}