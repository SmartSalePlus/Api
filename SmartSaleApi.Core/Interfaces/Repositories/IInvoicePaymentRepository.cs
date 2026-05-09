using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IInvoicePaymentRepository {
    void Add(InvoicePayment payment);
    void Delete(InvoicePayment payment);
    InvoicePayment Get(int paymentId);
}
