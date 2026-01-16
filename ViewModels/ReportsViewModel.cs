namespace SmartWMS.ViewModels;

public class ReportsViewModel : ViewModelBase
{
    private int _totalMaterials = 128;
    private int _inboundToday = 24;
    private int _outboundToday = 18;
    private int _lowStockAlerts = 5;

    public int TotalMaterials
    {
        get => _totalMaterials;
        set => SetProperty(ref _totalMaterials, value);
    }

    public int InboundToday
    {
        get => _inboundToday;
        set => SetProperty(ref _inboundToday, value);
    }

    public int OutboundToday
    {
        get => _outboundToday;
        set => SetProperty(ref _outboundToday, value);
    }

    public int LowStockAlerts
    {
        get => _lowStockAlerts;
        set => SetProperty(ref _lowStockAlerts, value);
    }
}
