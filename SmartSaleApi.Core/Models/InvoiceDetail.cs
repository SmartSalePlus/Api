namespace SmartSaleApi.Core.Models;

public sealed class InvoiceDetail {
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public int InPackage { get; set; }
    public double Price { get; set; }
    public int Total { get; set; }
    public Invoice Invoice { get; set; }
    public Product Product { get; set; }
}
