namespace SmartSaleApi.DAL.Entities;

internal sealed class Reception {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public ICollection<ReceptionDetail> ReceptionDetails { get; set; } = [];
}