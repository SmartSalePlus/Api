using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class ReceptionDetailExtension {
    public static Core::ReceptionDetail ToModel(this DAL::ReceptionDetail src) {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(src.Product);

        return new(
            src.Count,
            src.Price,
            src.Product.ToModel()
        );
    }

    public static IEnumerable<Core::ReceptionDetail> ToModel(this IEnumerable<DAL::ReceptionDetail> src)
        => src.Select(x => x.ToModel());

    public static DAL::ReceptionDetail ToEntity(this Core::ReceptionDetail src)
        => new() {
            ProductId = src.Product.Id,
            Count = src.Count,
            Price = src.Price
        };

    public static ICollection<DAL::ReceptionDetail> ToEntity(this IEnumerable<Core::ReceptionDetail> src)
        => src.Select(x => x.ToEntity()).ToList();
}