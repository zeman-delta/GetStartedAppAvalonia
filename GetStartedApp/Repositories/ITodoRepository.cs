using System;
using System.Collections.Generic;
using GetStartedApp.Models;

namespace GetStartedApp.Repositories;

public interface ITodoRepository
{
    public List<TodoItem> GetAll();
    void Add(TodoItem item);
    void Delete(Guid id);
    void UpdateCompleted(Guid id, bool completed);
}