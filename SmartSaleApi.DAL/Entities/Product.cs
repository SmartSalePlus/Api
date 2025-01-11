namespace SmartSaleApi.DAL.Entities;

internal sealed class Product {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
    public int CountInPackage { get; set; }
    public ICollection<ProductPriceHistory> ProductPriceHistories { get; set; } = [];
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = [];
}