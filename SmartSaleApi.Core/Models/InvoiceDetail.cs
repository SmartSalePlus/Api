using SmartSaleApi.Core.Enums;

namespace SmartSaleApi.Core.Models;

public sealed class InvoiceDetail {
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public int InPackage { get; set; }
    public double Price { get; set; }
    public int ReturnedCount { get; set; }
    public int AvailableCount { get; set; }
    public int Total { get; set; }
    public ReturnStatus ReturnStatus { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public ICollection<InvoiceDetailReturn> InvoiceDetailReturns { get; set; } = [];
}
