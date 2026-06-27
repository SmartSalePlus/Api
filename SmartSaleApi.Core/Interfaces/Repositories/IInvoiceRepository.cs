using SmartSaleApi.Core.Filters;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IInvoiceRepository {
    void Add(Invoice invoice);
    void Update(Invoice invoice);
    Invoice Get(int id);
    IEnumerable<Invoice> Get(InvoiceFilter parameter);
    IEnumerable<Invoice> Get();
}
