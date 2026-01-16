using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartWMS.Models;

namespace SmartWMS.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    private string _searchText = string.Empty;
    private string _selectedZone = "All Zones";
    private CellInfo? _selectedCell;
    private bool _isConnected = true;
    private bool _isGridView = true;

    public DashboardViewModel()
    {
        Cells = new ObservableCollection<CellInfo>();
        Zones = new ObservableCollection<string> { "All Zones", "Zone A (Wafer)", "Zone B (Chemical)" };

        RefreshCommand = new RelayCommand(Refresh);
        SelectCellCommand = new RelayCommand(SelectCell);
        OpenControlCommand = new RelayCommand(OpenControl);
        SwitchToGridViewCommand = new RelayCommand(() => IsGridView = true);
        SwitchToListViewCommand = new RelayCommand(() => IsGridView = false);

        LoadSampleData();
    }

    public ObservableCollection<CellInfo> Cells { get; }
    public ObservableCollection<string> Zones { get; }

    public string SearchText
    {
        get => _searchText;
        set => SetProperty(ref _searchText, value);
    }

    public string SelectedZone
    {
        get => _selectedZone;
        set => SetProperty(ref _selectedZone, value);
    }

    public CellInfo? SelectedCell
    {
        get => _selectedCell;
        set => SetProperty(ref _selectedCell, value);
    }

    public bool IsConnected
    {
        get => _isConnected;
        set => SetProperty(ref _isConnected, value);
    }

    public bool IsGridView
    {
        get => _isGridView;
        set
        {
            if (SetProperty(ref _isGridView, value))
            {
                OnPropertyChanged(nameof(IsListView));
            }
        }
    }

    public bool IsListView => !IsGridView;

    public ICommand RefreshCommand { get; }
    public ICommand SelectCellCommand { get; }
    public ICommand OpenControlCommand { get; }
    public ICommand SwitchToGridViewCommand { get; }
    public ICommand SwitchToListViewCommand { get; }

    public event Action<CellInfo>? OpenControlRequested;

    private void Refresh()
    {
        LoadSampleData();
    }

    private void SelectCell(object? parameter)
    {
        if (parameter is CellInfo cell)
        {
            SelectedCell = cell;
        }
    }

    private void OpenControl(object? parameter)
    {
        if (parameter is CellInfo cell)
        {
            OpenControlRequested?.Invoke(cell);
        }
    }

    private void LoadSampleData()
    {
        Cells.Clear();

        Cells.Add(new CellInfo
        {
            CellCode = "A01",
            Zone = "Zone A",
            Rack = "Rack 1",
            Status = CellStatus.Occupied,
            Temperature = 23.0f,
            Humidity = 45.0f,
            IsLightLeak = false,
            MaterialName = "Silicon Wafer 300mm",
            MaterialId = "MAT-00124"
        });

        Cells.Add(new CellInfo
        {
            CellCode = "A02",
            Zone = "Zone A",
            Rack = "Rack 1",
            Status = CellStatus.Warning,
            Temperature = 26.5f,
            Humidity = 48.0f,
            IsLightLeak = false,
            MaterialName = "Photoresist PR-500",
            MaterialId = "CHE-08921"
        });

        Cells.Add(new CellInfo
        {
            CellCode = "B01",
            Zone = "Zone B",
            Rack = "Rack 1",
            Status = CellStatus.RobotActive,
            Temperature = 22.0f,
            Humidity = 42.0f,
            IsLightLeak = false,
            MaterialName = "Assembly Kit Z-10",
            MaterialId = "ASM-00512",
            IsRobotActive = true
        });

        Cells.Add(new CellInfo
        {
            CellCode = "B02",
            Zone = "Zone B",
            Rack = "Rack 1",
            Status = CellStatus.Empty,
            Temperature = 21.0f,
            Humidity = 40.0f,
            IsLightLeak = false
        });

        Cells.Add(new CellInfo
        {
            CellCode = "A03",
            Zone = "Zone A",
            Rack = "Rack 2",
            Status = CellStatus.Occupied,
            Temperature = 24.0f,
            Humidity = 44.0f,
            IsLightLeak = false,
            MaterialName = "Developer NMD-3",
            MaterialId = "DEV-00331"
        });

        Cells.Add(new CellInfo
        {
            CellCode = "A04",
            Zone = "Zone A",
            Rack = "Rack 2",
            Status = CellStatus.Occupied,
            Temperature = 23.5f,
            Humidity = 46.0f,
            IsLightLeak = false,
            MaterialName = "Thinner OK-73",
            MaterialId = "THN-00892"
        });
    }
}
