using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
//[Authorize]
public sealed class BuyerController : ControllerBase {
    private readonly IBuyerService _buyerService;
    private readonly IBuyerReportService _reportService;

    public BuyerController(IBuyerService buyerService, IBuyerReportService reportService) {
        _buyerService = buyerService;
        _reportService = reportService;
    }

    [HttpPost]
    public void Add([FromBody] Buyer buyer) {
        _buyerService.Add(buyer);
    }

    [HttpPut]
    public void Update([FromBody] Buyer buyer) {
        _buyerService.Update(buyer);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _buyerService.Delete(id);
    }

    [HttpGet("{id}")]
    public Buyer Get(int id) {
        return _buyerService.Get(id);
    }

    [HttpGet("name/{name}")]
    public IEnumerable<Buyer> Get(string name) {
        return _buyerService.Get(name);
    }

    [HttpGet]
    public IEnumerable<Buyer> Get() {
        return _buyerService.Get();
    }

    [HttpGet]
    public FileStreamResult GetFile(int buyerId) {
        var (name, memoryStream) = _reportService.GetMemoryStream(buyerId);
        return File(memoryStream, "application/pdf", name);
    }
}