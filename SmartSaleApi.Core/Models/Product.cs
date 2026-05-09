namespace SmartSaleApi.Core.Models;

public sealed class Product {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
    public int InPackage { get; set; }
    public double Price { get; set; }
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = [];
}
