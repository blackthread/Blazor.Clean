namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
