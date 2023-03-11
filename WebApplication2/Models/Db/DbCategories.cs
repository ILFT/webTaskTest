using Npgsql;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApplication2.Models.Db
{
    public class DbCategories
    {

        public DbCategories() { }

        public List<string> AllCategories()
        {
            var connection = (new DbContext()).connection;
            string commandText = $"select name from category";
            List<string> resultList  = new List<string>();

            NpgsqlDataReader reader = (new NpgsqlCommand(commandText, connection)).ExecuteReader();
            while (reader.Read())
            {
                resultList.Add(reader[0].ToString());
            }
                
            return resultList;

        }
    }
}
