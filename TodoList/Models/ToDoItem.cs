namespace TodoList.Models
{
    public class ToDoItem (string name, bool isCompleted)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public bool IsCompleted { get; set; } = isCompleted;

    }
}