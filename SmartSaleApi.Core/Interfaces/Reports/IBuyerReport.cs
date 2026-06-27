namespace SmartSaleApi.Core.Interfaces.Reports;

public interface IBuyerReport {
    (string Name, MemoryStream MemoryStream) GetMemoryStream(int buyerId);
}
