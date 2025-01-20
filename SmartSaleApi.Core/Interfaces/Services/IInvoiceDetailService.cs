using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface IInvoiceDetailService {
    void AddRange(Invoice invoice);
}