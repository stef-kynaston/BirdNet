using System.Windows;
using System.Windows.Controls;
using BirdNet.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace BirdNet.Views;

public partial class MainWindow : INavigationWindow
{
    public MainWindow(MainWindowViewModel model, INavigationService navigationService)
    {
        InitializeComponent();

        // Set up the data context using the viewmodel
        DataContext = model;

        navigationService.SetNavigationControl(RootNavigation);
    }

    // ReSharper disable once AsyncVoidMethod
    private async void SearchBox_OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        if (DataContext is MainWindowViewModel model) await model.SearchByCommonNameAsync();

        e.Handled = true;
    }

    public INavigationView GetNavigation() => RootNavigation;

    public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

    public void SetPageService(INavigationViewPageProvider navigationViewPageProvider) =>
        RootNavigation.SetPageProviderService(navigationViewPageProvider);

    public void ShowWindow() => Show();

    public void CloseWindow() => Close();

    /// <summary>
    /// Raises the closed event.
    /// </summary>
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        // Make sure that closing this window will begin the process of closing the application.
        Application.Current.Shutdown();
    }

    INavigationView INavigationWindow.GetNavigation()
    {
        throw new NotImplementedException();
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }
}