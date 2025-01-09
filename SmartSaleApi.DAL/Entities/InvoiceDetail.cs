namespace SmartSaleApi.DAL.Entities;

internal sealed class InvoiceDetail {
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public double Total { get; set; }
    public required Invoice Invoice { get; set; }
    public required Product Product { get; set; }
}