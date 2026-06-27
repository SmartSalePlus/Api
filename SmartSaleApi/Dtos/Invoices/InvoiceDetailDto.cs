using SmartSaleApi.Core.Enums;

namespace SmartSaleApi.Dtos.Invoices;

public sealed record InvoiceDetailDto(
    int Id,
    int ProductId,
    string ProductName,
    int Count,
    int InPackage,
    double Price,
    int ReturnedCount,
    int AvailableCount,
    int Total,
    ReturnStatus ReturnStatus,
    IEnumerable<InvoiceDetailReturnDto> InvoiceDetailReturnDtos
);
