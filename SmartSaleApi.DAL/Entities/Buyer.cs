namespace SmartSaleApi.DAL.Entities;

internal sealed class Buyer {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Invoice> Invoices { get; set; } = [];
}