using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class ReceptionDetailExtension {
    public static Core::ReceptionDetail ToModel(this DAL::ReceptionDetail src)
        => new(
            src.Count,
            src.Price,
            src.Product.ToModel()
        );

    public static IEnumerable<Core::ReceptionDetail> ToModel(this IEnumerable<DAL::ReceptionDetail> src)
        => src.Select(x => x.ToModel());

    public static DAL::ReceptionDetail ToEntity(this Core::ReceptionDetail src, DAL::Reception reception, DAL::Product product)
        => new() {
            ReceptionId = reception.Id,
            ProductId = product.Id,
            Count = src.Count,
            Price = src.Price,
            Reception = reception,
            Product = product
        };
}