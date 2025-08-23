using iText.Layout.Element;
using iText.Layout.Properties;
using SmartSaleApi.Application.Extensions;
using SmartSaleApi.Application.Factories;
using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Interfaces.Services;

namespace SmartSaleApi.Application.Services;

public sealed class BuyerPdfService : IBuyerReportService {
    private readonly IBuyerService _buyerService;
    private readonly IInvoiceService _invoiceService;

    public BuyerPdfService(IBuyerService buyerService, IInvoiceService invoiceService) {
        _buyerService = buyerService;
        _invoiceService = invoiceService;
    }

    public (string Name, MemoryStream MemoryStream) GetMemoryStream(int buyerId) {
        var buyer = _buyerService.Get(buyerId);
        var parameter = new InvoiceInputParameter(DateOnly.MinValue, DateOnly.MaxValue, buyerId, false);
        var invoices = _invoiceService.Get(parameter);

        var date = DateTime.Now.ToString("dd.MM.yyyy");
        var name = $"{buyer.Name}_{date}.pdf";

        var memoryStream = new MemoryStream();
        var document = DocumentFactory.Create(memoryStream);

        document.Add(new Paragraph($"Дата: {date}"));
        document.Add(new Paragraph($"{buyer.Name} долги")
            .SetFontSize(14)
            .SetFont(PdfFontCustom.TimesNewRomanBold)
            .SetTextAlignment(TextAlignment.CENTER));

        foreach(var invoice in invoices) {
            document.Add(new Paragraph($"{invoice.Date:dd.MM.yyyy} - {invoice.TotalWithDiscount:N0}"));
        }

        document.Close();
        return (name, new(memoryStream.ToArray()));
    }
}