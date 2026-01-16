using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartWMS.ViewModels;

namespace SmartWMS.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        Loaded += DashboardView_Loaded;
    }

    private void DashboardView_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is DashboardViewModel viewModel)
        {
            viewModel.OpenControlRequested += ViewModel_OpenControlRequested;
        }
    }

    private void ViewModel_OpenControlRequested(Models.CellInfo cell)
    {
        var controlWindow = new CellControlWindow(cell);
        controlWindow.Owner = Window.GetWindow(this);
        controlWindow.ShowDialog();
    }
}

public class PercentConverter : IValueConverter
{
    public static PercentConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is float temp)
        {
            // Temperature range: 15-35°C maps to 0-200px
            var percent = (temp - 15) / 20.0 * 200;
            return Math.Clamp(percent, 0, 200);
        }
        return 100;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class HumidityPercentConverter : IValueConverter
{
    public static HumidityPercentConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is float humidity)
        {
            // Humidity range: 0-100% maps to 0-200px
            return humidity / 100.0 * 200;
        }
        return 100;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class PercentConverterSmall : IValueConverter
{
    public static PercentConverterSmall Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is float temp)
        {
            // Temperature range: 15-35°C maps to 0-80px (smaller for list view)
            var percent = (temp - 15) / 20.0 * 80;
            return Math.Clamp(percent, 0, 80);
        }
        return 40;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class HumidityPercentConverterSmall : IValueConverter
{
    public static HumidityPercentConverterSmall Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is float humidity)
        {
            // Humidity range: 0-100% maps to 0-80px (smaller for list view)
            return humidity / 100.0 * 80;
        }
        return 40;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
