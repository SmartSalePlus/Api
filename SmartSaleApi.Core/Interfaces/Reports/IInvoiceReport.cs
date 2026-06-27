namespace SmartSaleApi.Core.Interfaces.Reports;

public interface IInvoiceReport {
    (string Name, MemoryStream MemoryStream) GetMemoryStream(int invoiceId);
}
