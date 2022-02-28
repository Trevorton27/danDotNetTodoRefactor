using dotNetTodoReview.Data;
using dotNetTodoReview.Models;
using Npgsql;

namespace dotNetTodoReview.Services
{
    public class DeleteToDoService 

    {
        public ToDoModel DeleteToDo(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var deletedToDo = new ToDoModel();
                using var command = new NpgsqlCommand("DELETE FROM todos_info  WHERE id = @p1 RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", id)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    deletedToDo = new ToDoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return deletedToDo;
            };

        }
    }
}
