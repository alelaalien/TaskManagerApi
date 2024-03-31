using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities
{
    public class Activity : BaseEntity
    {
        //public int ActivityId { get; set; }
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string?  Detail { get; set; }
        public DateTime?  Date { get; set; } 
        public User User { get; set; }
        public List<SubTask> SubTasks { get; set; } = new(); 

    }
}
