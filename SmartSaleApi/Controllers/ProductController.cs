using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Reports;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Dtos.Products;
using SmartSaleApi.Extensions.Mapping;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ProductController : ControllerBase {
    private readonly IProductService _productService;
    private readonly IProductReport _reportService;

    public ProductController(IProductService productService, IProductReport reportService) {
        _productService = productService;
        _reportService = reportService;
    }

    [HttpPost]
    public void Add([FromBody] ProductSaveDto productDto) {
        _productService.Add(productDto.ToModel());
    }

    [HttpPut("{id}")]
    public void Update(int id, [FromBody] ProductSaveDto productDto) {
        _productService.Update(productDto.ToModel(id));
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _productService.Delete(id);
    }

    [HttpGet("{id}")]
    public ProductDto Get(int id) {
        return _productService.Get(id).ToDto();
    }

    [HttpGet("name/{name}")]
    public IEnumerable<ProductDto> Get(string name) {
        return _productService.Get(name).Select(x => x.ToDto());
    }

    [HttpGet]
    public IEnumerable<ProductDto> Get() {
        return _productService.Get().Select(x => x.ToDto());
    }

    [HttpGet]
    public FileStreamResult GetFile() {
        var (name, memoryStream) = _reportService.GetMemoryStream();
        return File(memoryStream, "application/pdf", name);
    }
}
