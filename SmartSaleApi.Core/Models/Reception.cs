namespace SmartSaleApi.Core.Models;

public sealed class Reception {
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
}
