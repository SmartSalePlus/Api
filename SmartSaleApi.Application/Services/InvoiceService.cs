using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Filters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class InvoiceService : IInvoiceService {
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceDetailsService _invoiceDetailsService;
    private readonly IInvoicePaymentsService _invoicePaymentsService;
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(
        IInvoiceRepository repository,
        IInvoiceDetailsService invoiceDetailsService,
        IInvoicePaymentsService invoicePaymentsService,
        IProductService productService,
        IUnitOfWork unitOfWork) {
        _repository = repository;
        _invoiceDetailsService = invoiceDetailsService;
        _invoicePaymentsService = invoicePaymentsService;
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public void Add(Invoice invoice) {
        _invoiceDetailsService.CalculateTotals(invoice);
        _invoicePaymentsService.Recalculate(invoice);
        invoice.EntityStatus = EntityStatus.Active;

        _productService.ReserveForInvoice(invoice.InvoiceDetails);
        _repository.Add(invoice);
        _unitOfWork.SaveChanges();
    }

    public void Update(Invoice invoice) {
        var existingInvoice = _repository.Get(invoice.Id);

        _invoiceDetailsService.CalculateTotals(invoice);
        _invoicePaymentsService.Recalculate(invoice);

        _productService.ReconcileInvoiceDetails(existingInvoice.InvoiceDetails, invoice.InvoiceDetails);
        _repository.Update(invoice);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id) {
        var invoice = _repository.Get(id);

        _productService.ReturnForInvoice(invoice.InvoiceDetails);
        _repository.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public Invoice Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Invoice> Get() {
        return _repository.Get();
    }

    public IEnumerable<Invoice> Get(InvoiceFilter parameter) {
        return _repository.Get(parameter);
    }
}
