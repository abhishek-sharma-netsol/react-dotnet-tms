
using Domain.Entities;
using Domain.Utils;

namespace Domain.Response
{
    public class TaskResponse
    {

        public TaskResponse(TaskItem task) {
            Id= task.Id;
            Title= task.Title;
            Description= task.Description;
            DueDate= task.DueDate;
            Priority= (Enums.Priority)task.Priority;
            Status = (Enums.Status)task.Status;
            UserId= task.UserId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Enums.Priority Priority { get; set; }
        public Enums.Status Status { get; set; }
        public int? UserId { get; set; }

        public virtual UserResponse? User { get; set; }
    }
}
