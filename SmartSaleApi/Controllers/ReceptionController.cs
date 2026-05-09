using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Dtos.Receptions;
using SmartSaleApi.Extensions.Mapping;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ReceptionController : ControllerBase {
    private readonly IReceptionService _receptionService;

    public ReceptionController(IReceptionService receptionService) {
        _receptionService = receptionService;
    }

    [HttpPost]
    public void Add([FromBody] ReceptionSaveDto receptionDto) {
        _receptionService.Add(receptionDto.ToModel());
    }

    [HttpPut("{id}")]
    public void Update(int id, [FromBody] ReceptionSaveDto receptionDto) {
        _receptionService.Update(receptionDto.ToModel(id));
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _receptionService.Delete(id);
    }

    [HttpGet("{id}")]
    public ReceptionDto Get(int id) {
        return _receptionService.Get(id).ToDto();
    }

    [HttpGet("date/{date}")]
    public IEnumerable<ReceptionDto> Get(DateOnly date) {
        return _receptionService.Get(date).Select(x => x.ToDto());
    }

    [HttpGet("{productId}")]
    public IEnumerable<ReceptionDto> GetByProduct(int productId) {
        return _receptionService.GetByProduct(productId).Select(x => x.ToDto());
    }

    [HttpGet]
    public IEnumerable<ReceptionDto> Get() {
        return _receptionService.Get().Select(x => x.ToDto());
    }
}
