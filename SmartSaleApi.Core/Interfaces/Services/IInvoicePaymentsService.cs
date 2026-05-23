using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IInvoicePaymentsService {
    void Recalculate(Invoice invoice);
}
