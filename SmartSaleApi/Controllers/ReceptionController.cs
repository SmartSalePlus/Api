using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;
using SmartSaleApi.Extensions.Mapping;
using SmartSaleApi.ViewModels;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ReceptionController : ControllerBase {
    private readonly IReceptionService _receptionService;
    private readonly IProductService _productService;

    public ReceptionController(IReceptionService receptionService, IProductService productService) {
        _receptionService = receptionService;
        _productService = productService;
    }

    [HttpPost]
    public void Add([FromBody] Reception reception) {
        _receptionService.Add(reception);
    }

    [HttpPut]
    public void Update([FromBody] Reception reception) {
        _receptionService.Update(reception);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _receptionService.Delete(id);
    }

    [HttpGet("{id}")]
    public ReceptionViewModel Get(int id) {
        var reception = _receptionService.Get(id);
        return GetReceptionViewModel(reception);
    }

    [HttpGet("date/{date}")]
    public IEnumerable<ReceptionViewModel> Get(DateOnly date) {
        var receptions = _receptionService.Get(date);
        return receptions.Select(x => GetReceptionViewModel(x));
    }

    [HttpGet("{productId}")]
    public IEnumerable<ReceptionViewModel> GetByProduct(int productId) {
        var receptions = _receptionService.GetByProduct(productId);
        return receptions.Select(x => GetReceptionViewModel(x));
    }

    [HttpGet]
    public IEnumerable<ReceptionViewModel> Get() {
        var receptions = _receptionService.Get();
        return receptions.Select(x => GetReceptionViewModel(x));
    }

    private ReceptionViewModel GetReceptionViewModel(Reception reception) {
        var receptionDetailViewModels = GetReceptionDetailViewModel(reception.ReceptionDetails);
        return reception.ToViewModel(receptionDetailViewModels);
    }

    private IEnumerable<ReceptionDetailViewModel> GetReceptionDetailViewModel(IEnumerable<ReceptionDetail> receptionDetails) {
        var products = _productService.Get(receptionDetails.Select(x => x.ProductId).ToArray());
        return receptionDetails.Select(x => x.ToViewModel(products.First(p => p.Id == x.ProductId)));
    }
}