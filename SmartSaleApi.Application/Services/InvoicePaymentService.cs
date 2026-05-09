using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class InvoicePaymentService : IInvoicePaymentService {
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoicePaymentRepository _invoicePaymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InvoicePaymentService(
        IInvoiceRepository invoiceRepository,
        IInvoicePaymentRepository invoicePaymentRepository,
        IUnitOfWork unitOfWork) {
        _invoiceRepository = invoiceRepository;
        _invoicePaymentRepository = invoicePaymentRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(InvoicePayment payment) {
        ArgumentNullException.ThrowIfNull(payment);

        var invoice = _invoiceRepository.Get(payment.InvoiceId);

        ValidatePaymentAmount(payment.Amount);
        ValidatePaymentDoesNotExceedRemaining(invoice, payment.Amount);

        _invoicePaymentRepository.Add(payment);

        var paidAmount = invoice.PaidAmount + payment.Amount;
        invoice.PaidAmount = paidAmount;
        invoice.PaymentStatus = RecalculatePaymentStatus(invoice.TotalWithDiscount, paidAmount);

        _invoiceRepository.Update(invoice);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int paymentId) {
        var payment = _invoicePaymentRepository.Get(paymentId);
        var invoice = _invoiceRepository.Get(payment.InvoiceId);

        _invoicePaymentRepository.Delete(payment);

        var paidAmount = Math.Max(0, invoice.PaidAmount - payment.Amount);
        invoice.PaidAmount = paidAmount;
        invoice.PaymentStatus = RecalculatePaymentStatus(invoice.TotalWithDiscount, paidAmount);

        _invoiceRepository.Update(invoice);
        _unitOfWork.SaveChanges();
    }

    private static PaymentStatus RecalculatePaymentStatus(int totalWithDiscount, int paidAmount) {
        if (paidAmount <= 0) {
            return PaymentStatus.Unpaid;
        }

        return paidAmount >= totalWithDiscount
            ? PaymentStatus.Paid
            : PaymentStatus.PartiallyPaid;
    }

    private static void ValidatePaymentAmount(int amount) {
        if (amount <= 0) {
            throw new InvalidOperationException("Сумма оплаты должна быть больше 0");
        }
    }

    private static void ValidatePaymentDoesNotExceedRemaining(Invoice invoice, int amount) {
        var remainingAmount = invoice.TotalWithDiscount - invoice.PaidAmount;
        if (amount > remainingAmount) {
            throw new InvalidOperationException($"Сумма оплаты превышает остаток. Осталось: {remainingAmount}");
        }
    }
}
