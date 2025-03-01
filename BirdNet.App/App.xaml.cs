using System.Configuration;
using System.Data;
using System.Windows;

namespace BirdNet;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    IServiceProvider _serviceProvider;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection services = new ServiceCollection();
        
        base.OnStartup(e);
    }
}

public class ServiceCollection
{
}