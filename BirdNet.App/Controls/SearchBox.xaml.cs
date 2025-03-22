using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BirdNet.Data.Entities;

namespace BirdNet.Controls;

public partial class SearchBox
{
    public static readonly DependencyProperty SelectedSpeciesProperty = DependencyProperty.Register(
        nameof(SelectedSpecies), typeof(Species), typeof(SearchBox), new PropertyMetadata(default(Species))
    );

    public static readonly DependencyProperty ItemsListProperty = DependencyProperty.Register(
        nameof(ItemsList), typeof(ObservableCollection<Species>), typeof(SearchBox),
        new PropertyMetadata(default(ObservableCollection<Species>))
    );

    public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
        nameof(SearchText), typeof(string), typeof(SearchBox), new PropertyMetadata(default(string))
    );

    public SearchBox()
    {
        InitializeComponent();
    }

    public ObservableCollection<Species> ItemsList
    {
        get => (ObservableCollection<Species>)GetValue(ItemsListProperty);
        set => SetValue(ItemsListProperty, value);
    }

    public string SearchText
    {
        get => (string)GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }

    public Species SelectedSpecies
    {
        get => (Species)GetValue(SelectedSpeciesProperty);

        set => SetValue(SelectedSpeciesProperty, value);
    }

    public event TextChangedEventHandler? SearchTextChanged;

    private void PartTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        SearchTextChanged?.Invoke(sender, e);
        PartPopup.IsOpen = ItemsList.Count > 0;
    }

    private void PartSuggestionsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (PartSuggestionsList.SelectedItem is not Species species) return;

        SelectedSpecies = species;
        SearchText = species.CommonNameSingle;
        PartPopup.IsOpen = false;
    }
}