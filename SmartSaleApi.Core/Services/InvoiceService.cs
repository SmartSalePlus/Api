using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Services;

public sealed class InvoiceService : IInvoiceService {
    private readonly IInvoiceRepository _repository;
    private readonly IProductService _productService;

    public InvoiceService(IInvoiceRepository repository, IProductService productService) {
        _repository = repository;
        _productService = productService;
    }

    public void Add(Invoice invoice) {
        if (invoice.InvoiceDetails.Any(x => x.Count <= 0)) {
            throw new ArgumentException($"Некорректное количество, значение <= 0");
        }

        _repository.Add(invoice);
        foreach (var invoiceDetail in invoice.InvoiceDetails) {
            var product = _productService.Get(invoiceDetail.ProductId);
            var updatedProduct = product with { Count = product.Count - invoiceDetail.Count };

            _productService.Update(updatedProduct);
        }
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public Invoice Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Invoice> Get() {
        return _repository.Get();
    }

    public IEnumerable<Invoice> Get(InvoiceInputParameter parameter) {
        return _repository.Get(parameter);
    }

    public void Update(Invoice invoice) {
        _repository.Update(invoice);
    }
}