# Dynamic Todo List UI - Plan

## Current State

- `TodoItem`: model with `Title`, `Description?`, `Completed` — plain class, no change notifications
- `TodoList`: wrapper around `List<TodoItem>` — not observable
- `MainWindowViewModel`: has `TodoList` and `[ObservableProperty] NewItemContent` — no commands yet
- `MainWindow.axaml`: empty `StackPanel`, no UI built

---

## Required Changes

### Step 1 — Make `TodoItem` reactive

`TodoItem` must notify the UI when `Completed` changes (for checkbox binding to work).

**Option A** — Use CommunityToolkit `[ObservableProperty]` (consistent with rest of project):

```csharp
public partial class TodoItem : ObservableObject
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private string? _description;
    [ObservableProperty] private bool _completed;
}
```

**Option B** — Implement `INotifyPropertyChanged` manually (more educational/explicit).

> **Question Q1 below** — which option do you prefer?

---

### Step 2 — Make `TodoList` use `ObservableCollection`

`List<TodoItem>` does not notify the UI when items are added/removed.
`TodoList.TodoItems` must be changed to `ObservableCollection<TodoItem>`.

```csharp
private ObservableCollection<TodoItem> _todoItems = new();
public ObservableCollection<TodoItem> TodoItems => _todoItems;
```

---

### Step 3 — Add Commands to `MainWindowViewModel`

Add `AddItemCommand` and `RemoveItemCommand` using CommunityToolkit `[RelayCommand]`:

```csharp
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
```

The ViewModel also needs to expose the items collection directly for binding:

```csharp
public ObservableCollection<TodoItem> Items => TodoList.TodoItems;
```

---

### Step 4 — Build the UI in `MainWindow.axaml`

Layout:

```
+------------------------------------------+
|  [ TextBox: new item title     ] [Add]   |
+------------------------------------------+
|  [ ] Buy groceries                 [X]   |
|  [x] Read book                     [X]   |
|  [ ] Call dentist                  [X]   |
+------------------------------------------+
```

Controls:

- **Input row**: `TextBox` bound to `NewItemContent` + `Button` bound to `AddItemCommand`
- **List**: `ItemsControl` bound to `Items` with a `DataTemplate`
- **Each item**: `CheckBox` (IsChecked -> Completed) + `TextBlock` (Title) + delete `Button` (RemoveItemCommand with item as parameter)

> **Questions Q2, Q3, Q4 below** — about Description, completed styling, and filtering.

---

## Open Questions — Please Answer

**Q1: TodoItem reactivity approach**
Should `TodoItem` use CommunityToolkit `[ObservableProperty]` (cleaner, less code)
or implement `INotifyPropertyChanged` manually (more explicit/educational)?

Do it manually.


**Q2: Description field**
The `TodoItem` has an optional `Description`. Should it be:

- A) Not shown in the list at all (Title only)
- B) Shown as a second line below the title
- **C) Shown on hover (tooltip)**
- D) Only visible when adding a new item (second input field)

use **C) Shown on hover (tooltip)**

**Q3: Completed item styling**
When an item is checked as completed, should it:

- A) Stay the same visually
- B) Get a strikethrough on the title
- **C) Get a strikethrough AND gray out**

use C) Get a strikethrough AND gray out

**Q4: Filtering**
Should there be filter buttons (All / Active / Completed) to show a subset of items?

- **A) No filtering needed**
- B) Yes, add filter buttons at the top or bottom

A) No filtering needed
