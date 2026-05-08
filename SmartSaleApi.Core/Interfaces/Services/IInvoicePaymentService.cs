using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IInvoicePaymentService {
    void Add(InvoicePayment payment);
    void Delete(int paymentId);
}
