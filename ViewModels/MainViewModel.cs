using System.Windows.Input;

namespace SmartWMS.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;
    private string _currentView = "Dashboard";

    public MainViewModel()
    {
        DashboardViewModel = new DashboardViewModel();
        MaterialsViewModel = new MaterialsViewModel();
        ReportsViewModel = new ReportsViewModel();
        SettingsViewModel = new SettingsViewModel();

        _currentViewModel = DashboardViewModel;

        NavigateCommand = new RelayCommand(Navigate);
    }

    public DashboardViewModel DashboardViewModel { get; }
    public MaterialsViewModel MaterialsViewModel { get; }
    public ReportsViewModel ReportsViewModel { get; }
    public SettingsViewModel SettingsViewModel { get; }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public string CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    public ICommand NavigateCommand { get; }

    private void Navigate(object? parameter)
    {
        if (parameter is not string viewName) return;

        CurrentView = viewName;
        CurrentViewModel = viewName switch
        {
            "Dashboard" => DashboardViewModel,
            "Inventory" => MaterialsViewModel,
            "Reports" => ReportsViewModel,
            "Settings" => SettingsViewModel,
            _ => DashboardViewModel
        };
    }
}
