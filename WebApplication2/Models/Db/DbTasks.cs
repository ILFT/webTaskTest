using Npgsql;
using System.Collections.Generic;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication2.Models.Db
{
    public class DbTasks
    {
        public DbTasks() 
        { 
        
        }
        public async Task AddTask(TaskViewModel task) {
            var connection = (new DbContext()).connection;
            //string commandText = $"WITH NEW_TASK AS (INSERT INTO TASKS (name, dataCreate, dataFinish, deadline, category, priority, comment) values (@nameTask, current_date, NULL, current_date + @duration, (SELECT id FROM CATEGORY WHERE name = @nameCategories), (SELECT id FROM PRIORITY WHERE name = @namePriority), @commentTask ) returning id) INSERT INTO task_tag SELECT (SELECT id FROM NEW_TASK), tag.id FROM  tag  WHERE tag.name in (@tagArray)";
            string commandText = $"WITH NEW_TASK AS (\r\nINSERT INTO TASKS (name, dataCreate, dataFinish, deadline, category, priority, comment) \r\nvalues \r\n('Тестовый проект csharp', current_date, NULL, current_date + 7, (SELECT id FROM CATEGORY WHERE name = 'Поручение'), (SELECT id FROM PRIORITY WHERE name = 'высокий'), 'проект для проверки работоспособности' )\r\nreturning id\r\n)\r\nINSERT INTO task_tag\r\nSELECT (SELECT id FROM NEW_TASK), tag.id\r\nFROM  tag \r\nWHERE tag.name in ('Аренды','Лицензия')\r\n";


            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                //cmd.Parameters.AddWithValue("nameTask", task.Name);
                //cmd.Parameters.AddWithValue("duration", (task.Deadline - task.DateCreate).Days);
                //cmd.Parameters.AddWithValue("nameCategories", task.Category);
                //cmd.Parameters.AddWithValue("namePriority", task.Priority);
                //cmd.Parameters.AddWithValue("commentTask", task.Comment);
                //cmd.Parameters.AddWithValue("tagArray", task.Tags);

                Console.WriteLine(cmd.CommandText);
                int rows = await cmd.ExecuteNonQueryAsync();
                
            }
        }
    }
}
