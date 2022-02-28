using dotNetTodoReview.Data;
using dotNetTodoReview.Models;
using Npgsql;
using System.Collections.Generic;

namespace dotNetTodoReview.Services
{
    public class GetToDoService
    {
        private static NpgsqlConnection _npgsqlconnection;
        public List<ToDoModel> GetTodos()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var todos = new List<ToDoModel>();
                using NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM todo_text ORDER BY id", connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ToDoModel todo = new ToDoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                    todos.Add(todo);
                }

                return todos;
            };

        }
    }
}
