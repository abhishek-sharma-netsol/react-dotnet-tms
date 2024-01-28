using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
