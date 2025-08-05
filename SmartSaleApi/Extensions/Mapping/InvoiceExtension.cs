using SmartSaleApi.Core.Models;
using SmartSaleApi.ViewModel;

namespace SmartSaleApi.Extensions.Mapping;

public static class InvoiceExtension {
    public static InvoiceViewModel ToViewModel(this Invoice invoice, Buyer buyer, IEnumerable<InvoiceDetailViewModel> invoiceDetailViewModels)
        => new(
            invoice.Id,
            invoice.Date,
            invoice.Total,
            invoice.Discount,
            invoice.TotalWithDiscount,
            invoice.IsPaid,
            buyer,
            invoiceDetailViewModels
        );
}