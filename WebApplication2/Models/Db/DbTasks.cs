using Npgsql;
using NpgsqlTypes;
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
            string commandText = $"WITH NEW_TASK AS (INSERT INTO TASKS (name, dataCreate, dataFinish, deadline, category, priority, comment) values (@nameTask, current_date, NULL, current_date + @duration, (SELECT id FROM CATEGORY WHERE name = @nameCategories), (SELECT id FROM PRIORITY WHERE name = @namePriority), @commentTask ) returning id) INSERT INTO task_tag SELECT (SELECT id FROM NEW_TASK), tag.id FROM  tag  WHERE tag.name = ANY(tagArray)";
            
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("nameTask", task.Name);
                cmd.Parameters.AddWithValue("duration", (task.Deadline - task.DateCreate).Days);
                cmd.Parameters.AddWithValue("nameCategories", task.Category);
                cmd.Parameters.AddWithValue("namePriority", task.Priority);
                cmd.Parameters.AddWithValue("commentTask", task.Comment);
                cmd.Parameters.AddWithValue("tagArray", task.Tags);

                await cmd.ExecuteNonQueryAsync();

            }

        }

        public async Task FinishTask(TaskViewModel task)
        {
            var connection = (new DbContext()).connection;
            string commandText = $"UPDATE TASKS SET dataFinish = current_date WHERE dataFinish IS NULL and id = @id";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", task.id);

                await cmd.ExecuteNonQueryAsync();

            }

        }

        public async Task DeleteTask(TaskViewModel task)
        {
            var connection = (new DbContext()).connection;
            string commandText = $"DELETE FROM TASKS  WHERE id = @id";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", task.id);

                await cmd.ExecuteNonQueryAsync();

            }

        }

        public async Task UpdateTask(TaskViewModel task)
        {
            var connection = (new DbContext()).connection;
            string commandText = $"WITH UPDATE_TASK AS (UPDATE TASKS SET (name, dataCreate, dataFinish, deadline, category, priority, comment) = (@nameTask, @dateCreateTask, @dateFinishTask, @deadlineTask, (SELECT id FROM CATEGORY WHERE name = @nameCategories), (SELECT id FROM PRIORITY WHERE name = @namePriority), @commentTask ) WHERE id = @idTask  returning id), DELETE_OLD as ( DELETE FROM TASK_TAG WHERE idTask = @idTask ) INSERT INTO task_tag SELECT (SELECT id FROM UPDATE_TASK), tag.id FROM  tag WHERE tag.name = ANY(@tagArray)";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
            
                cmd.Parameters.AddWithValue("idTask", task.id);
                cmd.Parameters.AddWithValue("nameTask", task.Name);

                cmd.Parameters.AddWithValue("dateCreateTask", task.DateCreate);
                cmd.Parameters.AddWithValue("dateFinishTask", (task.DateFinish is null) ? DBNull.Value : task.DateFinish) ;
                cmd.Parameters.AddWithValue("deadlineTask", task.Deadline);

                cmd.Parameters.AddWithValue("nameCategories", task.Category);
                cmd.Parameters.AddWithValue("namePriority", task.Priority);
                cmd.Parameters.AddWithValue("commentTask", task.Comment);
                cmd.Parameters.AddWithValue("tagArray", task.Tags);

                await cmd.ExecuteNonQueryAsync();

            }

        }
    }
}
