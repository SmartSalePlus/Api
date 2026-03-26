using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class SecurityController : ControllerBase {
    private readonly ISecurityService _securityService;
    private readonly IJwtService _jwtService;
    private readonly ICryptoService _cryptoService;

    public SecurityController(ISecurityService securityService, IJwtService jwtService, ICryptoService cryptoService) {
        _securityService = securityService;
        _jwtService = jwtService;
        _cryptoService = cryptoService;
    }

    [HttpPost]
    public ActionResult<string> Login([FromBody] User user) {
        if (_securityService.IsAuthenticated(user)) {
            var token = _jwtService.GenerateToken(user);
            return Ok(token);
        }

        return Unauthorized("Неверный логин или пароль");
    }

    [HttpGet]
    //[Authorize]
    public IActionResult ValidateToken() {
        return Ok();
    }

    [HttpGet]
    public string GetHash(string password) {
        return _cryptoService.ToHash(password);
    }
}