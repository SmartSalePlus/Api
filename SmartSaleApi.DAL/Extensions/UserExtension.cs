using Core = SmartSaleApi.Core.Models;
using DAL = SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Extensions;

internal static class UserExtension {
    public static Core::User ToModel(this DAL::User src)
        => new(
            src.Login,
            src.Password
        );
}