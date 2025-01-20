using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Interfaces.Repositories;

public interface IReceptionDetailRepository {
    void AddRange(Reception reception);
}