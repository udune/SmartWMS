namespace SmartWMS.Models;

public class AlertHistoryItem
{
    public string Time { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public AlertStatus Status { get; set; } = AlertStatus.Resolved;
}

public enum AlertStatus
{
    Resolved,
    Active,
    Log
}
