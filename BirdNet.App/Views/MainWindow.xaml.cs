using BirdNet.ViewModels;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace BirdNet.Views;

public partial class MainWindow
{
    private readonly MainWindowViewModel _model;

    public MainWindow(MainWindowViewModel model)
    {
        InitializeComponent();
        _model = model;
        DataContext = _model;

        ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Acrylic, updateAccent: false);
    }

    private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        args.Handled = true;
        string query = args.Text;

        if (query.Length >= 3)
        {
            _ = _model.SearchByQuery(args.Text);
        }
    }
}