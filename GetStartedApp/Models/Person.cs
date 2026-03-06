using CommunityToolkit.Mvvm.ComponentModel;

namespace GetStartedApp.Models;

public class Person: ObservableObject
{
    
    private string _name;
    
    private int _age;

    public string Name
    {
        get { return _name; }
        set { SetProperty(ref _name, value); }
    }

    public int Age
    {
        get { return _age; }
        set { SetProperty(ref _age, value); }
    }
    
}