using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Filters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class InvoiceService : IInvoiceService {
    private readonly IInvoiceRepository _repository;
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(
        IInvoiceRepository repository,
        IProductService productService,
        IUnitOfWork unitOfWork
    ) {
        _repository = repository;
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public void Add(Invoice invoice) {
        CalculateTotal(invoice);
        CalculatePayment(invoice);

        _productService.Sell(invoice.InvoiceDetails);
        _repository.Add(invoice);
        _unitOfWork.SaveChanges();
    }

    public void Update(Invoice invoice) {
        CalculateTotal(invoice);
        CalculatePayment(invoice);
        
        if (invoice.InvoiceDetails.All(x => x.ReturnStatus == ReturnStatus.Full)) {
            invoice.IsDeleted = true;
        }

        _repository.Update(invoice);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id) {
        var invoice = _repository.Get(id);

        _productService.Return(invoice.InvoiceDetails);
        invoice.IsDeleted = true;
        _unitOfWork.SaveChanges();
    }

    public Invoice Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Invoice> Get() {
        return _repository.Get();
    }

    public IEnumerable<Invoice> Get(InvoiceFilter parameter) {
        return _repository.Get(parameter);
    }

    private static void CalculateTotal(Invoice invoice) {
        var details = invoice.InvoiceDetails.ToList();

        if (details.Count == 0) {
            throw new ArgumentException("Накладная не содержит товаров");
        }

        if (details.Any(x => x.Count <= 0)) {
            throw new ArgumentException("Некорректное количество, значение <= 0");
        }

        foreach (var detail in details) {
            detail.ReturnedCount = detail.InvoiceDetailReturns.Sum(x => x.Count);
            detail.AvailableCount = detail.Count - detail.ReturnedCount;
            detail.Total = (int)Math.Round(detail.AvailableCount * detail.Price, MidpointRounding.AwayFromZero);
            detail.ReturnStatus = GetReturnStatus(detail.ReturnedCount, detail.Count);
        }

        invoice.Total = details.Sum(x => x.Total);
        invoice.TotalWithDiscount = invoice.Total - invoice.Discount;
    }

    private static ReturnStatus GetReturnStatus(int returnedCount, int count) {
        if (returnedCount == 0) {
            return ReturnStatus.None;
        }

        if (returnedCount < count) {
            return ReturnStatus.Partial;
        }

        return ReturnStatus.Full;
    }

    private static void CalculatePayment(Invoice invoice) {
        if (invoice.InvoicePayments.Any(x => x.Amount <= 0)) {
            throw new InvalidOperationException("Сумма оплаты должна быть больше 0");
        }

        invoice.PaidAmount = invoice.InvoicePayments.Sum(x => x.Amount);

        if (invoice.PaidAmount > invoice.TotalWithDiscount) {
            throw new InvalidOperationException($"Сумма оплаты превышает итоговую сумму накладной: {invoice.TotalWithDiscount}");
        }

        invoice.PaymentStatus = GetPaymentStatus(invoice.PaidAmount, invoice.TotalWithDiscount);
    }

    private static PaymentStatus GetPaymentStatus(int paidAmount, int totalWithDiscount) {
        if (paidAmount == 0) {
            return PaymentStatus.None;
        }

        if (paidAmount < totalWithDiscount) {
            return PaymentStatus.Partial;
        }

        return PaymentStatus.Full;
    }
}