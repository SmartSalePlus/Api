using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Reports;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Dtos.Buyers;
using SmartSaleApi.Extensions.Mapping;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class BuyerController : ControllerBase {
    private readonly IBuyerService _buyerService;
    private readonly IBuyerReport _reportService;

    public BuyerController(IBuyerService buyerService, IBuyerReport reportService) {
        _buyerService = buyerService;
        _reportService = reportService;
    }

    [HttpPost]
    public void Add([FromBody] BuyerSaveDto buyerDto) {
        _buyerService.Add(buyerDto.ToModel());
    }

    [HttpPut("{id}")]
    public void Update(int id, [FromBody] BuyerSaveDto buyerDto) {
        _buyerService.Update(buyerDto.ToModel(id));
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _buyerService.Delete(id);
    }

    [HttpGet("{id}")]
    public BuyerDto Get(int id) {
        return _buyerService.Get(id).ToDto();
    }

    [HttpGet("name/{name}")]
    public IEnumerable<BuyerDto> Get(string name) {
        return _buyerService.Get(name).Select(x => x.ToDto());
    }

    [HttpGet]
    public IEnumerable<BuyerDto> Get() {
        return _buyerService.Get().Select(x => x.ToDto());
    }

    [HttpGet]
    public FileStreamResult GetFile(int buyerId) {
        var (name, memoryStream) = _reportService.GetMemoryStream(buyerId);
        return File(memoryStream, "application/pdf", name);
    }
}
