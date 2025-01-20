using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Core.Extensions;

internal static class ReceptionExtension {
    public static Reception CloneWithNewId(this Reception src, int id)
        => new(
            id,
            src.Date,
            src.ReceptionDetails
        );
}