using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IInvoiceDetailRepository {
    void AddRange(Invoice invoice);
}