 
using TaskManager.Domain.Enum;

namespace TaskManager.Domain.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
     
        public string Name { get; set; }
        public string?  Detail { get; set; }
        public DateTime?  Date { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;  }
    }
}
