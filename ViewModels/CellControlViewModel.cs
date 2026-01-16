using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartWMS.Models;

namespace SmartWMS.ViewModels;

public class CellControlViewModel : ViewModelBase
{
    private CellInfo _cell;
    private float _targetTemperature = 22.0f;
    private float _temperatureTolerance = 0.5f;
    private float _targetHumidity = 45.0f;
    private float _humidityTolerance = 2.0f;
    private bool _blockLight = true;

    public CellControlViewModel(CellInfo cell)
    {
        _cell = cell;
        AlertHistory = new ObservableCollection<AlertHistoryItem>();

        ApplyCommand = new RelayCommand(Apply);
        CancelCommand = new RelayCommand(Cancel);
        ResetCommand = new RelayCommand(Reset);

        LoadAlertHistory();
    }

    public CellInfo Cell
    {
        get => _cell;
        set => SetProperty(ref _cell, value);
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

    public bool BlockLight
    {
        get => _blockLight;
        set => SetProperty(ref _blockLight, value);
    }

    public float TemperatureDeviation => Cell.Temperature - TargetTemperature;
    public float HumidityDeviation => Cell.Humidity - TargetHumidity;

    public bool IsTemperatureWithinRange =>
        Math.Abs(TemperatureDeviation) <= TemperatureTolerance;

    public bool IsHumidityWithinRange =>
        Math.Abs(HumidityDeviation) <= HumidityTolerance;

    public ObservableCollection<AlertHistoryItem> AlertHistory { get; }

    public ICommand ApplyCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand ResetCommand { get; }

    public event Action? CloseRequested;
    public event Action? ApplyRequested;

    private void Apply()
    {
        ApplyRequested?.Invoke();
        CloseRequested?.Invoke();
    }

    private void Cancel()
    {
        CloseRequested?.Invoke();
    }

    private void Reset()
    {
        TargetTemperature = 22.0f;
        TemperatureTolerance = 0.5f;
        TargetHumidity = 45.0f;
        HumidityTolerance = 2.0f;
        BlockLight = true;
    }

    private void LoadAlertHistory()
    {
        AlertHistory.Clear();
        AlertHistory.Add(new AlertHistoryItem
        {
            Time = "10:42 AM",
            Event = "Humidity Spike",
            Value = "48%",
            Status = AlertStatus.Resolved
        });
        AlertHistory.Add(new AlertHistoryItem
        {
            Time = "08:15 AM",
            Event = "Temp Low",
            Value = "21.2°C",
            Status = AlertStatus.Resolved
        });
        AlertHistory.Add(new AlertHistoryItem
        {
            Time = "Yesterday",
            Event = "Maintenance",
            Value = "-",
            Status = AlertStatus.Log
        });
    }
}
