using Npgsql;

namespace WebApplication2.Models.Db
{
    public class DbTags
    {

        public DbTags() { }

        public string[] AllTags()
        {
            var connection = (new DbContext()).connection;
            string commandText = $"select name from tags";
            List<string> resultList = new List<string>();

            NpgsqlDataReader reader = (new NpgsqlCommand(commandText, connection)).ExecuteReader();
            while (reader.Read())
            {
                resultList.Add(reader[0].ToString());
            }

            return resultList.ToArray();

        }


    }
}
