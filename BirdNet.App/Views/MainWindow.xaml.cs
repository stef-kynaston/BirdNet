using BirdNet.ViewModels;
using Wpf.Ui.Appearance;

namespace BirdNet.Views;

public partial class MainWindow
{
    public MainWindow(MainWindowViewModel model)
    {
        InitializeComponent();
        DataContext = model;
        
        ApplicationThemeManager.Apply(this);
    }
}