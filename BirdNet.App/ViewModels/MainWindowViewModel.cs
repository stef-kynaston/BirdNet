using System.Collections.ObjectModel;
using System.IO;
using BirdNet.Data.Entities;
using BirdNet.Services;
using BirdNet.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private string _imageBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
    private readonly BirdSearchService _birdSearchService;
    private bool _isInitialized;

    #region Properties

    [ObservableProperty]
    public partial ObservableCollection<Species> BirdList { get; set; } = [];

    [ObservableProperty]
    public partial Species? SelectedBird { get; set; }

    [ObservableProperty]
    public partial string QueryText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<object> NavigationItems { get; set; } = [];

    public string ImagePath => Path.Combine(_imageBasePath, SelectedBird?.ScientificName ?? string.Empty, "0.jpg");

    public string MapPath =>
        Path.Combine(_imageBasePath, "Maps", (SelectedBird?.ScientificName ?? string.Empty) + ".png");

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor for design-time - unused at runtime
    /// </summary>
    public MainWindowViewModel() : this(null!, null!)
    {
    }

    /// <inheritdoc/>
    public MainWindowViewModel(BirdSearchService birdSearchService, INavigationService navigationService)
    {
        _birdSearchService = birdSearchService;
        
        if (!_isInitialized)
        {

        }
    }

    #endregion

    #region Methods

    partial void OnSelectedBirdChanged(Species? oldValue, Species? newValue)
    {
        OnPropertyChanged(nameof(ImagePath));
        OnPropertyChanged(nameof(MapPath));
    }

    public async Task SearchByCommonNameAsync()
    {
        BirdList = new ObservableCollection<Species>(
            await _birdSearchService.SearchSpeciesByCommonNameAsync(QueryText)
        );
    }

    public async Task SearchByScientificNameAsync()
    {
        BirdList = new ObservableCollection<Species>(
            await _birdSearchService.SearchSpeciesByScientificNameAsync(QueryText)
        );
    }

    #endregion
}