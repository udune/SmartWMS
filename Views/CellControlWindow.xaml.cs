using System.Windows;
using System.Windows.Input;
using SmartWMS.Models;
using SmartWMS.ViewModels;

namespace SmartWMS.Views;

public partial class CellControlWindow : Window
{
    public CellControlWindow(CellInfo cell)
    {
        InitializeComponent();

        var viewModel = new CellControlViewModel(cell);
        viewModel.CloseRequested += () => Close();
        DataContext = viewModel;
    }

    private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }
        else
        {
            DragMove();
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
