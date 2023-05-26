using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Command.CreateToDoItem
{
    public class CreateToDoItemCommand : IRequest<int>
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
