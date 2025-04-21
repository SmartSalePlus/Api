namespace SmartSaleApi.DAL.Entities;

internal sealed class ReceptionDetail {
    public int ReceptionId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public Reception? Reception { get; set; }
    public Product? Product { get; set; }
}