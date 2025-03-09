using System.Windows;
using System.Windows.Controls;
using BirdNet.Data.Entities;

namespace BirdNet.Controls;

public partial class SearchBox
{
    public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
        nameof(SearchText), typeof(string), typeof(SearchBox), new PropertyMetadata(default(string))
    );

    public static readonly DependencyProperty FilteredSpeciesListProperty = DependencyProperty.Register(
        nameof(FilteredSpeciesList), typeof(List<Species>), typeof(SearchBox),
        new PropertyMetadata(default(List<Species>))
    );

    public SearchBox()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string SearchText
    {
        get => (string)GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }

    public List<Species> FilteredSpeciesList
    {
        get => (List<Species>)GetValue(FilteredSpeciesListProperty);
        set => SetValue(FilteredSpeciesListProperty, value);
    }

    public event TextChangedEventHandler? SearchTextChanged;

    private void PartTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        SearchTextChanged?.Invoke(this, e);
    }
}