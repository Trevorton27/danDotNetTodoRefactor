using Npgsql;

namespace dotNetTodoReview.Data
{
    public class DatabaseConnection
    {

        public NpgsqlConnection GetConnection()
        {
            // Env.TraversePath().Load();
            string connString = " Host=localhost;Port=5432;Database=test_todos;Username=postgres;Password=pitdline";
            //string connString = Environment.GetEnvironmentVariable("PRODUCTION_CONNECTION_STRING");

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
