using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;
using SmartSaleApi.Extensions.Mapping;
using SmartSaleApi.ViewModel;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class InvoiceController : ControllerBase {
    private readonly IInvoiceService _invoiceService;
    private readonly IBuyerService _buyerService;
    private readonly IProductService _productService;

    public InvoiceController(IInvoiceService invoiceService, IBuyerService buyerService, IProductService productService) {
        _invoiceService = invoiceService;
        _buyerService = buyerService;
        _productService = productService;
    }

    [HttpPost]
    public void Add([FromBody] Invoice invoice) {
        _invoiceService.Add(invoice);
    }

    [HttpPut]
    public void Update([FromBody] Invoice invoice) {
        _invoiceService.Update(invoice);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _invoiceService.Delete(id);
    }

    [HttpGet("{id}")]
    public InvoiceViewModel Get(int id) {
        var invoice = _invoiceService.Get(id);
        return GetInvoiceViewModel(invoice);
    }

    [HttpPost]
    public IEnumerable<InvoiceViewModel> Get([FromBody] InvoiceInputParameter parameter) {
        var invoices = _invoiceService.Get(parameter);
        return invoices.Select(x => GetInvoiceViewModel(x))
            .OrderByDescending(x => x.Date)
            .ThenByDescending(x => x.Buyer.Name);
    }

    [HttpGet]
    public IEnumerable<InvoiceViewModel> Get() {
        var invoices = _invoiceService.Get();
        return invoices.Select(x => GetInvoiceViewModel(x))
            .OrderByDescending(x => x.Date)
            .ThenByDescending(x => x.Buyer.Name);
    }

    private InvoiceViewModel GetInvoiceViewModel(Invoice invoice) {
        var buyer = _buyerService.Get(invoice.BuyerId);
        var invoiceDetailViewModels = GetInvoiceDetailViewModels(invoice.InvoiceDetails);
        return invoice.ToViewModel(buyer, invoiceDetailViewModels);
    }

    private IEnumerable<InvoiceDetailViewModel> GetInvoiceDetailViewModels(IEnumerable<InvoiceDetail> invoiceDetails) {
        return invoiceDetails.Select(x => x.ToViewModel(_productService.Get(x.ProductId)));
    }
}