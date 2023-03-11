using Npgsql;

namespace WebApplication2.Models.Db
{
    public class DbTags
    {

        public DbTags() { }

        public List<string> AllTags()
        {
            var connection = (new DbContext()).connection;
            string commandText = $"select name from tag";
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
