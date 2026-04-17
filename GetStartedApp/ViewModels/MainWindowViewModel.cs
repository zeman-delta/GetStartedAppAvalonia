using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GetStartedApp.Models;
using GetStartedApp.Repositories;

namespace GetStartedApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ITodoRepository _repository;

    [ObservableProperty]
    private string _newItemContent = string.Empty;

    public ObservableCollection<TodoItem> Items { get; } = new();

    public MainWindowViewModel(ITodoRepository repository)
    {
        _repository = repository;
        LoadItems();
    }

    private void LoadItems()
    {
        Items.Clear();
        foreach (var item in _repository.GetAll())
        {
            item.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(TodoItem.Completed) && sender is TodoItem changed)
                {
                    _repository.UpdateCompleted(changed.Id, changed.Completed);
                }
            };
            Items.Add(item);
        }
    }

    [RelayCommand]
    private void AddItem()
    {
        if (!string.IsNullOrWhiteSpace(NewItemContent))
        {
            var item = new TodoItem(NewItemContent);
            _repository.Add(item);
            item.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(TodoItem.Completed) && sender is TodoItem changed)
                {
                    _repository.UpdateCompleted(changed.Id, changed.Completed);
                }
            };
            Items.Add(item);
            NewItemContent = string.Empty;
        }
    }

    [RelayCommand]
    private void RemoveItem(TodoItem item)
    {
        _repository.Delete(item.Id);
        Items.Remove(item);
    }
}