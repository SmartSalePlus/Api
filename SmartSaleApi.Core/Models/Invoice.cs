using SmartSaleApi.Core.Enums;

namespace SmartSaleApi.Core.Models;

public sealed class Invoice {
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateOnly Date { get; set; }

    public int Total { get; set; }
    public int Discount { get; set; }
    public int TotalWithDiscount { get; set; }

    public int PaidAmount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public bool IsDeleted { get; set; }

    public Buyer Buyer { get; set; } = null!;
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = [];
    public ICollection<InvoicePayment> InvoicePayments { get; set; } = [];
}
