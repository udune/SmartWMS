using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using SmartWMS.Models;
using SmartWMS.Services;

namespace SmartWMS.ViewModels;

public class MaterialsViewModel : ViewModelBase
{
    private readonly ApiService _apiService;
    private string _searchText = string.Empty;
    private string _selectedType = "";
    private MaterialResponseDto? _selectedMaterial;
    private bool _isLoading;
    private List<MaterialResponseDto> _allMaterials = new();

    public MaterialsViewModel()
    {
        _apiService = new ApiService();
        Materials = new ObservableCollection<MaterialResponseDto>();
        MaterialTypes = new ObservableCollection<string> { "", "PR", "Thinner", "Developer" };

        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedMaterial != null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedMaterial != null);
        RefreshCommand = new RelayCommand(async () => await LoadMaterialsAsync());

        _ = LoadMaterialsAsync();
    }

    public ObservableCollection<MaterialResponseDto> Materials { get; }
    public ObservableCollection<string> MaterialTypes { get; }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                FilterMaterials();
            }
        }
    }

    public string SelectedType
    {
        get => _selectedType;
        set
        {
            if (SetProperty(ref _selectedType, value))
            {
                FilterMaterials();
            }
        }
    }

    public MaterialResponseDto? SelectedMaterial
    {
        get => _selectedMaterial;
        set => SetProperty(ref _selectedMaterial, value);
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand RefreshCommand { get; }

    private async Task LoadMaterialsAsync()
    {
        try
        {
            IsLoading = true;
            _allMaterials = await _apiService.GetMaterialsAsync();
            FilterMaterials();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Failed to connect to server.\n\nPlease check if the API server is running at http://localhost:5109\n\nError: {ex.Message}",
                "Connection Error",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"An error occurred while loading materials.\n\nError: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void FilterMaterials()
    {
        var filtered = _allMaterials.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var search = SearchText.ToLower();
            filtered = filtered.Where(m =>
                m.Id.ToLower().Contains(search) ||
                m.Name.ToLower().Contains(search) ||
                (m.LotId?.ToLower().Contains(search) ?? false) ||
                (m.Vendor?.ToLower().Contains(search) ?? false));
        }

        if (!string.IsNullOrWhiteSpace(SelectedType))
        {
            filtered = filtered.Where(m => m.Type == SelectedType);
        }

        Materials.Clear();
        foreach (var material in filtered)
        {
            Materials.Add(material);
        }
    }

    private void Add()
    {
        // TODO: Open add material dialog
    }

    private void Edit()
    {
        // TODO: Open edit material dialog
    }

    private async void Delete()
    {
        if (SelectedMaterial == null) return;

        var result = MessageBox.Show(
            $"Are you sure you want to delete '{SelectedMaterial.Name}'?",
            "Confirm Delete",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result != MessageBoxResult.Yes) return;

        try
        {
            var success = await _apiService.DeleteMaterialAsync(SelectedMaterial.Id);
            if (success)
            {
                _allMaterials.Remove(SelectedMaterial);
                Materials.Remove(SelectedMaterial);
                SelectedMaterial = null;
            }
            else
            {
                MessageBox.Show(
                    "Failed to delete the material.",
                    "Delete Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"An error occurred while deleting the material.\n\nError: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}