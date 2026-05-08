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
        var grouped = GetGroupedInvoiceDetails(invoice.InvoiceDetails);
        var products = GetProductsMap(grouped);
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
        var invoice = _repository.Get(id);
        var grouped = GetGroupedInvoiceDetails(invoice.InvoiceDetails);
        var products = GetProductsMap(grouped);

        foreach (var item in grouped) {
            if (!products.TryGetValue(item.ProductId, out var product)) {
                throw new InvalidOperationException($"Товар {item.ProductId} не найден");
            }

            product.Count += item.Count;
            _productService.Update(product);
        }

        _repository.Delete(id);
        _unitOfWork.SaveChanges();
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

    public static void ValidateInvoiceDetails(IReadOnlyCollection<InvoiceDetail> invoiceDetails) {
        if (invoiceDetails.Count == 0) {
            throw new ArgumentException("Накладная не содержит товаров");
        }

        if (invoiceDetails.Any(x => x.Count <= 0)) {
            throw new ArgumentException("Некорректное количество, значение <= 0");
        }
    }

    private IReadOnlyDictionary<int, Product> GetProductsMap(IEnumerable<(int ProductId, int Count)> grouped) {
        return _productService.Get(grouped.Select(x => x.ProductId).ToArray())
            .ToDictionary(p => p.Id);
    }

    private static List<(int ProductId, int Count)> GetGroupedInvoiceDetails(IEnumerable<InvoiceDetail> detailsSource) {
        var details = detailsSource.ToList();
        ValidateInvoiceDetails(details);

        return details
            .GroupBy(d => d.ProductId)
            .Select(g => (ProductId: g.Key, Count: g.Sum(x => x.Count)))
            .ToList();
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
