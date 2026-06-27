namespace SmartSaleApi.Core.Interfaces.Reports;

public interface IProductReport {
    (string Name, MemoryStream MemoryStream) GetMemoryStream();
}
