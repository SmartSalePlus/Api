using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ProductController : ControllerBase {
    private readonly IProductService _productService;
    private readonly IProductReportService _reportService;

    public ProductController(IProductService productService, IProductReportService reportService) {
        _productService = productService;
        _reportService = reportService;
    }

    [HttpPost]
    public void Add([FromBody] Product product) {
        _productService.Add(product);
    }

    [HttpPut]
    public void Update([FromBody] Product product) {
        _productService.Update(product);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _productService.Delete(id);
    }

    [HttpGet("{id}")]
    public Product Get(int id) {
        return _productService.Get(id);
    }

    [HttpGet("name/{name}")]
    public IEnumerable<Product> Get(string name) {
        return _productService.Get(name);
    }

    [HttpGet]
    public IEnumerable<Product> Get() {
        return _productService.Get();
    }

    [HttpGet]
    public FileStreamResult GetFile() {
        var (name, memoryStream) = _reportService.GetMemoryStream();
        return File(memoryStream, "application/pdf", name);
    }
}