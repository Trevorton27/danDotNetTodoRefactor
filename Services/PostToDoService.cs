using dotNetTodoReview.Data;
using dotNetTodoReview.Models;
using Npgsql;

namespace dotNetTodoReview.Services
{
    public class PostToDoService
    {
        public ToDoModel PostToDo(string text)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var newTodo = new ToDoModel();
                using var command = new NpgsqlCommand("INSERT INTO todos_info (todo_text) VALUES (@p1) RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", text)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newTodo = new ToDoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = text,
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return newTodo;
            };

        }
    }
}
