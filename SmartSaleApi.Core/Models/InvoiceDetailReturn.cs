namespace SmartSaleApi.Core.Models;

public sealed class InvoiceDetailReturn {
    public int Id { get; set; }
    public int InvoiceDetailId { get; set; }
    public int Count { get; set; }
    public DateTime Date { get; set; }
    public InvoiceDetail InvoiceDetail { get; set; } = null!;
}
