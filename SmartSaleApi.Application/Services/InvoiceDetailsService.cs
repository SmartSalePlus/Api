using SmartSaleApi.Core.Models;
using SmartSaleApi.Core.Interfaces.Services;

namespace SmartSaleApi.Application.Services;

public sealed class InvoiceDetailsService : IInvoiceDetailsService {
    public void CalculateTotals(Invoice invoice) {
        var details = invoice.InvoiceDetails.ToList();
        if (details.Count == 0) {
            throw new ArgumentException("Накладная не содержит товаров");
        }

        if (details.Any(x => x.Count <= 0)) {
            throw new ArgumentException("Некорректное количество, значение <= 0");
        }

        foreach (var detail in details) {
            detail.Total = (int)Math.Round(detail.Count * detail.Price, MidpointRounding.AwayFromZero);
        }

        invoice.Total = details.Sum(x => x.Total);
        invoice.TotalWithDiscount = invoice.Total - invoice.Discount;
    }
}
