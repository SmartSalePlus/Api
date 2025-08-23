namespace SmartSaleApi.Core.Interfaces.Services;

public interface IBuyerReportService {
    (string Name, MemoryStream MemoryStream) GetMemoryStream(int buyerId);
}