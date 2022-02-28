using dotNetTodoReview.Data;
using dotNetTodoReview.Models;
using Npgsql;

namespace dotNetTodoReview.Services
{
    public class UpdateToDoService
    {
        public ToDoModel UpdateToDo(int id, bool isComplete)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var updatedTodo = new ToDoModel();
                using var command = new NpgsqlCommand("UPDATE todos_info SET is_complete = @p1 WHERE id = @p2 RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", isComplete),
                    new NpgsqlParameter("p2", id)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    updatedTodo = new ToDoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = isComplete,
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return updatedTodo;
            };

        }
    }
}
