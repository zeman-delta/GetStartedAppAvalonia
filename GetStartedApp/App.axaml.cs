using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using DotNetEnv;
using GetStartedApp.Repositories;
using GetStartedApp.ViewModels;
using GetStartedApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GetStartedApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit.
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            Env.Load();

            var connectionString =
                $"Host={Env.GetString("HOST")};Port={Env.GetString("PORT")};Database={Env.GetString("DATABASE")};Username={Env.GetString("USERNAME")};Password={Env.GetString("PASSWORD")}";

            var services = new ServiceCollection();
            services.AddSingleton<ITodoRepository>(new TodoRepository(connectionString));
            services.AddTransient<MainWindowViewModel>();

            var provider = services.BuildServiceProvider();

            desktop.MainWindow = new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}