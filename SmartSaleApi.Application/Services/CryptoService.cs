using SmartSaleApi.Core.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace SmartSaleApi.Application.Services;

public sealed class CryptoService : ICryptoService {
    public string ToHash(string key) {
        var bytes = Encoding.UTF8.GetBytes(key);
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }
}