using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ReceptionController(IReceptionService service) : ControllerBase {
    [HttpPost]
    public void Add([FromBody] Reception reception) {
        service.Add(reception);
    }

    [HttpPut]
    public void Update([FromBody] Reception reception) {
        service.Update(reception);
    }

    [HttpDelete("id")]
    public void Delete(int id) {
        service.Delete(id);
    }

    [HttpGet("id")]
    public Reception Get(int id) {
        return service.Get(id);
    }

    [HttpGet("date")]
    public IEnumerable<Reception> GetByDate(DateTime date) {
        return service.GetByDate(date);
    }

    [HttpGet("productId")]
    public IEnumerable<Reception> GetByProduct(int productId) {
        return service.GetByProduct(productId);
    }

    [HttpGet]
    public IEnumerable<Reception> Get() {  
        return service.Get();
    }
}