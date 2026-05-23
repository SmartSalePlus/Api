using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IInvoiceDetailsService {
    void CalculateTotals(Invoice invoice);
}
