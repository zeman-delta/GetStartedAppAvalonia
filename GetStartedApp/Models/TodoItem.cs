using System;

namespace GetStartedApp.Models;

public class TodoItem
{
    
    private string _title;
    
    private string? _description;

    private bool _completed;


    public TodoItem(string title = null, string? description = null, bool completed = false)
    {
        _title = title ?? throw new ArgumentNullException(nameof(title));
        _description = description;
        _completed = completed;
    }
    
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool Completed { get; set; }

}