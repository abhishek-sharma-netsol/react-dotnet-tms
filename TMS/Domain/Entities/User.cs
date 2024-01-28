using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User
    {
        public User()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
