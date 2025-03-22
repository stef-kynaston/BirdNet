using System.Collections.ObjectModel;
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

    #region Constructors

    /// <summary>
    /// Constructor for design-time - unused at runtime
    /// </summary>
    public MainWindowViewModel() : this(null!)
    {
    }

    #endregion

    #region Methods

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

    #region Properties

    [ObservableProperty]
    public partial ObservableCollection<Species> BirdList { get; set; } = [];

    [ObservableProperty]
    public partial Species SelectedBird { get; set; } = null!;

    [ObservableProperty]
    public partial string QueryText { get; set; } = string.Empty;

    #endregion
}