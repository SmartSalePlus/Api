using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class InvoiceService : IInvoiceService {
    private readonly IInvoiceRepository _repository;
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IInvoiceRepository repository, IProductService productService, IUnitOfWork unitOfWork) {
        _repository = repository;
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public void Add(Invoice invoice) {
        var details = invoice.InvoiceDetails.ToList();
        ValidateInvoiceDetails(details);

        var grouped = details
            .GroupBy(d => d.ProductId)
            .Select(g => (ProductId: g.Key, Count: g.Sum(x => x.Count)))
            .ToList();

        var products = _productService.Get(grouped.Select(x => x.ProductId).ToArray())
            .ToDictionary(p => p.Id);

        ValidateStock(grouped, products);

        _repository.Add(invoice);

        foreach (var item in grouped) {
            var product = products[item.ProductId];
            product.Count -= item.Count;
            _productService.Update(product);
        }

        _unitOfWork.SaveChanges();
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public Invoice Get(int id) {
        return _repository.Get(id);
    }

    public IEnumerable<Invoice> Get() {
        return _repository.Get();
    }

    public IEnumerable<Invoice> Get(InvoiceInputParameter parameter) {
        return _repository.Get(parameter);
    }

    public void Update(Invoice invoice) {
        _repository.Update(invoice);
    }

    public static void ValidateInvoiceDetails(IReadOnlyCollection<InvoiceDetail> invoiceDetails) {
        if (invoiceDetails.Count == 0) {
            throw new ArgumentException("Накладная не содержит товаров");
        }

        if (invoiceDetails.Any(x => x.Count <= 0)) {
            throw new ArgumentException($"Некорректное количество, значение <= 0");
        }
    }

    private static void ValidateStock(IEnumerable<(int ProductId, int Count)> grouped, IReadOnlyDictionary<int, Product> products) {
        foreach (var item in grouped) {
            if (!products.TryGetValue(item.ProductId, out var product)) {
                throw new InvalidOperationException($"Товар {item.ProductId} не найден");
            }

            if (product.Count < item.Count) {
                throw new InvalidOperationException($"Недостаточно остатка по товару {product.Name}: нужно {item.Count}, доступно {product.Count}");
            }
        }
    }
}