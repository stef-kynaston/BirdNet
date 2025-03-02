using System.Windows;
using BirdNet.Services;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    private readonly BirdSearchService _birdSearchService;

    public string SearchQuery { get; set; }

    public MainWindowViewModel(BirdSearchService birdSearchService)
    {
        _birdSearchService = birdSearchService;
    }
}