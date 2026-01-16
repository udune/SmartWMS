namespace SmartWMS.Models;

public class InboundRequestDto
{
    public int MaterialId { get; set; }
    public string CellCode { get; set; } = string.Empty;
    public int Qty { get; set; }
    public string? WorkerId { get; set; }
}
