﻿using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities
{
    public class Meet : BaseEntity
    {
        public int MeetId { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public ItemStatus ItemStatus { get; set; }
        public ItemPriority ItemPriority { get; set; }
        public string? Detail { get; set; }
        public string? Description { get; set; }
        public required DateTime MeetDate { get; set; } 
        public User User { get; set; }
         
    }
}
