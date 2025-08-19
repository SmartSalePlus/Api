namespace SmartSaleApi.Core.Interfaces.Services;

public interface IInvoiceReportService {
    (string Name, MemoryStream MemoryStream) GetMemoryStream(int invoiceId);
}