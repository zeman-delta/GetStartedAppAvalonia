using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GetStartedApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    [ObservableProperty]
    private string _celsius = "0";

    [ObservableProperty]
    private string _fahrenheit = "0";

    [RelayCommand]
    private void Convert()
    {
        if (double.TryParse(Celsius, out double c))
        {
            var f = c * (9d / 5d) + 32;
            Fahrenheit = f.ToString("0.0");
        }
        else
        {
            Celsius = "0";
            Fahrenheit = "0";
        }
    }
}
