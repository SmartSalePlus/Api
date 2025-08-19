using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Application.Extensions;
using SmartSaleApi.Application.Factories;

namespace SmartSaleApi.Application.Services;

public sealed class InvoicePdfService : IInvoiceReportService {
    private readonly IInvoiceService _invoiceService;
    private readonly IProductService _productService;
    private readonly IBuyerService _buyerService;

    public InvoicePdfService(IInvoiceService invoiceService, IProductService productService, IBuyerService buyerService) {
        _invoiceService = invoiceService;
        _productService = productService;
        _buyerService = buyerService;
    }

    public (string Name, MemoryStream MemoryStream) GetMemoryStream(int invoiceId) {
        var invoice = _invoiceService.Get(invoiceId);
        var buyer = _buyerService.Get(invoice.BuyerId);
        var products = _productService.Get(invoice.InvoiceDetails.Select(x => x.ProductId).ToArray());

        var name = $"Накладная_{buyer.Name}_{invoice.Date}.pdf";

        var memoryStream = new MemoryStream();
        var document = DocumentFactory.Create(memoryStream);

        document.Add(new Paragraph($"Дата: {invoice.Date:dd.MM.yyyy}"));
        document.Add(new Paragraph("НАКЛАДНАЯ")
            .SetFontSize(14)
            .SetFont(PdfFontCustom.TimesNewRomanBold)
            .SetTextAlignment(TextAlignment.CENTER));

        document.Add(new Paragraph($"Кому: {buyer.Name}"));

        var table = new Table(UnitValue.CreatePercentArray([10f, 50, 12f, 12f, 16]))
            .SetWidth(UnitValue.CreatePercentValue(100));

        table.AddCell(new Paragraph("№ п/п")
            .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Наименование")
            .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Кол-во")
            .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Цена")
            .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Сумма")
            .SetTextAlignment(TextAlignment.CENTER));

        int number = 1;
        foreach (var invoiceDetail in invoice.InvoiceDetails) {
            var product = products.First(x => x.Id == invoiceDetail.ProductId);
            string count = product.CountInPackage > 1 ? $"{invoiceDetail.Count}/{product.CountInPackage}" : invoiceDetail.Count.ToString();

            table.AddCell(number.ToString());
            table.AddCell(product.Name.ToString());
            table.AddCell(count);
            table.AddCell(invoiceDetail.Price.ToString());
            table.AddCell(invoiceDetail.Total.ToString("N0"));

            number++;
        }

        document.Add(table);

        document.Add(new Paragraph($"Итого: {invoice.Total:N0}"));
        if (invoice.Discount > 0) {
            document.Add(new Paragraph($"Скидка: {invoice.Discount:N0}"));
            document.Add(new Paragraph($"Итого со скидкой: {invoice.TotalWithDiscount:N0}"));
        }

        document.Close();
        return (name, new(memoryStream.ToArray()));
    }
}