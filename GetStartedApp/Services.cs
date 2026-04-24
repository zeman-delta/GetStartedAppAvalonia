using DotNetEnv;
using GetStartedApp.Repositories;
using GetStartedApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace GetStartedApp;

public class Services
{
    
    public static ServiceProvider ServiceCollection()
    {
        Env.TraversePath().Load();
        var services = new ServiceCollection();

        // services
        services.AddTransient<MainWindowViewModel>();
        var connectionString =
            $"Host={Env.GetString("HOST")};Port={Env.GetString("PORT")};Database={Env.GetString("DATABASE")};Username={Env.GetString("USERNAME")};Password={Env.GetString("PASSWORD")}";
        services.AddSingleton<ITodoRepository>(new TodoRepository(connectionString));

        return services.BuildServiceProvider();
    }
    
}
