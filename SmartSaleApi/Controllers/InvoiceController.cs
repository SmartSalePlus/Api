using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Dtos.Invoices;
using SmartSaleApi.Extensions.Mapping;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class InvoiceController : ControllerBase {
    private readonly IInvoiceService _invoiceService;
    private readonly IInvoiceReportService _reportService;

    public InvoiceController(IInvoiceService invoiceService, IInvoiceReportService invoiceReportService) {
        _invoiceService = invoiceService;
        _reportService = invoiceReportService;
    }

    [HttpPost]
    public void Add([FromBody] InvoiceSaveDto invoiceDto) {
        _invoiceService.Add(invoiceDto.ToModel());
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _invoiceService.Delete(id);
    }

    [HttpGet("{id}")]
    public InvoiceDto Get(int id) {
        return _invoiceService.Get(id).ToDto();
    }

    [HttpPost]
    public IEnumerable<InvoiceDto> Get([FromBody] InvoiceFilterDto filter) {
        return _invoiceService.Get(filter.ToFilter())
            .Select(x => x.ToDto());
    }

    [HttpGet]
    public IEnumerable<InvoiceDto> Get() {
        return _invoiceService.Get().Select(x => x.ToDto());
    }

    [HttpGet]
    public FileStreamResult GetFile(int invoiceId) {
        var (name, memoryStream) = _reportService.GetMemoryStream(invoiceId);
        return File(memoryStream, "application/pdf", name);
    }
}
