using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using SmartWMS.Models;

namespace SmartWMS.Views;

public partial class RegisterMaterialWindow : Window
{
    public MaterialResponseDto? RegisteredMaterial { get; private set; }

    public RegisterMaterialWindow()
    {
        InitializeComponent();

        // Setup placeholder visibility handlers
        MaterialNameTextBox.TextChanged += (s, e) =>
            MaterialNamePlaceholder.Visibility = string.IsNullOrEmpty(MaterialNameTextBox.Text)
                ? Visibility.Visible : Visibility.Collapsed;

        VendorTextBox.TextChanged += (s, e) =>
            VendorPlaceholder.Visibility = string.IsNullOrEmpty(VendorTextBox.Text)
                ? Visibility.Visible : Visibility.Collapsed;

        LotIdTextBox.TextChanged += (s, e) =>
            LotIdPlaceholder.Visibility = string.IsNullOrEmpty(LotIdTextBox.Text)
                ? Visibility.Visible : Visibility.Collapsed;

        QuantityTextBox.TextChanged += (s, e) =>
            QuantityPlaceholder.Visibility = string.IsNullOrEmpty(QuantityTextBox.Text)
                ? Visibility.Visible : Visibility.Collapsed;

        // Allow dragging the window
        MouseLeftButtonDown += (s, e) =>
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        };
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(MaterialNameTextBox.Text))
        {
            MessageBox.Show("Please enter a material name.", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            MaterialNameTextBox.Focus();
            return;
        }

        if (TypeComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a material type.", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            TypeComboBox.Focus();
            return;
        }

        // Parse quantity
        int quantity = 0;
        if (!string.IsNullOrWhiteSpace(QuantityTextBox.Text))
        {
            if (!int.TryParse(QuantityTextBox.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                QuantityTextBox.Focus();
                return;
            }
        }

        // Get type from ComboBox
        var selectedType = (TypeComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content?.ToString() ?? "";
        var typeValue = selectedType switch
        {
            "Raw Material" => "PR",
            "Finished Good" => "Thinner",
            "Packaging" => "Developer",
            "Electronic Component" => "Component",
            _ => selectedType
        };

        // Create material DTO
        RegisteredMaterial = new MaterialResponseDto
        {
            Id = string.Empty, // Server will assign
            Name = MaterialNameTextBox.Text.Trim(),
            Vendor = string.IsNullOrWhiteSpace(VendorTextBox.Text) ? null : VendorTextBox.Text.Trim(),
            LotId = string.IsNullOrWhiteSpace(LotIdTextBox.Text) ? null : LotIdTextBox.Text.Trim(),
            Type = typeValue,
            StockQty = quantity,
            ExpiryDate = ExpiryDatePicker.SelectedDate
        };

        DialogResult = true;
        Close();
    }

    private void QuantityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        // Only allow numeric input
        e.Handled = !IsTextNumeric(e.Text);
    }

    private static bool IsTextNumeric(string text)
    {
        return Regex.IsMatch(text, "^[0-9]+$");
    }
}