using System.Windows.Controls;
using BirdNet.ViewModels;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace BirdNet.Views;

public partial class MainWindow
{
    public MainWindow(MainWindowViewModel model)
    {
        InitializeComponent();

        // Set up the data context using the viewmodel
        DataContext = model;

        // Apply the dark theme
        ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Acrylic, false);
    }

    // ReSharper disable once AsyncVoidMethod
    private async void SearchBox_OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        if (DataContext is MainWindowViewModel model) await model.SearchByCommonNameAsync();

        e.Handled = true;
    }
}