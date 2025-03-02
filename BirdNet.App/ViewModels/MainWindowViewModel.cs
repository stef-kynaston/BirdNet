using System.Windows.Controls;
using BirdNet.Services;
using BirdNet.Views;
using CommunityToolkit.Mvvm.Input;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    private readonly BirdSearchService _birdSearchService;
    
    public MainWindowViewModel(BirdSearchService birdSearchService)
    {
        _birdSearchService = birdSearchService;
    }

    public UserControl CurrentPage { get; }
}