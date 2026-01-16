using System.Windows.Input;
using SmartWMS.Models;

namespace SmartWMS.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    private float _targetTemperature = 23.0f;
    private float _temperatureTolerance = 2.0f;
    private float _targetHumidity = 45.0f;
    private float _humidityTolerance = 5.0f;
    private bool _allowLight = false;
    private string _serverUrl = "http://localhost:5109";

    public SettingsViewModel()
    {
        SaveCommand = new RelayCommand(Save);
        ResetCommand = new RelayCommand(Reset);
    }

    public float TargetTemperature
    {
        get => _targetTemperature;
        set => SetProperty(ref _targetTemperature, value);
    }

    public float TemperatureTolerance
    {
        get => _temperatureTolerance;
        set => SetProperty(ref _temperatureTolerance, value);
    }

    public float TargetHumidity
    {
        get => _targetHumidity;
        set => SetProperty(ref _targetHumidity, value);
    }

    public float HumidityTolerance
    {
        get => _humidityTolerance;
        set => SetProperty(ref _humidityTolerance, value);
    }

    public bool AllowLight
    {
        get => _allowLight;
        set => SetProperty(ref _allowLight, value);
    }

    public string ServerUrl
    {
        get => _serverUrl;
        set => SetProperty(ref _serverUrl, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand ResetCommand { get; }

    private void Save()
    {
        // TODO: Save settings to API
    }

    private void Reset()
    {
        TargetTemperature = 23.0f;
        TemperatureTolerance = 2.0f;
        TargetHumidity = 45.0f;
        HumidityTolerance = 5.0f;
        AllowLight = false;
    }
}
