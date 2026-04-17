using System;
using System.Collections.Generic;
using GetStartedApp.Models;
using Npgsql;

namespace GetStartedApp.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly NpgsqlConnection _connection;

    public TodoRepository(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
    }


    public List<TodoItem> GetAll()
    {
        var items = new List<TodoItem>();

        _connection.Open();

        using var command = new NpgsqlCommand(
            "SELECT id, title, description, completed FROM todo_item WHERE deleted_at IS NULL",
            _connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var item = new TodoItem(
                reader.GetString(1),
                reader.IsDBNull(2) ? null : reader.GetString(2),
                reader.GetBoolean(3))
            {
                Id = reader.GetGuid(0)
            };
            items.Add(item);
        }

        return items;
    }

    public void Add(TodoItem item)
    {
        _connection.Open();

        using var command = new NpgsqlCommand(
            "INSERT INTO todo_item (id, title, description, completed) VALUES (@id, @title, @description, @completed)",
            _connection);

        command.Parameters.AddWithValue("id", item.Id);
        command.Parameters.AddWithValue("title", item.Title);
        command.Parameters.AddWithValue("description", (object?)item.Description ?? DBNull.Value);
        command.Parameters.AddWithValue("completed", item.Completed);
        
        command.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        _connection.Open();

        using var command = new NpgsqlCommand(
            "UPDATE todo_item SET deleted_at = @deletedAt WHERE id = @id",
            _connection);

        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("deletedAt", DateTime.Today);

        command.ExecuteNonQuery();
    }

    public void UpdateCompleted(Guid id, bool completed)
    {
        _connection.Open();

        using var command = new NpgsqlCommand(
            "UPDATE todo_item SET completed = @completed WHERE id = @id",
            _connection);

        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("completed", completed);

        command.ExecuteNonQuery();
    }
}