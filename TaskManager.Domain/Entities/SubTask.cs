namespace TaskManager.Domain.Entities
{
    public class SubTask
    {
        public int SubTaskId { get; set; }
        public int ActivityId { get; set; }
        public required string Name { get; set;}
        public string? Detail { get; set;}
        public Activity Activity { get; set; }
    }
}