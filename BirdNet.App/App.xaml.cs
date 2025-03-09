using System.Windows;
using BirdNet.Data.Repositories;
using BirdNet.Services;
using BirdNet.ViewModels;
using BirdNet.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BirdNet;

public partial class App
{
    private IHost? _host;

    // ReSharper disable once AsyncVoidMethod
    protected override async void OnStartup(StartupEventArgs e)
    {
        _host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureLogging(
                logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Warning);
                    logging.AddConsole(Console.WriteLine);
                }
            )
            .ConfigureServices(
                (_, services) =>
                {
                    services.AddDbContext<AppDbContext>(
                        options => { options.UseSqlite(@"Data Source=..\..\..\Data\Repositories\BirdNet.db"); }
                    );

                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();

                    services.AddSingleton<BirdSearchService>();
                }
            )
            .Build();

        await _host.StartAsync();

        MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    // ReSharper disable once AsyncVoidMethod
    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host is not null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }
}