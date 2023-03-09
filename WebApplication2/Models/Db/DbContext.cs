using Npgsql;

namespace WebApplication2.Models.Db
{
    public class DbContext
    {

        private NpgsqlConnection connection;
        string connString = "Host=localhost;Username=postgres;Password=123;Database=test";
        public void NpgsqlBoardGameRepository()
        {
            connection = new NpgsqlConnection(connString);
            connection.Open();
        }

    }
}
