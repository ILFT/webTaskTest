namespace WebApplication2.Models
{
    public class TaskViewModel
    {
        public int id { get; }
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
            id = 5;
            Name = "сsharp update";
            DateCreate = DateTime.Now;
            DateFinish = null;
            Deadline = DateTime.Now.AddDays(11);
            Tags = new string[] { "Проверка", "Подписание" };
            Category = "Проект";
            Priority = "низкий";
            Comment = "замена задачач добавленной из c#";
        }
    }
}
