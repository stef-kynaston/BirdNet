using System.Windows.Controls;
using System.Windows.Navigation;
using BirdNet.ViewModels;

namespace BirdNet.Views;

public partial class SearchPage : UserControl
{
    public SearchPage(SearchPageViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}