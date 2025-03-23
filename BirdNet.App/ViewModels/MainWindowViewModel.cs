using System.Collections.ObjectModel;
using System.IO;
using BirdNet.Data.Entities;
using BirdNet.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel(BirdSearchService birdSearchService) : ObservableObject
{
    // Explicitly defined constructor
    // private readonly BirdSearchService _birdSearchService;
    //
    // public MainWindowViewModel(BirdSearchService birdSearchService)
    // {
    //     _birdSearchService = birdSearchService;
    // }

    private string _imageBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

    #region Constructors

    /// <summary>
    /// Constructor for design-time - unused at runtime
    /// </summary>
    public MainWindowViewModel() : this(null!)
    {
    }

    #endregion

    #region Properties

    [ObservableProperty]
    public partial ObservableCollection<Species> BirdList { get; set; } = [];

    [ObservableProperty]
    public partial Species? SelectedBird { get; set; }

    [ObservableProperty]
    public partial string QueryText { get; set; } = string.Empty;

    public string ImagePath => Path.Combine(_imageBasePath, SelectedBird?.ScientificName ?? string.Empty, "0.jpg");

    #endregion

    #region Methods
    
    partial void OnSelectedBirdChanged(Species? oldValue, Species? newValue)
    {
       OnPropertyChanged(nameof(ImagePath)); 
    }

    public async Task SearchByCommonNameAsync()
    {
        BirdList = new ObservableCollection<Species>(await birdSearchService.SearchSpeciesByCommonNameAsync(QueryText));
    }

    public async Task SearchByScientificNameAsync()
    {
        BirdList = new ObservableCollection<Species>(
            await birdSearchService.SearchSpeciesByScientificNameAsync(QueryText)
        );
    }

    #endregion
}