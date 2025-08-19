namespace SmartSaleApi.Core.Interfaces.Services;

public interface IProductReportService {
    (string Name, MemoryStream MemoryStream) GetMemoryStream();
}