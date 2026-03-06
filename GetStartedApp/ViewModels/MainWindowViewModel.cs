using System.Collections.ObjectModel;
using GetStartedApp.Models;

namespace GetStartedApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    private ObservableCollection<Person> _people;
    public ObservableCollection<Person> People
    {
        get => _people;
    }

    public MainWindowViewModel()
    {
        _people = new ObservableCollection<Person>()
        {
            new Person { Name = "Jan", Age = 30 },
            new Person { Name = "Honza", Age = 28 },
            new Person { Name = "Michal", Age = 45 }
        };
    }

}
