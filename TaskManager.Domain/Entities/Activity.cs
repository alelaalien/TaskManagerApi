using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string?  Detail { get; set; }
        public DateTime?  Date { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public User User { get; set; }
        public List<SubTask> SubTasks { get; set; } = new(); 

    }
}
