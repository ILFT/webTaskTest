using Npgsql;
using System.Collections.Generic;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication2.Models.Db
{
    public class DbTasks
    {

        async public Task AddTask(TaskViewModel task) {
            var connection = (new DbContext()).connection;
            string commandText = $"WITH NEW_TASK AS (\r\nINSERT INTO TASKS (name, dataCreate, dataFinish, deadline, category, priority, comment) \r\nvalues\r\n(@nameTask, current_date, NULL, current_date + @duration, (SELECT id FROM CATEGORY WHERE name = @nameCategories), (SELECT id FROM PRIORITY WHERE name = @namePriority), @commentTask )\r\nreturning id\r\n)\r\nINSERT INTO task_tag\r\nSELECT (SELECT id FROM NEW_TASK), tag.id\r\nFROM  tag \r\nWHERE tag.name in (@tagArray)";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("nameTask", task.Name);
                cmd.Parameters.AddWithValue("duration", task.Deadline - task.DateCreate);
                cmd.Parameters.AddWithValue("nameCategories", task.Category);
                cmd.Parameters.AddWithValue("namePriority", task.Priority);
                cmd.Parameters.AddWithValue("commentTask", task.Comment);
                cmd.Parameters.AddWithValue("tagArray", task.Tags);

                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
