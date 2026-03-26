using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class SecurityService : ISecurityService {
    private readonly IUserRepository _userRepository;
    private readonly ICryptoService _cryptoService;

    public SecurityService(IUserRepository userRepository, ICryptoService cryptoService) {
        _userRepository = userRepository;
        _cryptoService = cryptoService;
    }

    public bool IsAuthenticated(User user)
    {
        try {
            var password = _userRepository.Get(user.Login).Password;
            var hash = _cryptoService.ToHash(user.Password);
            return IsEqual(hash, password);
        }
        catch (ArgumentNullException) {
            return false;
        }
    }

    private bool IsEqual(string firstValue, string secondValue) {
        return firstValue.Equals(secondValue);
    }
}