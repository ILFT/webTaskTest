namespace WebApplication2.Models
{
    public class TaskViewModel
    {
        private int _id;
        public string Name { get; }
        public DateTime DateCreate { get; }
        public DateTime? DateFinish { get; }
        public DateTime Deadline { get; }
        public string[] Tags { get; }
        public string Category { get; }
        public string Priority { get; }
        public string Comment { get; }


        public TaskViewModel()
        {
            Name = "сsharp";
            DateCreate = DateTime.Now;
            DateFinish = null;
            Deadline = DateTime.Now.AddDays(4);
            Tags = new string[] { "Аренды", "Лицензия" };
            Category = "Поручение";
            Priority = "высокий";
            Comment = "задача добавленгная из c#"
        }
    }
}
