using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IInvoiceRepository {
    void Add(Invoice invoice);
    void Update(Invoice invoice);
    void Delete(int id);
    Invoice Get(int id);
    IEnumerable<Invoice> Get(DateOnly date);
    IEnumerable<Invoice> GetByBuyer(int buyerId);
    IEnumerable<Invoice> Get();
}