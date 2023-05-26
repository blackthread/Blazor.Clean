using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Commands.UpdateToDoItem
{
    public class UpdateToDoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}