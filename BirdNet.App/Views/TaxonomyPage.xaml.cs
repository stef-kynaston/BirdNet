using System.Windows.Controls;
using BirdNet.ViewModels;

namespace BirdNet.Views;

public partial class TaxonomyPage : UserControl
{
    public TaxonomyPage(TaxonomyPageViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}