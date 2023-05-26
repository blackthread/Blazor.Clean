using Blazor.Clean.Domain.Common;

namespace Blazor.Clean.Domain
{
    public class ToDoItem : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
