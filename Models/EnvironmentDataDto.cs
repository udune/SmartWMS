namespace SmartWMS.Models;

public class EnvironmentDataDto
{
    public float CurrentTemp { get; set; }
    public float CurrentHumid { get; set; }
    public bool IsLightLeak { get; set; }
}
