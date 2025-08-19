using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ProductController : ControllerBase {
    private readonly IProductService _service;
    private readonly IProductReportService _reportService;

    public ProductController(IProductService service, IProductReportService reportService) {
        _service = service;
        _reportService = reportService;
    }

    [HttpPost]
    public void Add([FromBody] Product product) {
        _service.Add(product);
    }

    [HttpPut]
    public void Update([FromBody] Product product) {
        _service.Update(product);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _service.Delete(id);
    }

    [HttpGet("{id}")]
    public Product Get(int id) {
        return _service.Get(id);
    }

    [HttpGet("name/{name}")]
    public IEnumerable<Product> Get(string name) {
        return _service.Get(name);
    }

    [HttpGet]
    public IEnumerable<Product> Get() {
        return _service.Get();
    }

    [HttpGet]
    public FileStreamResult GetFile() {
        var (name, memoryStream) = _reportService.GetMemoryStream();
        return File(memoryStream, "application/unknown", name);
    }
}