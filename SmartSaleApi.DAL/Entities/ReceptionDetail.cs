namespace SmartSaleApi.DAL.Entities;

internal sealed class ReceptionDetail {
    public int ReceptionId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public required Reception Reception { get; set; }
    public required Product Product { get; set; }
}