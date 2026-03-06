using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GetStartedApp.Models;

public class Person : INotifyPropertyChanged
{

    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            _age = value;
            OnPropertyChanged(nameof(Age));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}