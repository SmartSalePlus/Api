namespace SmartSaleApi.DAL.Entities;

internal sealed class Product {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CountInPackage { get; set; }
    public ICollection<PriceHistory> PriceHistories { get; set; } = [];
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = [];
}