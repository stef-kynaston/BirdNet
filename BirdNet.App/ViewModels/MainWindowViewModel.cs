using System.Collections.ObjectModel;
using BirdNet.Data.Entities;
using BirdNet.Services;
using CommunityToolkit.Mvvm.Input;

namespace BirdNet.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
  private readonly BirdSearchService _birdSearchService;

  public string SearchQuery
  {
    get => field;
    set => SetField(ref field, value);
  }

  public ObservableCollection<string> SearchResults { get; set; } = [];

  public MainWindowViewModel()
  {  }

  public MainWindowViewModel(BirdSearchService birdSearchService)
  {
    _birdSearchService = birdSearchService;
  }

  [RelayCommand]
  public async Task SearchButtonClicked()
  {
    IEnumerable<Species> results = await _birdSearchService.SearchSpeciesByCommonNameAsync(SearchQuery);
    SearchResults.Clear();
    foreach (var result in results)
    {
      SearchResults.Add(result.ScientificName);
    }
  }
}