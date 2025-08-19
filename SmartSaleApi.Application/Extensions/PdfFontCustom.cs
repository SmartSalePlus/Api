using iText.IO.Font;
using iText.Kernel.Font;
using System.Reflection;

namespace SmartSaleApi.Application.Extensions;

internal static class PdfFontCustom {
    public static PdfFont TimesNewRoman => CreateFont(TIMES_NEW_ROMAN);
    public static PdfFont TimesNewRomanBold => CreateFont(TIMES_NEW_ROMAN_BOLD);

    private const string TIMES_NEW_ROMAN = "times";
    private const string TIMES_NEW_ROMAN_BOLD = "timesbd";

    private static string GetPath(string name) {
        return Path.Combine(Directory.GetCurrentDirectory(), "Fonts", name);
    }

    private static PdfFont CreateFont(string name) {
        string resourceName = $"SmartSaleApi.Application.Fonts.{name}.ttf";
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream(resourceName) 
            ?? throw new FileNotFoundException($"Шрифт {resourceName} не найден.");

        var bytes = new byte[stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);

        return PdfFontFactory.CreateFont(bytes, PdfEncodings.IDENTITY_H);
    }
}