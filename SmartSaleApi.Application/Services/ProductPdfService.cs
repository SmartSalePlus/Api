using iText.Layout.Element;
using iText.Layout.Properties;
using SmartSaleApi.Application.Extensions;
using SmartSaleApi.Application.Factories;
using SmartSaleApi.Core.Interfaces.Services;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.Application.Services;

public sealed class ProductPdfService : IProductReportService {
    private readonly IProductService _productService;

    public ProductPdfService(IProductService productService) {
        _productService = productService;
    }

    public (string Name, MemoryStream MemoryStream) GetMemoryStream() {
        var products = _productService.Get();

        var date = DateTime.Now.ToString("dd.MM.yyyy");
        var name = $"Прайс_на_{date}.pdf";

        var memoryStream = new MemoryStream();
        var document = DocumentFactory.Create(memoryStream);

        document.Add(new Paragraph($"Дата: {date}"));
        document.Add(new Paragraph("ПРАЙС")
            .SetFontSize(14)
            .SetFont(PdfFontCustom.TimesNewRomanBold)
            .SetTextAlignment(TextAlignment.CENTER));

        var table = new Table(UnitValue.CreatePercentArray([10f, 70, 15f]))
            .SetWidth(UnitValue.CreatePercentValue(100));

        table.AddCell(new Paragraph("№ п/п")
           .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Наименование")
            .SetTextAlignment(TextAlignment.CENTER));

        table.AddCell(new Paragraph("Цена")
            .SetTextAlignment(TextAlignment.CENTER));

        int number = 1;
        foreach (var product in products) {
            table.AddCell(number.ToString());
            table.AddCell(GetProductName(product));
            table.AddCell(product.Price.ToString());

            number++;
        }

        document.Add(table);

        document.Close();
        return (name, new(memoryStream.ToArray()));
    }

    private string GetProductName(Product product) {
        return product.CountInPackage > 1 ? $"{product.Name} ({product.CountInPackage})" : product.Name;
    }
}