namespace SmartSaleApi.DAL.Entities;

internal sealed class Invoice {
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTime Date { get; set; }
    public double Total { get; set; }
    public double Discount { get; set; }
    public double TotalWithDiscount { get; set; }
    public bool IsPaid { get; set; }
    public required Buyer Buyer { get; set; }
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = [];
}