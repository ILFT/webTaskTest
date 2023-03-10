namespace WebApplication2.Models
{
    public class TaskViewModel
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime DateCreate { get; }
        public DateTime? DateFinish { get; }
        public DateTime Deadline { get; }
        public string[] Tags { get; }
        public string Category { get; }
        public string Priority { get; }
        public string Comment { get; }


      /*  public TaskViewModel(TaskViewModel task)
        {
            Id = task.Id;
            Name = task.Name;
            DateCreate = task.DateCreate;
            DateFinish = task.DateFinish;
            Deadline = task.Deadline;
            Tags = task.Tags;
            Category = task.Category;
            Priority = task.Priority;
            Comment = task.Comment;
        }*/
        public TaskViewModel(int id, string name, DateTime dateCreate, DateTime? dateFinish, DateTime deadline, string category, string priority, string comment, string[] tags )
        {
            Id = id;
            Name = name;
            DateCreate = dateCreate;
            DateFinish = dateFinish;
            Deadline = deadline;
            Tags = tags;
            Category = category;
            Priority = priority;
            Comment = comment;
        }

        public string ToString()
        { 
            return Id + (" ")+ Name + (" ") + DateCreate + (" ") + DateFinish + (" ") + Deadline + (" ") + Category + (" ") + Priority + (" ") + Comment + (" ") + Tags;
        }
     
    }
}
