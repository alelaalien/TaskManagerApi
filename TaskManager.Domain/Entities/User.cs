using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string Nick { get; set; }
        public required string Email { get; set; }
        public required string Pass { get; set; }
        public List<Activity> Tasks { get; set; } = new();
        public List<Meet> Meets { get; set; } = new();

    }
}
