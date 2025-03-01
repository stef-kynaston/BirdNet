using System.Windows.Controls;
using BirdNet.Views;
using CommunityToolkit.Mvvm.Input;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    public MainWindowViewModel()
    {
    }

    public UserControl CurrentPage { get; }
}