using CommunityToolkit.Mvvm.ComponentModel;
using GetStartedApp.Models;

namespace GetStartedApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public TodoList TodoList { get; }

    [ObservableProperty]
    private string _newItemContent;

    public MainWindowViewModel(TodoList todoList)
    {
        TodoList = todoList;
    }
    
}
