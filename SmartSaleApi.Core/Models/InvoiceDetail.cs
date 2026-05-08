namespace SmartSaleApi.Core.Models;

public sealed class InvoiceDetail {
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public int InPackage { get; set; }
    public double Price { get; set; }
    public int Total { get; set; }
    public required Invoice Invoice { get; set; }
    public required Product Product { get; set; }
}