using iText.Kernel.Pdf;
using iText.Layout;
using SmartSaleApi.Application.Extensions;

namespace SmartSaleApi.Application.Factories;

internal static class DocumentFactory {
    public static Document Create(MemoryStream memoryStream) {
        var pdfWriter = new PdfWriter(memoryStream);
        var pdfDocument = new PdfDocument(pdfWriter);
        return new Document(pdfDocument).SetFont(PdfFontCustom.TimesNewRoman);
    }
}