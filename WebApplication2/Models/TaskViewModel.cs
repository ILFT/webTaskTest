namespace WebApplication2.Models
{
    public class TaskViewModel
    {
        public int Id { get; }
        public string Name { get; }
        public DateOnly DateCreate { get; }
        public DateOnly? DateFinish { get; }
        public DateOnly Deadline { get; }
        public string[] Tags { get; }
        public string Category { get; }
        public string Priority { get; }
        public string Comment { get; }


        public TaskViewModel(int id, string name, DateOnly dateCreate, DateOnly? dateFinish, DateOnly deadline, string category, string priority, string comment, string[] tags )
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
