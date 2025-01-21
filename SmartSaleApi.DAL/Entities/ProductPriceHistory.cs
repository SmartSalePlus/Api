namespace SmartSaleApi.DAL.Entities;

internal sealed class ProductPriceHistory {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public DateOnly DateBegin { get; set; }
    public DateOnly DateEnd { get; set; }
    public required Product Product { get; set; }
}