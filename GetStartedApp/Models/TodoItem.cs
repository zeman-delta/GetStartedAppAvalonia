using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GetStartedApp.Models;

public class TodoItem : INotifyPropertyChanged
{
    private string _title;
    private string? _description;
    private bool _completed;

    public TodoItem(string title, string? description = null, bool completed = false)
    {
        _title = title ?? throw new ArgumentNullException(nameof(title));
        _description = description;
        _completed = completed;
    }

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }

    public bool Completed
    {
        get => _completed;
        set
        {
            if (_completed != value)
            {
                _completed = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}