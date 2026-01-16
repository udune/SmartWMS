namespace SmartWMS.Models;

public class MaterialResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Vendor { get; set; }
    public string? LotId { get; set; }
    public string? Type { get; set; }
    public int StockQty { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public DateTime CreatedAt { get; set; }

    public bool IsExpired => ExpiryDate.HasValue && ExpiryDate.Value < DateTime.Now;
    public bool IsExpiringSoon => ExpiryDate.HasValue &&
        ExpiryDate.Value > DateTime.Now &&
        ExpiryDate.Value < DateTime.Now.AddDays(30);
}
