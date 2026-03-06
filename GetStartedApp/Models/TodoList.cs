using System.Collections.ObjectModel;

namespace GetStartedApp.Models;

public class TodoList
{
    private ObservableCollection<TodoItem> _todoItems = new();

    public ObservableCollection<TodoItem> TodoItems => _todoItems;

    public void Add(TodoItem item) => _todoItems.Add(item);

    public void Remove(TodoItem item) => _todoItems.Remove(item);

    public void Clear() => _todoItems.Clear();

    public int Count => _todoItems.Count;
}