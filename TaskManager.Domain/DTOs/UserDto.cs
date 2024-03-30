using System;
 

namespace TaskManager.Domain.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public required string Nick { get; set; }
        public required string Email { get; set; }
    }
}
