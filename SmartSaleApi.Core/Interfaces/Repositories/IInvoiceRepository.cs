using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IInvoiceRepository {
    void Add(Invoice invoice);
    void Update(Invoice invoice);
    void Delete(int id);
    Invoice Get(int id);
    IEnumerable<Invoice> Get(InvoiceInputParameter parameter);
    IEnumerable<Invoice> Get();
}