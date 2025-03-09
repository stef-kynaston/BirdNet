using BirdNet.Data.Entities;
using BirdNet.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly BirdSearchService _birdSearchService;

    #region Properties

    [ObservableProperty]
    public partial List<Species> BirdList { get; set; } = [];

    [ObservableProperty]
    public partial Species SelectedBird { get; set; } = new Species
    {
        ScientificName = "Erithacus rubecula",
        CommonNameSingle = "European Robin",
        Description =
            "The European robin (Erithacus rubecula) is a small insectivorous passerine bird that was formerly classed as a member of the thrush family (Turdidae), but is now considered to be an Old World flycatcher. About 12.5–14.0 cm (5.0–5.5 inches) in length",
        OccurrenceCount = 5000000,
        Habitats = "Woodland, gardens, parks"
    };

    [ObservableProperty]
    public partial string SearchText { get; set; } = string.Empty;

    #endregion


    #region Constructors

    /// <summary>
    /// Constructor for design-time - unused at runtime
    /// </summary>
    public MainWindowViewModel() : this(null!)
    {
    }

    public MainWindowViewModel(BirdSearchService birdSearchService)
    {
        _birdSearchService = birdSearchService;
    }

    #endregion
}