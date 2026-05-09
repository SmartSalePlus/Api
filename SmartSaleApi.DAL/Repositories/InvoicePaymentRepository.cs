using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;

namespace SmartSaleApi.DAL.Repositories;

public sealed class InvoicePaymentRepository : IInvoicePaymentRepository {
    private readonly SmartSaleDbContext _context;

    public InvoicePaymentRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(InvoicePayment payment) {
        _context.InvoicePayments.Add(payment);
    }

    public void Delete(InvoicePayment payment) {
        _context.InvoicePayments.Remove(payment);
    }

    public InvoicePayment Get(int paymentId) {
        var payment = _context.InvoicePayments.FirstOrDefault(x => x.Id == paymentId);
        ArgumentNullException.ThrowIfNull(payment);
        return payment;
    }
}
