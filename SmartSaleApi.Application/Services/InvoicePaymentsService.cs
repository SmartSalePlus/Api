using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class InvoicePaymentsService : IInvoicePaymentsService {
    public void Recalculate(Invoice invoice) {
        if (invoice.InvoicePayments.Any(x => x.Amount <= 0)) {
            throw new InvalidOperationException("Сумма оплаты должна быть больше 0");
        }

        invoice.PaidAmount = invoice.InvoicePayments.Sum(x => x.Amount);

        if (invoice.PaidAmount > invoice.TotalWithDiscount) {
            throw new InvalidOperationException($"Сумма оплаты превышает итоговую сумму накладной: {invoice.TotalWithDiscount}");
        }

        invoice.PaymentStatus = RecalculatePaymentStatus(invoice.TotalWithDiscount, invoice.PaidAmount);
    }

    private static PaymentStatus RecalculatePaymentStatus(int totalWithDiscount, int paidAmount) {
        if (paidAmount <= 0) {
            return PaymentStatus.Unpaid;
        }

        return paidAmount >= totalWithDiscount
            ? PaymentStatus.Paid
            : PaymentStatus.PartiallyPaid;
    }
}
