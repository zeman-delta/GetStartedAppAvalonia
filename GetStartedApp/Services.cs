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
        
        string host = Env.GetString("HOST");
        string port = Env.GetString("PORT");
        string database = Env.GetString("DATABASE");
        string user = Env.GetString("USERNAME");
        string pass = Env.GetString("PASSWORD");
        var connectionString =
            $"Host={host};Port={port};Database={database};Username={user};Password={pass}";
        services.AddSingleton<ITodoRepository>(new TodoRepository(connectionString));

        return services.BuildServiceProvider();
    }
    
}
