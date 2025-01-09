namespace SmartSaleApi.DAL.Entities;

internal sealed class PriceHistory {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public DateTime DateBegin { get; set; }
    public DateTime DateEnd { get; set; }
    public required Product Product { get; set; }
}