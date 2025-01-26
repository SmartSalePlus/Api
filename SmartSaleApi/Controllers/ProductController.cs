using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ProductController(IProductService service) : ControllerBase {
    [HttpPost]
    public void Add([FromBody] Product product) {
        service.Add(product);
    }

    [HttpPut]
    public void Update([FromBody] Product product) {
        service.Update(product);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        service.Delete(id);
    }

    [HttpGet("{id}")]
    public Product Get(int id) {
        return service.Get(id);
    }

    [HttpGet("name/{name}")]
    public IEnumerable<Product> Get(string name) {
        return service.Get(name);
    }

    [HttpGet]
    public IEnumerable<Product> Get() {
        return service.Get();
    }
}