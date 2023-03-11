using Npgsql;

namespace WebApplication2.Models.Db
{
    public class DbPriorites
    {
        public DbPriorites() { }

        public List<string> AllPriorites()
        {
            var connection = (new DbContext()).connection;
            string commandText = $"select name from priority";
            List<string> resultList = new List<string>();

            NpgsqlDataReader reader = (new NpgsqlCommand(commandText, connection)).ExecuteReader();
            while (reader.Read())
            {
                resultList.Add(reader[0].ToString());
            }

            return resultList;

        }



    }
}
