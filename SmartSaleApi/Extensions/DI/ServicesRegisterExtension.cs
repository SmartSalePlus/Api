using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Application.Services;

namespace SmartSaleApi.Extensions.DI;

internal static class ServicesRegisterExtension {
    public static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReceptionService, ReceptionService>();
        services.AddScoped<IInvoiceReportService, InvoicePdfService>();
        services.AddScoped<IProductReportService, ProductPdfService>();
        services.AddScoped<IBuyerReportService, BuyerPdfService>();

        return services;
    }
}