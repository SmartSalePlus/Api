using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;
public sealed class ReceptionDetailRepository(SmartSaleDbContext context) : IReceptionDetailRepository {
    public void AddRange(Reception reception) {
        var receptionEntity = reception.ToEntity();
        context.Attach(receptionEntity);

        foreach (var receptionDetail in reception.ReceptionDetails) {
            var productEntity = receptionDetail.Product.ToEntity();
            context.Attach(productEntity);
            context.ReceptionDetails.Add(receptionDetail.ToEntity(receptionEntity, productEntity));
        }

        context.SaveChanges();
    }
}