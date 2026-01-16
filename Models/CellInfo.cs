namespace SmartWMS.Models;

public class CellInfo
{
    public string CellCode { get; set; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
    public string Rack { get; set; } = string.Empty;
    public CellStatus Status { get; set; } = CellStatus.Empty;
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public bool IsLightLeak { get; set; }
    public string? MaterialName { get; set; }
    public string? MaterialId { get; set; }
    public bool IsRobotActive { get; set; }

    public bool IsTemperatureOptimal => Temperature >= 21 && Temperature <= 25;
    public bool IsHumidityOptimal => Humidity >= 40 && Humidity <= 50;
    public bool IsEnvironmentOk => IsTemperatureOptimal && IsHumidityOptimal && !IsLightLeak;
}

public enum CellStatus
{
    Empty,
    Occupied,
    Warning,
    RobotActive
}
