using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartSaleApi.Application.Services;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Settings;
using System.Text;

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
        services.AddScoped<ICryptoService, CryptoService>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }

    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration) {
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        ArgumentNullException.ThrowIfNull(jwtSettings);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x => {
                x.TokenValidationParameters = new() {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = key
                };
            });

        return services;
    }
}