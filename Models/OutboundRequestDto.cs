namespace SmartWMS.Models;

public class OutboundRequestDto
{
    public int MaterialId { get; set; }
    public string CellCode { get; set; } = string.Empty;
    public int Qty { get; set; }
    public string? WorkerId { get; set; }
    public EnvironmentDataDto EnvData { get; set; } = new();
}
