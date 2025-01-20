using SmartSaleApi.Core.Extensions;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class InvoiceService(
    IInvoiceRepository repository,
    IInvoiceDetailService invoiceDetailService
) : IInvoiceService {
    public void Add(Invoice invoice) {
        var id = repository.Add(invoice);
        invoiceDetailService.AddRange(invoice.CloneWithNewId(id));
    }

    public void Delete(int id) {
        repository.Delete(id);
    }

    public Invoice Get(int id) {
        return repository.Get(id);
    }

    public IEnumerable<Invoice> Get() {
        return repository.Get();
    }

    public IEnumerable<Invoice> GetByBuyer(int buyerId) {
        return repository.GetByBuyer(buyerId);
    }

    public IEnumerable<Invoice> GetByDate(DateTime date) {
        return repository.GetByDate(date);
    }

    public void Update(Invoice invoice) {
        repository.Update(invoice);
    }
}