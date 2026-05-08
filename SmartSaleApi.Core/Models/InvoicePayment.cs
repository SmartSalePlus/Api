namespace SmartSaleApi.Core.Models;

public sealed class InvoicePayment {
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public DateOnly Date { get; set; }
    public int Amount { get; set; }
}