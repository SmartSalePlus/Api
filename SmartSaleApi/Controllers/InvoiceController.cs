using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class InvoiceController(IInvoiceService service) : ControllerBase {
    [HttpPost]
    public void Add([FromBody] Invoice invoice) {
        service.Add(invoice);
    }

    [HttpPut]
    public void Update([FromBody] Invoice invoice) {
        service.Update(invoice);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        service.Delete(id);
    }

    [HttpGet("{id}")]
    public Invoice Get(int id) {
        return service.Get(id);
    }

    [HttpGet("date/{date}")]
    public IEnumerable<Invoice> Get(DateOnly date) {
        return service.Get(date);
    }

    [HttpGet("{buyerId}")]
    public IEnumerable<Invoice> GetByBuyer(int buyerId) {
        return service.GetByBuyer(buyerId);
    }

    [HttpGet]
    public IEnumerable<Invoice> Get() {
        return service.Get();
    }
}