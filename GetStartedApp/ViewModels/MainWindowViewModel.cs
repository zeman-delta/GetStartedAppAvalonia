using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GetStartedApp.Models;

namespace GetStartedApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public TodoList TodoList { get; }

    [ObservableProperty]
    private string _newItemContent = string.Empty;

    public ObservableCollection<TodoItem> Items => TodoList.TodoItems;

    public MainWindowViewModel(TodoList todoList)
    {
        TodoList = todoList;
    }

    [RelayCommand]
    private void AddItem()
    {
        if (!string.IsNullOrWhiteSpace(NewItemContent))
        {
            TodoList.Add(new TodoItem(NewItemContent));
            NewItemContent = string.Empty;
        }
    }

    [RelayCommand]
    private void RemoveItem(TodoItem item) => TodoList.Remove(item);
}
