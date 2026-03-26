using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;
using SmartSaleApi.Core.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartSaleApi.Application.Services;

public sealed class JwtService : IJwtService {
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> options) {
        _jwtSettings = options.Value;
    }

    public string GenerateToken(User user) {
        Claim[] claims = [new(ClaimTypes.Name, user.Login)];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiryDays),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}