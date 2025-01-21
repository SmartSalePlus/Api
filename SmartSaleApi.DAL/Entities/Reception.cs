namespace SmartSaleApi.DAL.Entities;

internal sealed class Reception {
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
}