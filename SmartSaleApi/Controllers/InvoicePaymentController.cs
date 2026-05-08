using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class InvoicePaymentController : ControllerBase {
    private readonly IInvoicePaymentService _invoicePaymentService;

    public InvoicePaymentController(IInvoicePaymentService invoicePaymentService) {
        _invoicePaymentService = invoicePaymentService;
    }

    [HttpPost]
    public void Add([FromBody] InvoicePayment payment) {
        _invoicePaymentService.Add(payment);
    }

    [HttpDelete("{paymentId}")]
    public void Delete(int paymentId) {
        _invoicePaymentService.Delete(paymentId);
    }
}
