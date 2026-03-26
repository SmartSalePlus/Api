using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Services;

public interface ISecurityService {
    bool IsAuthenticated(User user);
}