using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class BuyerController(IBuyerService service) : ControllerBase {
    [HttpPost]
    public void Add([FromBody] Buyer buyer) {
        service.Add(buyer);
    }

    [HttpPut]
    public void Update([FromBody] Buyer buyer) {
        service.Update(buyer);
    }

    [HttpDelete("id")]
    public void Delete(int id) {
        service.Delete(id);
    }

    [HttpGet("id")]
    public Buyer Get(int id) {
        return service.Get(id);
    }

    [HttpGet("name")]
    public IEnumerable<Buyer> Get(string name) {
        return service.Get(name);
    }

    [HttpGet]
    public IEnumerable<Buyer> Get() {
        return service.Get();
    }
}