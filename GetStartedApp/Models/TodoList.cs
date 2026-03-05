using System.Collections;
using System.Collections.Generic;

namespace GetStartedApp.Models;

public class TodoList
{
    
    private List<TodoItem> _todoItems = new List<TodoItem>();
    
    public  List<TodoItem> TodoItems
    {
        get => _todoItems;
    }
    
    public void Add(TodoItem item)
    {
        _todoItems.Add(item);
    }
    
    public void Remove(TodoItem item)
    {
        _todoItems.Remove(item);
    }
    
    public void Clear()
    {
        _todoItems.Clear();
    }
    
    public int Count
    {
        get => _todoItems.Count;
    }
    
}