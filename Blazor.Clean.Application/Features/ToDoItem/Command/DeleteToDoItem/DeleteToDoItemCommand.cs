using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Command.DeleteToDoItem
{
    public class DeleteToDoItemCommand : IRequest<Unit>
    {
       public int Id { get; set; }
    }
}
