namespace SmartSaleApi.DAL.Entities;

internal sealed class User {
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}